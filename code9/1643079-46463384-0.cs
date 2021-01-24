    class Program{
        public void GetPowersOf2(int input)
        {
            var returnList = new List<double>();
            for (int i = 0; i < input + 1; i++)
            {
                returnList.Add(Math.Pow(2, i));
            }
             returnList.ForEach(Console.WriteLine);//display list from method.
            //return returnList;
        }
        static void Main(String[] args)
        {
            Program p = new Program();
            p.GetPowersOf2(2);
        }
    }
