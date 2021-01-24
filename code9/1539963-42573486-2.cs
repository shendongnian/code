    public class Appointment
    {
      public DateTime TimeStamp { get; } = DateTime.UtcNow;
      public string User { get; } =
        System.Security.Principal.WindowsPrincipal.Current.Identity.Name;
      public string Subject{ get; } = "New Subject"
    }
