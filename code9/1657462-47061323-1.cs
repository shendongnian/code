    const string URL = "https://www.fourmilab.ch/cgi-bin/Hotbits.api?nbytes=8&fmt=xml&npass=1&lpass=8&pwtype=3&apikey=HB18CsHhr5Muzoee1KAu4QY5xUe";
    static void Main(string[] args)
    {
        XDocument doc = XDocument.Load(URL);
        string randomNumbers = (string)doc.Descendants("random-data").FirstOrDefault();
        int[] numbers = randomNumbers.Split(new char[] { ' ', '\n' }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x, System.Globalization.NumberStyles.HexNumber)).ToArray();
        Console.WriteLine(string.Join(",",numbers.Select(x => x.ToString())));
        Console.ReadLine();
    }
