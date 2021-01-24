                List<B> b = new List<B>()
                {
                    new B {Sample = "Sample" }
                };
                IList<A> a = new List<A>(b);
                var typeList = a.GroupBy(x => x.GetType()).Select(type => type.Key).ToList(); 
                // Getting different types and grouping them
                if (typeList.Count == 1)
                {
                    if (typeList[0] == typeof(B))
                    {
                        //some code
                    }
                    else if (typeList[0] == typeof(C))
                    {
                        //Some code
                    }
                }
                else
                {
                    //There are multiple different types in the list
                }
