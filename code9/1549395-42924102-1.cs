        private static IEnumerable<PlayerPoints> GetDummyData()
        {
            return new[]
            {
                new PlayerPoints()
                {
                    CreateDate = DateTime.Today,
                    SeasonalPoints = new List<SeasonPoint>()
                    {
                        new SeasonPoint {Season = 1, Point = 100},
                        new SeasonPoint {Season = 2, Point = 100},
                        new SeasonPoint {Season = 3, Point = 100},
                        new SeasonPoint {Season = 4, Point = 100},
                        new SeasonPoint {Season = 5, Point = 100},
                        new SeasonPoint {Season = 6, Point = 100},
                        new SeasonPoint {Season = 7, Point = 100},
                    }
                },
                new PlayerPoints()
                {
                    CreateDate = DateTime.Today,
                    SeasonalPoints = new List<SeasonPoint>()
                    {
                        new SeasonPoint {Season = 1, Point = 100},
                        new SeasonPoint {Season = 2, Point = 100},
                        new SeasonPoint {Season = 3, Point = 100},
                        new SeasonPoint {Season = 4, Point = 100},
                        new SeasonPoint {Season = 5, Point = 100},
                        new SeasonPoint {Season = 6, Point = 150},
                        new SeasonPoint {Season = 7, Point = 100},
                    }
                },
                new PlayerPoints()
                {
                    CreateDate = DateTime.Today,
                    SeasonalPoints = new List<SeasonPoint>()
                    {
                        new SeasonPoint {Season = 1, Point = 100},
                        new SeasonPoint {Season = 2, Point = 100},
                        new SeasonPoint {Season = 3, Point = 100},
                        new SeasonPoint {Season = 4, Point = 100},
                        new SeasonPoint {Season = 5, Point = 100},
                        new SeasonPoint {Season = 6, Point = 0},
                        new SeasonPoint {Season = 7, Point = 300},
                    }
                },
            };
        }
    }
    }
