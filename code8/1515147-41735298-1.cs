    for (int i = 0; i < input.Length; i += 3) {
      if (i + 2 >= input.length) {
          Console.WriteLine(input[i] + ' ' + input[i + 1] + ' ' + input[i + 2]);
      } else if (input[i + 1] >= input.length) {
          Console.WriteLine(input[i] + ' ' + input[i + 1]);
      } else {
          Console.WriteLine(input[i]);
      }
    }
