    public int IndexProp {get; set;}
    public void AddToExcelBtn_Click(object sender, EventArgs e) 
    {
        //... some other code
        Index +=1;
        xlWorkSheet.Cells[IndexProp , 1] = comboBox2.Text;
        xlWorkSheet.Cells[IndexProp , 2] = textBox5.Text;
        xlWorkSheet.Cells[IndexProp , 3] = textBox2.Text;
        xlWorkSheet.Cells[IndexProp , 4] = comboBox3.Text;
        xlWorkSheet.Cells[IndexProp , 5] = textBox3.Text;
        xlWorkSheet.Cells[IndexProp , 6] = comboBox1.Text;
    }
