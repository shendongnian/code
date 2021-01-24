    var input = "asarrivalFDate=06/12/2017arrivalTDate=20/12/2017";
    var result = input.Split(
        new[]
            {
                "arrivalFDate=",
                "arrivalTDate="
            },
        StringSplitOptions.None);
    
    string agentName = result[0];
    string arrivalFDate = result[1];
    string arrivalTDate = result[2];
    
    Console.WriteLine(agentName);
    Console.WriteLine(arrivalFDate);
    Console.WriteLine(arrivalTDate);
