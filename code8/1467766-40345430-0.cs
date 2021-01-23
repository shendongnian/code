    private void SaveToPDF_Click(object sender, EventArgs e)
{
    SaveFileDialog SavePDFDialog = new SaveFileDialog();
    Stream MyStream;
    SavePDFDialog.Filter = "PDF File (*.pdf)|*.pdf|All Files(*.*)|*.*";
    SavePDFDialog.FilterIndex = 1;
    SavePDFDialog.RestoreDirectory = true;
    SavePDFDialog.FileName = ("Report");
        if (SavePDFDialog.ShowDialog() == DialogResult.OK)
        {
            if ((MyStream = SavePDFDialog.OpenFile()) != null)
            {
                try
                {
                    Document document = new Document();
                    PdfWriter.GetInstance(document, MyStream);
                    document.Open();
                    //Paragraph h = new Paragraph("Results from: " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLocalTime());
                    Paragraph h = new Paragraph("Results from: " + DateTime.Now.ToLocalTime());
                    Paragraph p1 = new Paragraph("The Top Scoring student is:" + TopStudentBox.Text);
                    Paragraph p2 = new Paragraph("The Question answer wrong the most is: " + MissedQuestionBox.Text);
                    document.Add(h);
                    document.Add(p1);
                    document.Add(p2);
                    document.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                MyStream.Close();
            }
        }
