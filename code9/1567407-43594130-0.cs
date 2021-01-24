    public sealed class SearchFacetLinkViewModel {
       public string Name { get; set; }
       public string Link { get; set; }
    }
    public sealed class SearchFacetViewModel {
       public string Description { get; set; }
       public IEnumerable<SearchFacetViewModel> Links { get; set; }
       public string SelectedFacet { get; set; }
    }
