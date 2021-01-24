    public class ParamGroup {
      ... 
      public override bool Equals(Object o) {
        ParamGroup other = o as ParamGroup;
        if (null == other)
          return false;
        return dbTable == other.dbTable &&
               dbIndexField == other.dbIndexField &&
               dbIndex == other.dbIndex;
      }
      public override int GetHashCode() {
        return (dbIndexField == null ? 0 : dbIndexField.GetHashCode()) ^
                dbIndex ^
               (dbTable == null ? 0 : dbTable.GetHashCode());
      }
    }
