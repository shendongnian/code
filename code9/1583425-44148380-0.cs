    public class IntDoubler
    {
        List<int> ints;
    
        public void DoubleUp()
        {
            //list to store elements to be added
            List<int> inserts = new List<int>();
            
            //foreach int, add one twice as large
            foreach (var insert in inserts)
            {
                inserts.Add(insert*2);
            }
            //attach the new list to the end of the old one
            inserts.AddRange(inserts);
        }
    }
