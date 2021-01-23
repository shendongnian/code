    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[5];
            for(int i = 0; i < arr.Length; i++)
            {
                int? input = null;
                while( !( input = Input.ReadInt("Give me number") ).HasValue ) { }
                arr[i] = input.Value;
            }
    
            Operations op = new Operations();
            op.Display(arr);
            op.Sort(ref arr);
            op.Display(arr);
        }
    }
