      enum Gender { female, male }
        struct Record
        {
            public string _Name;
            public int _Age;
            public Gender _Gender;
        }
        static void Main(string[] args)
        {
            //title 
            Console.Write("\t\t\t\t\tPatient Records\n");
            IList<Record> patients = GetRecords(5);
            SchedulePatients(patients);
        }
        static void SchedulePatients(IList<Record> patients)
        {
            Console.Write("a. Add\n d.Display\ns. Stats\nq. Quit");
            Console.Write("Your selection: ");
            string selection = Console.ReadLine();
            switch (selection)
            {
                case "a":
                    patients.Add(GetRecord());
                    SchedulePatients(patients);
                    break;
                case "d":
                    break;
                case "s":
                    Stats(patients);
                    break;
                case "q":
                    //CUtility.Pause();
                    break;
            }
        }
        static IList<Record> GetRecords(int amount)
        {
            IList<Record> patients = new List<Record>();
            for (int i = 0; i < amount; i++)
            {
                patients.Add(GetRecord());
            }
            return patients;
        }
        static Record GetRecord()
        {
            Record patient = new Record();
            Console.Write("Enter your age: ");
            int.TryParse(Console.ReadLine(), out patient._Age);
            Console.Write("Enter your name: ");
            patient._Name = Console.ReadLine();
            Console.Write("Enter your gender (female or male): ");
            Enum.TryParse(Console.ReadLine(), out patient._Gender);
            return patient;
        }
        static void Stats(IList<Record> patients)
        {
            foreach (var patient in patients)
            {
                Console.WriteLine(string.Concat("Name: ", patient._Name, " Age: ", patient._Age, " Gender: ", patient._Gender));
            }
            Console.ReadLine();
        }
    }
