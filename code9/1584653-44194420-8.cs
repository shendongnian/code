     [HttpPost]
     public ActionResult SaveOrUpdateQuestionsMaster(QuestionsMasterModel objQuestionsMasterModel)
     {
          //Save objQuestionsMasterModel data to database here 
          objQuestionsMasterModel= //Feach all data from database in this model for show on the QuestionsAction view 
          return PartialView("QuestionsAction", objQuestionsMasterModel);
     }
