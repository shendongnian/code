    // need to instantiate list somewhere near top
    var byteList = new List<byte>();
    
    using (var input = File.OpenRead(path))
    {
        input.Seek(0x1D, SeekOrigin.Begin);
        for (var i=0;i<4;i++){
            var byteThatIsRememberedNow = input.ReadByte() ^ 0x149;
            byteList.Add((byte) byteThatIsRememberedNow);
        }
    }
    // you'll need to replace this with something for your text box...
    // couldn't figure out from your question
    for (var i=0;i<byteList.Length;i++){
        Console.WriteLine(byteList[i]);
    }
