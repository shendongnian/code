    MessageModel Message = new MessageModel();
    Message.Name = "MyName";
    BindingList<MessageModel> list = new BindingList<MessageModel>();
    list.Add(Message); // list[0].Name = MyName
    Message = new MessageModel();
    Message.Name = "New Name"; //list[0].Name = MyName
