        private class ObjectStreamComp : IComparer
        {
            public int Compare(Object x, Object y )  
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                using (MemoryStream mx = new MemoryStream())
                using (MemoryStream my = new MemoryStream())
                {
                    binaryFormatter.Serialize(mx, x);
                    binaryFormatter.Serialize(my, y);
                    mx.Position = 0;
                    my.Position = 0;
                    return (new StreamReader(mx)).ReadToEnd().CompareTo((new StreamReader(my)).ReadToEnd());
                }   
            }
        }
