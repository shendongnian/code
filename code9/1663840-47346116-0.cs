    namespace Profile.Models
    {
        public class MainPageModel
        {
            public MainPageModel () {}
    
            public MainPageModel(Profiler profiler)
            {
                Profiler = profiler;
            }
    
            public Profiler Profiler { get; set; }
    
            public IFormFile Image{ get; set; }
    
        }
    }
