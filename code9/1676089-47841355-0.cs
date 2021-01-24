    void Main() {
        var beeps = new[] {
            new Beep(500, 1000, 200),
            new Beep(1000, 1000, 300),
            new Beep(300, 2000, 150),
            new Beep(500, 500, 200),
        };
    
        Song.PlayBeeps(beeps);
    }
    
    // Define other methods and classes here
    public struct Beep {
        readonly public int Amplitude;
        readonly public int Frequency;
        readonly public int Duration;
    
        public Beep(int a, int f, int d) {
            Amplitude = a;
            Frequency = f;
            Duration = d;
        }
    }
    
    public class Song {
        public static void PlayBeeps(params Beep[] beeps) {
            int Bytes = beeps.Sum(b => 4*(441 * b.Duration / 10));
    
            int[] Hdr = { 0X46464952, 36 + Bytes, 0X45564157, 0X20746D66, 16, 0X20001, 44100, 176400, 0X100004, 0X61746164, Bytes };
    
            using (MemoryStream MS = new MemoryStream(44 + Bytes)) {
                using (BinaryWriter BW = new BinaryWriter(MS)) {
                    for (int I = 0; I < Hdr.Length; I++) {
                        BW.Write(Hdr[I]);
                    }
                    foreach (var beep in beeps) {
                        double A = ((beep.Amplitude * (System.Math.Pow(2, 15))) / 1000) - 1;
                        double DeltaFT = 2 * Math.PI * beep.Frequency / 44100.0;
    
                        int Samples = 441 * beep.Duration / 10;
                        for (int T = 0; T < Samples; T++) {
                            short Sample = System.Convert.ToInt16(A * Math.Sin(DeltaFT * T));
                            BW.Write(Sample);
                            BW.Write(Sample);
                        }
                        BW.Flush();
                    }
    
                    MS.Seek(0, SeekOrigin.Begin);
                    using (var SP = new SoundPlayer(MS)) {
                        SP.PlaySync();
                    }
                }
            }
        }
    }
