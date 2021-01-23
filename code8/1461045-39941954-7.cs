    private SpeechRecognitionEvent ParseRecognizeResponse(IDictionary resp){
            if (resp == null)
                return null;
            
            List<SpeechRecognitionResult> results = new List<SpeechRecognitionResult>();
            IList iresults = resp["results"] as IList;
            if (iresults == null)
                return null;
            foreach (var r in iresults)
            {
                IDictionary iresult = r as IDictionary;
                if (iresults == null)
                    continue;
                SpeechRecognitionResult result = new SpeechRecognitionResult();
                
                //added this section, starting here
                IDictionary iKeywords_result = iresult["keywords_result"] as IDictionary;
                result.keywords_result = new KeywordResults();
                List<KeywordResult> keywordResults = new List<KeywordResult>();
                foreach (string key in keywordsToCheck) {
                    if (iKeywords_result[key] != null) {
                        IList keyword_Results = iKeywords_result[key] as IList;
                        if (keyword_Results == null) {
                            continue;
                        }
                        foreach (var res in keyword_Results) {
                            IDictionary kw_resultDic = res as IDictionary;
                            KeywordResult keyword_Result = new KeywordResult();
                            keyword_Result.confidence = (double)kw_resultDic["confidence"];
                            keyword_Result.end_time = (double)kw_resultDic["end_time"];
                            keyword_Result.start_time = (double)kw_resultDic["start_time"];
                            keyword_Result.normalized_text = (string)kw_resultDic["normalized_text"];
                            keywordResults.Add(keyword_Result);
                        }
                    }
                }
                result.keywords_result.keyword = keywordResults.ToArray();                   
                //ends here
                result.final = (bool)iresult["final"];
                IList ialternatives = iresult["alternatives"] as IList;
                if (ialternatives == null)
                    continue;
                List<SpeechRecognitionAlternative> alternatives = new List<SpeechRecognitionAlternative>();
                foreach (var a in ialternatives)
                {
                    IDictionary ialternative = a as IDictionary;
                    if (ialternative == null)
                        continue;
                    SpeechRecognitionAlternative alternative = new SpeechRecognitionAlternative();
                    alternative.transcript = (string)ialternative["transcript"];
                    if (ialternative.Contains("confidence"))
                        alternative.confidence = (double)ialternative["confidence"];
                    if (ialternative.Contains("timestamps"))
                    {
                        IList itimestamps = ialternative["timestamps"] as IList;
                        TimeStamp[] timestamps = new TimeStamp[itimestamps.Count];
                        for (int i = 0; i < itimestamps.Count; ++i)
                        {
                            IList itimestamp = itimestamps[i] as IList;
                            if (itimestamp == null)
                                continue;
                            TimeStamp ts = new TimeStamp();
                            ts.Word = (string)itimestamp[0];
                            ts.Start = (double)itimestamp[1];
                            ts.End = (double)itimestamp[2];
                            timestamps[i] = ts;
                        }
                        alternative.Timestamps = timestamps;
                    }
                    if (ialternative.Contains("word_confidence"))
                    {
                        IList iconfidence = ialternative["word_confidence"] as IList;
                        WordConfidence[] confidence = new WordConfidence[iconfidence.Count];
                        for (int i = 0; i < iconfidence.Count; ++i)
                        {
                            IList iwordconf = iconfidence[i] as IList;
                            if (iwordconf == null)
                                continue;
                            WordConfidence wc = new WordConfidence();
                            wc.Word = (string)iwordconf[0];
                            wc.Confidence = (double)iwordconf[1];
                            confidence[i] = wc;
                        }
                        alternative.WordConfidence = confidence;
                    }
                    alternatives.Add(alternative);
                }
                result.alternatives = alternatives.ToArray();
                results.Add(result);
            }
            return new SpeechRecognitionEvent(results.ToArray());                        
        }
