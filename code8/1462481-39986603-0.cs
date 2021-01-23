    var mySrcFolder = ""; // something from user variables?
    var myUtf8stage = ""; // something from user variables?
    var myFinalstage = ""; // something from user variables?
    
    // Static variables
    var ascii = System.Text.Encoding.ASCII;
    var utf16le = System.Text.Encoding.Unicode;
    var utf8 = System.Text.Encoding.UTF8;
    var ansi = System.Text.Encoding.Default;
    var append = false;
    
    // Set source file path and file name
    var src = System.IO.Path.Combine(
        mySrcFolder,
        String.Format("{0}.txt", myUtf8stage));
    
    // Set source file encoding (using list above)
    var src_enc = ascii;
    
    // Set target file path and file name
    var tgt = System.IO.Path.Combine(
        mySrcFolder,
        String.Format("{0}.txt", myFinalstage));
    
    // Set target file encoding (using list above)
    var tgt_enc = utf8;
    
    using (var read = new System.IO.StreamReader(src, src_enc))
    using (var write = new System.IO.StreamWriter(tgt, append, tgt_enc))
    {
        while (read.Peek() != -1)
        {
            var line = read.ReadLine();
            write.WriteLine(line);
        }
    }
