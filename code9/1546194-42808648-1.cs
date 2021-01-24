        private Action<bool>[] GetSubscribeMethods()
        {
            return new Action<bool>[]
            {
                SomeValueAChangedSubscribe,
                SomeValueBChangedSubscribe,
                SomeValueCChangedSubscribe,
                ...
            };
        }
