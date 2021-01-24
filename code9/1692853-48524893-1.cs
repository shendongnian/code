    Dictionary<string, object> assignees = new Dictionary<string, object>();
	foreach (string assignment in assignments.Keys)
	{
		assignees.Add(assignment, new NewAssignment());
	}
	var body = new
	{
		planId,
		bucketId,
		title,
		assignments = assignees,
		dueDateTime
	};
