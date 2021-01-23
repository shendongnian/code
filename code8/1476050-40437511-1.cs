        private void button9_Click()
        {
            string messages = "I am failing at coding,The Slow Brown Sheep jumped over the fox,Message3,Message4,Message5";
            axSkype1.CurrentUserProfile.MoodText =GetRandomMessage(messages);
        }
        string GetRandomMessage(string messages)
        {
            string[] messagesArray = messages.Split(new Char[] { ',' });
            return messagesArray[new Random().Next(0, messagesArray.Length)].ToString();
        }
