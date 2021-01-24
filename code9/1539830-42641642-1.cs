    <Assembly Name="*Application*" Dynamic="Required All" />    
   
    <!--Add your application specific runtime directives here.--> 
    <Namespace Name="System.Collections.ObjectModel" >
     <TypeInstantiation Name="ReadOnlyCollection" 
           Arguments="ContosoClient.DataModel.ProductGroup" Serialize="Public"/> 
     <TypeInstantiation Name="ObservableCollection"
           Arguments="ContosoClient.DataModel.ProductItem" Serialize="Public" />
     <TypeInstantiation Name="ReadOnlyObservableCollection"
           Arguments="ContosoClient.DataModel.ProductGroup" Serialize="Public" />     
    </Namespace>
