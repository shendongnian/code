    private void comboBox_MeasureItem(object sender, MeasureItemEventArgs e)
    {
        e.ItemWidth = 44;
        e.ItemHeight = 15;
    }
    . . .
    this.comboBox1.MeasureItem += new MeasureItemEventHandler(comboBox_MeasureItem);
    this.comboBox2.MeasureItem += new MeasureItemEventHandler(comboBox_MeasureItem);
    . . .
