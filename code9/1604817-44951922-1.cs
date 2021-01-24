        IAffinity aff = m_ignite.GetAffinity(cacheName);
        IClusterNode localNode = m_ignite.GetCluster().GetLocalNode();
        Parallel.ForEach(rows, r => 
        {
            string key = GetKey(r);
            if (aff.IsPrimary(localNode, key))
            {
                KeyValuePair<string, IBinaryObject> pair = BuildRow(r);
                ds.AddData(pair);
            }
        });
