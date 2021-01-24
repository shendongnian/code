    private async void loadCombo(string sqlCommand, string value, ComboBox loadBox)
            {
                await Task.Run(() =>
                {
                    var dt = sqlScript.loadCombo(sqlCommand, value, loadBox);
                    Invoke((Action)(() =>
                    {
                        loadBox.ValueMember = value;
                        loadBox.DataSource = dt;
                    }));
                });
            }
