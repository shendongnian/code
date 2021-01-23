		using System;
		namespace ConsoleApplication8
		{
			class Tape
			{
				public Tape(int length, int width)
				{
					len = length;
					wid = width;
				}
				public int len { get; set; }
				public int wid { get; set; }
				public override string ToString()
				{
					return string.Format("{0}\nLength: {1}\nWidth: {2}", GetType(), len, wid);
				}
			}
			class VideoTape : Tape
			{
				public int PlayTime { get; set; }
				public VideoTape(int length, int width, int playTime)
					: base(length, width)
				{
					PlayTime = playTime;
				}
				public override string ToString()
				{
					return string.Format("{0}\nPlay Time: {1}", base.ToString(), PlayTime);
				}
			}
			class AdhesiveTape : Tape
			{
				private int _stickiness;
				public AdhesiveTape(int length, int width, int stickiness)
					: base(length, width)
				{
					Stickiness = stickiness;
				}
				public int Stickiness
				{
					get { return _stickiness; }
					set
					{
						if (value >= 1 && value <= 10)
							_stickiness = value;
						else
							_stickiness = 0;
					}
				}
				public override string ToString()
				{
					return string.Format("{0}\nStickiness: {1}",
						base.ToString(), (Stickiness == 0) ? "Invalid Input" : Stickiness.ToString());
				}
			}
			class Test
			{
				static void Main(string[] args)
				{
					var tape = new Tape(100, 10);
					var videoTape = new VideoTape(50, 5, 200);
					var adhesiveTape = new AdhesiveTape(500, 8, 8);
					Console.WriteLine(tape);
					Console.WriteLine(videoTape);
					Console.WriteLine(adhesiveTape);
					Console.ReadLine();
				}
			}
		}
