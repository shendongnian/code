    var basilisks = new Basilisk[numberOfBasilisks];
    for (int i = 0; i < numberOfBasilisks; i++) {
        basilisks[i] = new Basilisk();
        var str = Console.ReadLine();
        var splittedBasilisk = str.Split(' ');
        basilisks[i].Name = splittedBasilisk[0];
        basilisks[i].Num1 = int.Parse(splittedBasilisk[1]);
        basilisks[i].Num2 = int.Parse(splittedBasilisk[2]);
        basilisks[i].Num3 = int.Parse(splittedBasilisk[3]);
        basilisks[i].Num4 = int.Parse(splittedBasilisk[4]);               
    }
