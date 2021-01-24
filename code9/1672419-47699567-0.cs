    using System;
    using System.Data.SqlClient;
    using System.Data.SqlTypes;
    using System.Data;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    
    namespace ConsoleApplication2
    {
    	class Program
    	{
    		private static string connectionString = "Data Source=localhost;Initial Catalog=my_test_db;Integrated Security=True;";
    
    		public static string ImageToBase64(Image image, ImageFormat imageFormat)
    		{
    			using (MemoryStream ms = new MemoryStream())
    			{
    				image.Save(ms, imageFormat);
    				byte[] imageBytes = ms.ToArray();
    				string base64String = Convert.ToBase64String(imageBytes);
    				return base64String;
    			}
    		}
    		public static Image Base64ToImage(string base64String)
    		{
    			byte[] imageBytes = Convert.FromBase64String(base64String);
    			using (MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
    			{
    				ms.Write(imageBytes, 0, imageBytes.Length);
    				Image image = Image.FromStream(ms, true);
    				return image;
    			}
    		}
    
    		static void Main(string[] args)
    		{
    			string image1base64;
    
    			using(Bitmap image1 = (Bitmap) Image.FromFile("C:\\test1.png"))
    				image1base64 = ImageToBase64((Image)image1, ImageFormat.Png);
    
    			using (SqlConnection sqlConnection = new SqlConnection(connectionString))
    			{
    				sqlConnection.Open();
    
    				using (SqlCommand sqlCommand = new SqlCommand("create table #base64test(id int not null, base64image varchar(max));", sqlConnection))
    					sqlCommand.ExecuteNonQuery();
    
    				using (SqlCommand sqlCommand = new SqlCommand("insert #base64test(id, base64image) values(@id, @base64image)", sqlConnection))
    				{
    					sqlCommand.Parameters.Add("@id", SqlDbType.Int);
    					sqlCommand.Parameters["@id"].Value = 1;
    
    					sqlCommand.Parameters.Add("@base64image", SqlDbType.VarChar, -1);
    					sqlCommand.Parameters["@base64image"].Value = image1base64;
    
    					sqlCommand.ExecuteNonQuery();
    				}
    
    				using (SqlCommand sqlCommand = new SqlCommand("select base64image from #base64test where id = @id", sqlConnection))
    				{
    					sqlCommand.Parameters.Add("@id", SqlDbType.Int);
    					sqlCommand.Parameters["@id"].Value = 1;
    
    					using (SqlDataReader rd = sqlCommand.ExecuteReader(CommandBehavior.SequentialAccess))
    					{
    						if (rd.Read() == false)
    							throw new ApplicationException("An error occurred ...");
    
    						object[] temp = new object[rd.FieldCount];//[1]
    
    						// read BLOB trick
    						if (rd.GetSqlValues(temp) != rd.FieldCount)
    							throw new ApplicationException("An error occurred ...");
    
    						Image image2 = Base64ToImage(((SqlString)temp[0]).ToString());
    						image2.Save("C:\\test2.png", ImageFormat.Png);
    					}
    				}
    			}
    		}
    	}
    }
