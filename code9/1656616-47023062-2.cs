    public partial class MyView : UserControl, IMySpecificViewService
    ...
    public MyView()
    { 
        var vm = (MyViewModel)this.DataContext;
        vm.ViewService = (IMySpecificViewService)this;
    } 
    public void ChangeButtonColor(Brush color)
    {
        Button2.Background = color;
    }  
