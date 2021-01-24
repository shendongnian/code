    public static bool numValidation(string strNum)
        {
            if (!string.IsNullOrWhiteSpace(strNum))
            {
                int temp;
                if (int.TryParse(strNum, out temp))
                {
                    Console.WriteLine("Phone Number is a valid input: " + temp);
                    return true;
                }
                else
                { Console.WriteLine(temp + "Is not Valid input!!"); }
            }
            return false;
        }
