        public bool IsSomethingTrue2(string aString) {
          if (null == aString)
            return false; 
          MyType value;
          if (!aDictionary.TryGetValue(aString, out value))
            return false;
          return (null == value) 
            ? false 
            : null == value.Field 
               ? false
               : value.Field.SubField == "someValue"; 
        }
