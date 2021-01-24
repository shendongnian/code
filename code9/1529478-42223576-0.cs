    async void loadCombo(string sqlComand, string value, ComboBox loadBox)
    {
        // disable button
  
        await Task.Run(() =>
        {
            var dt = sqlScript.loadCombo(sqlComand, value, loadBox);
            Invoke((Action)(() =>
            {
                loadBox.ValueMember = value; // is it out parameter? anyway, copying your code
                loadBox.DataSource = dt;
                loadBox.Refresh();
            }));
        }
        // enable button
    }
