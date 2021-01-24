    IEnumerable<MyNewClass> filterResult = itemList;
    if(nameFilterTextBox.Text != "") {
        filterResult = filterResult.Where(s => s.name == nameFilterTextBox.Text);
    }
    if(descriptionFilterTextBox.Text != "") {
        filterResult = filterResult.Where(s => s.description == descriptionFilterTextBox.Text)
    }
    if(comboBox1.SelectedIndex != null) {
        MyNewClass.Colors col = (MyNewClass.Colors)comboBox1.SelectedIndex;
        filterResult = filterResult.Where(s => s.color == col);
    }
    // do something with filterResult.ToList()
