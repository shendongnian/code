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
                             ch.Mode.Value != "Quad Index" &&
                             indexChannels.Any(i => i.ID == ch.Number))
                .Select(ch => indexChannels.First(i => i.ID == ch.Number)))
            .Where(item => item != default(VarItem))
            .Distinct());
    }
