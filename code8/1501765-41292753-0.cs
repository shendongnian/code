    int[] seq= new int[10];
    var seq2= new List<int>();
    
    for (int i = 0; i < seq.Length; i++)
    {
        Console.WriteLine("Add number ");
        seq[i] = int.Parse(Console.ReadLine());
        if (seq[i]%2==0)
        {
            seq2.Add(seq[i]);
        }
    }
    for (int i = 0; i < seq2.Count(); i++)
    {
        Console.WriteLine(seq2[i]);
    }
