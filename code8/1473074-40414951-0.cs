    <#@ template debug="false" hostspecific="false" language="C#" #>
    <#@ assembly name="System.Core" #>
    <#@ import namespace="System.Linq" #>
    <#@ import namespace="System.Text" #>
    <#@ import namespace="System.Collections.Generic" #>
    <#@ output extension=".cs" #>
    <#  var designTimeVisibleValue = "false"; #>
    using System.Windows.Controls;
    using System.ComponentModel;
    namespace WpfCustomControlLibrary1
    {
        [DesignTimeVisible(<#=designTimeVisibleValue#>)]
        public partial class UserControl1 : UserControl{}
    
        [DesignTimeVisible(<#=designTimeVisibleValue#>)]
        public partial class UserControl2 : UserControl{}
    }
