    string[] values = new string[] { "Test123Test",
                "TestTTTTest",
                "Test153jhdsTest",
                "123Test",
                "TEST123" };
    string searchQuery = "Test%Test";
    string regex = Regex.Escape(searchQuery).Replace("%", ".*?");
    string[] filteredValues = values.Where(str => Regex.IsMatch(str, regex)).ToArray();
