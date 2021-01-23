        using System.Collections.Generic; // for List<cars>
        ... ... ...
        public static void ReadMultiline()
        {
            // http://stackoverflow.com/questions/39945520/reading-data-from-a-text-file-into-a-struct-with-different-data-types-c-sharp
            var DLL = new List<cars>();
            string line;
            StreamReader file = new StreamReader(@"cars.txt");
            var item = new cars();
            int idx = 0;
            while ((line = file.ReadLine()) != null)
            {
                idx++;
                switch ( idx ) {
                    case 1: item.Make = line; break;
                    case 2: item.Model = line; break;
                    case 3: item.Year = Double.Parse(line); break;
                    case 4: item.Mileage = Double.Parse(line); break;
                    case 5: item.Price = Double.Parse(line); break;
                }
                if (line == "" && idx > 0 )
                {
                    DLL.Add(item);
                    idx = 0;
                    item = new cars();
                }
                if (line == "") continue;
            }
            // pick up the last one if not saved
            if (idx > 0 )
                DLL.Add(item);
            foreach( var x in DLL )
            {
                Console.WriteLine( String.Format( "Make={0} Model={1} Year={2} Mileage={3} Price={4}", x.Make, x.Model, x.Year, x.Mileage, x.Price) );
            }
        }
