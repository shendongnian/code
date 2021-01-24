    class TestViewModel : ViewModelBase
    {
       private TestModel model = new TestModel();
       public string DisplayValue
      {
         get{return model.DisplayValue;}
         set{ Set(()=>DisplayValue, ref model.DisplayValue, value); }
      }   
    }
