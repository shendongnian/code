    public class User : IMandatoryFields
    {
    private byte active;
    public byte Active
        {
            get
            {
                if (active == 1 && this.LocalActive == 1 && this.GlobalActive == 1) return 1;
                else return 0;
            }
            set { active = value; }
        }
    }
     public byte? LocalActive { get; set; } 
     public byte? GlobalActive { get; set; } 
