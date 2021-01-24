    using System;
    using System.Collections.Generic;
    using System.Text;
    
    
    [assembly: Xamarin.Forms.Dependency(typeof(DE2.ILocSettings))]
    namespace DE2
    {
        public interface ILocSettings
        {
    	    void OpenSettings();
    
    	}
