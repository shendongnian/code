    class Program
        {
            static void Main(string[] args)
            {
                if(args.count() == 0)
                {
                    Sendmail();
                    Downloadfile();
                    ProcessFile();
                    ExportFIle();
                }
                foreach(string s in args)
                {
                    switch(s)
                    case "SendMail":{Sendmail();break;}
                    etc.
                }
            }
        }
