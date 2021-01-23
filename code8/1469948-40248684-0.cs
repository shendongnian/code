    static private Int32 AttendeeRef;
    static public int attendeeref
    {
        get
        {
            return AttendeeRef;
        }
        set
        {
            if (value <= 40000 && value >= 60000)
            {
                throw new ArgumentException("Attendee Ref must be between 40000 and 60000!");
            }
            AttendeeRef = value;
        }
    }
