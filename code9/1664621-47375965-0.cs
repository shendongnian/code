    int GetIntOrZero(string value) {
      Int32.TryParse(value, out int res);
      return res;
    }
    var myObj = new MyType(args);
    var count = GetIntOrZero(myObj);
