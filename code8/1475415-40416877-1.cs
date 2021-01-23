      public int weight
        {
         get { return _weight; }
         set
         {
          _weight = value;
          if (_weight > 40)
              _charge = _weight * 2;
          else
             _charge = _weight * 1;
         }
      }
        
      private int _charge;
      public int Charge
      {
        get { return _charge; }
        set { _charge = value; }
      }
