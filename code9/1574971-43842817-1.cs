    class Program
    {
        static (double lat, double lng) GetLatLng(string address)
        {
            return (1, 1);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var ll = GetLatLng("some address");
            Console.WriteLine($"Lat: {ll.lat}, Long: {ll.lng}");
        }
    }
