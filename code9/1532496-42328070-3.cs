	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	namespace ConsoleApplication1
	{
		namespace ReferralDG
		{
			class Program
			{
				static void Main(string[] args)
				{
					Console.WriteLine("Even Minus Odd Game: ");
					Random rand = new Random();
					bool PlayAgain = false;
					do
					{
						int numberOfDice = 0;
						int totalOfDiceRolled = 0;
						while (numberOfDice > 10 || numberOfDice < 3)
						{
							Console.WriteLine("How many dice do you wish to play     with? (Between 3 and 10?)");
							numberOfDice = Convert.ToInt32(Console.ReadLine());
							if (numberOfDice > 10 || numberOfDice < 3)
							{
								Console.WriteLine("Please enter the correct number");
							}
						}
						Console.Write("Dice rolls: ");
						int evenTotal = 0;
						int oddTotal = 0;
						for (int i = 0; i < numberOfDice; i++)
						{
							int diceRoll = rand.Next(1, 7);
							if (diceRoll % 2 == 0)
							{
								evenTotal += diceRoll;
							}
							else
							{
								oddTotal += diceRoll;
							}
							totalOfDiceRolled += diceRoll;
							Console.Write(diceRoll + " ");
						}
						int counters = evenTotal - oddTotal;
						Console.WriteLine();
						if (counters > 1)
						{
							Console.WriteLine("You take " + counters + " counters.");
						}
						else if (counters > 0) // or if you rather counters == 1
						{
							Console.WriteLine("You take " + counters + " counter.");
						}
						else if (counters < -1)
						{
							Console.WriteLine("You give " + Math.Abs(counters) + " counters.");
						}
						else if (counters < 0)
						{
							Console.WriteLine("You give " + Math.Abs(counters) + " counter.");
						}
						else if (evenTotal == oddTotal)
						{
							Console.WriteLine("Even total is equal to odd total");
						}
						else
						{
							Console.WriteLine("No counters this game");
						}
						Console.WriteLine("Would you like to play again? (Y/N): ");
						string playAgain = Console.ReadLine().ToUpper();
						if (playAgain == "Y")
						{
							PlayAgain = true;
						}
						else
						{
							PlayAgain = false;
						}
					} while (PlayAgain);
				}
			}
		}
	}
