    public interface ITracksCurrentUser
    {
       Guid CurrentUserID {get;set;}
    }
    public class MyTable : ITracksCurrentUser
    {
        public DateTime Requested { get; set; }
        public Guid RequestedUserID { get; set; }
        public Guid ITracksCurrentUser.CurrentUserID
        {
          get { return RequestedUserID;}
          set { RequestedUserID = value;}
        }
    }
    public override int SaveChanges()
    {
       foreach(userentity in ChangeTracker.Entries().Select(e => e.Entity).OfType<ITracksCurrentUser>())
           userentity.CurrentUserID = Session["UserID"];
    }
