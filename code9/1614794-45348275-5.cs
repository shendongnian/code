	-----
	D:\Infx\work\cs>cat s.cs
	using System;
	using System.IO;
	using System.Data;
	using System.Text;
	using IBM.Data.Informix;
	using System.Windows.Forms;
	class sample {
		static void Main(string[] args) {
	try
	{
		 using (IfxConnection conn = new IfxConnection("Server=ids1210;Database=enus1252;uid=informix;pwd=ximrofni;DB_LOCALE=en_US.1252"))
		 {
			  conn.Open();
			  using (IfxCommand cmd = conn.CreateCommand())
			  {
				  cmd.CommandText = "select * from t1";
				  IfxDataReader rd = cmd.ExecuteReader();
				  rd.Read();
				  do
				  {
					   if (rd.HasRows)
							Console.WriteLine("c1= {0}", rd[0]);
				  } while (rd.Read());
			  }
		  }
	  }
	  catch (IfxException exc)
	  {
		   Console.WriteLine("Update: {0}", exc.Message);
		   foreach (IfxError error in exc.Errors)
			   Console.WriteLine("Error: ({1}): {0}", error.Message,  error.NativeError);
	  }
	}
	}
	D:\Infx\work\cs>csc.exe /R:D:\infx\csdk410tc8w2\bin\netf20\IBM.Data.Informix.dll /nologo s.cs /platform:x86
