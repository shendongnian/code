                    foreach (var nextRd1 in nextRefs1)
                    {
                        Console.WriteLine("   + {0}, {1}, {2}", nextRd1.DisplayName, nextRd1.BrowseName, nextRd1.NodeClass);
                        try
                        {
                            var _node = ExpandedNodeId.ToNodeId(nextRd1.NodeId, session.NamespaceUris);
                            DataValue dv2 = session.ReadValue(_node);
                        }
