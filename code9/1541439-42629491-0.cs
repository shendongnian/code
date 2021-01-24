    using System.Linq;
    using System.Collections.Generic;
    /// <summary>
    /// Base-Class
    /// </summary>
    public abstract class Thing
    {
        private ICollection<Thing> _things;
        public Thing()
        {
            _things = new List<Thing>();
        }
        public void AddSomething(Thing toAdd)
        {
            _things.Add(toAdd);
        }
        /// <summary>
        /// Assuming that every type can only appear once
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public T GetComonentOfType<T>() where T : Thing
        {
            return this.GetComonentOfType(typeof(T)) as T;
        }
        public Thing GetComonentOfType(Type t)
        {
            return _things.Where(x => x.GetType() == t).Single();
        }
    }
    /// <summary>
    /// One possible implementation
    /// </summary>
    public class SpecialThing : Thing
    {
    }
