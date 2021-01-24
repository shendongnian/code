    var list = new List<string>();
                    list.Add("something1");
                    list.Add("domething1");
                    list.Add("romething1");
                    list.Add("yomething1");
                    string input = "thing";
                    char[] inputchars = input.ToCharArray();
                    foreach (string word in list) //list = {"something1","something2","somefoo","bar"}
                    {
                        char[] characters = word.ToCharArray();
    
                        if (inputchars[0] == characters[0])
                            list.Remove(word);
                    }
                    return list;
