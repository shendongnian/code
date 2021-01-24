	public static void Main()
	{
		string numcont = "abc";
        double numenc = 1.1;
        double numfatura = 12.2;
        string zona = "def";
        DateTime data = new DateTime();
        string ean = "hij";
        double iva = 23.4;
        double precoantesdisc = 34.5;
        double preconet = 45.6;
		var info =  numcont + ";" + numenc + ";" + numfatura + ";" + data + ";"
                    + zona + Environment.NewLine + ean +";" + iva + ";" + 
                    precoantesdisc +";" + preconet;
		File.WriteAllText("abc.txt",info);
		Console.Write(info);
    }
