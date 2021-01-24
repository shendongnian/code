    using (BerkeleyPacketFilter filter = communicator.CreateFilter("ip and tcp"))
    {
        var prop = filter.GetType().GetField("_bpf",
                                             System.Reflection.BindingFlags.NonPublic
                                             | System.Reflection.BindingFlags.Instance);
        prop.SetValue(filter, &your_bpf_program);
        communicator.SetFilter(filter);
    }
