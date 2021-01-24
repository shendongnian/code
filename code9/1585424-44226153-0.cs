        {
            ...
            dataGridView1.CellMouseEnter += new DataGridViewCellEventHandler(dataGridView1_CellMouseEnter);
            menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
        }
        void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            mPoint = dataGridView1.PointToClient(Cursor.Position);
        }
        private void menuItem1_Click(object sender, EventArgs e)
        {
            DataGridView.HitTestInfo hitTestInfo = dataGridView1.HitTest(mPoint.X, mPoint.Y);
            Console.WriteLine(hitTestInfo.RowIndex + ", " + hitTestInfo.ColumnIndex);
        }
