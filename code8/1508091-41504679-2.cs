    private void button1_Click(object sender, EventArgs e)
        {
            if(File.Exists("json1.json"))
            {
                string inputJSON = File.ReadAllText("json1.json");
                if(!string.IsNullOrWhiteSpace(inputJSON))
                {
                    var userList = JsonConvert.DeserializeObject<List<User>>(inputJSON);
                }
            }
            
        }
