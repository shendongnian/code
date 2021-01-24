    // Follow links to build hashset of all linked tags
        static HashSet<int> followLinks(HashSet<int> testHs, List<HashSet<int>> pairs)
        {
            while (true)
            {
                var tester = new HashSet<int>(testHs);
                bool keepGoing = false;
                foreach (var p in pairs)
                {
                    if (testHs.Overlaps(p))
                    {
                        testHs.UnionWith(p);
                        keepGoing = true;
                    }
                }
                for (int i = pairs.Count - 1; i == 0; i-- )
                {
                    if (testHs.Overlaps(pairs[i]))
                    {
                        testHs.UnionWith(pairs[i]);
                        keepGoing = true;
                    }
                }
                    if (!keepGoing) break;
                if (testHs.SetEquals(tester)) break;
            }
            return testHs;
        }
