    using (var scope = DialogModule.BeginLifetimeScope(Conversation.Container, message))
    {
         var botDataStore = scope.Resolve<IBotDataStore<BotData>>();
         var key = Address.FromActivity(message);
        
         var userData = await botDataStore.LoadAsync(key, BotStoreType.BotUserData, CancellationToken.None);
         userData.SetProperty("UserName", result.UserInfo.GivenName + " " + result.UserInfo.FamilyName);
         userData.SetProperty("Email", result.UserInfo.DisplayableId);
         userData.SetProperty("GraphAccessToken", UserAccessToken);
         userData.SetProperty("TokenExpiryTime", result.ExpiresOn.ToString());
         await botDataStore.SaveAsync(key, BotStoreType.BotUserData, userData, CancellationToken.None);
         await botDataStore.FlushAsync(key, CancellationToken.None);
    }
