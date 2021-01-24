        Int32 value = 0;
        if (Int32.TryParse(String.Join(String.Empty, "۱۱۷".Select(Char.GetNumericValue)), out value))
        {
            Console.WriteLine(value);
            //....
        }
