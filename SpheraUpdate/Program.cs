using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using Newtonsoft.Json;
using System.Text.Json;
using System.Threading.Tasks;
using MIDAS.Entities;
using MIDAS.Proxies;
using MIDAS.Services;
using MIDAS.Utilities;
using System.ServiceModel;
using System.Linq;
using System.Text;
using System.IO;



namespace SpheraUpdate
{
    internal class AuthBody
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int CorporationId { get; set; }
    }

    internal class AuthorizeResponse
    {
        public string AccessToken { get; set; }
    }

    internal class Program
    {
        static async Task<string> GetAccessToken()
        {
            using var client = new HttpClient();
            var authBody = new AuthBody()
            {
                //UserName = "xompublish",
                //Password = "xompublish#01",
                //CorporationId = 2371

                UserName = "Xomapi",
                Password = "4#S?h6Yw",
                CorporationId = 2371
            };
            var response = await client.PostAsJsonAsync("https://api.spheracloud.net/api/v1/Authorize", authBody);
            var result = await response.Content.ReadFromJsonAsync<AuthorizeResponse>();
            return result.AccessToken;
        }
        static async Task<dynamic> GetAllFacilities(string accessToken)
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");
            string result = await client.GetStringAsync("https://api.spheracloud.net/api/v1/Facility");
            return result;
        }
        static async Task<dynamic> MaterialDelta(string accessToken, int facility_id)
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");
            //string api_call = "https://api.spheracloud.net/api/v1/MaterialDelta/FacilityId/" + facility_id.ToString() + "?startDate=2023-04-28&pageIndex=1&pageSize=10000";
            string api_call = "https://api.spheracloud.net/api/v1/MaterialDelta/FacilityId/7737?startDate=2023-03-08&endDate=2023-04-01&pageIndex=1&pageSize=10000";

            string result = await client.GetStringAsync(api_call);
            return result;
        }
        static async Task<dynamic> MaterialDetails(string accessToken, int id, int facility_id)
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");
            string api_call = "https://api.spheracloud.net/api/v1/Material/" + id.ToString() + "/Facility/" + facility_id.ToString() + "/Details";
            string result = await client.GetStringAsync(api_call);
            return result;
        }

        static async Task<dynamic> AllMaterialsCall(string accessToken, int facility_id, int page_index)
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");
            string api_call = "https://api.spheracloud.net/api/v1/Facility/" + facility_id.ToString() + "/Materials?pageIndex="+page_index.ToString()+"&pageSize=2";
            string result = await client.GetStringAsync(api_call);
            return result;
        }


        static async Task Main(string[] args)
        {     
            EnterpriseServiceClient wcfEnterpriseClient = new EnterpriseServiceClient("NetTcpBinding_IEnterpriseService", "net.tcp://10.128.195.214:9201/Enterprise");
            try
            {
                bool status = wcfEnterpriseClient.Initiate();
                Console.WriteLine(wcfEnterpriseClient.State);
            }
            catch (Exception e) { Console.WriteLine(e); }
            var accessToken = await GetAccessToken();
            string facilities = await GetAllFacilities(accessToken);
            var oResponse_facilities = JsonConvert.DeserializeObject<List<Facility>>(facilities);

            //string all_material_ids = await AllMaterialsCall(accessToken, oResponse_facilities[0].id, 1);
            //var oResponse_all_mats = JsonConvert.DeserializeObject<List<AllMaterials>>(all_material_ids);
            string delta = await MaterialDelta(accessToken, oResponse_facilities[0].id);
            var oResponse_deltas = JsonConvert.DeserializeObject<List<MaterialDelta>>(delta);
            //HttpClient client = new HttpClient();
            List<string> countries = new List<string>();
            List<string> languages = new List<string>();
            List<int> noGHS = new List<int>();
            List<int> noDGN = new List<int>();
            List<int> noNFPA = new List<int>();


            int cnt = 0;
            foreach (MaterialDelta delta_temp in oResponse_deltas)
            {
                //string material_detail = await MaterialDetails(accessToken, 1791088, oResponse_facilities[0].id);
                string material_detail = await MaterialDetails(accessToken, delta_temp.materialId, oResponse_facilities[0].id);
               
                MaterialDetails oResponse_details = JsonConvert.DeserializeObject<MaterialDetails>(material_detail);
                if (oResponse_details.sensitivity == null)
                {
                    Console.WriteLine("WTF");

                    continue;
                }
                try
                {
                    if (cnt % 1000 == 0)
                    {
                        Console.WriteLine(cnt);
                    }
                    if (oResponse_details.ghsHazardClassifications.Length < 1)
                    {
                        cnt++;
                        Console.WriteLine("no data");
                        Console.WriteLine(delta_temp.materialId);
                        noGHS.Add(delta_temp.materialId);
                        continue;
                    }
                    if (oResponse_details.nfpaHmisRatings.Length < 1)
                    {
                        cnt++;
                        Console.WriteLine("no data");

                        //Console.WriteLine(delta_temp.materialId);
                        noNFPA.Add(delta_temp.materialId);
                        continue;
                    }
                    Console.WriteLine("we have data!!!");
                    Console.WriteLine(delta_temp.materialId);


                }

                catch (Exception e) { 
                    Console.WriteLine(e);
                    Console.WriteLine(delta_temp.materialId);
                    continue;
                }

                string DGN_String = "";
                //var response = await client.GetAsync(oResponse_details.documentHistory[0].documentUrl);
                //using (var file = System.IO.File.Create("C:\\ProgramData\\midasii\\test.pdf"))
                //{ 
                //    var contentStream = await response.Content.ReadAsStreamAsync(); 
                //    await contentStream.CopyToAsync(file); 
                //}

                foreach (AdditionalProperty temp_addprop in oResponse_details.additionalProperties)
                {
                    if (temp_addprop.localizations[0].name == "DGN Number")
                    {
                        DGN_String = temp_addprop.values[0].value;
                        Console.WriteLine("DGN BABBBYYYYY");

                    }
                }
                if (DGN_String == "")
                {
                    Console.WriteLine(delta_temp.materialId);
                    DGN_String = oResponse_details.productCodes[0].code.ToString();
                    noDGN.Add(delta_temp.materialId);
                    Console.WriteLine(DGN_String);
                }
                PSIMsSubstance temp_psims_substance = new PSIMsSubstance();
                temp_psims_substance.Country = oResponse_details.sds.sdsManufacturer.country.ToString();
                if (oResponse_details.ghsHazardClassifications[0].hazardStatements.Length > 0)
                {
                    string temp_str = "";
                    foreach (Hazardstatement temp_hzrd_stmt in oResponse_details.ghsHazardClassifications[0].hazardStatements)
                    {
                        temp_str += temp_hzrd_stmt.code.ToString();
                        temp_str += ": ";
                        temp_str += temp_hzrd_stmt.statement;
                        temp_str += " ";
                    }
                    temp_psims_substance.HazardStatement = temp_str;
                    temp_psims_substance.IsHazardous = true;
                }
                else
                {
                    temp_psims_substance.HazardStatement = "NO HAZARD CLASSIFICATION";
                    temp_psims_substance.IsHazardous = false;

                }
                if (oResponse_details.ghsHazardClassifications[0].precautionaryStatements.Length > 0)
                {
                    string temp_str = "";
                    foreach (Precautionarystatement temp_pct_stmt in oResponse_details.ghsHazardClassifications[0].precautionaryStatements)
                    {
                        temp_str += temp_pct_stmt.code.ToString();
                        temp_str += ": ";
                        temp_str += temp_pct_stmt.statement;
                        temp_str += " ";
                    }
                    temp_psims_substance.PrecautionaryText = temp_str;
                }
                else
                {
                    temp_psims_substance.PrecautionaryText = "NO PRECAUTIONARY PHRASE";
                }
                temp_psims_substance.Language = oResponse_details.sds.language.ToString();
                temp_psims_substance.Company = oResponse_details.sds.sdsManufacturer.name.ToString();
                temp_psims_substance.MaterialName = oResponse_details.sds.materialName.ToString();
                temp_psims_substance.TradeName = oResponse_details.sds.materialName.ToString();

                temp_psims_substance.NFPAChronic = oResponse_details.nfpaHmisRatings[0].hmisChronic.ToString();
                if (oResponse_details.nfpaHmisRatings[0].nfpaFire == null)
                {
                    temp_psims_substance.NFPAFlame = "-";
                } else
                {
                    temp_psims_substance.NFPAFlame = oResponse_details.nfpaHmisRatings[0].nfpaFire.ToString();
                }
                if (oResponse_details.nfpaHmisRatings[0].nfpaHealth == null)
                {
                    temp_psims_substance.NFPAHealth = "-";
                }
                else
                {
                    temp_psims_substance.NFPAHealth = oResponse_details.nfpaHmisRatings[0].nfpaHealth.ToString();
                }
                if (oResponse_details.nfpaHmisRatings[0].nfpaInstability == null)
                {
                    temp_psims_substance.NFPAReact = "-";
                }
                else
                {
                    temp_psims_substance.NFPAReact = oResponse_details.nfpaHmisRatings[0].nfpaInstability.ToString();
                }


                temp_psims_substance.DateUpdated = oResponse_details.sds.revisionDate;
                if (oResponse_details.ghsHazardClassifications[0].signalWordDanger == "true")
                {
                    temp_psims_substance.SignalWord = "Danger";
                }
                else if (oResponse_details.ghsHazardClassifications[0].signalWordWarning == "true")
                {
                    temp_psims_substance.SignalWord = "Warning";
                }
                else if (oResponse_details.ghsHazardClassifications[0].signalWordNotHazardous == "true")
                {
                    temp_psims_substance.SignalWord = "";
                }
                temp_psims_substance.ValidFlag = true.ToString();
                temp_psims_substance.DocStatusCode = null;
                temp_psims_substance.ProductGroup = null;
                temp_psims_substance.FlashPointF = oResponse_details.physicalProperties[0].flashPointF1;
                if (oResponse_details.physicalProperties[0].fpTestType == null)
                {
                    temp_psims_substance.FlashPointMethod = "";
                }
                else
                {
                    temp_psims_substance.FlashPointMethod = oResponse_details.physicalProperties[0].fpTestType.ToString();
                }
                temp_psims_substance.Source = "CHEMICAL MGMT";
                string pict_string = "";
                if (oResponse_details.ghsHazardClassifications[0].environment == "true")
                {
                    pict_string += "AQUA|";
                }
                if (oResponse_details.ghsHazardClassifications[0].biohazardousInfectious == "true")
                {
                    pict_string += "BIO|";
                }
                if (oResponse_details.ghsHazardClassifications[0].corrosion == "true")
                {
                    pict_string += "ACID|";
                }
                if (oResponse_details.ghsHazardClassifications[0].exclamationMark == "true")
                {
                    pict_string += "EXCL|";
                }
                if (oResponse_details.ghsHazardClassifications[0].explodingBomb == "true")
                {
                    pict_string += "EXPL|";
                }
                if (oResponse_details.ghsHazardClassifications[0].skullAndCrossbones == "true")
                {
                    pict_string += "SKUL|";
                }
                if (oResponse_details.ghsHazardClassifications[0].flame == "true")
                {
                    pict_string += "FLAM|";
                }
                if (oResponse_details.ghsHazardClassifications[0].gasCylinder == "true")
                {
                    pict_string += "BOTT|";
                }
                if (oResponse_details.ghsHazardClassifications[0].healthHazard == "true")
                {
                    pict_string += "SILH|";
                }
                if (oResponse_details.ghsHazardClassifications[0].flameOverCircle == "true")
                {
                    pict_string += "RFLM|";
                }
                temp_psims_substance.Pictograms = pict_string;
                //Console.WriteLine(pict_string);
                //Console.WriteLine(oResponse_details.id);
                //Console.WriteLine(temp_psims_substance.Language);
                //Console.WriteLine(temp_psims_substance.Country);


                temp_psims_substance.DGN = DGN_String;
                if (temp_psims_substance.Country == "")
                {
                    
                    temp_psims_substance.Country = temp_psims_substance.Language.Substring(temp_psims_substance.Language.IndexOf("(")+1, temp_psims_substance.Language.IndexOf(")") - temp_psims_substance.Language.IndexOf("(")-1);
                }

                List<PSIMsSubstance> oCkPSIMsSubstances = new List<PSIMsSubstance>();
                List<PSIMsSubstLookup> oCkPSIMsSubstLookups = new List<PSIMsSubstLookup>();
                //////7010394XUS


                //Console.WriteLine(oResponse_details.id);

                //oCkPSIMsSubstances = wcfEnterpriseClient.GetPSIMsSubstances(temp_psims_substance.DGN.ToString() + "|" + temp_psims_substance.Country + "|" + temp_psims_substance.Language, MIDAS.Entities.PSIMsSubstanceMatch.DGNCNTRYLANG, "");
                //oCkPSIMsSubstLookups = wcfEnterpriseClient.GetPSIMsSubstLookups(oCkPSIMsSubstances[0].DGN, MIDAS.Entities.PSIMsSubstLookupMatch.DGN);


                //foreach (PSIMsSubstance temp_ock in oCkPSIMsSubstances)
                //{
                //    if (temp_ock.MaterialName != temp_psims_substance.MaterialName)
                //    {
                //        Console.WriteLine("Names different:");
                //        Console.WriteLine("MIDAS:");
                //        Console.WriteLine(temp_ock.MaterialName);
                //        Console.WriteLine("Sphera:");
                //        Console.WriteLine(temp_psims_substance.MaterialName);
                //        temp_ock.MaterialName = temp_psims_substance.MaterialName;
                //    }
                //    else
                //    {
                //        Console.WriteLine("Names Same");
                //        Console.WriteLine(temp_ock.MaterialName);

                //    }
                //    if (temp_ock.Country != temp_psims_substance.Country)
                //    {
                //        Console.WriteLine("Country different:");
                //        Console.WriteLine("MIDAS:");
                //        Console.WriteLine(temp_ock.Country);
                //        Console.WriteLine("Sphera:");
                //        Console.WriteLine(temp_psims_substance.Country);
                //        temp_ock.Country = temp_psims_substance.Country;
                //    }
                //    else
                //    {
                //        Console.WriteLine("Country Same");
                //        Console.WriteLine(temp_ock.Country);
                //    }
                //    if (temp_ock.Language != temp_psims_substance.Language)
                //    {
                //        Console.WriteLine("Language different:");
                //        Console.WriteLine("MIDAS:");
                //        Console.WriteLine(temp_ock.Language);
                //        Console.WriteLine("Sphera:");
                //        Console.WriteLine(temp_psims_substance.Language);
                //        temp_ock.Language = temp_psims_substance.Language;
                //    }
                //    else
                //    {
                //        Console.WriteLine("Language Same");
                //        Console.WriteLine(temp_ock.Language);
                //    }
                //    if (temp_ock.NFPAChronic != temp_psims_substance.NFPAChronic)
                //    {
                //        Console.WriteLine("NFPAChronic different:");
                //        Console.WriteLine("MIDAS:");
                //        Console.WriteLine(temp_ock.NFPAChronic);
                //        Console.WriteLine("Sphera:");
                //        Console.WriteLine(temp_psims_substance.NFPAChronic);
                //        temp_ock.NFPAChronic = temp_psims_substance.NFPAChronic;
                //    }
                //    else
                //    {
                //        Console.WriteLine("NFPAChronic Same");
                //        Console.WriteLine(temp_ock.NFPAChronic);
                //    }
                //    if (temp_ock.NFPAFlame != temp_psims_substance.NFPAFlame)
                //    {
                //        Console.WriteLine("NFPAChronic different:");
                //        Console.WriteLine("MIDAS:");
                //        Console.WriteLine(temp_ock.NFPAFlame);
                //        Console.WriteLine("Sphera:");
                //        Console.WriteLine(temp_psims_substance.NFPAFlame);
                //        temp_ock.NFPAFlame = temp_psims_substance.NFPAFlame;
                //    }
                //    else
                //    {
                //        Console.WriteLine("NFPAFlame Same");
                //        Console.WriteLine(temp_ock.NFPAFlame);
                //    }
                //    if (temp_ock.NFPAHealth != temp_psims_substance.NFPAHealth)
                //    {
                //        Console.WriteLine("NFPAHealth different:");
                //        Console.WriteLine("MIDAS:");
                //        Console.WriteLine(temp_ock.NFPAHealth);
                //        Console.WriteLine("Sphera:");
                //        Console.WriteLine(temp_psims_substance.NFPAHealth);
                //        temp_ock.NFPAHealth = temp_psims_substance.NFPAHealth;
                //    }
                //    else
                //    {
                //        Console.WriteLine("NFPAFlame Same");
                //        Console.WriteLine(temp_ock.NFPAHealth);
                //    }

                //    if (temp_ock.NFPAReact != temp_psims_substance.NFPAReact)
                //    {
                //        Console.WriteLine("NFPAReact different:");
                //        Console.WriteLine("MIDAS:");
                //        Console.WriteLine(temp_ock.NFPAReact);
                //        Console.WriteLine("Sphera:");
                //        Console.WriteLine(temp_psims_substance.NFPAReact);
                //        temp_ock.NFPAReact = temp_psims_substance.NFPAReact;
                //    }
                //    else
                //    {
                //        Console.WriteLine("NFPAReact Same");
                //        Console.WriteLine(temp_ock.NFPAReact);
                //    }


                //    if (temp_ock.SignalWord != temp_psims_substance.SignalWord)
                //    {
                //        Console.WriteLine("SignalWord different:");
                //        Console.WriteLine("MIDAS:");
                //        Console.WriteLine(temp_ock.SignalWord);
                //        Console.WriteLine("Sphera:");
                //        Console.WriteLine(temp_psims_substance.SignalWord);
                //        temp_ock.SignalWord = temp_psims_substance.SignalWord;
                //    }
                //    else
                //    {
                //        Console.WriteLine("SignalWord Same");
                //        Console.WriteLine(temp_ock.SignalWord);
                //    }

                //    if (temp_ock.ValidFlag != temp_psims_substance.ValidFlag)
                //    {
                //        Console.WriteLine("ValidFlag different:");
                //        Console.WriteLine("MIDAS:");
                //        Console.WriteLine(temp_ock.ValidFlag);
                //        Console.WriteLine("Sphera:");
                //        Console.WriteLine(temp_psims_substance.ValidFlag);
                //        temp_ock.ValidFlag = temp_psims_substance.ValidFlag;
                //    }
                //    else
                //    {
                //        Console.WriteLine("ValidFlag Same");
                //        Console.WriteLine(temp_ock.ValidFlag);
                //    }

                //    if (temp_ock.Source != temp_psims_substance.Source)
                //    {
                //        Console.WriteLine("Source different:");
                //        Console.WriteLine("MIDAS:");
                //        Console.WriteLine(temp_ock.Source);
                //        Console.WriteLine("Sphera:");
                //        Console.WriteLine(temp_psims_substance.Source);
                //        temp_ock.Source = temp_psims_substance.Source;
                //    }
                //    else
                //    {
                //        Console.WriteLine("Source Same");
                //        Console.WriteLine(temp_ock.Source);
                //    }

                //    if (temp_ock.FlashPointF != temp_psims_substance.FlashPointF)
                //    {
                //        Console.WriteLine("FlashPointF different:");
                //        Console.WriteLine("MIDAS:");
                //        Console.WriteLine(temp_ock.FlashPointF);
                //        Console.WriteLine("Sphera:");
                //        Console.WriteLine(temp_psims_substance.FlashPointF);
                //        temp_ock.FlashPointF = temp_psims_substance.FlashPointF;
                //    }
                //    else
                //    {
                //        Console.WriteLine("FlashPointF Same");
                //        Console.WriteLine(temp_ock.FlashPointF);
                //    }


                //    List<string> pict_words_1 = temp_psims_substance.Pictograms.Split('|').ToList<string>();
                //    List<string> pict_words_2 = temp_ock.Pictograms.Split('|').ToList<string>();
                //    if (new HashSet<string>(pict_words_1).SetEquals(pict_words_2))
                //    {
                //        Console.WriteLine("Pictograms Same");
                //        Console.WriteLine(temp_ock.Pictograms);
                //    }
                //    else
                //    {
                //        Console.WriteLine("Pictograms different:");
                //        Console.WriteLine("MIDAS:");
                //        Console.WriteLine(temp_ock.Pictograms);
                //        Console.WriteLine("Sphera:");
                //        Console.WriteLine(temp_psims_substance.Pictograms);
                //        temp_ock.Pictograms = temp_psims_substance.Pictograms;
                //    }


                //    PSIMsSubstance garbage = wcfEnterpriseClient.SavePSIMsSubstance(temp_ock);
                //}

            }
            Console.WriteLine("no GHS:\n");

            Console.WriteLine(String.Join("\n", noGHS));
            Console.WriteLine("no DGN:\n");

            Console.WriteLine(String.Join("\n", noDGN));


            try
            {
                wcfEnterpriseClient.Close();
                Console.WriteLine(wcfEnterpriseClient.State);
            }
            catch (Exception e) { Console.WriteLine(e); }


            Console.ReadKey();

        }
    }
}
