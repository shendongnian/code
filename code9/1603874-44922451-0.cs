    var list = new List<string> {"Allan", "Michael", "Jhon", "Smith", "George", "Jhon", "George", "George"};
            Dictionary<string, int> dictionary = new Dictionary<string,int>();
            var newList = new List<string>();
            for(int i=0; i<list.Count();i++){
                if(!dictionary.ContainsKey(list[i])){
                    dictionary.Add(list[i], 1);
                    newList.Add(list[i]);
                }
                else{
                    dictionary[list[i]] += 1;
                    newList.Add(list[i] + dictionary[list[i]]);
                }
            }
            for(int i=0; i<newList.Count(); i++){
                Console.WriteLine(newList[i]);
            }
