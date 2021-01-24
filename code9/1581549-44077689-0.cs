    void addPropertyValues<T>(SearchResult sr, T testlist, string propName) {
        foreach (var pv in sr[propName]) {
            testlist.Text = pv.ToString();
        }
    }
