    public partial class My : UserControl
    {
    // this will make the ambiguity with the existing trigges-DP legacy accessor
    public int Triggers {get;set;}
    
    // this will not make ambiguities, because it hides the original.
    // however it may cause other problems
    public new object Background {get;set; }
    
    // also OK, but needs justification as well.
    public override object ExistingVirtualProperty {get;set; }
    ...
