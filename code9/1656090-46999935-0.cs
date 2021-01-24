    using System;
    using System.IO;
    using System.Text;
    using System.Collections.Generic;
    
    class Transformer {
    	readonly StreamReader _input;
    	readonly Dictionary<string, char> _str2Char;
    	
    	public Transformer(Stream stream, Dictionary<string, char> str2Char) {
    		_input = new StreamReader(stream);
    		_str2Char = str2Char;
    	
    	}
    	public Stream Transfrom() {
    		var output = new StreamWriter(new MemoryStream());
    		
    		int c = -1;
    		// Buffer to keep read chars
    		var buffer = new StringBuilder();
    		// Read until the end of stream (-1)
    		while ((c = _input.Read()) != -1) {
    			char ch = (char)c;
    			// We separate input stream by upper char
    			if (char.IsUpper(ch)) {
    				if (buffer.Length >= 2) {
    					var str = buffer.ToString();
    					// We have to process "KeyOemcomma" individually
    					bool isSpecialCase = str == "Key" && ch == 'O';
    					if (!isSpecialCase) {
    						WriteToOutput(str, output);
    						buffer.Clear();
    					}
                        // Here should be more logic, if it was not "KeyOemcomma"
    					buffer.Append(ch);
    				}
    				else buffer.Append(ch);
    			}
    			else buffer.Append(ch);
    		}
    		if (buffer.Length > 0) {
    			WriteToOutput(buffer.ToString(), output);
    			buffer.Clear();
    		}
    		output.Flush();
    		return output.BaseStream;
    	}
    	
    	void WriteToOutput(string str, StreamWriter output) {
    		// Console.WriteLine(str);
    		char c;
    		if (_str2Char.TryGetValue(str, out c))
    			output.Write(c);
    		else 
    			output.Write(str);
    	}
    }
    
    public class Program
    {
    	public static void Main()
    	{
    		Dictionary<string, char> str2Char = new Dictionary<string, char> {
    			{"Return", '\n'},
    			{"Space", ' '},
    			{"KeyOemcomma", '?'}
    		};
    		string str = "Hello!ReturnHowSpaceAreSpaceYouKeyOemcomma";
    		var input = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(str));
    		var t = new Transformer(input, str2Char);
    		var output = t.Transfrom();
    		
    		// Start reading output stream from the begining
    		output.Seek(0, SeekOrigin.Begin);
    		var s = new StreamReader(output);
    	
    		int c;
    		while ((c = s.Read()) != -1) {
    			Console.Write((char)c);
    		}
    	}
    }
