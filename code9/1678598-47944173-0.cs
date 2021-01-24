    public class OtherProgramType
    {
      public OtherProgramType(string s, string pn, short? ptid, string dt)
      {
        this.State = s;
        this.PrgName = pn;
        this.ProgramTypeID = ptid;
        this.DisplayText = dt;
      }
      
      public string State { get; set; }
      public string PrgName { get; set; }
      public short? ProgramTypeID { get; set; }
      public string DisplayText { get; set; }
    }
