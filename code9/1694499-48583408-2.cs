    public void WriteState(string state)
        {
            using (StreamWriter writer = new StreamWriter("Your Path to your File"))
            {
                writer.WriteLine(state);
            }
        }
        public string GetState()
        {
            string saveText = "";
            using (StreamReader reader = new StreamReader("Your Path to your File"))
            {
                string text;
                if ((text = reader.ReadLine()) != null)
                {
                    saveText += text;
                }
            }
            return saveText;
        }
