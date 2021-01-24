    string[] answer = new string[10];
    for (int i = 0; i < answer.Length; i++)
    {
        answer[i] = "0";
    }
    int sum = 0;
    
    for (int i = 0; i < answer.Length; i++)
    {
        answer[i] = Console.ReadLine();
        if (answer[i] == "x")
        {
            break;
        }
        sum += Int32.Parse(answer[i]);
    }
    Console.WriteLine(sum);
    Console.Read();
