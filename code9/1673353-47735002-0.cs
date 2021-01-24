    using Microsoft.Bot.Builder.FormFlow;
    using System;
    namespace TestChatbot.Dialogs
    {
        [Serializable]
        public class OrderSearchQuery
        {
            [Prompt("Please enter {&}")]
            public string OrderNumber { get; set; }
            [Prompt("Please enter {&}?")]
            public String Location { get; set; }
            [Prompt("Please provide last status {&}?")]
            public string Status { get; set; }
        }
    }
