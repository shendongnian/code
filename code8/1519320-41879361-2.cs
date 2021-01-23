    class MovierankData:IComparable
    {
        public int CompareTo(MovierankData obj)
        {
            if(this.Value > obj.Value)
            {
                return 1;
            }
            else if(this.Value < obj.Value)
            {
                return -1;
            }
            else
            {
                return this.Name.CompareTo(obj.Name);
            }
        }
    }
