    if (res.IsSuccessStatusCode)
    {
        CommonConversation.User = JsonConvert.DeserializeObject<CustomerUser>(await res.Content.ReadAsStringAsync());
         await context.PostAsync($"Welcome {CommonConversation.User.FirstName}!");
         context.Done(email);
    }
