        public HttpResponseMessage GetNote(string ExamId, string QuestionId)
        {
            try
            {
                decimal exid = Convert.ToDecimal(ExamId);
                decimal qid = Convert.ToDecimal(QuestionId);
                var temp = new MemberQuestionsRepository().FirstOrDefault(x => x.MemberExamId == exid && x.QuestionId == qid);
                if (temp != null)
                {
                    var note = temp.Note;
                    return Request.CreateResponse(HttpStatusCode.OK, note);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "No Note Found");
                }
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.ExpectationFailed);
            }
        }
