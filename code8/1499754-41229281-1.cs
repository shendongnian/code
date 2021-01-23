    public static long addLong(long value, long adder) {
      unchecked { // we'll detect overflow manually
        if (value + adder < value && value + adder < adder) {
          Debug.Log("greater then max value");
          return long.MaxValue;
        }
        else if (value + adder > value && value + adder > adder) {
          Debug.Log("less then min value");
          return long.MinValue;
        }
        else {
          Debug.Log("within the [min..max] range");
          return value + adder;
        }
      }
    }
