	/// <summary>
	/// Splits the file name if it contains an executable AND an argument.
	/// </summary>
	public static void CheckSplitFileName( ref string fileName, ref string arguments )
	{
		if ( !string.IsNullOrEmpty( fileName ) )
		{
			if ( fileName.IndexOf( @"http://" ) == 0 ||
				fileName.IndexOf( @"https://" ) == 0 ||
				fileName.IndexOf( @"ftp://" ) == 0 ||
				fileName.IndexOf( @"file://" ) == 0 )
			{
				// URLs not supported, skip.
				return;
			}
			if ( File.Exists( fileName ) )
			{
				// Already a full path, do nothing.
				return;
			}
			else if ( Directory.Exists( fileName ) )
			{
				// Already a full path, do nothing.
				return;
			}
			else
			{
				// Remember.
				string originalFileName = fileName;
				if ( !string.IsNullOrEmpty( fileName ) )
				{
					fileName = fileName.Trim();
				}
				if ( !string.IsNullOrEmpty( arguments ) )
				{
					arguments = arguments.Trim();
				}
				// --
				if ( string.IsNullOrEmpty( arguments ) &&
					!string.IsNullOrEmpty( fileName ) && fileName.Length > 2 )
				{
					if ( fileName.StartsWith( @"""" ) )
					{
						int pos = fileName.IndexOf( @"""", 1 );
						if ( pos > 0 && fileName.Length > pos + 1 )
						{
							arguments = fileName.Substring( pos + 1 ).Trim();
							fileName = fileName.Substring( 0, pos + 1 ).Trim();
						}
					}
					else
					{
						int pos = fileName.IndexOf( @" " );
						if ( pos > 0 && fileName.Length > pos + 1 )
						{
							arguments = fileName.Substring( pos + 1 ).Trim();
							fileName = fileName.Substring( 0, pos + 1 ).Trim();
						}
					}
				}
				// --
				// Possibly revert back.
				if ( !string.IsNullOrEmpty( fileName ) )
				{
					string s = fileName.Trim( '"' );
					if ( !File.Exists( s ) && !Directory.Exists( s ) )
					{
						fileName = originalFileName;
					}
				}
			}
		}
	}
