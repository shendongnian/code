       int count =  int.Parse(Console.ReadLine());
        for(int k = 0; k < count; k++){
            string input = Console.ReadLine();
             Enumerable.Range(0, input.Length)
                .OrderBy(o => o % 2 != 0)
                .Select(o => {
                    if(o == 1)
                       Console.Write(" ");
                    Console.Write(input[o]);
                    return input[o];
                }).ToArray();
            Console.Write("\n");
        }
