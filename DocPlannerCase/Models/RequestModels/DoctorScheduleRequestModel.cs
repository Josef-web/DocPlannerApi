namespace DocPlannerCase.Models.RequestModels;

public class DoctorScheduleRequestModel
{
    public string Id { get; set; }
    public int DoctorId { get; set; }
    public int VisitId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}