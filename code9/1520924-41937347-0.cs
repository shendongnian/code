    // assume the input is 1337
    public string tostr(int n) {
        //line below is creating a placeholder for the result string
        string s = "";
        // below line we can split into 3 lines to explain in more detail:
        foreach (char c in n-- + "") {
        // first n is decremented by one :
        // n--; // input value of n is now 1336
        // then value of n is concatenated with an empty string :
        // string numberString = n + ""; // numberString is "1336";
        // which then is iterated though :
        // foreach(char c in numberString) { // meaning foreach(char c in "1336")
        foreach (char c in n-- + "") {  //<------HOW IS THIS POSSIBLE ?
            s = s + c; // here each sign of the numberString is added into the placeholder
        }
        return s; // return filled placeholder
    }
