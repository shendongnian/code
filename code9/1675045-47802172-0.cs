    enum SomeClassType {
    	None,
    	InstantiableClass1,
    	InstantiableClass2
    }
    
    class CustomTextBox : TextBox
    {
    	private int _number = 0;
    	private SomeClassType _someClassType = SomeClassType.None;
    
     	[EditorBrowsable(EditorBrowsableState.Never)]
        public SomeAbstractClass SomeProperty { get; set; }
    	
    	[DefaultValue(0)]
    	public int Number { 
    		get { return _number; }
    		set { _number = value; CreateSomeClass(); }
    	}
    	
    	[DefaultValue(SomeClassType.None)]
    	public SomeClassType SomeClassType {
    		get { return _someClassType; }
    		set { _someClassType = value; CreateSomeClass(); }
    	}
    	
    	private void CreateSomeClass() {
    		switch (_someClassType) {
    			case SomeClassType.InstantiableClass1:
    				SomeProperty = new InstantiableClass1(_number);
    				break;
    			case SomeClassType.InstantiableClass2:
    				SomeProperty = new InstantiableClass2(_number);
    				break;
    			default:
    				SomeProperty = null;
    				break;
    		}
    	}
    }
