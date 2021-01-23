        if (DateTime.TryParseExact(answerString,"date-format",CultureInfo.InvariantCulture,DateTimeStyles.None,out dDate))
        {
                        //var date = DateTime.Parse(answerString); no need to parse again parsed date is in dDate
                        // var indianTime = CovertToDefaultTimeZone(date);
                        answerString = dDate.ToString("dd/MM/yyyy");
                        Console.WriteLine(answerString);
                        Console.ReadLine();
        }
