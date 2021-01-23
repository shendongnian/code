            List <string> nonEmptyDirectory = System.IO.Directory.GetDirectories(path, "*",SearchOption.AllDirectories).Where(x => Directory.GetFiles(x).Length != 0).ToList();
            int nonEmptyDirectoryCounter = nonEmptyDirectory.Count;
            Console.WriteLine("Directory non vuote = {0}", nonEmptyDirectoryCounter);
            foreach (string nonEmptyDirectoryValue in nonEmptyDirectory)
            {
                string fileFullPath = nonEmptyDirectoryValue;
                var directory = new DirectoryInfo(nonEmptyDirectoryValue);
                var orderedFiles = directory.EnumerateFiles("*.pdf").OrderByDescending(f => f.CreationTime);
                var newestTwo = orderedFiles.Take(2).ToArray();
                var fullNames = newestTwo.Select(File => File.FullName).ToArray();
                Console.WriteLine(fullNames[0]);
                Console.WriteLine(fullNames[1]);
                
                PdfReader pdfReader1 = new PdfReader(fullNames[0]);
                int numberOfPagesFile1 = pdfReader1.NumberOfPages;
                PdfReader pdfReader2 = new PdfReader(fullNames[1]);
                int numberOfPagesFile2 = pdfReader2.NumberOfPages;
                totalItalianPages = totalItalianPages + numberOfPagesFile1;
                totalGermanPages = totalGermanPages + numberOfPagesFile2;
                Console.WriteLine("Numero pagine del documento1 pdf = {0}", numberOfPagesFile1);
                Console.WriteLine("Numero pagine del documento2 pdf = {0}", numberOfPagesFile2);
                Console.WriteLine("Numero totale pagine documento IT = {0}", totalItalianPages);
                Console.WriteLine("Numero totale pagine documento DE = {0}", totalGermanPages);
                
                Console.ReadKey();
            }
