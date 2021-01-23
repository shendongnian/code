    delegate void AddItemDelegate(ComboBox cmb, string value);
    void AddItem(ComboBox cmb, string value) {
        if (cmb.InvokeRequired) {
            cbm.Invoke( new AddItemDelegate( AddItem ), cmb, value );
        } else {
            cmb.Items.add(value);
        }
    }
