		public class OstacolisRuntime
		{
			public int CodiceOstacolo { get; set; }
			public int TipoOstacolo { get; set; }
			public int Tipologia { get; set; }
			public string Nome { get; set; }
			public double PosizioneX { get; set; }
			public double PosizioneY { get; set; }
			public double PosizioneZ { get; set; }
			public double AngoloX { get; set; }
			public double AngoloY { get; set; }
			public double AngoloZ { get; set; }
			public double ScalaX { get; set; }
			public double ScalaY { get; set; }
			public double ScalaZ { get; set; }
			public List<SubOggetto> SubOggettos { get; set; } //sub
		}
		public class SubOggetto
		{
			public string Immagine { get; set; }
			public int Tipologia { get; set; }
			public string Nome { get; set; }
			public double PosizioneX { get; set; }
			public double PosizioneY { get; set; }
			public double PosizioneZ { get; set; }
			public double AngoloX { get; set; }
			public double AngoloY { get; set; }
			public double AngoloZ { get; set; }
			public double ScalaX { get; set; }
			public double ScalaY { get; set; }
			public double ScalaZ { get; set; }
			public List<SubOggetto> SubOggettos { get; set; } //recursive relashioship
		}
		public class RootObject
		{
			public List<OstacolisRuntime> OstacolisRuntime { get; set; }
		}
