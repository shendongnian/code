    public static void SetReadOnly(Form frm) {
        var controls = new Queue<Control>();
        controls.Enqueue(frm);
        while (controls.Count > 0) {
            var control = controls.Dequeue();
            if (control is TextBox) {
                var txtBox = control as TextBox;
                txtBox.ReadOnly = true;
            }
            if (control.HasChildren) {
                foreach (var child in control.Controls.OfType<Control>()) {
                    controls.Enqueue(child);
                }
            }
        }
    }
