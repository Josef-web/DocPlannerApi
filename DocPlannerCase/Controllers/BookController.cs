using DocPlannerCase.Business.Concrete;
using DocPlannerCase.Models.RequestModels;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DocPlannerCase.Controllers;

public class BookController : Controller
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }
    
    
    [HttpPost("book-visit")]
    [SwaggerOperation(
        Summary = "Book Appointment",
        Description = "Books an appointment with the specified informations.")]
    
    public async Task<BookRequestModel> BookVisit(BookRequestModel request)
    {
        return  await _bookService.BookVisit(request);
    }
    
    
    [HttpPost("cancel-booking")]
    [SwaggerOperation(
        Summary = "Cancel Booking",
        Description = "Cancels the booking with the specified bookingId.")]
    public async Task<ActionResult<bool>> CancelBooking(int bookingId)
    {
        try
        {
            var isCancelled = await _bookService.CancelBooking(bookingId);
            return Ok(isCancelled);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Failed to cancel booking: {ex.Message}");
        }
    }
}