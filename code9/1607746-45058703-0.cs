    [XmlElement("Results", typeof(List<TestCaseResult>))]
    public List<TestCaseResult> Results
    {
        get
        {
            return results.OrderByDescending(x => x.Time).ToList();
        }
        set
        {
            results = value;
        }
    }
