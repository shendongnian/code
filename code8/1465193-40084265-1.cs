    private void ShowInputForm()
    {
        using (var frm = new InputDialog())
        {
           frm.InputSet += (s, e) =>
           {
              txtResult.Text = e.Input;
           }
           
           frm.ShowDialog();
        }
    }
