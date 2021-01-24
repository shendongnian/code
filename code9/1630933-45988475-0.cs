    int subjectCount = 0;
    foreach (IWebElement element in allOptions)
    {
        if (subject.Contains(element.Text))
        {
            subjectCount++;
        }
    }
