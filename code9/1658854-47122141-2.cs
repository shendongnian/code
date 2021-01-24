    public class RecordArray
    {
        public static RecordClass[] rArray {get; private set;}
        public static void Init(int Size)
        {
            //RNG for phone numbers
            Random Rnd = new Random();
            //Creating an array of RecordClass
            rArray = new RecordClass[Size];
            //Loop through the array
            for(int i = 0; i < rArray.Length; i++)
            {
                rArray[i] = new RecordClass();
                rArray[i].Name = "Name" + i;
                rArray[i].Number = Rnd.Next();
                rArray[i].Email = rArray[i].Name + "@gmail.com";
            }
        }
        public static int FindByName(RecordClass[] rArray, string Name)
        {
            //Loop through rArray to find if Name matches. If match, return index. Otherwise, return -1.
            for(int i = 0; i < rArray.Length; i++)
            {
                if (rArray[i].Name == Name)
                {
                    return i;
                }
            }
            return -1;
        }
    }
