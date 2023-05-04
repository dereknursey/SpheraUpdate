using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace SpheraUpdate
//{
public class MaterialDelta
{
    public int materialId { get; set; }
    public int facilityId { get; set; }
    public DeltaDetail[] deltaDetails { get; set; }
}
public class DeltaDetail
{
    public int eventTypeId { get; set; }
    public string eventType { get; set; }
    public int relatedObjectId { get; set; }
    public int modifiedBy { get; set; }
    public DateTime? created { get; set; }

}

