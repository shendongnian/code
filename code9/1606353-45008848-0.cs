    public class ConditionalDoAction {
    
        // initialize this with the conditions when this shall be performed 
        public ActionItemToPerform Condition { get; set; }
    
        // TODO: tweak delegate to match your method signatures...
        public Action<CurrentParameters> Do { get; set; }
    }
