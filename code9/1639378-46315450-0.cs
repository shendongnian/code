            //Here is just an example of list of array 
            List<object> obj = new List<object>();
            obj.Add(5);
            obj.Add(4);
            obj.Add("we");
            obj.Add(5);
            foreach (var item in obj)
            {
                int count = obj.Count(a => a.ToString() == item.ToString());
                //for finding the dublicate occurence
                if (count > 1)
                {
                    //for removing that dublicated occurence.
                    int index = obj.FindIndex(m => m.ToString() == item.ToString());
                    obj.RemoveAt(index); 
                }
            }
