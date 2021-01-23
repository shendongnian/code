    var query = await db.Phrases;
    // common where clauses
    switch (options.PhraseTypeSelectId) {
        case 0:
            query = query.Where(w => /* appropriate restriction for 0 */);
            break;
        // other cases
    }
    // more conditional where clauses perhaps
    // projection clauses like Select()
    // finally, execute the query
    List<Phrases> phrases = await query.ToListAsync();
