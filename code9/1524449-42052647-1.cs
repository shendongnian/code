    public class Student {
    
        public Student() {
            LendedBooks = new List<LendedBook>();
        }
    
        [Key]
        public string PESEL { get; set; }
    
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Surname { get; set; }
        public string Class { get; set; }
    	
        public virtual List<LendedBook> LendedBooks { get; set; }
    }
    
    public class Book {
    
        public Book() {
        }
    
        [Key]
        public string CatalogueNumber { get; set; }
    
        public string Name { get; set; }
        public string Author { get; set; }
    }
    
    public class LendedBook
    {
        public DateTime DateOfLend { get; set; }
        public DateTime? DateOfReturn { get; set; }
    	
    	// TODO: Annotations, ForeignKey
    	public string StudentPesel { get; set; }
        public virtual Student Student { get; set; }
    	
    	// TODO: Annotations, ForeignKey
    	public string CatalogueNumber { get; set; }
        public virtual Book Book { get; set; }
    }
    
    public static void AddBookToStudent(Student student, Book book) {
    	using (var context = new DbContext()) {
    		var findStudent = context.Students.Find(student.PESEL);
    		var findBook = context.Books.Find(book.CatalogueNumber);
    		
    		if (findBook != null) {
    			// Something like ...
    			findStudent?.LendedBooks.Add(new LendedBook() {
    				DateOfLend = DateTime.Today,
    				DateOfReturn = book.DateOfLend + new TimeSpan(7, 0, 0, 0),
    				Book = findBook
    			});
    			
    			context.SaveChanges();
    		}
    	}
    }
