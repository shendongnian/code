    public IQueryable<Terminal> GetTerminals()
    {
            IQueryable<Terminal> terminals = context.TerminalInfos
            .Join(
                context.Components,
                C => C.Id,
                TI => TI.Id,
                (C, TI) => new Terminal(C,TI) //This is a lambda expression
            );
        return terminals;
    }
