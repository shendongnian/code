    static void Main(string[] args)
    {
        // Runtime arguments:
        // [0] Folder Path
        // [1] N for numeral, A for all
        // [2] separator string
        // [3] echo (N for app closes silently, Y app waits for user input to close
        //Initialize
        string path = args[0];
        string num = args[1];
        string sep = args[2];
        string ech = args[3];
        string ocrval = String.Empty;
        bool numeral = false;
        if (num == "N")
          numeral = true;
        //Start TESSNET initialization
        Tesseract ocr = new tessnet2.Tesseract();
        ocr.Init(null, "eng", numeral);
        //Generate string array to read filenames in the path directory
        string[] allFiles = Directory.GetFiles(path,"*",SearchOption.TopDirectoryOnly); 
        //Run OCR code
        foreach (string fn in allFiles)
        {
            Bitmap bm = new Bitmap(fn);
            var result = ocr.DoOCR(bm, Rectangle.Empty);
            foreach (tessnet2.Word word in result)
            {
                ocrval = ocrval + word.Text;
            }
            ocrval = ocrval + sep;
            bm.Dispose();
        }
        //Write result to textfile
        File.WriteAllText(path+"/result/result.txt", ocrval);
        //echo output
        if (ech == "Y")
        {
            Console.WriteLine(ocrval);
            Console.WriteLine("Process Completed. Press any key to close");
            Console.ReadLine();
        }
    }
