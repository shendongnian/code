    using (FileStream fsOutput = new FileStream(outputfilePath, FileMode.Create))
    {
        byte[] bytes = new byte[fsInput.Length];
        while (cs.Read(bytes, 0, (int)fsInput.Length) > 0) ;
        fsOutput.Write(bytes, 0, bytes.Length);
    }
