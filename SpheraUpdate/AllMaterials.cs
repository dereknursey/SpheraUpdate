using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//namespace SpheraUpdate
//{
public class AllMaterials
{   
        public int id { get; set; }
        public int sdsVersion { get; set; }
        public Sds sds { get; set; }
        public int statusId { get; set; }
        public Status status { get; set; }
        public DateTime statusDate { get; set; }
        public Sensitivity sensitivity { get; set; }
        public Additionalproperty[] additionalProperty { get; set; }
        public string[] productCodes { get; set; }
        public object[] siteNumbers { get; set; }
        public DateTime created { get; set; }
        public DateTime modified { get; set; }
        public object deleted { get; set; }
        public string modifiedBy { get; set; }
    }


    public class Additionalproperty
    {
        public int id { get; set; }
        public string textValue { get; set; }
        public string languageId { get; set; }
        public string propertyName { get; set; }
        public string propertyLabel { get; set; }
        public string type { get; set; }
        public bool status { get; set; }
        public object userCode { get; set; }
    }








//}
