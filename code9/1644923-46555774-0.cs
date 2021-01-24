    using SearchResultCollection searchGroupsResults = searchGroups.FindAll())
    {
        foreach (SearchResult group in searchGroupsResults)
        {
            Console.WriteLine("Group: " + group.Properties["name"][0].ToString() + " - Member Count: " + group.Properties["member"].Count.ToString());
        }
    }
