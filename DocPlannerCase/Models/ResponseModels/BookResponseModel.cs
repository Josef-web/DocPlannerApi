using DocPlannerCase.Models.RequestModels;

namespace DocPlannerCase.Models.ResponseModels;

public class BookResponseModel
{
    public List<BookRequestModel> Data { get; set; }
    public bool status { get; set; }
}