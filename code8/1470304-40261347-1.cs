      List<int[]> inputs = new List<int[]>();
      string[] headers = { "First equation: ", "Second equation: ", "Third equation: " };
      string[] prompts = { "Enter x: ", "Enter y: ", "Enter z: " };
      for (int i = 0; i < 3; i++)
      {
        int[] input = new int[3];
        Console.WriteLine(headers[i]);
        for (int j = 0; j < 3; j++)
        {
          Console.Write(prompts[j]);
          input[j] = int.Parse(Console.ReadLine());
        }
        inputs.Add(input);
        Console.WriteLine();
      }
