    private class Tile
    {
        private frmMain _frm;
        public Tile (frmMain frm)
        {
            _frm = frm;
        }
        private void swap(object sender, EventArgs e)
        {
            if (won) {
                MessageBox.Show(_frm.textBox1.Text);
            }
        }
    }
