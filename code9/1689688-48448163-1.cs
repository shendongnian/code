    var groups = response.Aggs.Nested("specifications").Terms("groups");
                    foreach(var bucket in groups.Buckets)
                    {
                        rtxAggs.AppendText(bucket.Key);
                        var values = bucket.Terms("attribute");
                        foreach(var valBucket in values.Buckets)
                        {
                            rtxAggs.AppendText(Environment.NewLine);
                            rtxAggs.AppendText("  " + valBucket.Key + "(" + valBucket.DocCount + ")");
                        }
                        rtxAggs.AppendText(Environment.NewLine);
                    }
