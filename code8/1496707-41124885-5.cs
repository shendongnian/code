    public interface IAnimalsCollection<TAnimal, TVertebrate, TInvertebrate>
        where TAnimal: IAnimal
        where TVertebrate: IVertebrate<TAnimal>
        where TInvertebrate: IInvertebrate<TAnimal>
    {
        IEnumerable<IAnimal> Animals { get; }
        IEnumerable<TVertebrate> Vertebrates { get; }
        IEnumerable<TInvertebrate> Invertebrates { get; }
        ....
    }
    public class AnimalsCollection<TAnimal, TVertebrate, TInvertebrate> : IAnimalsCollection<TAnimal, TVertebrate, TInvertebrate>
        where TAnimal : IAnimal
        where TVertebrate : IVertebrate<TAnimal>
        where TInvertebrate : IInvertebrate<TAnimal>
    {
        public AnimalsCollection(IEnumerable<TVertebrate> vertebrates, IEnumerable<TInvertebrate> invertebrates)
        {
            Vertebrates = vertebrates;
            Invertebrates = invertebrates;
        }
        public IEnumerable<IAnimal> Animals => Vertebrates.Cast<IAnimal>().Concat(Invertebrates.Cast<IAnimal>());     
        public IEnumerable<TInvertebrate> Invertebrates { get; }
        public IEnumerable<TVertebrate> Vertebrates { get; }
    }
