using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace SpheraUpdate
//{
public class MaterialDetails
{

    public Sensitivity sensitivity { get; set; }
    public Healthhazard healthHazard { get; set; }
    public Physicalhazard physicalHazard { get; set; }
    public Physicalproperty[] physicalProperties { get; set; }
    public Ingredient[] ingredients { get; set; }
    public object[] saraClassifications { get; set; }
    public Whmishazards whmisHazards { get; set; }
    public Nfpahmisrating[] nfpaHmisRatings { get; set; }
    public object[] chemicalAreas { get; set; }
    public Ghshazardclassification[] ghsHazardClassifications { get; set; }
    public Documenthistory[] documentHistory { get; set; }
    public Ansihazards ansiHazards { get; set; }
    public Transportation[] transportation { get; set; }
    public AdditionalProperty[] additionalProperties { get; set; }
    public object[] materialUses { get; set; }
    public object[] chemicalCategories { get; set; }
    public object[] attachments { get; set; }
    public object[] additionalSdss { get; set; }
    public Routesofentry routesOfEntry { get; set; }
    public Euhazardclassification euHazardClassification { get; set; }
    public object[] synonyms { get; set; }
    public Productcode[] productCodes { get; set; }
    public Agenciesclassified[] agenciesClassified { get; set; }
    public object[] notes { get; set; }
    public object[] siteNumbers { get; set; }
    public int? id { get; set; }
    public int? sdsVersion { get; set; }
    public Sds sds { get; set; }
    public int? statusId { get; set; }
    public Status status { get; set; }
    public DateTime statusDate { get; set; }
    public AdditionalProperty[] additionalProperty { get; set; }
    public DateTime? created { get; set; }
    public DateTime? modified { get; set; }
    public object deleted { get; set; }
    public string? modifiedBy { get; set; }

}
public class Sensitivity
{
    public bool? internalProprietary { get; set; }
    public bool? externalProprietary { get; set; }
    public bool? publicHostedSds { get; set; }
}

public class Healthhazard
{
    public bool? mildIrritant { get; set; }
    public bool? irritant_Acute { get; set; }
    public bool? irritant_Chronic { get; set; }
    public bool? skinIrritant_Acute { get; set; }
    public bool? skinIrritant_Chronic { get; set; }
    public bool? eyeIrritant_Acute { get; set; }
    public bool? eyeIrritant_Chronic { get; set; }
    public bool? lungIrritant_Acute { get; set; }
    public bool? lungIrritant_Chronic { get; set; }
    public bool? corrosive_Acute { get; set; }
    public bool? corrosive_Chronic { get; set; }
    public bool? skinCorrosive_Acute { get; set; }
    public bool? skinCorrosive_Chronic { get; set; }
    public bool? eyeCorrosive_Acute { get; set; }
    public bool? eyeCorrosive_Chronic { get; set; }
    public bool? lungsCorrosive_Acute { get; set; }
    public bool? lungsCorrosive_Chronic { get; set; }
    public bool? simpleAsphyxiant_Acute { get; set; }
    public bool? simpleAsphyxiant_Chronic { get; set; }
    public bool? toxic_Acute { get; set; }
    public bool? toxic_Chronic { get; set; }
    public bool? highlyToxic_Acute { get; set; }
    public bool? highlyToxic_Chronic { get; set; }
    public bool? sensitizer_Acute { get; set; }
    public bool? sensitizer_Chronic { get; set; }
    public bool? skinSensitizer_Acute { get; set; }
    public bool? skinSensitizer_Chronic { get; set; }
    public bool? cardiovascularSensitizer_Acute { get; set; }
    public bool? cardiovascularSensitizer_Chronic { get; set; }
    public bool? lungsSensitizer_Acute { get; set; }
    public bool? lungsSensitizer_Chronic { get; set; }
    public bool? reproductive_Acute { get; set; }
    public bool? reproductive_Chronic { get; set; }
    public bool? mutagen_Acute { get; set; }
    public bool? mutagen_Chronic { get; set; }
    public bool? lachrymator_Acute { get; set; }
    public bool? lachrymator_Chronic { get; set; }
    public bool? carcinogen_Acute { get; set; }
    public bool? carcinogen_Chronic { get; set; }
    public int? carcinogen_IARC { get; set; }
    public string? carcinogen_IARC_Category { get; set; }
    public int? carcinogen_NTP { get; set; }
    public string? carcinogen_NTP_Category { get; set; }
    public bool? oshA_Carcinogen { get; set; }
    public bool? tO_Liver_Acute { get; set; }
    public bool? tO_Liver_Chronic { get; set; }
    public bool? tO_Kidney_Acute { get; set; }
    public bool? tO_Kidney_Chronic { get; set; }
    public bool? tO_Eyes_Acute { get; set; }
    public bool? tO_Eyes_Chronic { get; set; }
    public bool? tO_Ear_Acute { get; set; }
    public bool? tO_Ear_Chronic { get; set; }
    public bool? tO_Skin_Acute { get; set; }
    public bool? tO_Skin_Chronic { get; set; }
    public bool? tO_Urinary_Acute { get; set; }
    public bool? tO_Urinary_Chronic { get; set; }
    public bool? tO_Brain_Acute { get; set; }
    public bool? tO_Brain_Chronic { get; set; }
    public bool? tO_Musculoskeletal_Acute { get; set; }
    public bool? tO_Musculoskeletal_Chronic { get; set; }
    public bool? tO_Endocrine_Acute { get; set; }
    public bool? tO_Endocrine_Chronic { get; set; }
    public bool? tO_Respiratory_Acute { get; set; }
    public bool? tO_Respiratory_Chronic { get; set; }
    public bool? tO_Prostate_Acute { get; set; }
    public bool? tO_Prostate_Chronic { get; set; }
    public bool? tO_NervousSystem_Acute { get; set; }
    public bool? tO_NervousSystem_Chronic { get; set; }
    public bool? tO_CNS_Acute { get; set; }
    public bool? tO_CNS_Chronic { get; set; }
    public bool? tO_PNS_Acute { get; set; }
    public bool? tO_PNS_Chronic { get; set; }
    public bool? tO_ImmuneSystem_Acute { get; set; }
    public bool? tO_ImmuneSystem_Chronic { get; set; }
    public bool? tO_Anemia_Acute { get; set; }
    public bool? tO_Anemia_Chronic { get; set; }
    public bool? tO_Methemoglobinemia_Acute { get; set; }
    public bool? tO_Methemoglobinemia_Chronic { get; set; }
    public bool? tO_Carboxyhemoglobinemia_Acute { get; set; }
    public bool? tO_Carboxyhemoglobinemia_Chronic { get; set; }
    public bool? tO_ChemicalAsphyxiant_Acute { get; set; }
    public bool? tO_ChemicalAsphyxiant_Chronic { get; set; }
    public bool? tO_BoneMarrow_Acute { get; set; }
    public bool? tO_BoneMarrow_Chronic { get; set; }
    public bool? tO_Cardiovascular_Acute { get; set; }
    public bool? tO_Cardiovascular_Chronic { get; set; }
    public bool? tO_Spleen_Acute { get; set; }
    public bool? tO_Spleen_Chronic { get; set; }
    public bool? tO_Gastrointestinal_Acute { get; set; }
    public bool? tO_Gastrointestinal_Chronic { get; set; }
    public bool? tO_FrostBite_Acute { get; set; }
    public bool? tO_FrostBite_Chronic { get; set; }
}

