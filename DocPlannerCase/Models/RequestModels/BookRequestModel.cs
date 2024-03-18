namespace DocPlannerCase.Models.RequestModels;

public class BookRequestModel
{
    public int BookingId { get; set; }
    public int VisitId { get; set; }
    public int DoctorId { get; set; }
    public int HospitalId { get; set; }
    public double BranchId { get; set; }
    public DateTime StartTime{ get; set; }
    public DateTime EndTime { get; set; }
    public DateOnly Date { get; set; }
    public string PatientName { get; set; }
    public string PatientSurname { get; set; }
}