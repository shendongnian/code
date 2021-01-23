            if (DateTime.TryParse(answerString, out dDate))
            {
                DateTime enteredDate = DateTime.Parse(answerString);
                var Date = enteredDate.ToString("dd/MM/yyyy");
                answerString = Date;
               Console.WriteLine(answerString);
            }
        else{
        //operation
            }
