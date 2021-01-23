    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Threading;
    namespace BgraVsPbgra {
        public partial class MainWindow : Window {
            readonly WrapPanel Panel;
            readonly TextBlock Output;
            readonly PixelFormat FN = PixelFormats.Bgra32;
            readonly PixelFormat FP = PixelFormats.Pbgra32;
            readonly List<long> TN = new List<long>();
            readonly List<long> TP = new List<long>();
            DateTime T0;
            long DT => (DateTime.Now - T0).Ticks;
            DateTime Now => DateTime.Now;
            public MainWindow() {
                InitializeComponent();
                SizeToContent = SizeToContent.WidthAndHeight;
                Title = "Bgra32 vs Pbgra Benchmark";
                Panel = new WrapPanel {
                    Width = 512,
                    Height = 512
                };
                Output = new TextBlock {
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    Foreground = new SolidColorBrush(Colors.White)
                };
                (Content as Grid).Children.Add(Panel);
                (Content as Grid).Children.Add(Output);
                Dispatcher.BeginInvoke(new Action(() => Start()), DispatcherPriority.SystemIdle);
            }
            private async void Start() {
                Output.Text += "Bgra32 vs Pbgra32 benchmark started.\r\n\r\n";
                var t0 = DateTime.Now;
                var n = 3;
                var i = 16384;
                for (var p = 1; p <= n; p++) {
                    Output.Text += $"\r\nPass {p}/{n}.\r\n\r\n";
                    await Benchmark(i / 4, 0.75, true);
                    await Benchmark(i / 4, 0.75, false);
                    await Benchmark(i / 4, 1, true);
                    await Benchmark(i / 4, 1, false);
                }
                var t = (DateTime.Now - t0).TotalSeconds;
                Output.Text += $"\r\nDone in {t:0.0}s.\r\n";
            }
            private async Task Benchmark(int n = 256, double opacity = 1, bool cheat = false) {
                Output.Text += $"Benchmarking with opacity = {opacity}...   ";
                if (cheat) Output.Text += "CHEATING!...   ";
                //Output.Text += "\r\n";
                for (int i = 0; i < n; i++) await Dispatcher.BeginInvoke(new Action(async () => await DrawTestAsync(opacity, cheat)), DispatcherPriority.Send);
                Output.Text += ($"Pbgra32 advantage: {(TN.Average() / TP.Average() * 100d - 100d):0.0}%\r\n");
            }
            async Task DrawTestAsync(double opacity = 1, bool cheat = false) {
                await Dispatcher.BeginInvoke(new Action(() => {
                    Panel.Children.Clear();
                    for (int i = 0; i < 8; i++) {
                        T0 = Now; Panel.Children.Add(new Image { Source = CreateBitmap(FP, cheat), Width = 128, Height = 128, Opacity = opacity }); TP.Add(DT);
                        T0 = Now; Panel.Children.Add(new Image { Source = CreateBitmap(FN, cheat), Width = 128, Height = 128, Opacity = opacity }); TN.Add(DT);
                    }
                }), DispatcherPriority.Send);
                
            }
            BitmapSource CreateBitmap(PixelFormat pixelFormat, bool cheat = false) {
                var bitmap = new WriteableBitmap(256, 256, 96, 96, pixelFormat, null);
                bitmap.Lock();
                unsafe
                {
                    var pixels = (uint*)bitmap.BackBuffer;
                    if (pixelFormat == FN || cheat)
                        for (uint y = 0; y < 256; y++) for (uint x = 0; x < 256; x++) pixels[x + y * 256] = 0x80000000u | (x << 16) | y;
                    else
                        for (uint y = 0; y < 256; y++) for (uint x = 0; x < 256; x++) pixels[x + y * 256] = 0x80000000u | (x / 2 << 16) | y / 2;
                }
                bitmap.Unlock();
                bitmap.Freeze();
                return bitmap;
            }
        }
    }
