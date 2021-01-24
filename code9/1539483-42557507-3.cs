        public double this[int index] 
        {
            switch (index)
            {
                case 1: return this.WK_001
                case 2: return this.WK_002
            }
            // Or: return (double) this.GetType().GetProperty($"WK_{index:D3}").GetValue(c, null);
        }
