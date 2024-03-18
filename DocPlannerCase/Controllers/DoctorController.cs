using DocPlannerCase.Business.Concrete;
using DocPlannerCase.Models.RequestModels;
using DocPlannerCase.Models.ResponseModels;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DocPlannerCase.Controllers;

public class DoctorController : Controller
{
    private readonly IDoctorService _doctorService;

    public DoctorController(IDoctorService doctorService)
    {
        _doctorService = doctorService;
    }

    [HttpGet("all-doctors")]
    [SwaggerOperation(
        Summary = "Get All Doctors",
        Description = "Retrieves a list of all doctors in the system.")]
    public async Task<List<DoctorRequestModel>> FetchDoctors()
    {
        return await _doctorService.GetAllDoctors();
    }

    [HttpGet("doctor-schedule/{doctorId}")]
    [SwaggerOperation(
        Summary = "Get Doctor Schedule",
        Description = "Retrieves the schedule of a doctor by their ID.")]
    public async Task<List<DoctorScheduleRequestModel>> GetDoctorSchedule(int doctorId)
    {
        return await _doctorService.GetDoctorScheduleById(doctorId);
    }

    [HttpGet("doctor-available-slots/{doctorId}")]
    [SwaggerOperation(
        Summary = "Get Doctor Available Slots",
        Description = "Retrieves the available slots of a doctor by their ID.")]
    public async Task<DoctorAvailableSlotsResponseModel> GetAvailableSlots(int doctorId)
    {
        return await _doctorService.GetAvailableSlots(doctorId);
    }
    
    [HttpGet("export-doctors")]
    [SwaggerOperation(
        Summary = "Export Doctors to CSV",
        Description = "Exports the list of Turkish doctors to a CSV file."
    )]
    public async Task<IActionResult> ExportDoctorsToCsv(List<DoctorRequestModel> doctors)
    {
        try
        {
            var filteredDoctors = doctors.Where(d => d.Nationality.ToLower() == "turkish");
            var filePath = "DoctorsOutput.csv";
            
            await _doctorService.ExportDoctorsToCsv(filteredDoctors);
            
            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
            return File(fileBytes, "text/csv", "DoctorsOutput.csv");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Failed to export doctors to CSV: {ex.Message}");
        }
    }
    
}