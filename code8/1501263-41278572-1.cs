    IEnumerable tempList = o as IEnumerable;
            if (tempList != null)
            {
                IEnumerable<DumyClass> items = tempList.OfType<DumyClass>();
                if(items.Count() != 0)
                {
                    //Then handle the list of the specific type as needed.
                }            
            }
