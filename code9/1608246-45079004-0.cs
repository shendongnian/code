            protected void Auction_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            ListViewDataItem dataitem = (ListViewDataItem)e.Item;
            decimal pln = Convert.ToDecimal(DataBinder.Eval(e.Item.DataItem, "Price"));
            Repositories.ICurrencyRepository repo = new Repositories.ICurrencyRepository();
            decimal eur = Math.Ceiling(repo.CurrencyExchange(pln, "PLN", "EUR") * 100) / 100;
            var EurName = e.Item.FindControl("EurName") as Label;
            EurName.Text = eur.ToString();
        }
