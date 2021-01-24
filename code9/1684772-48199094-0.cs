    foreach (string s in tokens)
    {
        if (double.TryParse(s, out oneNum))
        {
            nums.Add(oneNum);
        }
        else
        {
            Console.WriteLine("You have inputed invalid number, please try again!");   
            break;
        }
