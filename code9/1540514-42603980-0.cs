    public class Class01
    {
        public List<string> myList = new List<string>();
        public void _addsList()
        {
            myList.Add("0001Test01");
            myList.Add("0002Test02");
            myList.Add("0003Test03");
            myList.Add("0004Test04");            
        }
    }
    class Class02
    {
        public void _callList()
        {
            var class01 = new Class01();
            class01._addsList(); //<--- Had to add this line
            for (int i = 0; i < class01.myList.Count; i++)
            {
                Console.WriteLine(class01.myList[i] + ",");
            }
            string wits2;
            List<string> buffer = new List<string>();
            for (int i = 0; i < class01.myList.Count; i++)
            {
                wits2 = class01.myList[i].Substring(0, 4);
                Console.WriteLine(wits2);
            }
            Console.ReadKey();
        }
    }
