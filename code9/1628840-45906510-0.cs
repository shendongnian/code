    using Android.App;
    using Android.Widget;
    using Android.OS;
    using Xamarin.Forms;
    using ZXing.Mobile;
    using System;
    
    namespace QRCodeReader
    {
        [Activity(Label = "QRCodeReader", MainLauncher = true, Icon = "@drawable/icon")]
        public class MainActivity : Activity
        {
            MobileBarcodeScanner scanner;
            protected override void OnCreate(Bundle bundle)
            {
                base.OnCreate(bundle);
                Forms.Init(this, bundle);
                MobileBarcodeScanner.Initialize(Application);
    
                try
                {
                    bool Scanning = true;
                    var scanner = new MobileBarcodeScanner();
                    scanner.UseCustomOverlay = false;
                    scanner.TopText = "Hold camera up to barcode to scan";
                    scanner.BottomText = "Barcode will automatically scan";
                    scanner.CancelButtonText = "Done";
                    scanner.FlashButtonText = "Flash";
    
                    Device.StartTimer(TimeSpan.FromSeconds(3), () =>
                    {
                        scanner.AutoFocus();
                        if (Scanning)
                            return true;
                        else
                            return false;
                    });
    
                    scanner.Scan().ContinueWith(t =>
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        Scanning = false;
                        if (t.Result != null)
                        {
                            Toast.MakeText(this, t.Result.Text, ToastLength.Long).Show();
                        }
                    }));
                }
                catch (Exception ex)
                {
                    Toast.MakeText(this, ex.Message.ToString(), ToastLength.Long).Show();
                    // Handle exception
                }
            }
        }
    }
