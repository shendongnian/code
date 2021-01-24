    public enum GenderModel
    {
        NotSpecified = 0,
        Male = 1,
        Female = 2
    }
    public enum GenderDto
    {
        NotSpecified = 0,
        Male = 1,
        Female = 2
    }
    public class Person1
    {
        public GenderModel Gender { get; set; }
    }
    public class Person2
    {
        public GenderDto Gender { get; set; }
    }
    public class EnumMapInjection:IValueInjection
    {
        public object Map(object source, object target)
        {
            StaticValueInjecter.DefaultInjection.Map(source, target);
            if (target is Person2 && source is Person1)
            {
                ((Person2) target).Gender = (GenderDto)((Person1) source).Gender;
            }
            return target;
        }
    }
