    Try
    {
    smtpServer.Send(mail); // Attempts to send the email
    Debug.Log("success");
    }
    catch (SmtpFailedRecipientsException) // Catches send failure
    {
    mail.Dispose(); // ends the SMTP connection
    SceneManager.LoadScene("SceneName"); //Reloads the scene to clear textboxes
    }
