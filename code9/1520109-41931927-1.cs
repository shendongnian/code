    public sealed partial class MainPage : Page
    {
        public ObservableCollection<Test> cc { get; set; }
        public MainPage()
        {
            this.InitializeComponent();
            cc = new ObservableCollection<Test>();
            cc.Add(new Test() {Length=200,Brush= new SolidColorBrush(Colors.Red),Num=1 });
            cc.Add(new Test() { Length = 150, Brush = new SolidColorBrush(Colors.Blue), Num = 2 });
            cc.Add(new Test() { Length = 100, Brush = new SolidColorBrush(Colors.LightCyan), Num = 3 });
            cc.Add(new Test() { Length = 50, Brush = new SolidColorBrush(Colors.SandyBrown), Num = 4 });
            this.DataContext = this;
        }
    }
    public class Test
    {
        public double Length { get; set; }
        public SolidColorBrush Brush { get; set; }
        public int Num { get; set; }
    }
    public class MyItemResizer : IItemResizer
    {
        public Size Resize(object item, Size oldSize, Size availableSize)
        {
            return new Size(availableSize.Width, oldSize.Height);
        }
    }
