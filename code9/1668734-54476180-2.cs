    public string GetRabbitMQMessages(string domainName, string port, string 
                queueName, string virtualHost, WebClient client, string 
                methodType)
    {
        string messageResult = string.Empty;
        string strUri = "http://" + domainName + ":" + port + 
                        "/api/queues/" + virtualHost + "/";
        var data = client.DownloadString(strUri + queueName + "/");
        var queueInfo = JsonConvert.DeserializeObject<QueueInfo>(data);
        if (queueInfo == null || queueInfo.messages == 0)
                   return string.Empty;
        if (methodType == "POST")
        {
            string postbody = "  
            {\"ackmode\":\"ack_requeue_true\",\"count\":
             \"$totalMessageCount\",\"name\":\"${DomainName}\",
             \"requeue\":\"false\",\"encoding\":\"auto\",\"vhost\" :
             \"${QueueName}\"}";
             postbody = postbody.Replace("$totalMessageCount", 
             queueInfo.messages.ToString()).Replace("${DomainName}", 
             domainName).Replace("${QueueName}", queueName);
             messageResult = client.UploadString(strUri + queueName + 
             "/get", "POST", postbody);
      }
      return messageResult;
