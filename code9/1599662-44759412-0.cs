    case 1:
       Console.WriteLine("Enter an amount in Stone");
       double UserInput = double.Parse(Console.ReadLine());
       double result = StoneToPounds(UserInput);
       Console.WriteLine(result.ToString());
       break;
