    Metric.Config.WithInternalMetrics()
                .WithOwin(middleware => app.UseOwin(pipeline => pipeline(next => Engage(middleware, next))), config => config
                    .WithRequestMetricsConfig(c => c.WithAllOwinMetrics()
                                                , new[] {
                                                        new Regex("(?i)^metrics"),
                                                        new Regex("(?i)^health"),
                                                        new Regex("(?i)^json")
                                                        }
                                                )
                    .WithMetricsEndpoint(endpointConfig =>
                    {
                        endpointConfig
                            .MetricsJsonEndpoint(enabled: true)
                            .MetricsEndpoint(enabled: true)
                            .MetricsHealthEndpoint(enabled: true)
                            .MetricsTextEndpoint(enabled: false)
                            .MetricsPingEndpoint(enabled: false);
                    })
                );
