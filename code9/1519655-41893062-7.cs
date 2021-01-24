    /// <summary>
    /// Safe, managed WMI queries support.
    /// </summary>
    static class WMI {
    /// <summary>
    /// Queries WMI and returns results as an array of dynamic objects.
    /// </summary>
    /// <param name="q"></param>
    /// <returns></returns>
    public static dynamic[] Query(string q) {
        using (var s = new ManagementObjectSearcher(q))
            return
                s
                .Get()
                .OfType<ManagementObject>()
                .Select(i => {
                    var x = new ExpandoObject();
                    using (i) foreach (var p in i.Properties) (x as IDictionary<string, object>).Add(p.Name, p.Value);
                    return x;
                })
                .ToArray();
        }
    }
