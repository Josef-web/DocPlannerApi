namespace DocPlannerCase.Models.RequestModels;

public class DoctorRequestModel
{
    public int DoctorId { get; set; }
    public string Name { get; set; }
    public string HospitalName { get; set; }
    public string Gender { get; set; }
    public int HospitalId { get; set; }
    public double BranchId { get; set; }
    public int SpecialtyId { get; set; }
    public string Nationality { get; set; }
    public DateTime CreatedAt { get; set; }
}