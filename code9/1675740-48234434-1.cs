       JObject contact1Add = new JObject();
       contact1Add.Add("firstname", "Jack");
    
       HttpRequestMessage updateRequest1 = new HttpRequestMessage(
           new HttpMethod("PATCH"), contact1Uri);
       updateRequest1.Content = new StringContent(contact1Add.ToString(),
           Encoding.UTF8, "application/json");
       HttpResponseMessage updateResponse1 =
           await httpClient.SendAsync(updateRequest1);
       if (updateResponse1.StatusCode == HttpStatusCode.NoContent) //204
       {
        Console.WriteLine("Contact '{0} {1}' updated with " +
            "firstname", contact1.GetValue("firstname"),
            contact1.GetValue("lastname"));
       }
       else
       {
        Console.WriteLine("Failed to update contact for reason: {0}",
            updateResponse1.ReasonPhrase);
        throw new CrmHttpResponseException(updateResponse1.Content);
       }
