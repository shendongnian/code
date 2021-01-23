    public class ProcessViewModel
    {
      public int Id {get;set;}
      public bool ShowDivOne {get;set;}
      public bool ShowDivTwo {get;set;}
    
      ProcessViewModel(){}
      ProcessViewModel(ItemProcess data){
        Id = data.Id;
        ShowDivOne = data.DivOneVisible.HasValue ? data.DivOneVisible.Value : false;
        ShowDivTwo = data.DivTwoVisible.HasValue ? data.DivTwoVisible.Value : false;
      }
    }
