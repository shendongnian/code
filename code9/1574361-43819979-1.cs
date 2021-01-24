    private async void TextBox_TextChanged(object sender, EventArgs e)
    {
        listBox.DataSource = null;
        var task = Task.Run(() =>
            {
                var resultList = new List<string>();
                foreach (string item in tempList)
                    if (item.ToLower().Contains(textBox.Text.ToLower()))
                        resultList.Add(item);
                return resultList;
            });
        listBox.DataSource = await task;
    }
