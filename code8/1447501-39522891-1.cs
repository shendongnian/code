    <Directives xmlns="http://schemas.microsoft.com/netfx/2013/01/metadata">
      <Application>
        <!--
          An Assembly element with Name="*Application*" applies to all assemblies in
          the application package. The asterisks are not wildcards.
        -->
        <Assembly Name="*Application*" Dynamic="Required All" />
        
        <!-- Add your application specific runtime directives here. -->
    
        <!-- Make all members of a type visible to .NET Native -->
        <Type Name="Columns" Dynamic="Required All" DataContractSerializer="All" />
        <Type Name="Rows" Dynamic="Required All" DataContractSerializer="All" />
        <Type Name="CellData" Dynamic="Required All" DataContractSerializer="All" />
    
        <Namespace Name="System.Collections.Generic">
          <TypeInstantiation Name="Dictionary" Arguments="System.String, System.Object" Dynamic="Required All" DataContractSerializer="Required All" />
          <TypeInstantiation Name="List" Arguments="CellData" Dynamic="Required All" DataContractSerializer="All" />
        </Namespace>
        
        <Namespace Name="Windows.ApplicationModel">
              <TypeInstantiation Name="PackageVersion" Arguments="System.UInt16, System.UInt16, System.UInt16, System.UInt16" Dynamic="Required All" DataContractSerializer="Required All" />      
        </Namespace>
        
        <Namespace Name="Windows.UI">
          <TypeInstantiation Name="Color" Arguments="System.Byte, System.Byte, System.Byte, System.Byte" Dynamic="Required All" DataContractSerializer="Required All"/>
        </Namespace>
    
        <Namespace Name="Windows.UI.Xaml">
          <TypeInstantiation Name="TextAlignment" Arguments="System.Enum" Dynamic="Required All" DataContractJsonSerializer="Required All"/>
        </Namespace>
    
    
      </Application>
    </Directives>
