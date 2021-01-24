    private async Task DoSomethingAsync()
    {
       await DbClass.GetSomeItemsFromDbAsync();
    }
    
    public partial class MyForm : Form
    {
       private async void btButton_Click(object sender, EventArgs e)
       {
          await DoSomethingAsync();
       }
    }
