    (bool IsDivisibleBy3, bool IsDivisibleBy5) match = (i % 3 == 0, i % 5 == 0);
    switch (match)
    {
        case var _ when match.IsDivisibleBy3 && match.IsDivisibleBy5:
            // FizzBuzz
            break;
        case var _ when match.IsDivisibleBy3:
            // Fizz
            break;
        case var _ when match.IsDivisibleBy5:
            // Buzz
            break;
        default:
            //
            break;
    }
