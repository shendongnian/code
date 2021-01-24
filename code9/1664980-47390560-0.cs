       private static float FahrenheitToCelsius(float t) {
         return (t - 32.0f) / 5.0f * 9.0f ;
       }
       private staic float ObtainFarenheight() {
         while (true) {
           Console.WriteLine("Skriv in temperaturen i Fahrenheit: "); 
           float result = 0.0f;
           if (float.TryParse(Console.ReadLine(), out result))
             return result; 
           Console.WriteLine("Error. Only numbers acceptable.");
         } 
       }
       private static float AcceptableCelsius() {
         while (true) {
           float result = FahrenheitToCelsius(ObtainFarenheight());
           if (result > 77) 
             Console.WriteLine("This is too hot. Turn down the temperature.") 
           else if (result < 73) 
             Console.WriteLine("This is too cold. Turn up the temperature"); 
           else 
             return result;
         }
       } 
