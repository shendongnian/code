//Where K is key
//where T is a generic entity which may be a programming language
public interface ICoder<K, T>
{
Task Program();
Task LearnNewLanguage(T Language);
K GetCoderId();
}
and your implementation
public class CoderImplementation<TDbContext> : ICoder<string, ProgrammingLanguage> where TDbContext : DbContext
{
private readonly TDbContext _edu;
public CoderImplemtation(TDbContext edu)
{
_edu = edu;
}
public Task Program()
{
...start programming by 12 to 6
}
public Task LearnNewLanguage(string Name)
{
_edu.AddLanguage(Name);
}
}
By telling it that `TDbContext` is of type `DbContext` you can be able to access methods which a `DbContext` exposes
even though that `DbContext` is not known
