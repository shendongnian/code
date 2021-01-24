    public class TeamMember {
        public int MemberId {get;set;}
        public int TeamId {get;set;}
        public bool IsManager {get;set;}
        public virtual User Member {get;set;}
        public virtual Team Team {get;set;}
    }
    //Either add an ID or use fluent API to define the key to be a combination of player/teamid
