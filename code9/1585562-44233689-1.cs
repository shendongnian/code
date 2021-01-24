    using System.Collections.Generic;
    
    namespace MyApp
    {
        public interface IMessageSubscriber
        {
            void Notify(string topic, Dictionary<string, string> fields);
        }
    }
