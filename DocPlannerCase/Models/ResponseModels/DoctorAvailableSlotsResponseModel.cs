using DocPlannerCase.Models.RequestModels;

namespace DocPlannerCase.Models.ResponseModels;

public class DoctorAvailableSlotsResponseModel
{
    public List<DoctorScheduleRequestModel> Data { get; set; }
    public string Message { get; set; }
}