    static void GetRecords(Record[] patient_rec)
    {
        for (int i = 0; i < patient_rec.Length; i++)
        {
            Console.Write("Enter your age: ");
            int.TryParse(Console.ReadLine(), out patient_rec[i]._Age);
            Console.Write("Enter your name: ");
            patient_rec[i]._Name = Console.ReadLine();
            Console.Write("Enter your gender (female or male): ");
            Gender.TryParse(Console.ReadLine(), out patient_rec[i]._Gender);
            Console.Write("Enter another (Y/N)? ");
            var s = Console.ReadLine();
            if (s.ToUpper() != "Y") return;
       }
       Console.WriteLine("You've entered the maximum number of records.");
    }
