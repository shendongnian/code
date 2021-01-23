           var loggBoken = new List<string[]>();
            string[] post = new string[2];
            post[0] = "a";
            post[1] = "b";
            loggBoken.Add(post); //don't need to specifie ToArray()
            // use join to create total string of every item in current array
            // split by new line
            foreach (string[] item in loggBoken)
            {                
                    MessageBox.Show(String.Join("\n", item));                
            }
