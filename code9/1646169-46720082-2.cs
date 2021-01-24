    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    namespace moo_in_csharp
    {
        internal class Individual
        {
            public int[] Decisions;
            public double Fitness;
            private int _numdecisions = 6;
    
            /// <summary>
            /// Default constructor.
            /// </summary>
            public Individual()
            {
                Decisions = new int[_numdecisions];
            }
    
            /// <summary>
            /// Replaces first half of decisions with those of the mate.
            /// </summary>
            /// <param name="mate"></param>
            public void Crossover(Individual mate)
            {
                int crossoverPoint = _numdecisions / 2;
                for (int i = 0; i < crossoverPoint; i++)
                {
                    Decisions[i] = mate.Decisions[i];
                }
            }
    
            /// <summary>
            /// Simple fitness function that computes sum of a+b+c+d+e+f.
            /// </summary>
            public double Evaluate()
            {
                Fitness = Decisions.Sum();
                return Fitness;
            }
    
            /// <summary>
            /// Assigns random values to its decisions.
            /// </summary>
            public void Generate()
            {
                for (int i = 0; i < _numdecisions; i++)
                {
                    Decisions[i] = Program.rand.Next(0, 101);
                }
            }
    
            /// <summary>
            /// Randomly mutate select decisions.
            /// </summary>
            public void Mutate()
            {
                for (int i = 0; i < _numdecisions; i++)
                {
                    Decisions[i] = Program.rand.Next(0, 101);
                }
            }
        }
    
        internal class Program
        {
            public static Random rand = new Random();
    
            private static void Main(string[] args)
            {
                //parameters
                int populationSize = 100;
                int numGenerations = 50;
                double mutationRate = 0.2;
                double crossoverRate = 0.8;
    
                //build initial population
                List<Individual> solutions = new List<Individual>();
                for (int i = 0; i < populationSize; i++)
                {
                    var solution = new Individual();
                    solution.Generate();
                    solution.Evaluate();
                    solutions.Add(solution);
                }
    
                //calculate average score of initial population
                var averageScoreBefore = solutions.Select(x => x.Evaluate()).Average();
    
                //iterate across number of generations
                for (int i = 0; i < numGenerations; i++)
                {
                    //build offspring by mating sequential pairs of solutions
                    var offspring = new List<Individual>();
                    for (int e = 0; e < solutions.Count() - 1; e += 2)
                    {
                        if (rand.NextDouble() < crossoverRate)
                        {
                            var newIndividual = new Individual();
                            solutions[e].Decisions.CopyTo(newIndividual.Decisions, 0);
                            newIndividual.Crossover(solutions[e + 1]);
                            offspring.Add(newIndividual);
                        }
                    }
    
                    //add our offspring to our solutions
                    solutions.AddRange(offspring);
    
                    //mutate solutions at a low rate
                    foreach (var solution in solutions)
                    {
                        if (rand.NextDouble() < mutationRate)
                        {
                            solution.Mutate();
                        }
                    }
    
                    //sort our solutions and down-sample to initial population size
                    solutions = solutions.OrderByDescending(x => x.Evaluate()).ToList();
                    solutions = solutions.Take(populationSize).ToList();
                }
    
                //calculate average score after
                var averageScoreAfter = solutions.Select(x => x.Evaluate()).Average();
                Debug.WriteLine(averageScoreBefore + "," + averageScoreAfter);
            }
        }
    }
