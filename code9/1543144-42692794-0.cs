    private Lazy<InnerItem> _details = new Lazy<Details>(() => new InnerItem {/*use some default initialization here if you need*/} ); 
    public InnerItem Display
    {
       get {
           return _details.Value;
       }
    }
