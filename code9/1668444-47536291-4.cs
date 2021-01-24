    List<Contact> contacts = contactService.GetAllContacts(); // User would have a collection for you.
    var post = Json.SerializeObject(contacts);
    
    var request = WebRequest.Create(url) as HttpWebRequest;
    request.Method = "POST";
    request.ContentType = ...
    request.ContentLength = post.Length;
    request.UserAgent = ...
    request.Accept = ...
    request.Referer = ...
    
    using(var writer = new StreamWriter(request.GetRequestStream())
    {
         writer.Write(post); 
         request.GetResponse();
         request.Close();
    }
