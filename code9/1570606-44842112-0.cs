    public interface IGodObject { } //empty marker interface
    public interface IWriter { }
    public interface IReader { }
    public class GodObject : IGodObject, IReader, IWriter { }
    services.AddScoped<IGodObject>(p =>
    {
        return new GodObject();
    });
    services.AddScoped<IReader>(p =>
    {
        return p.GetService<IGodObject>() as IReader;
    });
    services.AddScoped<IWriter>(p =>
    {
        return p.GetService<IGodObject>() as IWriter;
    });
