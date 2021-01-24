    using(var bw = new BinaryWriter(File.OpenWrite("myFile.txt")))
    {
        bw.Write(1234.01m); //there is actualy 16 bytes written to file. Double is 8 bytes long.
        bw.Write((double)5);
    }
