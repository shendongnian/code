    int[] theArray = new int[] { 43, 12, 93, 40, 1, 25, 4, 63, 92, 86, 46, 48, 18, 75, 82, 97, 89, 66, 49, 7, 62, 24, 47, 67, 88, 2, 74, 99, 23, 80 }; //array
    int[] partialSums = new int[3];
    
    // Parallely start three threads that sum parts of the original array in multiples of 10
    Parallel.For(0, 3, (counter) =>
    {
        int sum = 0;
        for (int i = counter * 10; i < (counter + 1) * 10; i++)
            sum += theArray[i];
        partialSums[counter] = sum;
    });
    // Print the result
    foreach (var sum in partialSums)
        Console.WriteLine(sum);    
