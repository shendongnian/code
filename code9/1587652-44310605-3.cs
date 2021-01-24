            IEnumerable<DayOfWeek> enumRange = DayOfWeek.Sunday.RangeToInc(DayOfWeek.Wednesday);
            foreach (var item in enumRange)
            {
                Console.Write(item + " ");
                //
            }
            Console.WriteLine();
            int a = 4;
            var intRange = a.RangeToInc(10);
            foreach (var item in intRange)
            {
                Console.Write(item + " ");
            }
            //output 
            // Sunday Monday Tuesday Wednesday
            // 4 5 6 7 8 9 10
