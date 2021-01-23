	[System.Runtime.InteropServices.StructLayout( System.Runtime.InteropServices.LayoutKind.Sequential, Pack = 4 )]
	public struct Move {
		private static readonly BitVector32.Section SEC_COLOR = BitVector32.CreateSection( 1 );
		private static readonly BitVector32.Section SEC_ORIGIN = BitVector32.CreateSection( 63, SEC_COLOR );
		private static readonly BitVector32.Section SEC_DESTINATION = BitVector32.CreateSection( 63, SEC_ORIGIN );
		private BitVector32 low;
		private BitVector32 high;
		public PlayerColor Color {
			get {
				return (PlayerColor)low[ SEC_COLOR ];
			}
			set {
				low[ SEC_COLOR ] = (int)value;
			}
		}
		public int Origin {
			get {
				return low[ SEC_ORIGIN ];
			}
			set {
				low[ SEC_ORIGIN ] = value;
			}
		}
		public int Destination {
			get {
				return low[ SEC_DESTINATION ];
			}
			set {
				low[ SEC_DESTINATION ] = value;
			}
		}
	}
