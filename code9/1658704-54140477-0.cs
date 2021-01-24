       **Here is the solution for you.**
       1.  **Connect with rabbitMQ using API**  
           public WebClient GetRabbitMqConnection(string userName, string password)
           {
                var client = new WebClient(); 
                client.Credentials = new NetworkCredential(userName, password);
                return client;
           }
       2. **Retrieve message by providing appropriate parameter in below method.**
          public string GetRabbitMQMessages(string domainName, string port, string 
                                            queueName, string virtualHost, WebClient 
                                            client, string methodType)
          {
                     string messageResult = string.Empty;
                     string strUri = "http://" + domainName + ":" + port + "/api/queues/" 
                                     + virtualHost + "/";
                     var data = client.DownloadString(strUri + queueName + "/");
                     var queueInfo = JsonConvert.DeserializeObject<QueueInfo>(data);
                     if (queueInfo == null || queueInfo.messages == 0)
                         return string.Empty;
                     if (methodType == "POST")
                     {
                         string postbody = "  
                     {\"ackmode\":\"ack_requeue_true\",\"count\":
                      \"$totalMessageCount\",
                      \"name\":\"${DomainName}\",\"requeue\":\"false\",
                      \"encoding\":\"auto\",\"vhost\" : \"${QueueName}\"}";
                      postbody = postbody.Replace("$totalMessageCount", 
                      queueInfo.messages.ToString()).Replace("${DomainName}", 
                      domainName).Replace("${QueueName}", queueName);
                      messageResult = client.UploadString(strUri + queueName + "/get", 
                      "POST", postbody);
                     }
                    return messageResult;
            }
   
        **I wish it will solve your problem. All the best and cheers !!!!!!**
