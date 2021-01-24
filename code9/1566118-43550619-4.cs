    static void Main(string[] args)
        {
            var value = "MyString";
            using (var sha256 = SHA256.Create())
            {
                var hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(value));
                var hash = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
                Console.WriteLine(hash);
            }
            using (var sha256 = SHA256.Create())
            {
                var hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(value));
                var hash = BitConverter.ToInt64(hashBytes.Take(8).ToArray(), 0);
                hash = IPAddress.HostToNetworkOrder(hash);
                Console.WriteLine(hash);
            }
            using (var md5 = MD5.Create())
            {
                var hashBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(value));
                var hash = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
                Console.WriteLine(hash);
            }
            using (var md5 = MD5.Create())
            {
                var hashBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(value));
                var hash = BitConverter.ToInt64(hashBytes.Take(8).ToArray(), 0);
                hash = IPAddress.HostToNetworkOrder(hash);
                Console.WriteLine(hash);
            }
            Console.ReadLine();
        }
