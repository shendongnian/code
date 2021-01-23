    public class Test
    {
       [Required]
       [StringIdLengthRange(Minimum = 10, Maximum = 20)]
       public string Id { get; set; }
    }
