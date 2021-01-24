    public static void Main()
    {
        var serializer = new XmlSerializer(typeof(AppList));
        var reader = new StreamReader("YourFile.xml");
        var result = serializer.Deserialize(reader) as AppList;
        reader.Close();
        foreach (var thisVlc in result.VLC)
        {
            Console.WriteLine(thisVlc.MD5GoldenHash);
        }
        // if you want to make changes to xml file then do the following
        result.VLC[0].MD5GoldenHash = "Something to show modificaition";
        serializer.Serialize(new StreamWriter("YourFileOrSomeOtherFile.xml"), result);
    }
