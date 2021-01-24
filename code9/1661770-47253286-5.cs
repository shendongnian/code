      string sentence = "This 15 i2s the45best str7ng 1n th3 w0r17ld";
      
      int[] primes = ExtractIntValues(sentence)
        .Where(number => IsPrime(number))
        .ToArray(); 
      Console.WriteLine($"string '{sentence}' contains {primes.Length} prime numbers: {string.Join(", ", primes)}"); 
