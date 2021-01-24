        string myName = "Steve";
        this.textBox1.Text = string.Format( "{0}{1}", Test.Greeting, myName );
    
        public class Test
        {
            public static string Greeting { get; set; } = "My Name is: ";
        }
