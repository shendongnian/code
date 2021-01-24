    return new ObservableCollection<VarItem>(
        indexChannels
        .Take(1)
        .Union(indexChannels.Where(i => i == CurChannel.IndexChannel).Take(1))
        .Union(channels
            .Where(c => c.Mode.Value != "Q-Decode" &&
                        c.Mode.Value != "Quad Index")
            // The following line could be turned into
            // .Select(c => indexChannels.First(i => i.ID == c.Number))
            // OR
            // .Select(c => indexChannels.Single(i => i.ID == c.Number))
            // OR 
            // .SelectMany(c => indexChannels.Where(i => i.ID == c.Number))
            // depending on how many channels in indexChannels 
            // are expected to match each Number property.
            .Select(c => indexChannels.FirstOrDefault(i => i.ID == c.Number))
    );
