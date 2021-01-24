        public class Game
        {
            [Required]
            public int? Id { get; set; }
    
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
            public DateTime date { get; set; } // Validate the date format "YYYY-MM-DD"
         }
