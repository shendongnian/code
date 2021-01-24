    [XmlRoot(ElementName = "Step")]
    public class WorkflowStep
    {
        [XmlAnyElement("Action")]
        [XmlAnyElement("NewAction")]
        public XmlElement[] Actions
        {
            get;
            set;
        }
    }
