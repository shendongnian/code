                dynamic d = JArray.Parse(stringy);
                foreach(var ob in d)
                {
                    if(ob.ParentID != ob.Id)
                    {
                        string debug = "oh snapple, it's a child object";
                    }
                }
