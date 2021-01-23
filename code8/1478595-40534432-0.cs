    public static int indexProp = 0;
    public void OpenExcelFile(string path){
        //Open new file here
        indexProp = 0; //reset value as needed
    }
    
    public void AddToExcelBtn_Click(object sender, EventArgs e) 
    {
    //... some other code
    indexProp +=1;
    xlWorkSheet.Cells[indexProp , 1] = comboBox2.Text;
    xlWorkSheet.Cells[indexProp , 2] = textBox5.Text;
    xlWorkSheet.Cells[indexProp , 3] = textBox2.Text;
    xlWorkSheet.Cells[indexProp , 4] = comboBox3.Text;
    xlWorkSheet.Cells[indexProp , 5] = textBox3.Text;
    xlWorkSheet.Cells[indexProp , 6] = comboBox1.Text;
}
