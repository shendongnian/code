    static void DeleteArtical()
    {
        string input;
    
        Console.WriteLine("Enter name you want to delete: ");
        input = Console.ReadLine();
    
        List < Artical > articals = new List < Artical > ();
        using(StreamWriter sw = File.AppendText((@ "../../dat.txt"))) {
          if (articals.Exists(x => string.Equals(x.name, input, StringComparison.OrdinalIgnoreCase))) { 
            Console.WriteLine("Done !!");
            artikli.Remove(k);
          }
    
        }
    }
