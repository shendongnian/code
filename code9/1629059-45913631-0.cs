     static void Main(string[] args)
    {
        int[] tablica1 = new int[20];
        Random tab = new Random();
        for (int i = 0; i < 20; i++)
        {
            tablica1[i] = tab.Next(20);
            Console.WriteLine("Tablica wylosowała nastepujace elementy:");
            Console.WriteLine(tablica1[i]);
        }
        Console.Read();
        int[] tablica2 = new int[20];
        for (int i = 20; i > 0; i--)
        {
          tablica2[i]=tablica1[20-i];
        }
       
    }
}
