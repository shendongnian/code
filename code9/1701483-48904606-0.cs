    //inside the loop
    var conn = Factory.CreateConnection();
    var channel = conn.CreateModel();
    
    try
    {
       var data = Get(conn, channel);
       //Process
       channel.BasicAck(data.DeliveryTag, false);
    }
    catch(Exception e)
    {
       //handle e
    }
    finally
    {
       conn?.Close();
       channel?.Close();
    }
    //end of loop
