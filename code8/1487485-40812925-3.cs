            Dictionary<string[], string> messages = new Dictionary<string[], string>();
            messages.Add(new string[] { "greeting", "hello", "hei", "hi" }, "Hello!");
            messages.Add(new string[] { "greeting", "bye", "buh-bye", "sayonara" }, "Bye!");
            
            // add tags
            string[] tags = new string[2];
            tags[0] = "greeting";
            tags[1] = "buh-bye";
            List<string> lista = new List<string>(); // list to store the results
            // loop true the keys from every row
            // loop true the keys of the current row
            // check if tags contains key 
            // ckeck if lista already contains the key that was recognized(no duplicates in list)
            foreach (var value in messages.Keys)
                foreach (var value11 in value)
                    if (tags.Contains(value11))
                        if(!lista.Contains(messages[value]))
                            lista.Add(messages[value]);
           
