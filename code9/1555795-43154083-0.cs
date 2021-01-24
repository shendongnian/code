    //Your custom control in your PCL project
    public partial class PhrasesFrameRendererClass : Frame
    {
        public static readonly BindableProperty SwipeLeftCommandProperty = 
        BindableProperty.Create(nameof(SwipeLeftCommand), typeof(ICommand), typeof(PhrasesFrameRendererClass ), null);
        public ICommand SwipeLeftCommand
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }
    }
    //Your custom control renderer
    public class PhraseFrameCustomRenderer : FrameRenderer
    {
       UISwipeGestureRecognizer leftSwipeGestureRecognizer;
       protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
       {
           base.OnElementChanged(e);
           leftSwipeGestureRecognizer = new UISwipeGestureRecognizer();
           leftSwipeGestureRecognizer.Direction = UISwipeGestureRecognizerDirection.Left;
           leftSwipeGestureRecognizer.NumberOfTouchesRequired = 1;
           leftSwipeGestureRecognizer.AddTarget((obj) =>
           {
               var myFrame = Element as PhrasesFrameRendererClassl
               if(myFrame != null){
                   if(myFrame.SwipeLeftCommand != null && myFrame.SwipeLeftCommand.CanExecute()){
                       myFrame.SwipeLeftCommand.Execute();
                   }
               }
           });
       }
    }
    //Your ViewModel
    public class PhrasesViewModel{
    
        public Command GetRandomWordsCommand {get;set;}
        
        public PhrasesViewModel(){
            GetRandomWordsCommand = new Command(ExecuteGetRandomWords);
        }
    
        private void ExecuteGetRandomWords(){
       
        //Your method goes here
        
        }
    
    }
    //Your XAML
    <yourControls:PhrasesFrameRendererClass SwipeLeftCommand="{Binding GetRandomWordsCommand }"/>
