    private void tbSearch_KeyDown(object sender, KeyEventArgs e) {
        //...
               cl2.Search(tbSearch.Text, ref this); // pass the ref of current instance to cl2
            }
        }
    }
    public async void Search(string search_value, ref Form1 frm) {
        //...
        foreach (XmlNode node in XMLlist) {
            // ...
            frm.Update_SearchList(result); // use the frm reference instead
        }
    }
    public void Update_SearchList(string [] array) {
        if (InvokeRequired)
            BeginInvoke(new MethodInvoker(() => Update_SearchList(array)));
        else {
            ListViewItem item = new ListViewItem(array);
            this.listV.BeginUpdate();                
            this.listV.Items.Add(item);
            this.listV.EndUpdate();  
        }        
    }
