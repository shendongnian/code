    private async void ComposeSms(Windows.ApplicationModel.Contacts.Contact recipient, string messageBody, StorageFile attachmentFile, string mimeType)
    {
        var chatMessage = new Windows.ApplicationModel.Chat.ChatMessage();
        chatMessage.Body = messageBody;
        if (attachmentFile != null)
        {
            var stream = Windows.Storage.Streams.RandomAccessStreamReference.CreateFromFile(attachmentFile);
            var attachment = new Windows.ApplicationModel.Chat.ChatMessageAttachment(mimeType, stream);
            chatMessage.Attachments.Add(attachment);
        }
        var phone = recipient.Phones.FirstOrDefault<Windows.ApplicationModel.Contacts.ContactPhone>();
        if (phone != null)
        {
            chatMessage.Recipients.Add(phone.Number);
        }
        await Windows.ApplicationModel.Chat.ChatMessageManager.ShowComposeSmsMessageAsync(chatMessage);
    }
