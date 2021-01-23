    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Timers;
    using System.Threading.Tasks;
    
    namespace CalculatingGame
    {
        class Game
        {
            Difficulty Game_Diff;
            GameType Game_Type;
    
            int TicksRemaining = 0;
    
            int TotalAnswers = 0;
            int CorrectAnswers = 0;
            int WrongAnswers = 0;
    
            Timer TimerCountdown;
    
            public Game(Difficulty GDiff, GameType GType)
            {
                Game_Diff = GDiff;
                Game_Type = GType;
    
                TimerCountdown = new Timer(100);
                TimerCountdown.Elapsed += TimerCD;
                TimerCountdown.AutoReset = true;
            }
    
            public void Handler(int Answer)
            {
                if (TicksRemaining > 0)
                {
                    if (Answer == Game_Type.Answer)
                    {
                        CorrectAnswers++;
                        Console.WriteLine("Good job. You got the correct answer.");
                    }
                    else
                    {
                        WrongAnswers++;
                        Console.WriteLine("Wrong answer. The answer was " + Game_Type.Answer + ".");
                    }
                    TotalAnswers++;
    
                    Console.WriteLine("Current score: " + CorrectAnswers + " correct answers out of " + TotalAnswers);
    
                    TicksRemaining = 0;
                    Console.WriteLine("Press Enter to get your new sum.");
                    TimerCountdown.Stop();
                }
                else
                {
                    string SumText = Game_Type.MakeSum(Game_Diff);
                    Console.WriteLine("What is the solution to the sum " + SumText);
                    TicksRemaining = Game_Diff.Time;
                    TimerCountdown.Start();
                }
            }
    
            public void TimerCD(Object source, ElapsedEventArgs e)
            {
                if(TicksRemaining > 0)
                {
                    TicksRemaining--;
    
                    if ((TicksRemaining % 10) == 0)
                    {
                        Console.Write(Math.Floor((decimal)(TicksRemaining / 10)) + "...");
                    }
    
                    if (TicksRemaining == 0)
                    {
                        WrongAnswers++;
                        Console.WriteLine("\r\nTime is up. The answer was " + Game_Type.Answer);
                        Console.WriteLine("Press Enter to get your new sum.");
                        TimerCountdown.Stop();
                    }
                }
            }
    
            public void Stop()
            {
                TimerCountdown.Stop();
            }
        }
    }
