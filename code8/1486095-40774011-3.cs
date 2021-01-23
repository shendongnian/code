    public static void ReadSeatPrices() {
        using (var reader = new StreamReader(File.OpenRead("seat.txt"))) {
            int i = 0;
            while (!reader.EndOfStream) {
                var double result;
                if (double.TryParse(reader.ReadLine(), out result)) {
                    seatprices[i] = result;
                    i++;
                } else {
                   //something goes wrong
                }
            }
        }
    }
