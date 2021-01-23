    class Program
    {
        static void Main(string[] args)
        {
            string email = "test@test.com";
            string emailTwo = "test2@subdomain.host.com";
            Uri uri = new Uri($"mailto:{email}");
            Uri uriTwo = new Uri($"mailto:{emailTwo}");
            string emailOneHost = uri.Host;
            string emailTwoHost = uriTwo.Host;
            Console.WriteLine(emailOneHost); // test.com
            Console.WriteLine(emailTwoHost); // subdomain.host.com
            Console.ReadKey();
        }
    }
