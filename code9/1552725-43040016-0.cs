    class ToRomanNumber
    {
        string s = "";
        public string ToRoman(int number)
        {
            if ((number < 0) || (number > 3999))
            {
                s = s + "Invalid input";
            }
            if (number < 1) return s;
            if (number >= 1000) { s = s + "M"; ToRoman(number - 1000); return s; }
            if (number >= 900) { s = s + "CM"; ToRoman(number - 900); return s; }
            if (number >= 500) { s = s + "D"; ToRoman(number - 500); return s; }
            if (number >= 400) { s = s + "CD"; ToRoman(number - 400); return s; }
            if (number >= 100) { s = s + "C"; ToRoman(number - 100); return s; }
            if (number >= 90) { s = s + "XC"; ToRoman(number - 90); return s; }
            if (number >= 50) { s = s + "L"; ToRoman(number - 50); return s; }
            if (number >= 40) { s = s + "XL"; ToRoman(number - 40); return s; }
            if (number >= 10) { s = s + "X"; ToRoman(number - 10); return s; }
            if (number >= 9) { s = s + "IX"; ToRoman(number - 9); return s; }
            if (number >= 5) { s = s + "V"; ToRoman(number - 5); return s; }
            if (number >= 4) { s = s + "IV"; ToRoman(number - 4); return s; }
            if (number >= 1) { s = s + "I"; ToRoman(number - 1); return s; }
            return s;
        }
    }
