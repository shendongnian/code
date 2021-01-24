    var itemsWithIndex = myList
        // If you would like to change the order of auto-generated IDs,
        // change the expression inside OrderBy; This step is optional.
        .OrderBy(item => <some-expression>)
        .Select((item, index) => new { Item=item, NewId=index+1});
