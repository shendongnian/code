    using System;
    using System.Data;
    using System.Linq;
    
    namespace SO
    {
        public class ComboBox { public string SelectedValue; }
    
        public class Program
        {
            public static void Main(string[] args)
            {
                var cboSort1 = new ComboBox { SelectedValue = "not a dupe" };
                var cboSort2 = new ComboBox { SelectedValue = "also not a dupe" };
                var cboSort3 = new ComboBox { SelectedValue = "this is a dupe" };
                var cboSort4 = new ComboBox { SelectedValue = "no dupe here" };
                var cboSort5 = new ComboBox { SelectedValue = "this is a dupe" };
    
                var boxes = new[] { cboSort1, cboSort2, cboSort3, cboSort4, cboSort5 };
    
                var dupes = boxes
                    .GroupBy(cb => cb.SelectedValue)       # groups by the value
                    .Where(grp => grp.ToList().Count > 1)  # this value has more then 1 
                    .Select(grp => grp.Key);               # just select the SelectedValue
    
                // now you just check if your CB has this selectedValue:
                if (dupes.Any(d => d == cboSort1.SelectedValue))
                    Console.WriteLine("CB1 is a dupe");
                if (dupes.Any(d => d == cboSort2.SelectedValue))
                    Console.WriteLine("CB2 is a dupe");
                if (dupes.Any(d => d == cboSort3.SelectedValue))
                    Console.WriteLine("CB3 is a dupe");
                if (dupes.Any(d => d == cboSort4.SelectedValue))
                    Console.WriteLine("CB4 is a dupe");
                if (dupes.Any(d => d == cboSort5.SelectedValue))
                    Console.WriteLine("CB5 is a dupe");        
            }
        }
    }
