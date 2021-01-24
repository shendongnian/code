    public class ToolTypeModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        //  In case of nothing working, break glass.
        //  
        //  If you may have more than one instance of ToolTypeModel with the 
        //  same Id and Name, you'll need this commented code so the combobox 
        //  will consider them the same value. Overriding Equals() can cause 
        //  weird side effects, so I avoid it if I can. 
        /*
        public override bool Equals(object obj)
        {
            return (obj is ToolTypeModel)
                        ? (obj as ToolTypeModel).Id == Id
                        : false;
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
        */
    }
