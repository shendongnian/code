    var inp = Console.ReadLine();
    var split = inp.Split(' ');
    if (split.Length == 2 
        && int.TryParse(split[0], out var a)  // assumes C#7 feature of inline var declaration 
        && int.TryParse(split[1], out var b)  // for out parameters, else declare ints earlyer
    )
    {
        // do something with a and b which are ints....
    }
    else
    {
        // either not enough or too many or non-int input by the usere. handle it.
    }
