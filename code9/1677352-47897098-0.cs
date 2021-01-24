    public interface IInstanceComparer<T>
    {
        IEnumerable<PropertyDifference> GetDifferences(T left, T right);
    }
    public abstract class InstanceComparer<T> : IInstanceComparer<T>
    {
        public IEnumerable<PropertyDifference> GetDifferences(T left, T right)
        {
            var result = new List<PropertyDifference>();
            PopulateDifferences(left, right, result);
            return result;
        }
        public abstract void PopulateDifferences(T left, T right, 
           List<PropertyDifference> differences);
    }
    public class PropertyDifference
    {
        public PropertyDifference(string propertyName, string leftValue, 
            string rightValue)
        {
            PropertyName = propertyName;
            LeftValue = leftValue;
            RightValue = rightValue;
        }
        public string PropertyName { get; }
        public string LeftValue { get; }
        public string RightValue { get; }
    }
    public class Animal
    {
        public string Name { get; }
        public int NumberOfLimbs { get; }
        public DateTime Created { get; }
    }
    public class AnimalDifferenceComparer : InstanceComparer<Animal>
    {
        public override void PopulateDifferences(Animal left, Animal right, 
            List<PropertyDifference> differences)
        {
           if(left.Name != right.Name) 
               differences.Add(new PropertyDifference("Name", left.Name, right.Name));
           if(left.NumberOfLimbs!=right.NumberOfLimbs) 
               differences.Add(new PropertyDifference("NumberOfLimbs", 
                   left.NumberOfLimbs.ToString(), 
                   right.NumberOfLimbs.ToString()));
        }
    }
