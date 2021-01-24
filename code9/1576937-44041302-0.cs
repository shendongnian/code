    IBasicProperties mqProps = model.CreateBasicProperties();
    mqProps.ContentType = "text/plain";
    mqProps.DeliveryMode = 2;
    mqProps.Expiration = "300000" 
    
    model.BasicPublish(exchangeName,
                       routingKey, mqProps,
                       messageBodyBytes);
