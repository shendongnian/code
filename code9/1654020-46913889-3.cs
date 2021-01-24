    // Dictionary<int, string>:
    //   Key   - int    - index
    //   Value - string - eMail
    public Dictionary<int, string> GetMail(int id) {
      var result = db.table1
        .AsEnumerable()                              // Do not materialize prematurely
        .Where(row => row.idTable == id)               
        .SelectMany(row => row.email.Split(','))     // flatten sequence
        .Select((email, index) => new {              // key and value specifictaion
           key = index,
           email = email })  
        .ToDictionary(pair => pair.key,              // final dictionary 
                      pair => pair.email); 
    }
