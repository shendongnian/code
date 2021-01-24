    string TEMPprocitano; 
    private void button1_Click(object sender, EventArgs e)
    {
        citanjeReda();
    }
    public void citanjeReda()
    {
      if (openFileDialog1.ShowDialog() == DialogResult.OK)
              {
         int brojRedova=File.ReadLines(openFileDialog1.FileName).Count();
         StreamReader sr = new StreamReader(openFileDialog1.FileName);
                  for (int i = 0; i <= brojRedova; i++)
                  {
                      TEMPprocitano = sr.ReadLine();
                      f1();  
                  }
                  sr.Close();
              }
    }
    public void f1()  //doc_pers_no 11
    {
        try
        {
            StringBuilder F1 = new StringBuilder(TEMPprocitano);
            F1.Remove(0, 22);
            F1.Remove(11, 698);
            MessageBox.Show(F1.ToString());
 
            //Create a Word document
            Document doc = new Document();
            Section section = doc.AddSection();
            Paragraph paragraph = section.AddParagraph();
 
            //Append a Textbox to paragraph
            Spire.Doc.Fields.TextBox tb = paragraph.AppendTextBox(170, 20);
 
            //Set the position of Textbox
            tb.Format.HorizontalOrigin = HorizontalOrigin.Page;
            tb.Format.HorizontalPosition = 150;
            tb.Format.VerticalOrigin = VerticalOrigin.Page;
            tb.Format.VerticalPosition = 50;
            tb.Format.NoLine = true;
 
            CharacterFormat format = new CharacterFormat(doc);
            format.FontName = "Calibri";
            format.FontSize = 11;
            format.Bold = false;
 
 
            Paragraph par1 = tb.Body.AddParagraph();
            par1.AppendText(F1.ToString()).ApplyCharacterFormat(format);
              ////// for F3
           StringBuilder F3 = new StringBuilder(TEMPprocitano);
                F3.Remove(0, 49);
                F3.Remove(32, 650);
                MessageBox.Show(F3.ToString());
               
                //Append a Textbox to paragraph
                Spire.Doc.Fields.TextBox tb3 = paragraph.AppendTextBox(170, 20);
 
                //Set the position of Textbox
                tb3.Format.HorizontalOrigin = HorizontalOrigin.Page;
                tb3.Format.HorizontalPosition = 70;
                tb3.Format.VerticalOrigin = VerticalOrigin.Page;
                tb3.Format.VerticalPosition = 70;
                tb3.Format.NoLine = true;
 
                Paragraph par3 = tb3.Body.AddParagraph();
                par3.AppendText(F3.ToString()).ApplyCharacterFormat(format);
 
            //Save to file
            doc.SaveToFile("job.docx", FileFormat.Docx);
 
        }    catch (Exception){}
    }
