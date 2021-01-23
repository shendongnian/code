    [MetaDataType(typeof(EmployeeMetaData))]
    public partial class Employee
    {
       [Column("Description")]
       public string DescriptionAdd
       {
          set { }
          get { return DateTime.Now.ToString("dd MMM yyyy : hh:mm tt") + " by " + Core.Authorization.LoginUser.Current.FullName + " <span style='display:none;'>" + Core.Authorization.LoginUser.Current.EmailAddress + "</span> " + value + "<br />"; }
       }
    }
    public class EmployeeMetaData
    {
       [NotMapped]
       public string Description
       {
          get;
          set;
       }
    }
