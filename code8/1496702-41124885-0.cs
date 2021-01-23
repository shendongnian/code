    public interface IAnimal { }
    public interface IVertebrate<TAnimal> where TAnimal : IAnimal { }
    public interface IInvertebrate<TAnimal> where TAnimal : IAnimal { }
    public interface ISwimmingAnimal : IAnimal { }
    public interface ISwimmingVertebrate : IVertebrate<ISwimmingAnimal> { }
    public interface ISwimmingInvertebrate : IInvertebrate<ISwimmingAnimal> { }
