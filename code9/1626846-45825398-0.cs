    namespace Testconsole
    {
        class Program
        {
            static void Main(string[] args)
            {
              if (args[0] = "8")
                ScheduleFor8();
              if (args[0] = "12")
                ScheduleFor12();
    
            }
            static void ScheduleFor8() {
                Sendmail();
                Downloadfile();
                ProcessFile();
                ExportFIle();
            }
            static void ScheduleFor12() {
                ProcessFile();
                ExportFIle();
            }
        }
    }
