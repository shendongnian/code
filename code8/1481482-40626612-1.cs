    this.listView1.BeginInvoke(
                new Action(() => 
                {
                    foreach (ListViewItem itemrow in this.listView1.Items)
                    {
                        result = PumpStart.SymbolAdd(itemrow.SubItems[0].Text.Trim());
                        if(result != ResultCode.Ok )
                        {
                            Console.WriteLine("Error adding symbol. " + mgr.ErrorDescription(result));
                        }
                    }
                })
    );
