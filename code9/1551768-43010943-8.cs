    foreach(var userEmailProvider in UserEmailProviders) {
         // I'm assuming the factory is injected
         var emailService = _emailProviderFactory.Create(userEmailProvider.Name);
         emailService.Send(new EmailMessage(), new List<TemplateContent>());
    }
