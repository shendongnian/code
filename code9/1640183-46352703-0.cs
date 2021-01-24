    <#@ template debug="false" hostspecific="false" language="C#" #>
    using System.Reflection;
    [assembly: AssemblyVersion("1.0.6.<#= this.RevisionNumber #>")]
    [assembly: AssemblyFileVersion("1.0.6.<#= this.RevisionNumber #>")]
    <#+
        int RevisionNumber = (int)(DateTime.UtcNow - new DateTime(2000,1,1)).TotalHours;
    #>
