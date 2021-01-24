    Dictionary<int, string> dict = new Dictionary<int, string>();
    int key = -100; string value = "";
    foreach(IWebElement element in all)
    {
            foreach (var str in element.Text.Split(' '))
            {     
                int new_key;
                if (int.TryParse(str.Trim(), out new_key))
                {
                    if (value == "")
                        key = new_key;
                    else
                    {
                        dict[key] = value.Trim();
                        value = "";
                        key = new_key;
                    }
                }
                else
                {
                    value += str + " ";
                }
            }
            dict[key] = value.Trim();
    }
