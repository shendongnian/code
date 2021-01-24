        
        public static async void OnMessageReceived(object sender, MessageEventArgs e)
        {
            bool found = false; //temporary bool, most likely unneeded
            foreach (var word in toBlacklist)
            {
                if (e.Message.RawText.ToLower().Contains(word.ToLower()))
                {
                    found = true;
                }
            }
            if (found)
            {
                await e.Message.Delete();
            }
        }
