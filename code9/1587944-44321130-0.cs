    var possibleNum = data[i, 1].ToString();
    var num = 0.0m;
    if (decimal.TryParse(possibleNum, out num)
    {
        _vm.Factorial = num; // succeeded. It is a number
    }
    else 
    {
        // possibleNum is not a number. What do you want to do?
    }
