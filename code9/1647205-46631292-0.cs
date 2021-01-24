    using System.Linq;
    
    // 1. Get source collection of the CollectionViewSource
    IEnumerable source = AllCRSP.SourceCollection;
    
    // 2. Make it generic using Linq OfType<> method 
    IEnumerable<SPFetchCREntity> source_typed = source.OfType<SPFetchCREntity>();
    // 3. You can filter your list using Linq Where method
    IEnumerable<SPFetchCREntity> source_typed_filtered = source_typed.Where(obj => obj != null && entity.SW_Version == SearchMU.ToString());
    // 4. Get string equivalent of your objects using Linq Select method
    IEnumerable<string> source_string = source_typed_filtered.Select(obj => <...something like obj.ToString()...>);
 
    // 5. Convert it ToList using Linq
    List<string> list = source_string.ToList();
