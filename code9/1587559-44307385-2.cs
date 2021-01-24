    private void tbSearch_KeyDown(object sender, KeyEventArgs e) {
        //...
                var results = cl2.Search(tbSearch.Text);
                foreach (var item in results) Update_SearchList(item);
            }
        }
    }
    public List<xxx> Search(string search_value) {
        //...
        var results = new List<xxx>(); // change type to the correct type
        foreach (XmlNode node in XMLlist) {
            // ...
            results.Add(result);
        }
        return results;
    }
