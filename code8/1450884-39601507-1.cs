    public interface IParent<T> //note: general-purpose interface unrelated to taxonomies
    {
        ICollection<T> Children { get; }
    }
    public interface IChild<T> //note: general-purpose interface unrelated to taxonomies
    {
        T Parent { get; set; }
    }
    public interface ITaxonomy
    {
        string CommonName { get; set; }
        string ScientificName { get; set; }
        IParent<ITaxonomy> AsParent {get; } //returns `null` if not a parent
        IChild<ITaxonomy> AsChild {get; } //returns `null` if not a child
    }
    IChild<ITaxonomy> selectedEntityAsChild = selectedEntity.AsChild;
    if( selectedEntityAsChild != null )
    {
        ITaxonomy parent = selectedEntityAsChild.Parent;
        ...
    }
    IParent<ITaxonomy> selectedEntityAsParent = selectedEntity.AsParent;
    if( selectedEntityAsParent != null )
    {
        ICollection<ITaxonomy> children = selectedEntityAsParent.Children;
        ...
    }
