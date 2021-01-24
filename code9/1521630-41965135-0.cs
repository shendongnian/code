            Console.Write("CSV full path File: ");
            string csvFile = Console.ReadLine();
            while (!ValidateCsv(csvFile))
            {
                Console.Write("Retype full path CSV File: ");
                csvFile = Console.ReadLine();
            }
            private static bool ValidateCsv(string csvFile)
            {
               bool isPathTrue = false;
               FileInfo csvFileInfo = new FileInfo(csvFile);
               isPathTrue = csvFileInfo.Exists;
               return isPathTrue;
            }
