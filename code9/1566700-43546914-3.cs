    var obj = new {
        name = "flare",
        children = new[] {
            new {
                name = "analytics",
                children = new dynamic [] {
                    new {
                        name = "cluster",
                        children = new dynamic [] {
                            new { name = "AgglomerativeCluster", size = 3938},
                            new { name = "MergeEdge", size = 743},
                        }
                    },
                    new {
                        name = "graph",
                        children = new dynamic [] {
                            new { name = "BetweennessCentrality", size = 3534},
                            new { name = "SpanningTree", size = 3416},
                        }
                    },
                    new {
                        name = "optimization",
                        children = new dynamic [] {
                            new { name = "AspectRatioBanker", size = 7074},
                        }
                    },
                }
            },
            new {
                name = "animate",
                children = new dynamic [] {
                    new { name = "Easing", size = 17010},
                    new { name = "FunctionSequence", size = 5842},
                    new {
                        name = "interpolate",
                        children = new [] {
                        new { name = "ArrayInterpolator",  size = 1983},
                        new { name = "RectangleInterpolator", size = 2042}
                        }
                    },
                    new { name = "ISchedulable", size = 1041},
                    new { name = "Tween", size = 6006},
                }
            },
        }
    };
    var json = JsonConvert.SerializeObject(obj, Formatting.Indented);
