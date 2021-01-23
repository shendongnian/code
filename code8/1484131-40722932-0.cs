    IReadOnlyCollection<IWebElement> unfiltered = Driver.FindElements(By.Id("brdrQuestion.QuestionRenderer.StackPanel.MultiChoiceQuestionViewer.sp.StackPanel.RadioTextRegionViewer1.LayoutRoot.Panel.text.sp.rich.LayoutRoot.TextBlock"));
    Console.WriteLine(unfiltered.Count);
    List<IWebElement> filtered = unfiltered.Where(f => f.GetCssValue("color") == "rgba(180, 137, 59, 1)").ToList();
    Console.WriteLine(filtered.Count);
    foreach (IWebElement element in filtered)
    {
        Console.WriteLine(element.Location.X);
        Console.WriteLine(element.Location.Y);
    }
