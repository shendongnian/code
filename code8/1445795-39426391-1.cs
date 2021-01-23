    Quote quote = new Quote();
    quote_identifier.Text = quote.Identifier.ToString();
    quote.Author = quote_author.Text;
    quote.Body = quote_body.Text;
    quote.Title = quote_title.Text;
    quote.Source = quote_source.Text;
    
    QuotesList.Add(quote);
    NotifyPropertyChanged(()=>QuotesList);
