	using System;
	using System.Threading;
	namespace ConsoleApplication1
	{
		class Program
		{
			static string[] array1 = new string[] { "ANGEL MARTIN ROMERO RIVERA", "CRISOGONO CORTES ZARATE", "RAFAEL ARMANDO DE LEON ALVARADO", "TEST" };
			static string[] array2 = new string[] { "ANGEL MARTIN", "CRISOGONO ZARATE", "RAFAEL DE LEON ALVARADO", "TEST" };
			static void Main(string[] args)
			{
				for (var i = 0; i < array1.Length; i++)
				{
					for (var j = 0; j < array2.Length; j++)
					{
						// compare (if they will equal)
						if (array1[i] == array2[j])
						{
							// will match Array1 & Array2 on "TEST", ok, so loop...
							Console.WriteLine("Match: {0}array1:{1}{2}array2:{3}", System.Environment.NewLine, array1[i], System.Environment.NewLine, array2[j]);
						}
						else
						{
							// if data is like your example
							if (array1[i].Contains(array2[j]))
							{
								Console.WriteLine("Match: {0}array1:{1}{2}array2:{3}", System.Environment.NewLine, array1[i], System.Environment.NewLine, array2[j]);
								// match on
								// will match Array1 & Array2 on "ANGEL MARTIN" and "TEST", ok, so loop...
								// will NOT match on CRISOGONO ZARATE, but the else condition will...
							}
							else
							{
								// so, to get this match we do
								var array2subArray = array2[j].Split(' ');
								for (var k = 0; k < array2subArray.Length; k++)
								{
									// match all the terms in each array where the match is possible (or the smaller against the larger, i.e., if array1[i] is a name of 4 words and array2[j] is a name of 2 words, for this to be a valid match, both of the words in array2[j] must be contained in array1[i]
									// I would write the code but then that would leave out the fun for you...
									// Here's a start...
							        // you need to fix the below, but it is a start, blah, blah, blah...
									if (array1[i].Contains(array2subArray[k]))
									{
										// this will match on "CRISOGONO"
										Console.WriteLine("Potential Match: {0}array1:{1}{2}array2:{3}", System.Environment.NewLine, array1[i], System.Environment.NewLine, array2[j]);
										Console.WriteLine("processing furter to see if true match...");
									}
								}
							}
						}
					}
				}
				Console.ReadKey();
			}
		}
	}
