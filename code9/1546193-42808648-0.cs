        private void SomeValueAChangedSubscribe(bool subscribe)
        {
            if (subscribe)
            {
                SomeSingleton.Instance.SomeValueAChanged += OnSomeSingleton_SomeValueAChanged;
            }
            else
            {
                SomeSingleton.Instance.SomeValueAChanged -= OnSomeSingleton_SomeValueAChanged;
            }
        }
