    int MaxNumber = 100;
    // create a list of all even numbers
    List<int> even_list = Enumerable.Range(0, MaxNumber+1).Where(x => x % 2 == 0).ToList();
    // for the amount of numbers to be displayed in a line
    int numbers_in_single_line = 10
    for (int i = 1; i <= even_list.Count; i += numbers_in_single_line)
    {
        Console.WriteLine(String.Join(" ", even_list.Skip(i).Take(numbers_in_single_line )));
    }
