       1. To Retrive Message from RabbitMQ we need to first connect with RabbitMQ server 
    public WebClient GetRabbitMqConnection(string userName, string password)
    {
        var client = new WebClient(); 
        client.Credentials = new NetworkCredential(userName, password);
        return client;
    }
    2. Now retrieve message from RabbitMQ using below code.
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
      } 
      I think this will help you to implement RabbitMQ.
