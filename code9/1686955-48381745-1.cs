    <#@ template debug="false" hostspecific="true" language="C#" #>
    <#@ assembly name="System.Core" #>
    <#@ assembly name="System.Windows.Forms" #>
    <#@ output extension=".cs" #>
    
    namespace WpfApplication1 {
        public class LocResourceKey {
            private LocResourceKey(string key) {
                Key = key;
            }
    
            public string Key { get; }	
            <#using (var reader = new System.Resources.ResXResourceReader(this.Host.ResolvePath("Properties\\Resources.resx"))) {
                var enumerator = reader.GetEnumerator();
                while (enumerator.MoveNext()) {
    				Write("\r\n\t\t");
    				#>public static readonly LocResourceKey <#= enumerator.Key #> = new LocResourceKey("<#= enumerator.Key #>");<#				
                }
    			Write("\r\n");
            }#>
    	}
    }
