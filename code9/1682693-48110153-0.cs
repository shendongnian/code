     IList<string> text = new List<string>() { "pid456","Pid 123" }; //Place your pid here
     var endTag = "xyz"; //end tag of tag file or EOF
                IList<string> log = File.ReadAllLines(file).ToList<string>();
                for (int i = log.Count - 1; i > 0; i--)
                {
                    if (text.Any(t => log[i].Contains(t)))
                    {
                       var PID= log[i];
                    }
                    if (log[i].Contains(endTag))
                    {
                        break;
                    }
                 }
