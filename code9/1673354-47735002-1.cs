    using Microsoft.Bot.Builder.FormFlow;
    using System;
    namespace TestChatbot.Dialogs
    {
        [Serializable]
        public class OrderFollowUp
        {
            [Prompt("Please enter {&}?")]
            public string SubOrderNumber { get; set; }
            [Prompt("Please enter {&}?")]
            public string SubOrderVersion { get; set; }
        }
    }
