    private void DataGridViewMouseClick(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv != null)
            {
                // find the current index
                int currentIndex = dgv.CurrentRow.Index;
                // find the current Ticket
                Ticket currentTicket = dgv.CurrentRow.DataBoundItem as Ticket;
                ContextMenu menu = new ContextMenu();
                // set up the context menu here...
                menu.Show(dgv, new Point(e.X, e.Y));
            }
        }
    }
