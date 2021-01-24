    int enteredValue;
    if(int.TryParse(System.Console.ReadLine(), out enteredValue); 
    {
        //Check if enteredValue has been set to your needs !
        //Store your converted Value
        double convertedValue = TemperatureConverter.CelsiusToFahrenheit(enteredValue); // I assume double here ..
        //Display the result on your console:
        System.Console.WriteLine($"{enteredValue} Celsius is {convertedValue} Fahrenheit");
    }
    else { /*Handle wrong input here*/ }
