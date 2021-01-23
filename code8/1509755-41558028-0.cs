    class MyDataGridView : DataGridView {
        public MyDataGridView() {
            ParentChanged += OnParentChanged;
        }
        private void OnParentChanged(object sender, EventArgs eventArgs) {
            Parent.MouseClick += (o, args) =>
            {
                // Detect if the click landed in MyDataGridView
                if (!ClientRectangle.Contains(PointToClient(Control.MousePosition))) {
                    Hide();
                }
            };
        }
    }
