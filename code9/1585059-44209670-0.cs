    string s = "1[::]One[::]2[::]Two[::]3[::]Three";
            string[] splitted = s.Split(new string[] { "[::]" }, StringSplitOptions.None);
            Dictionary<int, string> dic = new Dictionary<int, string>();
            for (int i = 0; i < splitted.Length; i++)
            {
                if(i%2 == 0)
                {
                    dic[int.Parse(splitted[i])] = splitted[i + 1];
                    i++;
                }                
            }