public class Physicalhazard
{
    public bool? flammableLiquid { get; set; }
    public bool? flammableSolid { get; set; }
    public bool? flammableGas { get; set; }
    public bool? combustibleLiquid { get; set; }
    public bool? compressedGas { get; set; }
    public bool? oxidizer { get; set; }
    public bool? unstableReactive { get; set; }
    public bool? organicPeroxide { get; set; }
    public bool? waterReactive { get; set; }
    public bool? pyrophoric { get; set; }
    public bool? explosive { get; set; }
    public bool? radioactive { get; set; }
    public object? ufcFlammable { get; set; }
    public object? bocaSolvent { get; set; }
    public object? bocaFlammable { get; set; }
}

public class Whmishazards
{
    public bool? compressed { get; set; }
    public bool? corrosive { get; set; }
    public bool? flammable { get; set; }
    public bool? otherToxicEffects { get; set; }
    public bool? oxidizing { get; set; }
    public bool? biohazard { get; set; }
    public bool? poisonous { get; set; }
    public bool? reactive { get; set; }
}

public class Ansihazards
{
    public bool? corrosive { get; set; }
    public bool? explosive { get; set; }
    public bool? flammable { get; set; }
    public bool? poison { get; set; }
    public object? signalWord { get; set; }
    public object? statementOfHazard { get; set; }
    public object? precautionaryMeasures { get; set; }
}

public class Routesofentry
{
    public object? inhalation { get; set; }
    public object? skin { get; set; }
    public object? eye { get; set; }
    public object? ingestion { get; set; }
    public object? other { get; set; }
    public object? storeAboveTemperatureF { get; set; }
    public object? storeBelowTemperatureF { get; set; }
    public object? storeAboveTemperatureC { get; set; }
    public object? storeBelowTemperatureC { get; set; }
    public object[]? ppeCodesCollection { get; set; }
}

