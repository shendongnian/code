    get
    {
        return new ObservableCollection<VarItem>((
            new List<VarItem>
            {
                indexChannels.First(),
                indexChannels.FirstOrDefault(i => i == CurChannel.IndexChannel)
            })
            .Union(channels
                .Where(ch => ch.Mode.Value != "Q-Decode" &&
                             ch.Mode.Value != "Quad Index")
                .Select(ch => indexChannels.FirstOrDefault(i => i.ID == ch.Number)))
            .Where(varItem => varItem != default(VarItem))
            .Distinct());
    }
