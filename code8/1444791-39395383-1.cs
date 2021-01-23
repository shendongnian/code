            var l1 = array1.Select(i=>i.ToString()).ToList();
            var l2 = array2.ToList();
            var l3 = array3.ToList();
            l1.Add("");
            l2.Add("");
            l3.Add("");
            // ----------------------------------
            foreach (var a in l1)
                foreach (var b in l2)
                   foreach (var c in l3)
             Console.WriteLine($"{a}{b}{c}");
            
