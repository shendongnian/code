            dynamic userList = JsonConvert.DeserializeObject(File.ReadAllText("file.js"));
            foreach (var user in userList.clients)
            {
                ///MessageBox.Show(user.id);
                Console.WriteLine(user.id);
            }
