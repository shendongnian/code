    public interface JSONConvertable
    {
        void Initialise(JSONNode node);
    }
    public class JSONArrayConverter<T> where T : JSONConvertable, new()
    {
        public JSONArrayConverter(JSONNode p)
        {
            JSONArray tab = p.AsArray;
            IList<T> result = new List<T>();
            for (int i = 0; i < tab.Count(); i++)
            {
                JSONNode value = tab[i];
                result[i] = new T();
                result[i].Initialise(value);
            }
        }
    }
