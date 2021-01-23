    using System;
    using System.Collections.Generic;
    using System.Linq;
    class Program
    {
        static void Main(string[] args)
        {
            var fixtures = new List<Match> {
                new Match { Team1 = "Eagles", Team1Score = 2, Team2 = "Hawks", Team2Score = 4},
                new Match { Team1 = "Hawks", Team1Score = 1, Team2 = "Eagles", Team2Score = 2 },
            };
            var results = fixtures
                .GroupBy(x => x, new MatchComparer())
                .Select(x => new { x.Key.Team1, x.Key.Team2, Team1Total = x.Sum(s => s.Team1Score), Team2Total = x.Sum(s => s.Team2Score) });
        }
    }
    public class MatchComparer : IEqualityComparer<Match>
    {
        public bool Equals(Match x, Match y)
        {
            return (x.Team1 == y.Team1 && x.Team2 == y.Team2) ||
                (x.Team1 == y.Team2 && x.Team2 == y.Team1);
        }
        public int GetHashCode(Match obj)
        {
            return obj.Team1.GetHashCode() + obj.Team2.GetHashCode();
        }
    }
    public class Match
    {
        public string Team1 { get; set;}
        public int Team1Score { get; set; }
        public string Team2 { get; set; }
        public int Team2Score { get; set; }
    }
