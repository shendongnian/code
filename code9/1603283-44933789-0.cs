            frmNewConfig f = new frmNewConfig();
            if (f.ShowDialog() == DialogResult.OK)
            {
                Object c = new Object();
                c = (Object)f.Tag;
                _yourList.Add(c);
              **example**
                 valueA = txtValueA.Text;
                 valueB = txtValueB.Text;
            }
