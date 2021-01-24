    public class BaseClass {
        public BaseClass(
            Func<string, bool> stringToBool = null,
            Func<string, string> stringToString = null
        ){
            stringToBool = stringToBool ?? DefaultStringToBool;
            stringToString = stringToString ?? DefaultStringToString;
        }
        private static bool DefaultStringToBool(string s) {
            <Insert default logic here>;
        }
        private static string DefaultStringToString(string s) {
            <Insert default logic here>;
        }
    }
