    string test = "-123";
    string result;
    foreach(Char i in test) {
        if (Char.IsNumber(i)) {
            result += i;
        }
    }
    int value = int.Parse(result);
