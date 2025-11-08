using OnatrixUmbraco.ViewModels;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;

namespace OnatrixUmbraco.Services;

public class FormSubmissionService(IContentService contentService)
{
    private readonly IContentService _contentService = contentService;
    
    public bool SaveCallbackRequest(CallbackFormViewModel model)
    {
        var container = _contentService.GetRootContent().FirstOrDefault(x => x.ContentType.Alias == "formSubmissions");
        if (container is null) return false;

        var requestName = $"{DateTime.Now:yyyy-MM-dd HH:mm} - {model.Name}";

        var request = _contentService.Create(requestName, container, "callbackRequest");
        request.SetValue("callbackRequestName", model.Name);
        request.SetValue("callbackRequestEmail", model.Email);
        request.SetValue("callbackRequestPhone", model.Phone);
        request.SetValue("callbackRequestSelectedOption", model.SelectedOption);
        
        var saveResult = _contentService.Save(request);
        return saveResult.Success;
    }

    public bool SaveQuestionRequest(QuestionFormViewModel model)
    {
        return true;
    }
}