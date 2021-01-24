                string s = "1/09/2017 12:00:00 AM";
                string format = "d/MM/yyyy hh:mm:ss tt";
                DateTime parsedDateTime = DateTime.ParseExact(s, format, null);
                string output = parsedDateTime.ToString("d/MM/yy");
                string ss = output.Replace("-","/");
                Console.Write(ss); //output is 1/09/17
