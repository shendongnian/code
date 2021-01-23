      DispatcherTimer _timerChat = new DispatcherTimer(DispatcherPriority.Render);
            _timerChat.Interval = TimeSpan.FromSeconds(15);
            _timerChat.Tick += new EventHandler(timerchat_Tick);
            _timerChat.Start();
        public async void timerchat_Tick(object sender, EventArgs e)
        {
    //...
            await getMessages();
    //...
        }
        
        public async Task getMessages()
        {
            try
            {
                // ...
                    string result = await content.ReadAsStringAsync();
                    
                // ....
            }
            catch (Exception e)
            {
                MessageBox.Show("GetMessages: " + e);
            }
        }
