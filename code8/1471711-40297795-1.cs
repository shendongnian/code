    var guessed = foo;
    var opposite = db.Table.AsEnumerable().Where(x.Opposite == guessed).FirstOrDefault();
    id(opposite != null)
    {
        //to get the word from the opposite
        var wordFromOpposite = opposite.Word;
        if(!db.Table.AsEnumerable().Any(x => x.Word == word && x.Opposite == guessed))
        {
           ...Notify the user he guessed wrong
        }
    }
