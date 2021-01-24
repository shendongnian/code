    for (var i = 0; i < input.Length; i++)
    {
        var c = input[i];
        if(char.IsUpper(c))
        {
            var charsToAdd = input.Skip(i).TakeWhile(char.IsUpper).ToArray();
            if(charsToAdd.Length > 1)
            {
                i += charsToAdd.Length - 1;
            }
            if(i > 0) list.Add(' ');
            list.Add(charsToAdd);
        }
        else 
        {
            list.Add(c);
        }
    }
