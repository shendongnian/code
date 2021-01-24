    public abstract class GroupEventualityDto
    {
        public int Id { get; set; }
        public int IdGroup { get; set; }
        public int IdEventuality { get; set; }
    }
    public class GroupEventualityDto<T> : GroupEventualityDto
    {
      
        public T Value { get; set; }
    }
    public static void Main(string[] args)
    {
        var one = new GroupEventualityDto<int>() {Value = 123};
        var two = new GroupEventualityDto<string>() {Value = "string"};
        var three = new GroupEventualityDto<double>() {Value = 45.54};
        var list = new List<GroupEventualityDto>()
        {
            one,
            two,
            three
        };
        foreach (var val in list)
        {
            Console.WriteLine(val.GetType());
        }
    }
