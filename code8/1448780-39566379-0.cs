    public class CourseList
    {
       [DataMember]
       public int CourseID { get; set; }
       [DataMember]
       public string CourseCategoryCode { get; set; }
       [DataMember]
       public string BoardCode { get; set; }
       [DataMember]
       public string CourseCode { get; set; }
       [DataMember]
       public string CourseName { get; set; }
       [DataMember]
       public string CourseDisplayName { get; set; }
       [DataMember]
       public string CourseShortName { get; set; }
       public ObservableCollection<Productdetails> Course_Products { get; set; }
