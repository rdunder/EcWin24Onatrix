using OnatrixUmbraco.ViewModels;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;

namespace OnatrixUmbraco.Services;

public class FormSubmissionService(IContentService contentService, EmailService emailService)
{
    private readonly IContentService _contentService = contentService;
    private readonly EmailService _emailService = emailService;
    
    public async Task<bool> SaveCallbackRequest(CallbackFormViewModel model)
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
        
        await _emailService.SendEmailAsync(model.Email, "Callback", $"Dear {model.Name}!\nThank you for your message. \nWe will get back to you ASAP about {model.SelectedOption}");
        
        return saveResult.Success;
    }

    public async Task<bool> SaveQuestionRequest(QuestionFormViewModel model)
    {
        var container = _contentService.GetRootContent().FirstOrDefault(x => x.ContentType.Alias == "formSubmissions");
        if (container is null) return false;

        var requestName = $"{DateTime.Now:yyyy-MM-dd HH:mm} - {model.Name}";

        var request = _contentService.Create(requestName, container, "questionRequest");
        request.SetValue("questionRequestName", model.Name);
        request.SetValue("questionRequestEmail", model.Email);
        request.SetValue("questionRequestQuestion", model.Question);
        
        var saveResult = _contentService.Save(request);
        
        await _emailService.SendEmailAsync(model.Email, "Question", $"Dear {model.Name}!\nThank you for your message. \nWe will get back to you ASAP. \nYour qestion: {model.Question}");
        
        return saveResult.Success;
    }
}