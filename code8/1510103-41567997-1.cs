    public class Operations
    {
        public void Display(int[] arr)
        {
            foreach(int i in arr)
            {
                // and since you have "Input" class that can display things
                Input.Write(i.ToString());
            }
        }
    
        public void Sort(ref int[] arr)
        {
            Array.Sort(arr);
        }
    }
