        class Box
        {
            public string partNumber;
            public DateTime date;
            public int quantity;
            public int position;
            public int orderColumn;
            public int boxnum;
        
            public Box(string partNumber, int quantity, int position, DateTime date, int orderColumn, int boxnum)
            {
                this.partNumber = partNumber;
                this.quantity = quantity;
                this.position = position;
                this.fecha = date;
                this.orderColumn = orderColumn;
                this.boxnum = boxnum;
            }
        }
        
            class BoxCollection : List<Box>
        {
        
            public Color GetBoxColor(Box box)
            {
            return GetBoxColor(IndexOf(box));
        }
    
        public Color GetBoxColor(int index)
        {
            return GetBoxFifo(index) == 1 ? Color.Red : Color.Green;
        }
    
        public int GetBoxFifo(Box box)
        {
            return GetBoxFifo(IndexOf(box));
        }
    
        public int GetBoxFifo(int index)
        {
            return this.Where(c => c.partNumber == this[index].partNumber)
                .OrderBy(c=> c.date).ToList().IndexOf(this[index]) + 1;
        }
    
    }
