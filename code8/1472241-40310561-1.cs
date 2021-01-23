    private async void Button1_Click(object sender, EventArgs e)
    {
        int c = Convert.ToInt16(txbColumn.Text);
        int f = Convert.ToInt16(txbRow.Text);
        await Task.Run(()=> draw.DynamicTextBox(c, f));
        foreach (Control txtb in draw.textboxList)
        {
            Paneltxb.Controls.Add(txtb); 
        }
    }
    public class generator
    {
    public ArrayList textboxList;
    ...
    public void DynamicTextBox(int c, int f )
    {
     ...
    }...
