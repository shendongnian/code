    static void Main(string[] args)
    {
        var one = new List<DataBlockBase>();
        one.Add(new DataBlockOne { Id = 1, CustomPropertyDataBlockOne = 314 });
    
        var two = new List<DataBlockBase>();
        two.Add(new DataBlockTwo { Id = 2, CustomPropertyDatablockTwo = long.MaxValue });
    
        AllData allData = new AllData
        {
            One = one,
            Two = two
        };
    
        #region Access Base Class Properties
        var result = (DataBlockBase)allData.GetType().GetProperty("One").GetValue(allData);
        var oneId = result.Id;
        #endregion
    
        #region Switch Into Custom Class Properties
        if (result is DataBlockTwo)
        {
            var thisId = result.Id;
            var thisCustomPropertyTwo = ((DataBlockTwo)result).CustomPropertyDatablockTwo;
        }
    
        if (result is DataBlockOne)
        {
            var thisId = result.Id;
            var thisCustomPropertyOne = ((DataBlockOne)result).CustomPropertyDataBlockOne;
        }
        #endregion
    
    
        Console.Read();
    }
    
    
    public class AllData
    {
        public List<DataBlockBase> One { get; set; }
        public List<DataBlockBase> Two { get; set; }
    }
    
    public class DataBlockOne : DataBlockBase
    {
        public int CustomPropertyDataBlockOne { get; set; }
    }
    
    public class DataBlockTwo : DataBlockBase
    {
        public long CustomPropertyDatablockTwo { get; set; }
    }
    
    public abstract class DataBlockBase
    {
        public int Id { get; set; }
    }
