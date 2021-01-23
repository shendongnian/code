    public static long addLong(long value, long adder) {
      if (value + adder < value && value + adder < adder) {
        Debug.Log("greater then max value");
        return value = long.MaxValue;
      }
      else if (value + adder > value && value + adder > adder) {
        Debug.Log("less then min value");
        return value = long.MinValue;
      }
      else {
        Debug.Log("within the [min..max] range");
        return value + adder;
      }
    }
