    public abstract class AccountBase
    {
        public string PrimaryAccountHolder 
        { 
            get { … } 
            set { … }
        }
        public string SecondaryAccountHolder
        { 
            get { … } 
            set 
            { 
                …  
                if (RequiresSecondaryAccountHolder && value == null) throw …;
                …  
            } 
        }
        public abstract bool RequiresSecondaryAccountHolder { get; }
    }
