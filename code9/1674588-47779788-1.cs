    char[] delimiters = { '+', '-', '\\', '*' };
    string[] inputs = inputBox.Text.Split(delimiters);
    if (inputs.Length == 2) {
        bool pass = double.TryParse(inputs[0], out number1);
        pass = double.TryParse(inputs[1], out number2);
    }
