    protected void DoSearch_Command(object sender, CommandEventArgs e)
    {
        //create a new item to hold search results, in this case a list
        List<string> searchResults = new List<string>();
        //the text from the textbox that contains the search word
        string searchTerm = SearchField.Text.Trim();
        //hide the 'more' button
        MoreButton.Visible = false;
        //add some dummy data for testing
        for (int i = 1; i <= 50; i++)
        {
            searchResults.Add("Search result " + i);
        }
        //if the results are more than 10 and the click is not from the 'more' button take 10 items
        if (searchResults.Count > 10 && e.CommandName == "Search")
        {
            searchResults = searchResults.Take(10).ToList();
            //show the more button
            MoreButton.Visible = true;
        }
        //show results in gridview
        SearchResultsGridView.DataSource = searchResults;
        SearchResultsGridView.DataBind();
    }
