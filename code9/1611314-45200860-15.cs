    [Serializable]
    public partial class EmployeeToJobTitleMatchLink
    {
        public EmployeeToJobTitleMatchLink()
        {
            //this.Id = Guid.NewGuid(); /* this works in conjuction with <generator class="assigned"></generator>   */
        }
    
    
        //EF Tweaks
        public Guid TheEmployeeUUID { get; set; }
        public Guid TheJobTitleUUID { get; set; }
    
        public Guid? LinkSurrogateUUID { get; set; }
    
        /*  These are "scalar properties of the ~~relationship~~  */
        public int PriorityRank { get; set; }
        public DateTime JobStartedOnDate { get; set; }
    
        public Employee TheEmployee { get; set; }
        public JobTitle TheJobTitle { get; set; }
    }
