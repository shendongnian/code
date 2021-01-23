    public class DamageTypeArray
    {
        private readonly int[] _dTypeArray = new int[12];
        
        public int this[int key]
        {
            get
            {
                return _dTypeArray[key]
            }
            set
            {
                _dTypeArray[key] = value;
            }
        }
    }
