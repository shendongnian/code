     var token = GetAccessTokenAsync();
     var credential = new TokenCredentials(token.Result.AccessToken);
     string provisoningStatus = "Failed";
     try
       {
         var result =CreateTemplateDeploymentAsync(credential, "tom", "MyWindowsVM", "you subscription Id")
                       .Result;
                    provisoningStatus = result.Properties.ProvisioningState;
       }
     catch (Exception)
      {
                    
         //ToDo
      }
      if (provisoningStatus.Equals("Failed"))
      {
             //TODo
      }
     
    }
