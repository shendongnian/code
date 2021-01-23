    public interface BaseContainer
    {
        // common properties
    }
    public class Picture : BaseContainer
    {
        
    }
    public class Parameter : BaseContainer
    {
        
    }
    interface SetupStep<T> where T:BaseContainer
    {
        ObservableCollection<T> Containers { get; set; }
    }
    public class PictureContainer:SetupStep<Picture>
    {
        
        public ObservableCollection<Picture> Containers { get; set; }
    }
    public class ParameterContainer : SetupStep<Parameter>
    {
        public ObservableCollection<Parameter> Containers { get; set; }
    }
