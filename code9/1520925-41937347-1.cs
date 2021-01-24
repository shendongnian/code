    // assume the input is 1337
    public string tostr(int n) {
        //line below is creating a placeholder for the result string
        string s = "";
        // below line we can split into 2 lines to explain in more detail:
        foreach (char c in n-- + "") {
        // then value of n is concatenated with an empty string :
        // string numberString = n-- + ""; // numberString is "1337";
        // and after this line value of n will be 1336
        // which then is iterated though :
        // foreach(char c in numberString) { // meaning foreach(char c in "1337")
        foreach (char c in n-- + "") {  //<------HOW IS THIS POSSIBLE ?
            s = s + c; // here each sign of the numberString is added into the placeholder
        }
        return s; // return filled placeholder
    }
