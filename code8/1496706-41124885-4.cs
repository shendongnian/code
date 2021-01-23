    public interface IAnimal { }
    public interface IVertebrate<out TAnimal>: IAnimal where TAnimal : IAnimal { }
    public interface IInvertebrate<out TAnimal>: IAnimal where TAnimal : IAnimal { }
    public interface ISwimmingAnimal : IAnimal { }
    public interface ISwimmingVertebrate : IVertebrate<ISwimmingAnimal> { }
    public interface ISwimmingInvertebrate : IInvertebrate<ISwimmingAnimal> { }
