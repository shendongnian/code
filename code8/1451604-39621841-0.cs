			DataCls ci = new DataCls();
			ci.Parse( "[AE][1W] Message:Console Station is not available Priority:Info Time:Sep 21 2016  1:13PM Tag:/System Components/R431ESV/Stations/Console Stations/CStn01" );
		}
		public class DataCls
		{
			public string Message { get; set; }
			public string Priority { get; set; }
			public DateTime Time { get; set; }
			public string Tag { get; set; }
			public void Parse( string parseStr )
			{
				const string MESSAGE_MARKER = "Message:";
				const string PRIORITY_MARKER = "Priority:";
				const string TIME_MARKER = "Time:";
				const string TAG_MARKER = "Tag:";
				this.Message = GetTextPart(parseStr, MESSAGE_MARKER, PRIORITY_MARKER );
				this.Priority = GetTextPart( parseStr, PRIORITY_MARKER, TIME_MARKER );
				this.Time = DateTime.Parse( GetTextPart( parseStr, TIME_MARKER, TAG_MARKER ) );
				this.Tag = GetTextPart( parseStr, TAG_MARKER, null );
			}
			private string GetTextPart( string text, string before, string after )
			{
				string result = null;
				int posBefore = text.IndexOf( before );
				if( after != null )
				{
					int posAfter = text.IndexOf( after );
					result = text.Remove( posAfter ).Substring( posBefore + before.Length ).TrimEnd();
				}
				else
					result = text.Substring( posBefore + before.Length );
				return result;
			}
		}
