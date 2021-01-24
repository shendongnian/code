    private async void checkExistance()
    {
        bool checkExistance = api.CheckIfExist(PhoneNumber);
        Message msg = new Message();
        msg = handler.ObtainMessage();
        if (checkExistance)
        {
            msg.Arg1 = 0;//tell MyHandler exist
        }
        else
        {
            msg.Arg1 = 1;//tell MyHandler didnt exist
        }   
        handler.SendMessage(msg);
    }
