        foreach (string lineA in mylistA)
        {     
           foreach (string lineB in mylistB)
           {                     
                if (lineB.ToUpper() == lineA.ToUpper())
                {
                      ResultsToDocument();
                }
           }
        }
