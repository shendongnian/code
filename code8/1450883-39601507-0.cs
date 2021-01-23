    public interface IParent<T>
    {
        ICollection<T> Children { get; }
    }
    public interface IChild<T>
    {
        T Parent { get; set; }
    }
    public interface ITaxonomy
    {
        string CommonName { get; set; }
        string ScientificName { get; set; }
        IParent<ITaxonomy> AsParent {get; }
        IChild<ITaxonomy> AsChild {get; }
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
