    public class Optionddl
    {
        public string text { get; set; }
        public string value { get; set; }
        public static implicit operator string(Optionddl option)
        {
            return option.text + "," + option.value;
        }
        public static implicit operator Optionddl(string str)
        {
            string[] extracted = str.Split(",");
            return new Optionddl { text = extracted[0], value = extracted[1] };
        }
    }
