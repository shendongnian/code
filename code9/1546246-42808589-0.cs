    //The UserControl you created
	[Designer(typeof(UserControlDesigner))]
    [DefaultEvent("TextChanged")]
    public partial class UserControl : UserControl
    {
		//The property where we will store the UserControlDesigner instance when it is created
		internal UserControlDesigner Designer;
		
		//Initialize the UserControl
		public UserControl()
		{
			//Check for design time
			if (DesignMode)
				//Set the individual value to this UserControlDesigner instance's property
				Designer.DesignerProperty = 1;
		}
	}
	
	//The custom ControlDesigner should used to design your UserControl
	internal class UserControlDesigner : ControlDesigner
    {
		//The UserControl which is designed with this instance
        internal UserControl DesignedControl;
		
		//The Property you want to change each copy of your UserControl individually
        internal int DesignerProperty;
		
		//The method which is called when the UserControlDesigner instance is created
        public override void Initialize(IComponent component)
        {
            base.Initialize(component);
			
			//Cast the IComponent which is designed with this designer instance to your UserControl class
            DesignedControl = component as UserControl;
			
			//Check for successful cast
            if (DesignedControl != null)
				//Store this UserControlDesigner instance in the property "Designer" which we've created to access the instance in design time
                DesignedControl.Designer = this;
        }
    }
