    public void TestMethod2()
    {
        string[] keywords =
        {
            "SELECT", "FROM", "WHERE", "GROUP", "HAVING", "ORDER", "LEFT",  "RIGHT", "JOIN", "INNER", "OUTER", "ASC",
            "DESC", "AND", "OR","IN", "BETWEEN", "BY", "NOT", "ON", "AS", "CASE", "WHEN", "ELSE", "UPDATE", "SET"
        };
        var actualString = "SELECT * FROm A Join B On C in D case e join t left outer join inner join right join";
        var cnt = sqlTest.Split(' ').Count();
        for (int i = 0; i < cnt; i++)
        {
            var text = sqlTest.Split(' ')[i];
            var isExists = keywords.Any(x => x.Equals(text, StringComparison.OrdinalIgnoreCase));
            if (!isExists)
            {
                continue;
            }
            actualString = actualString.Replace(text, text.ToUpper());
        }
        var expectedString = "SELECT * FROM A JOIN B ON C IN D CASE e JOIN t LEFT OUTER JOIN INNER JOIN RIGHT JOIN";
    }
