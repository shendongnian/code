	public class ActivityLog
	{
		[BsonId]
		public int Id { get; set; }
		public DbRef<User> User { get; set; }
		public string Action { get; set; }
		public DateTime ActionDateTime { get; set; }
	}
	public class User
	{
		[BsonId]
		public int Id { get; set; }
		public string UserId { get; set; }
		public string UserName { get; set; }
		public DateTime LoginDate { get; set; }
	}
  
    //usage
	// Getting user and activityLog collections
	var usersCollection = db.GetCollection<User>("Users");
	var activityLogsCollection = db.GetCollection<ActivityLog>("ActivityLogs");
	// Creating a new User instance
	var user = new User { UserId = 5, ...};
	usersCollection.Insert(user);
	// Create a instance of ActivityLog and reference to User John
	var activityLog = new ActivityLog
	{
		OrderNumber = 1,
		OrderDate = DateTime.Now,
        //Add it by DbRef
		User = new DbRef<User>(usersCollection, user.UserId)
	};
	activityLogsCollection.Insert(activityLog)
