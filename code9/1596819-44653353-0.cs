    (i % 3 == 0)
    ? (i % 5 == 0)
      ? Console.WriteLine(i + " FizzBuzz")
      : Console.WriteLine(i + " Fizz");
    : (i % 5 == 0)
      ? Console.WriteLine(i + " Buzz");
      : Console.WriteLine(i);
