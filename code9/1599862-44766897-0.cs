    public abstract class MergeSettingsBase : ISettingsA, ISettingsB
    {
        private readonly ISettingsA _settingsA;
        private readonly ISettingsB _settingsB;
        
        public MergeSettingsBase(ISettingsA settingsA, ISettingsB settingsB)
        {
            _settingsA = settingsA;
            _settingsB = settingsB;
        }
        string ISettingsA.SomeValue {
            get {
                return _settingsA.SomeValue;
            }
        }
        int ISettingsB.AnotherValue {
            get {
                return _settingsB.AnotherValue;
            }
        }
    }
    public class Settings : MergeSettingsBase {
        override string ISettingsA.SomeValue {
            return "abc";
        }
    }
