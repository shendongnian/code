    public class SlackService
    {
        internal static async Task<SlackMembersRootObject> GetSlackUsersList(string slackApiToken, CancellationToken ct)
        {
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync($"https://slack.com/api/users.list?token=" + $"{slackApiToken}", ct).ConfigureAwait(false))
                {
                    var jsonString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var rootObject = Newtonsoft.Json.JsonConvert.DeserializeObject<SlackMembersRootObject>(jsonString);
                    return rootObject;
                }
            }
        }
    }
    public static async Task StartSlackDirectMessage(string msAppId, string msAppPassword, string slackApiToken, string message, string botSlackUsername, string botName, string destEmailAddress, string destName, string lang, CancellationToken ct)
    {
        // Getting Slack user (and bot) list
        var slackUsersList = await SlackService.GetSlackUsersList(slackApiToken, CancellationToken.None);
        // Get Bot SlackId by searching its "username", you can also search by other criteria
        var slackBotUser = slackUsersList.Members.FirstOrDefault(x => x.Name == botSlackUsername);
        if (slackBotUser == null)
        {
            throw new Exception($"Slack API : no bot found for name '{botSlackUsername}'");
        }
        // Get User SlackId by email address
        var slackTargetedUser = slackUsersList.Members.FirstOrDefault(x => x.Profile.Email == destEmailAddress);
        if (slackTargetedUser != null)
        {
            // if found, starting the conversation by passing the right IDs
            await StartDirectMessage(msAppId, msAppPassword, "https://slack.botframework.com/", "slack", $"{slackBotUser.Profile.Bot_id}:{slackBotUser.Team_id}", botName, $"{slackTargetedUser.Id}:{slackTargetedUser.Team_id}", destName, message, lang, ct);
        }
        else
        {
            throw new Exception($"Slack API : no user found for email '{destEmailAddress}'");
        }
    }
