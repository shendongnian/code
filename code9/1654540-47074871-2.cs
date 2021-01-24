                var payload = new JObject
                (
                    new JProperty("to", deviceToken),
                    new JProperty("data", new JObject(
                                                      new JProperty("title", "title goes here"),
                                                      new JProperty("message", "notification text goes here"),
                                                      new JProperty("priority", "high")
                                                      )),
                    new JProperty("notId", $"{new Random().Next(int.MaxValue)}"),
                    new JProperty("content-available", 1),
                    new JProperty("soundname", "default"),
                    new JProperty("image", @"www/assets/img/logo.png"),
                    new JProperty("image-type", "circle"),
                    new JProperty("style", "inbox"),
                    new JProperty("notData", new JObject(
                                                           new JProperty("storyId", story.Id),
                                                           new JProperty("profileId", profile.Id)
                                                         ))
                ).ToString(Newtonsoft.Json.Formatting.None);
