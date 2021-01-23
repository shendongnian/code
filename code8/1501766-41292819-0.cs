    int[] seq= new int[10];
    int n = 0;
    List<int> seq2= new List<int>;
    
    for (int i = 0; i < seq.Length; i++)
    {
        Console.WriteLine("Add number ");
        seq[i] = int.Parse(Console.ReadLine());
        if (seq[i]%2==0)
        {
            seq2.Add(seq[i]);
            n++;
        }
    }
    for (int i = 0; i < seq2.Length - 1; i++)
    {
        Console.WriteLine(seq2[i]);
    }
