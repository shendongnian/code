    /// <summary>
    /// Returns a list of IDs that correspond to the elements of type test-id
    /// </summary>
    /// <param name="testId">The test-id that the elements should contain</param>
    /// <returns>A list of IDs</returns>
    public List<string> GetIdsByTestId(string testId)
    {
        return Driver.FindElements(By.CssSelector($"[test-id={testId}]")).Select(e => e.GetAttribute("id")).ToList();
    }
