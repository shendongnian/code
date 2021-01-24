        var predicate = CreatePredicate();
        var levelDetail = new LevelDetail { LevelDate = new DateTime(2017, 08, 19) };
        var level = new Level { LevelDetails = new List<LevelDetail> { levelDetail } };
        var test = new Test { TestDate = new DateTime(2027, 08, 19), Levels = new List<Level> { level } };
        var result = predicate.Compile()(test);
