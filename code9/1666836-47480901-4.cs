    public class NumberEditorViewModel : BindableBase
    {
	    // subtypes ///////////////////////////////
	    public class SubTypeA
	    {
		    public string PrecisionType 
		    {
			    get { return _precisionType; } 
			    set { _precisionType = value; OnPropertyChanged ( ); }
		    }
		    private string _precisionType;
	    }
	
	    public class SubTypeB
	    {
		    public string INPC 
		    {
			    get { return _inpc; } 
			    set { _inpc = value; OnPropertyChanged ( ); }
		    }
		    private string _inpc;
	    }
	
	    // ctor ///////////////////////////////
	
	    public NumberEditorViewModel ( )
	    {
		    ExampleA = new SubTypeA ( );
		    ExampleB = new SubTypeB ( );
		
		    ExempleA.PropertyChanged += ( sender, e ) =>
		    {
			    if ( e.PropertyName == nameof ( SubTypeA.PrecisionType ) )
			    {
				    var exempleA = sender as ExempleA;
				
				    ExampleB.INPC = ... /* newValue calculated */
			    }
		    }
	    }
        public SubTypeA ExampleA { get; private set; }
        public SubTypeB ExampleB { get; private set; }
    }
