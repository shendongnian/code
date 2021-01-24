    while (counter <= int.Parse(userinput))
        {
            Console.Write("Please enter the weight of package {0}: ", counter);
            userinput2 = Console.ReadLine();
            result = (double.Parse(userinput2) * 2.35) + result;
            counter++;
        }
