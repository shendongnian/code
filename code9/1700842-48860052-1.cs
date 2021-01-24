    public async Task<ActionResult> IndexAsync(CancellationToken cancellationToken, TokenErrorResponse errorResp)
      {
       var result = await new AuthorizationCodeMvcApp(this, new AppFlowMetadata()).
        AuthorizeAsync(cancellationToken);
       if (errorResp !=null)
       {
        if (result.Credential != null)
        {
         var service = new DriveService(new BaseClientService.Initializer
         {
          HttpClientInitializer = result.Credential,
          ApplicationName = "ASP.NET MVC Sample"
         });
    
         // YOUR CODE SHOULD BE HERE..
         // SAMPLE CODE:
         try
         {
          var list = await service.Files.List().ExecuteAsync();
          ViewBag.Message = "FILE COUNT IS: " + list.Files.Count;
          return View();
         }
         catch (Exception ex)
         {
          return View();
         }
        }
        else
        {
         return new RedirectResult(result.RedirectUri);
        }
       }
       else
        return View();
      }
