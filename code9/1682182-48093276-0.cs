    public class DutyAssignmentEntry
    {
        private string _Week;
        private int _Template;
        private bool _WeeklyMode;
        private List<Assignment> _MidweekAssignments;
        private List<Assignment> _WeekendAssignments;
        private List<Assignment> _WeeklyAssignments;
        [XmlAttribute]
        public string Week
        {
            get => _Week; set => _Week = value;
        }
        [XmlAttribute]
        public int Template
        {
            get => _Template; set => _Template = value;
        }
        [XmlAttribute]
        public bool WeeklyMode
        {
            get => _WeeklyMode; set => _WeeklyMode = value;
        }
        public List<Assignment> MidweekAssignments
        {
            get => _MidweekAssignments; set => _MidweekAssignments = value;
        }
        [XmlIgnore]
        public bool MidweekAssignmentsSpecified
        {
            get { return (_MidweekAssignments.Count > 0); }
        }
        public List<Assignment> WeekendAssignments
        {
            get => _WeekendAssignments; set => _WeekendAssignments = value;
        }
        [XmlIgnore]
        public bool WeekendAssignmentsSpecified
        {
            get { return (_WeekendAssignments.Count > 0); }
        }
        public List<Assignment> WeeklyAssignments
        {
            get => _WeeklyAssignments; set => _WeeklyAssignments = value;
        }
        [XmlIgnore]
        public bool WeeklyAssignmentsSpecified
        {
            get { return (_WeeklyAssignments.Count > 0); }
        }
        public DutyAssignmentEntry()
        {
            _Week = "";
            _Template = -1;
            _WeeklyMode = true;
            _MidweekAssignments = new List<Assignment>();
            _WeekendAssignments = new List<Assignment>();
            _WeeklyAssignments = new List<Assignment>();
        }
    }
