        //GET: All Diary events
		[NoCache]
		public JsonResult GetDiaryEvents(string start, string end)
			{
			// code code code...
			var rows = eventList.ToArray();
			return Json(rows, JsonRequestBehavior.AllowGet);
			
			}
