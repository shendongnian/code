    int num1;
    int num2;
    bool isNum1Valid = int.TryParse(Number1.Text, out num1);
    bool isNum2Valid = int.TryParse(Number2.Text, out num2);
    if (!isNum1Valid)
    {
        // num1 is invalid. Throw an error message or something
    }
    if (!isNum2Valid)
    {
        // num2 is invalid. Throw an error message or something
    }
