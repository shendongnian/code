    string userInput = Console.ReadLine();
    int code = SomehowGenerateRandomCode();
    string codeString = code.ToString();
    // Let's assume that both numbers have 3 digits.
    for (int i = 0; i < 3; i++) {
        if(userInput[i] == codeString[i]) {
            // digits are equal
        } else {
            // digits are different
        }
    }
