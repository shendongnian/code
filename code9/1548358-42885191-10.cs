    var emotions = new[] {
        Tuple.Create(p.anger, Emotion.Anger),
        Tuple.Create(p.fear, Emotion.Fear),
        Tuple.Create(p.sadness, Emotion.Sadness),
        Tuple.Create(p.disgust, Emotion.Disgust),
        Tuple.Create(p.joy, Emotion.Joy),
    };
    var highestEmotions = emotions
        .MaxByAll(t => t.Item1)
        .Select(e => e.Item2);
