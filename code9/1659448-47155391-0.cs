        var group = new BsonDocument
        {
            { "$group",
                new BsonDocument
                    {
                        { "_id", new BsonDocument { { "Country","$Country" },
                                                    { "Staff_ID", "$Staff_ID" },
                                                    { "Trans_Year", "$WeCare.CustSatisfaction.Trans_Year" },
                                                    { "Trans_Month", "$WeCare.CustSatisfaction.Trans_Month" }
                                                  }
                        },
                        { "CustPastAnswers", new BsonDocument { { "$push",
                                                                new BsonDocument { { "SurveyComment", "$WeCare.CustPastAnswers.SurveyComment" } } 
                                                                }
                                                              }                            
                        },
                        { "HH", new BsonDocument { { "$sum", "$WeCare.CustSatisfaction.HH" } }
                        }
                    }
             }
         };
