    interface TwoProperties {
      object GetProperty1();
      object GetProperty2();
    }
    class Model : TwoProperties {
      int intValue;
      stringStringValue;
      public override object GetProperty1() {
        return intValue;
      }
      public override object GetProperty2() {
        return stringValue;
      }
    }
