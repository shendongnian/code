    using FestivalHolledauApp.iOS;
    using UIKit;
    using Xamarin.Forms;
    using Xamarin.Forms.Platform.iOS;
    using System.Linq;
    
    [assembly: ExportRenderer(typeof(SearchBar), typeof(CustomSearchBarRenderer))]
    namespace FestivalHolledauApp.iOS
    {
        public class CustomSearchBarRenderer : SearchBarRenderer
        {
            protected override void OnElementChanged(ElementChangedEventArgs<SearchBar> e)
            {
                base.OnElementChanged(e);
    
                // Fixing Cancel button
                if (e.NewElement != null)
                {             
                    this.Control.TextChanged += (s, ea) =>
                    {
                        this.Control.ShowsCancelButton = true;
                        SetCancelButtonText();
                    };
    
                    this.Control.OnEditingStarted += (s, ea) => //when control receives focus
                    {
                        this.Control.ShowsCancelButton = true;
                        SetCancelButtonText();
                    };
    
                    this.Control.OnEditingStopped += (s, ea) => //when control looses focus 
                    {
                        this.Control.ShowsCancelButton = false;
                    };
                }
            }
    
            private void SetCancelButtonText()
            {
                var cancelButton = Control.Descendants().OfType<UIButton>().FirstOrDefault();
                if (cancelButton != null)
                {
                    cancelButton.SetTitle("Schließen", UIControlState.Normal);
                }
            }
        }
    }
