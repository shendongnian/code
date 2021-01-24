    string line;
    var file = 
       new System.IO.StreamReader(@"C:\Users\Firzanah\Downloads\"+TextFile);
    System.Console.WriteLine("Contents of nvram.txt = /n");
    while((line = file.ReadLine()) != null)
    {
       Console.WriteLine("\t" + line);
    }
    
    file.Close();
    System.Console.ReadKey();
