    string outputTime = string.Empty; 
    string timeFormat = inputTime.Substring(inputTime.Length - 2); 
    switch (timeFormat)  
            {  
                case ("AM"):  
                    outputTime = inputTime.Replace("AM", "");  
                    break;  
                case ("PM"):  
                    int hours = 0;  
                    int.TryParse(inputTime.Replace("PM", ""), out hours);  
                    outputTime = (hours + 12).ToString();  
                    break;  
            }  
    DateTime newDateTime = date.Add(TimeSpan.Parse(outputTime));
