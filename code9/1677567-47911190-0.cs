    namespace Yuri1
    {
    public partial class Yuri1Page : ContentPage
    {
        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            Stopwatch s = new Stopwatch();
            await Task.Run(() =>
            {
                s.Start();
                Task.Delay(3000).Wait();
            });
            MyEntry.Text="Text after long method: " + s.ElapsedMilliseconds.ToString();
        }
    
            //MyText.Text = "Text after long method" + s.ElapsedMilliseconds.ToString();        }
        public Yuri1Page()
            {
                InitializeComponent();
            }
 
    }
 
    }
