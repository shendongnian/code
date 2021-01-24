	`@model IPagedList<WebApplication3.Models.TopicAndDetails>
     @{ string topic = ""; }
	...
	@foreach (var item in Model)
	{...
			@Html.DisplayFor(modelItem => item.Topic)
            topic = item.Topic;
	...
	}..
	@using (Html.BeginForm("Index", "QuestionAndAnswer", FormMethod.Post))
	{
		   @Html.TextBoxFor(model => topic) 
		   <button type="submit" class="btn btn-default" value="submit">Submit</button>
	}`
