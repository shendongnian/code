    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        listBox2.Items.Clear();
        var currentItem = listBox1.SelectedItem as TestPath;
        listBox2.Items.Add(currentItem.Original.FullPath); // or any property
        }
    }
