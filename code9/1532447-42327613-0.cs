    using System.ComponentModel.DataAnnotations;
    namespace ... {
        public class Review : Atom
        {
            /// <summary>
            ///     Name
            /// </summary>
    #if __MOBILE__
            // Xamarin iOS or Android-specific code
            [Required]
            [Display(Name = "Name")]
            [StringLength(40, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
            [DataType(DataType.Text)]
    #endif
            public string Autor { get; set; }
        }
    }
