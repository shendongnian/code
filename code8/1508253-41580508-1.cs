    namespace SESTest
    {
    using System;
    using System.Net.Mail;
    namespace AmazonSESSample
    {
        class Program
        {
            static void Main(string[] args)
            {
                const String FROM = "from-email";   // Replace with your "From" address. This address must be verified.
                const String TO = "to-email";  // Replace with a "To" address. If your account is still in the
                                                            // sandbox, this address must be verified.
                const String SUBJECT = "Amazon SES test (SMTP interface accessed using C#)";
                const String BODY = "This email and attachment was sent through the Amazon SES SMTP interface by using C#.";
                // Supply your SMTP credentials below. Note that your SMTP credentials are different from your AWS credentials.
                const String SMTP_USERNAME = "user-creds";  // Replace with your SMTP username. 
                const String SMTP_PASSWORD = "password";  // Replace with your SMTP password.
                // Amazon SES SMTP host name. 
                const String HOST = "your-region.amazonaws.com";
                // The port you will connect to on the Amazon SES SMTP endpoint. We are choosing port 587 because we will use
                // STARTTLS to encrypt the connection.
                const int PORT = 2587;
                // Create an SMTP client with the specified host name and port.
                using (System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient(HOST, PORT))
                {
                    // Create a network credential with your SMTP user name and password.
                    client.Credentials = new System.Net.NetworkCredential(SMTP_USERNAME, SMTP_PASSWORD);
                    // Use SSL when accessing Amazon SES. The SMTP session will begin on an unencrypted connection, and then 
                    // the client will issue a STARTTLS command to upgrade to an encrypted connection using SSL.
                    client.EnableSsl = true;
                    // Send the email. 
                    try
                    {
                        Console.WriteLine("Attempting to send an email through the Amazon SES SMTP interface...");
                        var mailMessage = new MailMessage()
                        {
                            Body = BODY,
                            Subject = SUBJECT,
                            From = new MailAddress(FROM)
                        };
                        mailMessage.To.Add(new MailAddress(TO));
                        //REMOVE THIS CODE
                        //System.IO.MemoryStream ms = new System.IO.MemoryStream(attchmentRec.ssSTAttachment.ssBinary);
                        //Attachment attach = new Attachment(ms, attchmentRec.ssSTAttachment.ssFilename);
                        //mailMessage.Attachments.Add(attach);
                        System.Net.Mime.ContentType contentType = new System.Net.Mime.ContentType();
                        contentType.MediaType = System.Net.Mime.MediaTypeNames.Application.Octet;
                        contentType.Name = "Lebowski.docx";
                        mailMessage.Attachments.Add(new Attachment("C:\\users\\luis\\Documents\\Lebowski.docx", contentType));
                        client.Send(mailMessage);
                        Console.WriteLine("Email sent!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("The email was not sent.");
                        Console.WriteLine("Error message: " + ex.Message);
                    }
                }
                Console.Write("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
    }
