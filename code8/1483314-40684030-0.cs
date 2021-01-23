	@{
		var i = 0;
		var posts = Session["num"] as List<class_project.Models.Post>;
		if (posts != null)
		{
			foreach (class_project.Models.Post item in posts)
			{
				 <p>@item.PropertyOne</p>
				 <p>@item.PropertyTwo</p>
			}
		}
	} 
