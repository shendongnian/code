    EntityTypeConfiguration<tblMeetings> MeetingsType = builder.EntitySet<tblMeetings>("Meetings").EntityType;
    MeetingsType.HasKey(p => p.Meeting_ID);
    
    var MeetingsFunctionBadges = MeetingsType.Collection.Function("Badges");
    MeetingsFunctionBadges.Parameter<int>("key");
    MeetingsFunctionBadges.Returns<List<tblBadges>>();
