    using System;
    using System.Text;
    
    namespace ConsoleApplication
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			string textonorm, textobin = "", textobin1 = "", textocod = "";
    			int textval, quant, result, txtvalor;
    
    			Console.WriteLine("Digite a frase que deseja criptografar!");
    			textonorm = Console.ReadLine();
    
    			textval = System.Text.ASCIIEncoding.UTF8.GetByteCount(textonorm);
    			byte[] phrase = Encoding.ASCII.GetBytes(textonorm);
    
    			foreach (byte b in phrase)
    			{
    				textobin += Convert.ToString(b, 2);
    				textval = textobin.Length;
    			}
    
    			if (textval < 64)
    			{
    				quant = 64;
    				foreach (byte b in phrase)
    				{
    					textobin1 += Convert.ToString(b, 2);
    				}
    				textocod = textobin1.PadLeft(quant, '0');
    				txtvalor = textobin1.Length;
    				Console.WriteLine(textocod.ToString() + "\r\n " + "\r\n " + txtvalor.ToString());
    
    				char[] chararray = textocod.ToCharArray();
    				int[,] matrizval = new int[8, 8];
    
    				if (chararray.Length == 64)
    					for (int i = 0; i < 8; ++i)
    					{
    						for (int j = 0; j < 8; ++j)
    						{
    							int val = chararray[i * 8 + j] - '0';
    							Console.Write(val);
    							matrizval[i, j] = val;
    						}
    						Console.WriteLine();
    					}
    			}
    			else
    			{
    				Console.WriteLine("ok");
    			}
    
    			Console.Write("\nPress any key...");
    			Console.ReadKey();
    		}
    	}
    }
