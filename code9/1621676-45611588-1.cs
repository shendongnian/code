    private async Task<bool> ShowProducts(string page, string keyWord)
    {
        string text = textBox1.Text;
        string res = await Task.Run(() => AO.GetPageInfo(page, text)); //run on a thread pool
        if(res == "")
        {
            return false;
        }
    
        label12.Text = res;
        CurrentPage = int.Parse(page);
        textBox3.Text = page;
        //flowLayoutPanel2.Visible = false;
        flowLayoutPanel2.Controls.Clear();
    
        Products = await Task.Run(() => AO.SearchProducts(CurrentPage.ToString(), text)); //run on a thread pool
    
        //foreach(Product X in Products)
        //    flowLayoutPanel2.Controls.Add(new Card(X));
        
        //This code will block only for the time of adding the controls.
        //This is unavoidable as flowLayoutPanel2 is part of the UI 
        //and has to be updated on the UI thread.
        //Making the controls is done on a thread pool so it won't block
        flowLayoutPanel2.Controls.AddRange(await Task.Run(() => Products.Select(x => new Card(x)).ToArray()));
    
        return true;
    }
