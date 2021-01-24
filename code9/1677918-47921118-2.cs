    string[] answer = new string[10];
    
    //HERE
    for (int i = 0; i < answer.Length; i++)
    {
        answer[i] = "0";
    }    
    
    int sum = 0;
    for (int i = 0; i < answer.Length; i++)
    {
        sum += Int32.Parse(answer[i]);
        if (answer[i] == "x")
        {
            Console.WriteLine(sum);
        }
        answer[i] = Console.ReadLine();
    }
    Console.Read();
