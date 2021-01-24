    using System.Data;
    using System.Data.Sql;
    
    var instances = SqlDataSourceEnumerator.Instance.GetDataSources();
    foreach (DataRow instance in instances.AsEnumerable())
    {
        Console.WriteLine($"ServerName: {instance["ServerName"]}; "+
           " Instance: {instance["InstanceName"]}");
    }
