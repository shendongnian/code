    myfunction()
       {
           List<AmazonEnvelopeMessage> list = new List<AmazonEnvelopeMessage>();
           foreach (var s in skus)
           { 
               AmazonEnvelopeMessage message = new AmazonEnvelopeMessage();
               AmazonEnvelopeLibrary.Models.Product product = new Product();
               ...
               message.Item = product;
               list.Add(message);
          }
          amazon.Envelope.message.AddRange(list);
        }
