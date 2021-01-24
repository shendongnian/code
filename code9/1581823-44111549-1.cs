    public class StringBagAlgorithm
    {
        public List<string> ListofString { get; set; }
        public bool ComputeString(string myString)
        {
            //return true or false depending on the computation with the list of strings;
            return true;
        }
    }
    public class StringsComputer
    {
        public List<string> FirstList { get; set; }
        public List<string> SecoundList { get; set; }
        public StringBagAlgorithm BagAlgorithm { get; set; }
        public StringsComputer(StringBagAlgorithm bagAlgorithm, List<string> listA, List<string> listB)
        {
            BagAlgorithm = bagAlgorithm;
            FirstList = listA;
            SecoundList = listB;
        }
        public StringsComputer()
        {
        }
        public void ComputeSecondList()
        {
            if(BagAlgorithm != null)
            {
               for (int i = 0; i < SecoundList.Count; i++)
                   BagAlgorithm.ComputeString(SecoundList[i]);
            }
        }
    }
    public class program
    {
        public static void Main()
        {
            List<string> listA = new List<string>() { "A", "B", "C", "D" };
            List<string> listB = new List<string>() { "E", "F", "C", "H" };
            StringBagAlgorithm sba = new StringBagAlgorithm();
            StringsComputer sc = new StringsComputer() {
                FirstList = listA,
                SecoundList = listB,
                BagAlgorithm = sba
            };
            sc.ComputeSecondList();
        }
    }
