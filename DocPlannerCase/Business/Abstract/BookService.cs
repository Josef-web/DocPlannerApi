using DocPlannerCase.Business.Concrete;
using DocPlannerCase.Models.RequestModels;
using Newtonsoft.Json;

namespace DocPlannerCase.Business.Abstract;

public class BookService : IBookService
{
     private readonly HttpClient _httpClient;

    public BookService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<BookRequestModel> BookVisit(BookRequestModel request)
    {
        
        var bookingData = new Dictionary<string, string>()
        {
            { "VisitId", "0" }, 
            { "startTime", request.StartTime.ToString(@"hh\:mm") },
            { "endTime", request.EndTime.ToString(@"hh\:mm") },
            { "date", request.Date.ToString("dd/MM/yyyy") },
            { "PatientName", request.PatientName },
            { "PatientSurname", request.PatientSurname },
            { "hospitalId", request.HospitalId.ToString() },
            { "doctorId", request.DoctorId.ToString() },
            { "branchId", Math.Round((double)request.DoctorId, 0).ToString() }
        };

        var content = new FormUrlEncodedContent(bookingData);

        
        HttpResponseMessage response = await _httpClient.PostAsync(
            "https://3aff8cc7-91f8-4577-bef3-e566d6c41d74.mock.pstmn.io/BookVisit?", content);

     
        if (response.IsSuccessStatusCode)
        {
            string jsonResponse = await response.Content.ReadAsStringAsync();
            var bookingResult = JsonConvert.DeserializeObject<BookRequestModel>(jsonResponse);
            return bookingResult;
        }
        else
        {
            throw new Exception("Failed to book visit. HTTP status code: " + response.StatusCode);
        }

    }


    public async Task<bool> CancelBooking(int bookingId)
    {
        
        var response = await _httpClient.PostAsync(
            $"https://3aff8cc7-91f8-4577-bef3-e566d6c41d74.mock.pstmn.io/bookVisit?BookingID={bookingId}",null);
        
        if (response.IsSuccessStatusCode)
        {
            string jsonResponse = await response.Content.ReadAsStringAsync();
            var responseData = JsonConvert.DeserializeObject<dynamic>(jsonResponse);
            bool status = responseData.status;
            return status;
        }
        else
        {
            return false;
        }
    }
}