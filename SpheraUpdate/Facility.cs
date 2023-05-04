using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public class Facility
{
    public int id { get; set; }
    public string name { get; set; }
    public string areaId { get; set; }
    public int corporationId { get; set; }
    public object siteCode { get; set; }
    public object dunsNumber { get; set; }
    public object sicCode { get; set; }
    public object naicNumber { get; set; }
    public object epaNumber { get; set; }
    public object npdesPermit { get; set; }
    public object undergroundInjectionId { get; set; }
    public object latitude { get; set; }
    public object longitude { get; set; }
    public object triFacilityId { get; set; }
    public object rmpFacilityId { get; set; }
    public bool emergencyPlanning { get; set; }
    public bool chemicalAccidentPrevention { get; set; }
    public object maximumNumberOccupants { get; set; }
    public bool isManned { get; set; }
    public object parentCompanyName { get; set; }
    public object parentCompanyAddress { get; set; }
    public object parentCompanyPhone { get; set; }
    public object parentCompanyEmail { get; set; }
    public object redirectText { get; set; }
    public object redirectUrl { get; set; }
    public object[] externalIds { get; set; }
    public DateTime created { get; set; }
    public DateTime modified { get; set; }
    public object deleted { get; set; }
    public string modifiedBy { get; set; }
}


