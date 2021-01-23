    class MyDataGridView : DataGridView, IMessageFilter {
        public MyDataGridView() {
            Application.AddMessageFilter(this);
            this.HandleDestroyed += (sender, args) => Application.RemoveMessageFilter(this);
        }
        public bool PreFilterMessage(ref Message m) {
            if (m.Msg == 0x201) {
                if (!ClientRectangle.Contains(PointToClient(Control.MousePosition))) {
                    Hide();
                }
            }
            return false;
        }
    }
