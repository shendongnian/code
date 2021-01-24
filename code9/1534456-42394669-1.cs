    List<Questions> Questions = _repo.GetQuestions();
        Questions = Questions.OrderBy(x => x.GroupAOrderNo).ToList();
    var  FilteredQuestions =
                    Questions.Where(a => GroupAorB == "A" ? a.ShowToGroupA : a.ShowToGroupB).Select(q => new Question
                    {
                        ID = q.ID,
                        AllowedResponse =
                            q.AllowedResponse.Where(r => GroupAorB == "A" ? r.ShowToGroupA : r.ShowToGroupB).ToList()
    
                    }).ToList();
    return Request.CreateResponse(HttpStatusCode.OK, Questions);
