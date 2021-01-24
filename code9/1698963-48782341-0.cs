        using System.Web.Mvc;
    
        public class MultiSelectViewModel {
    
            /// <summary>
            /// Selected values of the multi select.
            /// </summary>
            public string[] SelectedValues { get; set; }
    
            /// <summary>
            /// Possible options.
            /// </summary>
            public MultiSelectList AvailableOptions { get; set; }
        }
