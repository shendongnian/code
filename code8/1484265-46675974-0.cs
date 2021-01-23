    static void Main(String[] args) {
        string[] tokens_n = Console.ReadLine().Split(' ');
        int n = Convert.ToInt32(tokens_n[0]);
        int k = Convert.ToInt32(tokens_n[1]);
        string[] a_temp = Console.ReadLine().Split(' ');
        int[] a = Array.ConvertAll(a_temp,Int32.Parse);
        
        // use the periodicity of the shifting creating a shift between 0 and n - 1.
        int shifts = k % n;
        
        // Create a new array to hold the elements at their new positions.    
        int[] newPositions = new int[a.Length];
        // You only need to iterate of the array once assigning each element its new position.
        for(int i= 0; i < a.Length; ++i)
        {
            // Here is the magic: (for clarification see table below)
            int position = (i - shifts + n)%n;
            newPositions[position] = a[i];
        }
        
        foreach(var element in newPositions)
            Console.Write($"{element} ");
    }
