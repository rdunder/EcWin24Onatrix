using Azure;
using Azure.Communication.Email;

namespace OnatrixUmbraco.Services;

public class EmailService(ILogger<EmailService> logger, IConfiguration config, EmailClient emailClient)
{
    private readonly ILogger<EmailService> _logger = logger;
    private readonly IConfiguration _config = config;
    private readonly EmailClient _emailClient = emailClient;
    
    public async Task SendEmailAsync(string recipient, string subject, string message)
    {
        try
        {
            var emailSender = _config["EmailCommunicationConfig:EmailSender"];
            
            var emailMessage = new EmailMessage(
                senderAddress: emailSender,
                
                recipients: new EmailRecipients(new List<EmailAddress>
                {
                    new EmailAddress("surbiff@gmail.com")
                }),
                
                content: new EmailContent(subject)
                {
                    PlainText = message
                }
            );
        
            await _emailClient.SendAsync(WaitUntil.Completed, emailMessage);
            _logger.LogInformation("Email sent");
        }
        catch (Exception e)
        {
            
            _logger.LogError($"An error occurred trying to send Email:  {e.Message}");
            _logger.LogError($"VALUES: {recipient} -- {subject} -- {message}");
            return;
        }
    }
}