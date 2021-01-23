    for (int i = 0; i < input.length; i += 3) {
        if (input[i + 2]) {
            Console.WriteLine(input[i] + ' ' + input[i + 1] + ' ' + input[i + 2]);
        } else if (input [i + 1]) {
            Console.WriteLine(input[i] + ' ' + input[i + 1]);
        } else {
            Console.WriteLine(input[i]);
        }
    }
