    public class BoolArray
    {
        List<List<bool>> storedTab;
    
        public BoolArray(int newRowSize = 1, int newColumnSize = 1, bool defaultValue = false)
        {
            storedTab = new List<List<bool>>();
            reSize(newRowSize, newColumnSize, defaultValue);
        }
    
        //Grows by 5 as default
        public void reSize(int newRowSize = 5, int newColumnSize = 5, bool defaultValue = false)
        {
            //Fixes problem when newRowSize is 0
            if (newRowSize <= 0)
            {
                //Add/Increment Column to every row
                int allRow = storedTab.Count;
    
                for (int i = 0; i < allRow; i++)
                {
    
                    for (int j = 0; j < newColumnSize; j++)
                    {
                        storedTab[i].Add(defaultValue);
                    }
                }
            }
            else
            {
                for (int i = 0; i < newRowSize; i++)
                {
                    //Resize Row
                    storedTab.Add(new List<bool>());
    
    
                    //Resize Column
                    for (int j = 0; j < newColumnSize; j++)
                    {
                        storedTab[i].Add(defaultValue);
                    }
                }
            }
        }
    
        public void setValue(int row, int column, bool value)
        {
            storedTab[row][column] = value;
        }
    
        public bool getValue(int row, int column)
        {
            return storedTab[row][column];
        }
    
        public int rowSize
        {
            get { return storedTab.Count; }
        }
    
        public int columSize
        {
            get
            {
                return storedTab[0].Count;
            }
        }
    
        public void clear()
        {
            for (int i = 0; i < rowSize; i++)
            {
                for (int j = 0; j < columSize; j++)
                {
                    storedTab[j].Clear();
                }
            }
            storedTab.Clear();
        }
    }
