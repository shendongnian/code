    var testList = new List<Test>
    {
        new Test {
            Levels = new List<Level> {
                new Level {
                    LevelDetails = new List<LevelDetail> {
                        new LevelDetail {
                            LevelDate = DateTime.Today
                        }
                    }
                }
            },
            // Not matched
            TestDate = DateTime.Today
        },
        new Test {
            Levels = new List<Level> {
                new Level {
                    LevelDetails = new List<LevelDetail> {
                        new LevelDetail {
                            LevelDate = DateTime.Today
                        }
                    }
                }
            },
            // Not matched
            TestDate = DateTime.Today.AddDays(-1)
        },
        new Test {
            Levels = new List<Level> {
                new Level {
                    LevelDetails = new List<LevelDetail> {
                        new LevelDetail {
                            LevelDate = DateTime.Today
                        }
                    }
                }
            },
            // Matched
            TestDate = DateTime.Today.AddDays(-2)
        }
    };
