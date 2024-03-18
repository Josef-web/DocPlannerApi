using DocPlannerCase.Models.RequestModels;
using DocPlannerCase.Models.ResponseModels;

namespace DocPlannerCase.Business.Concrete;

public interface IDoctorService
{
    Task<List<DoctorRequestModel>> GetAllDoctors();
    Task<List<DoctorScheduleRequestModel>> GetDoctorScheduleById(int doctorId);
    Task<DoctorAvailableSlotsResponseModel> GetAvailableSlots(int doctorId);
    Task ExportDoctorsToCsv(IEnumerable<DoctorRequestModel> doctors);
}