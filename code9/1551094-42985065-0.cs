			// prime read
			string line = "Type School\r\nName St Peter's\r\nPlace Denver\r\nType Student\r\nName Karl\r\nPlace Boulder\r\nName Raul\r\nPlace Denver";
			List<string> Students = line.Substring ( line.IndexOf ( "Type Student" ) + 12 ).Split ( new string [ ] { "\r\nName" }, StringSplitOptions.RemoveEmptyEntries ).ToList ( );
			foreach ( string student in Students )
			{
				string [ ] info = student.Replace ( "Place ", "" ).Split ( new [ ] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries );
				string Name = info [ 0 ].Trim ( );
				string Place = info [ 1 ].Trim ( );
			}
