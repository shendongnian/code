    var birthMonth = Console.ReadLine();
    int month;
    
    if(!ValidateMonth(birthMonth, out month) {
        // process invalid month or whatever
    }
    bool ValidateBirthMonth(string birthMonth, out int month) {
        var month = default(int);
    
        if(!int.TryParse(birthMonth, out month)) {
            Console.WriteLine("invalid month");
        
            return;
        }
    
        if (month >= 1 && month <= 12) {
            Console.WriteLine("... great!!!");
    
            return;
        }
    
        Console.WriteLine("invalid entry: month must be 1-12");
    }
