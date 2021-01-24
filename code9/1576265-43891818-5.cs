var q9i = from view in tv.test_views                                // FROM test_view
          group view by new { view.LastName, view.AutoName } into g // GROUP BY LastName, AutoName
          select new <b>QueryResult</b> { g.Key.AutoName, g.Key.LastName,              // SELECT AutoName, LastName
                       Count = g.Where(x => x.Type != null).Count() }; // COUNT(Type)</code></pre>
**Or, you can return `List<object>`**:
public List&lt;<b>object</b>&gt; GroupExample() {
    // ...
}
