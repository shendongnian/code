    public class Author
    {
      public int Number { get; set; }
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public void Show()
      {
        MessageBox.Show($"Author Number: {Number}\nAuthor First Name: {FirstName}\nAuthor Last Name: {LastName}");
      }
