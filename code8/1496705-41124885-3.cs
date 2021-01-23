    public interface IAnimalsCollection<TAnimal, TVertebrate, TInvertebrate>
        where TAnimal: IAnimal
        where TVertebrate: IVertebrate<TAnimal>
        where TInvertebrate: IInvertebrate<TAnimal>
    {
        IEnumerable<TAnimal> Animals { get; }
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
        public IEnumerable<TAnimal> Animals => Vertebrates.Cast<TAnimal>().Concat(Invertebrates.Cast<TAnimal>());     
        public IEnumerable<TInvertebrate> Invertebrates { get; }
        public IEnumerable<TVertebrate> Vertebrates { get; }
    }
