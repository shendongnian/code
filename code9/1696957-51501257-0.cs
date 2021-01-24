    public abstract class AttribDoubleReader: IReadOnlyDictionary<string, AttributeValue>
    {
     public double this[string key] => GetValue(key);
     private double GetValue(string key)
     {
        if (TryGetValue(key, out AttributeValue value))
        {
            return value.AsDouble();
        }
        else
        {
            MessageBox.Show("ERROR: KEY "+ key + " NOT FOUND.");
            throw new KeyNotFoundException();
        }
     }
    }
