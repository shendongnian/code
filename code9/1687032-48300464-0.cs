        public class Game
        {
            [Required]
            public int? Id { get; set; }
    
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
            public DateTime date { get; set; } // Validate the date format "YYYY-MM-DD"
         }
