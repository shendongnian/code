csharp
public class MyResults
{
    public MyResults()
    {
        this.Items= new Collection<MyElement>();
    }
    public MyRequest RequestDetails { get; set; }
    public Collection<MyElement> Items { get; set; }
}
