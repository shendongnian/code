    interface IResponseFormatter<T> {
        // Follow C# naming conventions: method names start in an upper case letter
        T FormatResponseOptimizated(T[] tagsValues);
    }
    public class FormatResponseInterpolatedData
         : IResponseFormatter<Dictionary<string,List<object[]>>> {
        public Dictionary<string,List<object[]>> FormatResponseOptimizated(Dictionary<string,List<object[]>>[] tagsValues) {
            ...
        }
    }
