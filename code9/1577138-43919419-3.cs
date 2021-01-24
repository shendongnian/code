      public class INSC_InscriptionMetadata
      {
        [Display(Name = "Mobile Phone")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Enter a valid format")] //Vérifie le format du tel
        public object TelephoneMobile { get; set; }
    
        [Display(Name = "Home Phone")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Enter a valid format")] //Vérifie le format du tel
        public object TelephoneMaison { get; set; }
      }
