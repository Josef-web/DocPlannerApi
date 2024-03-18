using DocPlannerCase.Models.RequestModels;

namespace DocPlannerCase.Models.ResponseModels;

public class DoctorScheduleResponseModel
{
    public List<DoctorScheduleRequestModel> Data { get; set; }

}