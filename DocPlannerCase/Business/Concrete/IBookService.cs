using DocPlannerCase.Models.RequestModels;

namespace DocPlannerCase.Business.Concrete;

public interface IBookService
{
    Task<BookRequestModel> BookVisit(BookRequestModel request);
    Task<bool> CancelBooking(int bookingId);
}