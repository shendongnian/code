	 [HttpPost] 
	 public ActionResult Index( string topic) 
	 { 
		TopicAndDetails newtopic = new TopicAndDetails(); 
		newtopic.Topic = topic; 
		db.Topics.Add(newtopic); 
		db.SaveChanges(); 
		return RedirectToAction("Index"); 
	}
