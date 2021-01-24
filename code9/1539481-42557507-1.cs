        public int this[int index] 
        {
            switch (index)
            {
                case 1: return this.WK_1
                case 2: return this.WK_2
            }
            // Or: return (int) this.GetType().GetProperty("WK_" + index).GetValue(c, null);
        }
