    using Windows.UI.Xaml.Controls;
    using Xamarin.Forms;
    using Xamarin.Forms.Platform.UWP;
    [assembly: ResolutionGroupName("YOURAPP")]
    [assembly: ExportEffect(typeof(YOURAPP.UWP.Effects.SwitchEffect), nameof(YOURAPP.UWP.Effects.SwitchEffect))]
    namespace YOURAPP.UWP.Effects
    {
        public class SwitchEffect : PlatformEffect
        {
            protected override void OnAttached()
            {
                if (Control is ToggleSwitch switchControl)
                {
                    switchControl.OffContent = string.Empty;
                    switchControl.OnContent = string.Empty;
                }
            }
            protected override void OnDetached()
            { }
        }
    }
