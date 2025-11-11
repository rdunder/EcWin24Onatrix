using Azure.Communication.Email;
using OnatrixUmbraco.Services;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.CreateUmbracoBuilder()
    .AddBackOffice()
    .AddWebsite()
    .AddComposers()
    .AddAzureBlobMediaFileSystem()
    .AddAzureBlobImageSharpCache()
    .Build();

builder.Services.AddScoped<FormSubmissionService>();

var emailConnectionString = builder.Configuration["EmailCommunicationConfig:EmailConnectionString"] ?? throw new ArgumentNullException($"Failed to get connectionstring for EmailService:\n{nameof(args)}");
builder.Services.AddScoped(x => new EmailClient(emailConnectionString));
                      
builder.Services.AddScoped<EmailService>();

WebApplication app = builder.Build();

await app.BootUmbracoAsync();


app.UseUmbraco()
    .WithMiddleware(u =>
    {
        u.UseBackOffice();
        u.UseWebsite();
    })
    .WithEndpoints(u =>
    {
        u.UseBackOfficeEndpoints();
        u.UseWebsiteEndpoints();
    });

await app.RunAsync();
