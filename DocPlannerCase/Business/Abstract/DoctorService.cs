using System.Globalization;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;
using DocPlannerCase.Business.Concrete;
using DocPlannerCase.Models.RequestModels;
using DocPlannerCase.Models.ResponseModels;
using Newtonsoft.Json;

namespace DocPlannerCase.Business.Abstract;

public class DoctorService : IDoctorService
{
    private readonly HttpClient _httpClient;

    public DoctorService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<DoctorRequestModel>> GetAllDoctors()
    {
        HttpResponseMessage response =
            await _httpClient.GetAsync("https://3aff8cc7-91f8-4577-bef3-e566d6c41d74.mock.pstmn.io/fetchDoctors");
        if (response.IsSuccessStatusCode)
        {
            string jsonResponse = await response.Content.ReadAsStringAsync();
            var doctors = JsonConvert.DeserializeObject<DoctorResponseModel>(jsonResponse);
            var doctorsData = doctors.Data.Select(d => new DoctorRequestModel
            {
                DoctorId = d.DoctorId,
                Name = d.Name,
                Gender = d.Gender,
                HospitalName = d.HospitalName,
                HospitalId = d.HospitalId,
                SpecialtyId = d.SpecialtyId,
                Nationality = d.Nationality,
                CreatedAt = d.CreatedAt,
                BranchId = (int)Math.Round(d.BranchId)
            }).ToList();

            return doctorsData;
        }

        throw new Exception("Failed to fetch doctors. HTTP status code: " + response.StatusCode);
    }

    public async Task<List<DoctorScheduleRequestModel>> GetDoctorScheduleById(int doctorId)
    {
        HttpResponseMessage response = await _httpClient.GetAsync(
            $"https://3aff8cc7-91f8-4577-bef3-e566d6c41d74.mock.pstmn.io/fetchSchedules?doctorId={doctorId}");

        if (response.IsSuccessStatusCode)
        {
            string jsonResponse = await response.Content.ReadAsStringAsync();
            var doctorScheduleResponse = JsonConvert.DeserializeObject<DoctorScheduleResponseModel>(jsonResponse);
            return doctorScheduleResponse.Data;
        }

        throw new Exception("Failed to fetch doctor schedules. HTTP status code: " + response.StatusCode);
    }

    public async Task<DoctorAvailableSlotsResponseModel> GetAvailableSlots(int doctorId)
    {
        HttpResponseMessage response = await _httpClient.GetAsync(
            $"https://3aff8cc7-91f8-4577-bef3-e566d6c41d74.mock.pstmn.io/fetchSchedules?doctorId={doctorId}");

        if (response.IsSuccessStatusCode)
        {
            string jsonResponse = await response.Content.ReadAsStringAsync();
            var doctorScheduleResponse = JsonConvert.DeserializeObject<DoctorAvailableSlotsResponseModel>(jsonResponse);
            return doctorScheduleResponse;
        }

        string errorMessage = await response.Content.ReadAsStringAsync();
        throw new Exception("Failed to fetch available slots. Error message: " + errorMessage);
    }
    
    
    public async Task ExportDoctorsToCsv(IEnumerable<DoctorRequestModel> doctors)
    {
        
         var filePath = "DoctorsOutput.csv";
        
        using (var writer = new StreamWriter(filePath, false, Encoding.UTF8))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            csv.WriteHeader<DoctorRequestModel>();
            csv.NextRecord();
            csv.WriteRecords(doctors.Select(d => new DoctorRequestModel
            {
                Name = d.Name,
                Gender = (d.Gender == "male") ? "Erkek" : "Kadın",
                Nationality = d.Nationality
            }));
        }
        
    }
    
    
}