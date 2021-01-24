    internal class MyBaseActivity : Activity
    {
        protected override void OnResume ()
        {
            base.OnResume ();
    
            // Get the language from wherever.
            var userSelectedCulture = new CultureInfo ("fr-FR");
    
            Thread.CurrentThread.CurrentCulture = userSelectedCulture;
        }
    }
