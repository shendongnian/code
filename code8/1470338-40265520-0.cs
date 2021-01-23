    public async void timerchat_Tick(object sender, EventArgs e)
    {
        if (counterChat != incChat)
        {
            incChat++;
        }
        else
        {
            await getMessages();
            OnPropertyChanged("Friends");
            incChat = 0;
        }
    }
