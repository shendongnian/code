    public static void GetSelectedValue(ComboBox c, Action<String> gotValue) {
        if( c.SelectedIndex >= 0 ) {
            ComboBoxItem item = c.Items[ c.SelectedIndex ];
            gotValue( item.Content.ToString() );
        }
    }
