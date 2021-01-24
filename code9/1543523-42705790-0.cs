    while (!InArray(Console.ReadLine()));
    // ...
    public static bool InArray(string s){
        foreach(var item in array) {
            if (item.Equals(s)) return false;
        }
        return true;
    }
