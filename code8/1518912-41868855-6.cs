        public class QAutomaton
        {
            private readonly Dictionary<string, Dictionary<string, string>> _graph = new Dictionary<string, Dictionary<string, string>>();
            public void AddState(string state)
            {
                _graph.Add(state, new Dictionary<string, string>());
            }
            public void AddCondition(string from, string condition, string to)
            {
                _graph[from].Add(condition, to);
            }
            public string GetNext(string from, string condition)
            {
                var conds = _graph[from];
                string nextState;
                conds.TryGetValue(condition, out nextState);
                return nextState;
            }
        }
        public class Quest
        {
            public string CurrentState = "Start";
            private readonly QAutomaton _automaton;
            public Quest(QAutomaton automaton)
            {
                _automaton = automaton;
            }
            public void FeedEvent(string condition)
            {
                var nextState = _automaton.GetNext(CurrentState, condition);
                if (nextState != null)
                {
                    CurrentState = nextState;
                }
            }
        }
        public static void Main()
        {
            var fa = new QAutomaton();
            fa.AddState("Start");
            fa.AddState("Kill robber");
            fa.AddState("Ask robber to return items");
            fa.AddCondition("Start", "talked with barmen about robber", "Kill robber");
            fa.AddCondition("Start", "talked with robber wife", "Ask robber to return items");
            //describe rest here...
            _quest = new Quest(fa);
        }
        public static void OnTalkedWithBarmenAboutRobberEventHandler()
        {
            _quest.FeedEvent("talked with barmen about robber");
            var state = _quest.CurrentState;
            if (state == "Kill robber")
            {
                //locate him on global map or something
            }
        }