public class Euhazardclassification
{
    public bool? symbol_E { get; set; }
    public bool? symbol_Tplus { get; set; }
    public bool? symbol_O { get; set; }
    public bool? symbol_X { get; set; }
    public bool? symbol_F { get; set; }
    public bool? symbol_Xi { get; set; }
    public bool? symbol_Fplus { get; set; }
    public bool? symbol_C { get; set; }
    public bool? symbol_T { get; set; }
    public bool? symbol_N { get; set; }
    public object[]? hazardClass { get; set; }
    public object[]? riskPhrase { get; set; }
    public object[]? safetyPhrase { get; set; }
}

public class Sds
{
    public int? id { get; set; }
    public int? localeId { get; set; }
    public string? language { get; set; }
    public string? materialName { get; set; }
    public int? manufacturerId { get; set; }
    public Sdsmanufacturer sdsManufacturer { get; set; }
    public DateTime revisionDate { get; set; }
    public object startDate { get; set; }
    public DateTime? lastVerifiedDate { get; set; }
    public string cas { get; set; }
    public string documentUrl { get; set; }
    public bool isProprietary { get; set; }
    public int? msdsVersion { get; set; }
    public DateTime created { get; set; }
    public DateTime modified { get; set; }
    public object deleted { get; set; }
    public string modifiedBy { get; set; }
}

public class Sdsmanufacturer
{
    public string name { get; set; }
    public string country { get; set; }
}

public class Status
{
    public string status { get; set; }
}

public class Physicalproperty
{
    public string? physicalForm { get; set; }
    public string? description { get; set; }
    public string? boilingPointComparator { get; set; }
    public string? boilingPointF1 { get; set; }
    public string? boilingPointC1 { get; set; }
    public object? boilingPointF2 { get; set; }
    public object? boilingPointC2 { get; set; }
    public object? meltingPointComparator { get; set; }
    public object? meltingPointF1 { get; set; }
    public object? meltingPointF2 { get; set; }
    public object? meltingPointC1 { get; set; }
    public object? meltingPointC2 { get; set; }
    public object? phComparator { get; set; }
    public object? ph { get; set; }
    public object? ph2 { get; set; }
    public string? specificGravityComparator { get; set; }
    public object? specificGravity { get; set; }
    public object? specificGravity2 { get; set; }
    public string? densityComparator { get; set; }
    public float? densityWt { get; set; }
    public object? density2 { get; set; }
    public string? waterSolubility { get; set; }
    public float? vaporPressure { get; set; }
    public string? vaporPressureComparator { get; set; }
    public string? vaporPressureUnit { get; set; }
    public string? vaporPressureF { get; set; }
    public string? vaporPressureC { get; set; }
    public string? vaporDensity { get; set; }
    public string? vaporDensityComparator { get; set; }
    public object? evaporationRate { get; set; }
    public object? evaporationRateUnit { get; set; }
    public object evaporationRateComparator { get; set; }
    public object vocPercent { get; set; }
    public object vocWt { get; set; }
    public object vocVolume { get; set; }
    public object vocUnspecified { get; set; }
    public object vocUnspecified2 { get; set; }
    public object vocUnspecifiedComparator { get; set; }
    public object vocUnspecifiedUnitId { get; set; }
    public object volatility { get; set; }
    public string flashPointComparator { get; set; }
    public string flashPointF1 { get; set; }
    public float? flashPointC1 { get; set; }
    public object flashPointF2 { get; set; }
    public object flashPointC2 { get; set; }
    public object fpTestType { get; set; }
    public string uel { get; set; }
    public float? lel { get; set; }
    public object specificGravityUnitID { get; set; }
    public string densityUnitId { get; set; }
    public object inputDensityUnitId { get; set; }
    public object inputDensityComparator { get; set; }
    public object inputDensityWt { get; set; }
    public object inputDensity2 { get; set; }
    public object bulkDensityComparator { get; set; }
    public object bulkDensity { get; set; }
    public object bulkDensity2 { get; set; }
    public object bulkDensityUnitId { get; set; }
    public object waterSolubilityComparator { get; set; }
    public object waterSolubilityValue { get; set; }
    public object waterSolubilityValue2 { get; set; }
    public object waterSolubilityUnitId { get; set; }
    public object odorThresholdComparator { get; set; }
    public object odorThresholdUnitId { get; set; }
    public object odorThreshold { get; set; }
    public object odorThreshold2 { get; set; }
    public object vaporPressure2 { get; set; }
    public object vaporDensity2 { get; set; }
    public string vaporDensityUnitId { get; set; }
    public string viscosityComparator { get; set; }
    public string viscosity { get; set; }
    public object viscosity2 { get; set; }
    public string viscosityUnitId { get; set; }
    public string viscosityF { get; set; }
    public string viscosityC { get; set; }
    public object viscosityTempUnitId { get; set; }
    public object evaporationRate2 { get; set; }
    public object vocsWtComparator { get; set; }
    public object vocsWt2 { get; set; }
    public object vocsWtUnitId { get; set; }
    public object vocsVolComparator { get; set; }
    public object vocsVol2 { get; set; }
    public object voCsVolUnitId { get; set; }
    public object volatilesWtComparator { get; set; }
    public object volatilesWt { get; set; }
    public object volatilesWt2 { get; set; }
    public object volatilesWtUnitId { get; set; }
    public object volatilesVolComparator { get; set; }
    public object volatilesVol { get; set; }
    public object volatilesVol2 { get; set; }
    public object volatilesVolUnitId { get; set; }
    public object volatilesUnspecified { get; set; }
    public object volatilesUnspecified2 { get; set; }
    public object volatilesUnspecifiedComparator { get; set; }
    public object volatilesUnspecifiedUnitId { get; set; }
    public object autoIgnitionComparator { get; set; }
    public object autoIgnitionF1 { get; set; }
    public object autoIgnitionF2 { get; set; }
    public object autoIgnitionC1 { get; set; }
    public object autoIgnitionC2 { get; set; }
    public object halfLife { get; set; }
    public object halfLifeUnitId { get; set; }
    public object partitionCoefficient { get; set; }
    public object distributionCoefficient { get; set; }
    public object bioAccumulationFactor { get; set; }
    public object bioConcentrationFactor { get; set; }
}

