    string quotesLogic(string collaboration)
            {
                StringBuilder after = new StringBuilder(collaboration);
    
                if (after.ToString().StartsWith("\"") && after.ToString().EndsWith("\""))//removes 1st and last quotes as those are system generated
                {
                    after.Remove(0, 1);
                    after.Remove(after.Length - 1, 1);
                    int count = after.Length - 1;
                    //FACT: if you try to add DoubleQuote in a cell in excel. It'll save that quote as 2 times DoubleQuote(Like "")  which means first DoubleQuote is to give instruction to CPU that the next DoubleQuote  is not system generated.
                    while (count > 0)//This loop find twice insertion of 2 DoubleQuotes and neutralise them to One DoubleQuote. 
                    {
                        if (after[count] == '"' && after[count - 1] == '"')
                        {
                            after.Remove(count, 1);
                        }
                        count--;
                    }
                }
    
                return after.ToString();
            }
