    public class SomeOtherClass
    {
        // One option is to have a public property that can be set
        public Form1 FormInstance { get; set; }
        // Another option is to have it set in a constructor
        public SomeOtherClass(Form1 form1)
        {
            this.FormInstance = form1;
        }
        // A third option would be to pass it directly to the method
        public void AMethodThatChecksForm1(Form1 form1)
        {
            if (form1 != null && form1.Checked)
            {
                // Do something if the checkbox is checked
            }
        }
        // This method uses the local instance of the Form1 
        // that was either set directly or from the constructor
        public void AMethodThatChecksForm1()
        {
            AMethodThatChecksForm1(this.FormInstance);
        }
    }
