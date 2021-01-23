        using System;
    using System.Collections.Generic;
    
    namespace _41167195
    {
        class Program
        {
            static void Main(string[] args)
            {
                string pathToDBINfoFile = @"M:\StackOverflowQuestionsAndAnswers\41167195\41167195\sample\DBInfo.txt";//the path to the file holding the info
                Dictionary<string, string> connStringValues = DoIt(pathToDBINfoFile);//Get the values from the file using a method that returns a dictionary
                string serverValue = connStringValues["SERVER"];//just for you to see what the results are
                string dbValue = connStringValues["DATABASE"];//just for you to see what the results are
    
                //Now you can adjust the line below using the stuff you got from above.
                //string constr = ConfigurationManager.ConnectionStrings["DRIVER={SQL Server}; SERVER=SERVER DATABASE=DB UID=;PWD=;LANGUAGE=Deutsch;Trusted_Connection=YES"].ConnectionString;
            }
    
    
            private static Dictionary<string, string> DoIt(string incomingDBInfoPath)
            {
                Dictionary<string, string> retVal = new Dictionary<string, string>();//initialize a dictionary, this will be our return value
    
                using (System.IO.StreamReader sr = new System.IO.StreamReader(incomingDBInfoPath))
                {
                    string currentLine = string.Empty;
                    bool areWeThereYet = false;
                    bool isItDoneYet = false;
                    while ((currentLine = sr.ReadLine()) != null)//while there is something to read
                    {
                        if (currentLine.ToLower() == "<anfang>")
                        {
                            areWeThereYet = true;
                            continue;//force the while to go into the next iteration
                        }
                        else if (currentLine.ToLower() == "<ende>")
                        {
                            isItDoneYet = true;
                        }
    
                        if (areWeThereYet && !isItDoneYet)
                        {
                            string[] bleh = currentLine.Split(new string[] { "==" }, StringSplitOptions.RemoveEmptyEntries);
                            retVal.Add(bleh[0], bleh[1]);//add the value to the dictionary
                        }
                        else if (isItDoneYet)
                        {
                            break;//we are done, get out of here
                        }
                        else
                        {
                            continue;//we don't need this line
                        }
                    }
                }
    
                return retVal;
            }
        }
    }
