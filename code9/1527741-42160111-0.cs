        static void Main(string[] args)
        {
            List<string> tmpList = new List<string>();
            for (int i = 0; i < 10; i++)
            {
                Debug.WriteLine("List Item No" + i);
                tmpList.Add("Item " + i);
            }
            Debug.WriteLine("_____________");
            Debug.WriteLine("List Count: " +tmpList.Count());
            Debug.WriteLine("_____________");
            for (int i = 0; i < tmpList.Count(); i++)
            {
                    Debug.WriteLine(tmpList[i]);
            }
        }
