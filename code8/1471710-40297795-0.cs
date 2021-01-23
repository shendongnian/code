    var guessed = foo;
    
    if(!db.Table.AsEnumerable().Any(x => x.Word == word && x.Opposite == guessed))
    {
    ...Notify the user he guessed wrong
    }
