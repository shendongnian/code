      catch (WebException ex)
      {
           var ftpResponse = ex.Response as FtpWebResponse;                      
           log.Error(ftpResponse.StatusCode); //as enumerate
           log.Error((int)ftpResponse.StatusCode); //as integer
      }
