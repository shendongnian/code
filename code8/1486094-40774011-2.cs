    public static void ReadSeatPrices() {
        using (var reader = new StreamReader(File.OpenRead("seat.txt"))) {
            int i = 0;
            while (!reader.EndOfStream) {
                seatprices[i] = reader.ReadLine();
                i++;
            }
        }
    }
