    // The values that we want to query.
    // In your case, it's essentially the table that you're querying.
    // I used an anonymous class for brevity.
    var values = new[] {
        new { key = 99, a = 0, b = 4, c = 5, d = 9, e = 2 },
        new { key = 100, a = 0, b = 5, c = 3, d = 2, e = 10 }
    };
    // The query. I prefer to use the linq query syntax
    // for actual SQL queries, but you should be able to translate
    // this to the lambda format fairly easily.
    var query = (from v in values
                // Transform each value in the object/row
                // to a name/value pair We include the key so that we
                // can distinguish different rows.
                // Because we need this query to be translated to SQL,
                // we have to use an anonymous class.
                from column in new[] { 
                    new { key = v.key, name = "a", value= v.a },
                    new { key = v.key, name = "b", value= v.b },
                    new { key = v.key, name = "c", value= v.c },
                    new { key = v.key, name = "d", value= v.d },
                    new { key = v.key, name = "e", value= v.e }
                }
                
                // Group the same row values together
                group column by column.key into g
                
                // Inner select to grab the top two values from
                // each row
                let top2 = (
                    from value in g
                    orderby value.value descending
                    select value
                ).Take(2)
                // Grab the results from the inner select
                // as a single-dimensional array
                from topValue in top2
                select topValue);
    // Collapse the query to actual values.
    var results = query.ToArray();
    foreach(var value in results) {
        Console.WriteLine("Key: {0}, Name: {1}, Value: {2}", 
            value.key, 
            value.name, 
            value.value);
    }
