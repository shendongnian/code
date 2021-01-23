	@{
		//var i = 0; //You can delete this variable.
		var posts = Session["num"] as List<class_project.Models.Post>;
		if (posts != null)
		{
			//foreach (class_project.Models.Post item in posts)
			//the same as "foreach (var item in posts)"
			foreach (var item in posts)
			{
				 <p>@item.PropertyOne</p>
				 <p>@item.PropertyTwo</p>
			}
		}
	} 
