    public List<string> getLabels(MyEvent targetEvent)
    {
        List<string> result = this.client.Cypher.Match("(newE:MyEvent)")
            .Where((MyEvent newE) => newE.myid == targetEvent.myid)
            .Return( newE=> newE.Labels() )
            .Results.ToList();
            return result;
    }
