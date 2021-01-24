        // namespace used to organize code not required
        var VisitMeNameSpace = {
	    var currentUser = GetCurrentUser();
    	var pageName = GetPage();
    	var visitMe_GetVisitMeVisitors = "ProjectName/VisitMe/GetVisitMeVisitors";
		var args = {
					page: pagename
				   }
        
		$.ajax({
				url: visitMe_GetVisitMeVisitors,
				type: "GET",
				data: args
			})
			.done(function (data) {
				if (data is good)
					$("selector").removeClass("disabled");
			})
			.fail(function(){
				alert("There was a problem getting visitor IDs for this page");
			});
	}// end VisitMeNameSpace 
        // In your C# controller maybe something like 
        public JsonResult GetVisitMeVisitors(string page)
		{
			// whatever you are currently using to query database do that here. We will call this from VisitMe.js
			var visitContainer = new ProjectContainerForVisitMe();
			var visitRecords = (from record in visitContainer.VisitMeTableOrModel where record.page == page select record).ToList();
			return Json(visitRecords, JsonRequestBehavior.AllowGet);
		}
