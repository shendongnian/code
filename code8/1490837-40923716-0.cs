    var variables = input.Split(new[] { "(", "||", "&&", ")", " " }, 
        StringSplitOptions.RemoveEmptyEntries);
    var interpreter = new Interpreter();
    foreach (var variable in variables)
    {
        interpreter.SetVariable(variable, text.Contains(variable));
    }
    var result = (bool)interpreter.Parse(input).Invoke();
