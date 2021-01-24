    Stage st1 = new Stage
    {
          MathStage = MatchStage.FirstHalfAssumedStartTime,
          PossibleStages = new List<MatchStage> { MatchStage.FirstHalfAssumedEndTime }
    };
    bool res = IsProposedStageValid(st1, MatchStage.PauseEndTime);
