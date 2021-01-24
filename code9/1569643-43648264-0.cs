    Console.Write("Enter Item Count: ");
    int number = int.Parse(Console.ReadLine());
    int[] myArrai1 = new int[number];
    for (int i = 0; i < number; i++) {
        Console.Write("Enter Number " + (i + 1) + ": ");
        myArrai1[i] = int.Parse(Console.ReadLine());
    }
    Console.WriteLine("Every other number entered: ");
    for (int j = 0; j < number; j = j + 2) {
        Console.WriteLine(myArrai1[j]);
    }
