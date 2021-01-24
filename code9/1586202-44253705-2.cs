    public class PT
    {
        public int Col1 { get; set; }
        ...
        public virtual CH CH { get; set; } // optional, do not put [Required] attribute
    }
    public CH
    {
        public int Col1 { get; set; }
        ...
        [Required] // CH table needs PT table for the 1-1 relationship
        public PT PT { get; set; }
    }
   
    PT_CH_ViewModel viewModel = new PT_CH_ViewModel()
    {
        PTCol1 = pt.Col1,
        PTCol2 = pt.Col2,
        PTCol3 = pt.Col3,
        CHCol1 = pt.CH.Col1,
        CHCol2 = pt.CH.Col2
    };
    
    
    return View(viewModel);
