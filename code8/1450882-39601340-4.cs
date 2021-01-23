    class Taxonomy : ITaxonomy, ITaxonomyHasChildren<Taxonomy>, ITaxonomyHasParent<Taxonomy>
    {
    	public string CommonName { get; set; }
    	public string ScientificName { get; set; }
    	public Taxonomy Parent { get; set; }
    	public List<Taxonomy> Children { get; set; } = new List<Taxonomy>();
    	IReadOnlyCollection<Taxonomy> ITaxonomyHasChildren<Taxonomy>.Children => Children;
    }
