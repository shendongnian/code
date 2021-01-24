    class Program 
    { 
        static void Main() 
        { 
           string number = "100.51yutr"; 
           int Result_of_Conversion = 0;
           bool is_Conversion_Successful = int.TryParse(number, out Result_of_Conversion);
            var result = is_Conversion_Successful ? Result_of_Conversion.ToString() : "Check";
            Console.WriteLine(result);
        }
    }
