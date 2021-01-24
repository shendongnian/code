    private static void SplitChars()
        {
            string animals = "cat98dog75";
            Dictionary<string, string> dMyobject = new Dictionary<string, string>();
            string sType = "",sCount = "";
            bool bLastOneWasNum = false;
            foreach (var item in animals.ToCharArray())
            {
                
                if (char.IsLetter(item))
                {
                    if (bLastOneWasNum)
                    {
                        dMyobject.Add(sType, sCount);
                        sType = ""; sCount = "";
                        bLastOneWasNum = false;
                    }
                    sType = sType + item;
                }
                else if (char.IsNumber(item))
                {
                    bLastOneWasNum = true;
                    sCount = sCount + item;
                }
            }
            dMyobject.Add(sType, sCount);
            foreach (var item in dMyobject)
            {
                Console.WriteLine(item.Key + "- " + item.Value);
            }
        }
