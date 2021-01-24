    using System;
    using System.Text;
    using System.Windows.Forms;
    using iTextSharp.text.pdf;
    using iTextSharp.text.pdf.parser;
    using System.IO;
    namespace ZestawienieFaktur
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                
            }
            private void button1_Click(object sender, EventArgs e)
            {
                string[] filePaths = Directory.GetFiles(@"D:\faktury\", "*.pdf");
               foreach (string fp in filePaths)
                {
                    ExtractTextFromPdf(fp);
                }
              
            }
            public static string ExtractTextFromPdf(string path)
            {
                using (PdfReader reader = new PdfReader(path))
                {
                    StringBuilder text = new StringBuilder();
                    for (int i = 1; i <= reader.NumberOfPages; i++)
                    {
                        text.Append(PdfTextExtractor.GetTextFromPage(reader, i));
                    }
                    string lines = text.ToString();
                    using (var file = new StreamWriter(@"D:\faktury\test1.txt"))
                    {
                        file.WriteLine(lines);
                        file.Close();
                    }
                    return lines; 
                }
            }
        }
        }
