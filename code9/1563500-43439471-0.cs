       class BitSet
       {
          private bool[] _bits;
          public BitSet(int length)
          {
            _bits = new bool[length];
          }
         public bool this[int index]
          {
              get
              {
                  return _bits[index];
              }
              set
              {
                  _bits[index] = value;
              }
          }
       } 
