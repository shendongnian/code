        static void Main(string[] args)
        {
            List<ChamberMembers> lst = new List<ChamberMembers>();
            lst.Add(new ChamberMembers
            {
                companysortName = "b"
            });
            lst.Add(new ChamberMembers
            {
                companysortName = "z"
            });
            lst.Add(new ChamberMembers
            {
                companysortName = "e"
            });
            lst.Add(new ChamberMembers
            {
                companysortName = "a"
            });
            Console.WriteLine("\nBefore sort:");
            foreach (ChamberMembers ChamberMember in lst)
            {
                Console.WriteLine(ChamberMember.companysortName);
            }
            lst.Sort();
            Console.WriteLine("\nAfter sort:");
            foreach (ChamberMembers ChamberMember in lst)
            {
                Console.WriteLine(ChamberMember.companysortName);
            }
            Console.ReadLine();
        }
    }
    public class ChamberMembers : IComparable<ChamberMembers>
    {
        public string companysortName  { get; set; }
     
        public int CompareTo(ChamberMembers Chamber)
        {
            if (Chamber == null)
                return 1;
            else
                   return string.Compare(this.companysortName, Chamber.companysortName, CultureInfo.InvariantCulture, CompareOptions.IgnoreSymbols);
        }
    }
