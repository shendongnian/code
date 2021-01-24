    string[] inputs = inputBox.Text.Split('+');
    if (inputs.Length == 2) {
        bool pass = int.TryParse(inputs[0], out number1);
        pass = int.TryParse(inputs[1], out number2);
    }
