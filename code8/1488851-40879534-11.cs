    void ICompletionSource.AugmentCompletionSession(ICompletionSession session, IList<CompletionSet> completionSets)
            {
                Dictionary<string, string> strList = new Dictionary<string, string>();
                strList.Add("#adapt-samelevel", "Test1");
                strList.Add("abort", "Test2");
                strList.Add("#adapt-modified", "Test3");
                m_compList = new List<Completion>();
                foreach (KeyValuePair<string, string> kvp in strList)
                    m_compList.Add(new Completion(kvp.Key, kvp.Key, kvp.Value, null, null));
    
                completionSets.Add(new CompletionSet(
                    "Tokens",    //the non-localized title of the tab
                    "Tokens",    //the display title of the tab
                    FindTokenSpanAtPosition(session.GetTriggerPoint(m_textBuffer),
                        session),
                    m_compList,
                    null));
            }
