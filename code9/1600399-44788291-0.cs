    var questions = entities.Answers
                            .Where(answer => answer.aapprove == 1)
                            .GroupBy(answer => answer.Question_qid)
                            .Select(group => new {
                                Question = group.First().Question,
                                Answers = group;
                            });
