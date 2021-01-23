    class Program
    {
        static void Main(string[] args)
        {
            int i_Num = 0;
            string Str_Num = "";
            string[] linkToPLC = {"toto[{0}].test{1}", "tata[{0}].test{1}", "titi[{0}].test{1}"};
            List<string> genlnkPLCCanvas = new List<string>(linkToPLC);
            List<string> genlnkPLCworkingwith = new List<string>(linkToPLC);
           
            Console.WriteLine("Insert Num: ");
            Str_Num = Console.ReadLine();
            i_Num = Convert.ToInt32(Str_Num);
            for (int item = 0; item < genlnkPLCCanvas.Count; item++)
            {
                genlnkPLCworkingwith[item] = String.Format(genlnkPLCCanvas[item], i_Num, 200);
            }
            var CanvasListReport = genlnkPLCCanvas.Select(item =>  "Canvas List = " + item);
            var WorkingListReport = genlnkPLCworkingwith.Select(item => "Working list = " + item);//string.Format(item, i_Num, 200));
            // now you can do whatever you want with the reports: 
            //  - print them to console
            //      Console.WriteLine(string.Join(Envrironment.NewLine, withListReport));
            //  - save to file: File.WriteAllLines(@"C:\MyFile.txt", withListReport);
            //  - print to, say, WinForm UI: 
            //      MyTextBox.Text = string.Join(Envrironment.NewLine, withListReport)
            Console.WriteLine(string.Join(Environment.NewLine, CanvasListReport));
            Console.WriteLine(string.Join(Environment.NewLine, WorkingListReport));
            Console.ReadKey();
        }
    }
