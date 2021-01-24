cs
public class WorkItem
{
    [JsonProperty("System.Id")]
    public int Id { get; set; }
    [JsonProperty("System.TeamProject")]
    public string Project { get; set; }
    [JsonProperty("System.State")]
    public string State { get; set; }
    [JsonProperty("System.Title")]
    public string Title { get; set; }
}
then implement custom type converter using `Newtonsoft.Json` serializer under the hood:
cs
public class WorkItemTypeConverter : ITypeConverter<IDictionary<string, object>, WorkItem>
{
    public WorkItem Convert(IDictionary<string, object> source, WorkItem destination, ResolutionContext context)
    {
        var json = JsonConvert.SerializeObject(source);
        return JsonConvert.DeserializeObject<WorkItem>(json);
    }
}
and specify it's usage in AutoMapper configuration:
cs
Mapper.Initialize(cfg =>
{
    cfg.CreateMap<IDictionary<string, object>, WorkItem>()
        .ConvertUsing<WorkItemTypeConverter>();
});
I based my answer on [this one](https://stackoverflow.com/a/7310568/8065832) by Darin Dimitrov.
