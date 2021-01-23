    class Program 
    {
        private static List<float> list = new List<float>();
        static void Main() {
            // see your code
            // ......
            com.Close();
            // Write list to file
            System.IO.File.WriteAllLines("data.txt", list.Select(p => p.ToString()));
            // convert list to array
            float[] floatArray = list.ToArray();
        }
        private static void RxHandler(object sender, SerialDataReceivedEventArgs e) {
            // see your code
            // ......
            sp.Read(buffer, 0, bytes);
            // store float in variable
            float f = ToFloat(new byte[] { buffer[0], buffer[1], buffer[2], buffer[3] }));
            Console.WriteLine(f);
            // add float to list
            list.Add(f);
        }
