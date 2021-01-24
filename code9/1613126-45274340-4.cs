            System.Windows.Forms.ListView listView = new System.Windows.Forms.ListView();
            DateTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            X = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            Y = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            Z = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            SuspendLayout();
            listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            DateTime,
            X,
            Y,
            Z});
            listView.GridLines = true;
            listView.View = System.Windows.Forms.View.Details;
            DateTime.Text = "DateTime";
            X.Text = "X";
            Y.Text = "Y";
            Z.Text = "Z";
            this.Controls.Add(this.listView);
            
            StreamReader file = new StreamReader("filepath");
            string sLine;
            while ((sLine = file.ReadLine()) != null)
            {
                string[] sarr= sLine.Split(';');
                StringBuilder sb = new StringBuilder(sarr[0]);
                sb[sarr[0].IndexOf(':')] = ' ';
                sarr[0] = sb.ToString().Replace(':', '.');
                string[] sData = { sarr[0], sarr[2], sarr[4], sarr[6] };
                ListViewItem item = new ListViewItem(sData);
                listView.Items.Add(item);
            }          
