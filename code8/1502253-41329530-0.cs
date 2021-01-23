    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;
    using Spire.Doc;
    using Spire.Pdf;
    using Spire.Pdf.Graphics;
    using Spire.Presentation;
    using Spire.Xls;
    
    namespace Merge_Office_Files_to_PDF
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "All files (*.docx, *.pdf, *.pptx, *.pdf)| *.docx; *.pdf; *.pptx; *.xlsx";
            ofd.Multiselect = true;
            if (DialogResult.OK == ofd.ShowDialog())
            {
                string[] files = ofd.FileNames;
                listBox1.Items.AddRange(files);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string ext = string.Empty;
            List<Stream> filesStreams = new List<Stream>();
            MemoryStream ms1 = new MemoryStream();
            MemoryStream ms2 = new MemoryStream();
            MemoryStream ms3 = new MemoryStream();
            foreach (object item in listBox1.Items)
            {
                ext = Path.GetExtension(item.ToString());
                switch (ext)
                {
                    case ".docx":
                        Document doc = new Document(item.ToString());
                        doc.SaveToStream(ms1, Spire.Doc.FileFormat.PDF);
                        filesStreams.Add(ms1);
                        break;
                    case ".pdf":
                        filesStreams.Add(File.OpenRead(item.ToString()));
                        break;
                    case ".pptx":
                        Presentation ppt = new Presentation(item.ToString(), Spire.Presentation.FileFormat.Auto);
                        ppt.SaveToFile(ms2, Spire.Presentation.FileFormat.PDF);
                        filesStreams.Add(ms2);
                        break;
                    case ".xlsx":
                        Workbook xls = new Workbook();
                        xls.LoadFromFile(item.ToString());
                        xls.SaveToStream(ms3, Spire.Xls.FileFormat.PDF);
                        filesStreams.Add(ms3);
                        break;
                    default:
                        break;
                }
            }
            string outputFile = "result.pdf";
            PdfDocumentBase result = PdfDocument.MergeFiles(filesStreams.ToArray());
            result.Save(outputFile, Spire.Pdf.FileFormat.PDF);
            ms1.Close();
            ms2.Close();
            ms3.Close();            
        }
    }
