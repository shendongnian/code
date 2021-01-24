            var result = surveyEntities.Candidates
                .GroupJoin(
                    surveyEntities.Votes,
                    c => c.CandidateID,
                    v => v.CandidateID,
                    (c, v) => new {
                        Name = c.Name,
                        ID = c.CandidateID,
                        Pic = c.Image,
                        Votes = v.Count() }
                );
