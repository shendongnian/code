    [XmlElement]
    public List<Assignment> MidweekAssignments
    {
        get { return  _MidweekAssignments; } set {   _MidweekAssignments = value;}
    }
    private List<Assignment> _MidweekAssignments;
    [XmlElement]
    public List<Assignment> WeekendAssignments
    {
        get { return _WeekendAssignments; } set {   _WeekendAssignments = value;}
    }
    private List<Assignment> _WeekendAssignments;
    
    [XmlElement]
    public List<Assignment> WeeklyAssignments
    {
        get 
        {  return  _WeeklyAssignments;  } set {   _WeeklyAssignments = value;}
    }
    private List<Assignment> _WeeklyAssignments;
