    public class PerformanceViewModel
    {
    
        public PerformanceViewModel(CustomPerformanceePerformersModel model)
        {
            PerformanceId = model.performanceObj.PerformanceId;
            IsVisible = model.performanceObj.IsVisible;
            IsFeatured = model.performanceObj.IsFeatured;
        }
        public int PerformanceId { get; set; }
    
        public bool IsVisible { get; set; }
    
        public bool IsFeatured { get; set; }
    
    
        public void Update(CustomPerformancePerformersModel model)
        {
            model.performanceObj.IsVisible = IsVisible;
            model.performanceObj.IsFeatured = IsFeatured;
        }
    }
