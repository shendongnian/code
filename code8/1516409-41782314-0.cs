    Console.WriteLine("give number ");
    int avain = int.Parse(Console.ReadLine());
    
    string viesti_s = "HELLO !";
    
    for (int i = 0; i < viesti_i.Length; i += avain)
    {
       viesti_s = viesti_i.Insert(avain, "b");
    }
    
    Console.WriteLine(viesti_s);
    Console.ReadKey();
