    using (System.Net.WebClient client = new System.Net.WebClient())
    {
    	client.Credentials = new System.Net.NetworkCredential(rmq_user, rmq_pass);
    	client.Headers.Set("Content-Type", "application/json");
    	response = client.UploadString(messagePath, jsonPayload);
    }
