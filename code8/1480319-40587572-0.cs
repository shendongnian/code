    case 2:
    case 3:
    if (yourVar == 3)
    {
      Console.WriteLine("ID: 1" + Environment.NewLine + 
          "Make: Get Technologies .inc" + Environment.NewLine +
          "Model: HF 410" + Environment.NewLine +
          "MBSize: 4096" + Environment.NewLine + "Price: $129.95");
      Console.ReadLine();    
    }
    Console.WriteLine("Gekozen actie: 2. Gegevens MP3 speler opslaan");
    Console.WriteLine("Type de ID: ");
    int id = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Type de Maker: ");
    string MAKE = Convert.ToString(Console.ReadLine());
    Console.WriteLine("Type de Model : ");
    var MODEL = Convert.ToString(Console.ReadLine());
    Console.WriteLine("Type de MBGrootte: ");
    int MBSize = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Type de Prijs: ");
    var PRICE = Convert.ToString(Console.ReadLine());
    Console.ReadLine();
    Console.WriteLine("Ingevoerde gegevens: " +
    Environment.NewLine + "Uw ID: " + id +
    Environment.NewLine + "Uw Maker: " + MAKE +
    Environment.NewLine + "Uw Model: " + MODEL +
    Environment.NewLine + "Uw MBGrootte: " + MBSize +
    Environment.NewLine + "Uw Prijs: " + PRICE);
    Console.ReadLine();
    break;
