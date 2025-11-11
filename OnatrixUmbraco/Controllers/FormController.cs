using Microsoft.AspNetCore.Mvc;
using OnatrixUmbraco.Services;
using OnatrixUmbraco.ViewModels;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.Controllers;

namespace OnatrixUmbraco.Controllers;

public class FormController(
    IUmbracoContextAccessor umbracoContextAccessor,
    IUmbracoDatabaseFactory databaseFactory,
    ServiceContext services,
    AppCaches appCaches,
    IProfilingLogger profilingLogger,
    IPublishedUrlProvider publishedUrlProvider,
    FormSubmissionService formSubmissionService)
    : SurfaceController(umbracoContextAccessor,
        databaseFactory,
        services,
        appCaches,
        profilingLogger,
        publishedUrlProvider)
{
    private readonly FormSubmissionService _formSubmissionService = formSubmissionService;
    
    [HttpPost]
    public async Task<IActionResult> CallbackFormSubmit(CallbackFormViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return CurrentUmbracoPage();
        }

        var result = await _formSubmissionService.SaveCallbackRequest(model);

        if (!result)
        {
            TempData["FormError"] = "Something went wrong";
            return RedirectToCurrentUmbracoPage();
        }
        
        TempData["Success"] = "Thank you for your submission";
        return RedirectToCurrentUmbracoPage();
    }

    [HttpPost]
    public async Task<IActionResult> QuestionFormSubmit(QuestionFormViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return CurrentUmbracoPage();
        }
        
        var result = await _formSubmissionService.SaveQuestionRequest(model);

        if (!result)
        {
            TempData["FormError"] = "Something went wrong";
            return RedirectToCurrentUmbracoPage();
        }
        
        TempData["Success"] = "Thank you for your submission";
        return RedirectToCurrentUmbracoPage();
    }
}