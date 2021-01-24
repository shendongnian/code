    void client_UploadValuesCompleted(object sender, UploadValuesCompletedEventArgs e)
    {
        string json = Encoding.UTF8.GetString(e.Result);
        //List<Message> message = JsonConvert.DeserializeObject<List<Message>>(json);
        //mock list of messages which you will get after deserializing the json above
        List<Message> message = new List<Message> { new Message { message = "message1" }, new Message { message = "message2" }, new Message { message = "message3" } };
    
        var allMessages = message.Select(x => x.message);
    
        foreach (var messageItem in allMessages)
        {
            listView1.Items.Add(messageItem);
        }
    }