public class Ingredient
{
    public int? id { get; set; }
    public int? sdsVersion { get; set; }
    public string name { get; set; }
    public string cas { get; set; }
    public string concentration1 { get; set; }
    public string concentration2 { get; set; }
    public bool? percentageNotSpecified { get; set; }
    public bool? balance { get; set; }
}

public class Nfpahmisrating
{
    public string nfpaFire { get; set; }
    public string nfpaHealth { get; set; }
    public string nfpaInstability { get; set; }
    public string nfpaSpecialHazard { get; set; }
    public bool hmisChronic { get; set; }
    public string hmisFlammability { get; set; }
    public string hmisHealth { get; set; }
    public string hmisPhysical { get; set; }
}

public class Ghshazardclassification
{
    public string regulatoryAgency { get; set; }
    public string? corrosion { get; set; }
    public string? biohazardousInfectious { get; set; }
    public string? gasCylinder { get; set; }
    public string? exclamationMark { get; set; }
    public string? explodingBomb { get; set; }
    public string? flame { get; set; }
    public string? environment { get; set; }
    public string? flameOverCircle { get; set; }
    public string? healthHazard { get; set; }
    public string? skullAndCrossbones { get; set; }
    public string? signalWordDanger { get; set; }
    public string? signalWordWarning { get; set; }
    public string? signalWordNotHazardous { get; set; }
    public Hazardclassification[] hazardClassifications { get; set; }
    public Hazardstatement[] hazardStatements { get; set; }
    public Precautionarystatement[] precautionaryStatements { get; set; }
    public object[] customPhrases { get; set; }
}

public class Documenthistory
{
    public DateTime revisionDate { get; set; }
    public string languageRegion { get; set; }
    public string documentUrl { get; set; }
}

public class Transportation
{
    public string agency { get; set; }
    public string shippingName { get; set; }
    public object unNumber { get; set; }
    public object classification { get; set; }
    public object packagingGroup { get; set; }
    public bool? marinePollutant { get; set; }
}

public class Productcode
{
    public string code { get; set; }
}

public class Agenciesclassified
{
    public string fullName { get; set; }
    public string abbreviation { get; set; }
}

public class AdditionalProperty
{
    public int id { get; set; }
    public string type { get; set; }
    public string scope { get; set; }
    public string status { get; set; }
    public string userCode { get; set; }
    public bool isIdentifier { get; set; }
    public int defaultLanguageId { get; set; }
    public object dateDisplayFormat { get; set; }
    public Localization[] localizations { get; set; }
    public Value[] values { get; set; }
}

public class Localization
{
    public int languageId { get; set; }
    public string name { get; set; }
    public string displayLabel { get; set; }
}

public class Value
{
    public int languageId { get; set; }
    public object listValueId { get; set; }
    public string value { get; set; }
    public object imageDescription { get; set; }
    public object imageName { get; set; }
}

public class Precautionarystatement
{
    public string code { get; set; }
    public string statement { get; set; }
    public Dynamicphrase[] dynamicPhrases { get; set; }
}

public class Dynamicphrase
{
    public string text { get; set; }
}

public class Hazardclassification
{
    public string code { get; set; }
    public string classification { get; set; }
}

public class Hazardstatement
{
    public string code { get; set; }
    public string statement { get; set; }
    public Dynamicphrase[] dynamicPhrases { get; set; }
}


//}
