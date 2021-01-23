    public interface Containers
    {
        // common properties
    }
    public class Picture : Containers
    {
        
    }
    public class Parameter : Containers
    {
        
    }
    public class SetupStep<T> where T:Containers
    {
        public ObservableCollection<T> Containers { get; set; }
    }
    public class PictureContainer:SetupStep<Picture>
    {
        public ObservableCollection<Picture> Content { get; set; }
    }
    public class ParameterContainer
    {
        public ObservableCollection<Parameter> Content { get; set; }
    }
