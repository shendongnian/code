	using Microsoft.Office.Interop.Word;
	using System;
	namespace consolFindBoldWord
	{
		class Program
		{
			static void Main(string[] args)
			{
				Application application = new Application();
				Document doc = application.Documents.Open("I:\\word.docx");
				foreach (Range s in doc.Sentences)
				{
					foreach (Range rg in s.Words)
					{
						if (rg.Bold == -1)
						{
							/*  WRITE YOUR CODE HERE IF WORD IS BOLD*/
							Console.WriteLine("Bold : {0}", rg.Text);
						}
					}
				}
				doc.Close();
			}
		}
	}
