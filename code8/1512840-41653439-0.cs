    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication3 {
    
        struct MyInt : IEquatable<MyInt> {
            private int _value;
    
            public MyInt(int value) {
                _value = value;
            }
    
            // make it look like int
            static public implicit operator MyInt(int value) {
                return new MyInt(value);
            }
            public static explicit operator int(MyInt instance) {
                return instance._value;
            }
    
            // main difference in these 3 methods
            private int GetDigitsNum() {
                int temp, res;
                for (res = 0, temp = Math.Abs(_value); temp > 0; ++res, temp /= 10);
                return res;
            }
            public bool Equals(MyInt other) {
                int digits = other.GetDigitsNum();
                if (digits != this.GetDigitsNum())
                    return false;
                int temp = other._value;
    
                // prepare mul used in shifts
                int mul = 1;
                for (int i = 0; i < digits - 1; ++i)
                    mul *= 10;
    
                // compare
                for (int i = 0; i < digits; ++i) {
                    if (temp == _value)
                        return true;
                    // ROR
                    int t = temp % 10;
                    temp = temp / 10 + t * mul;
                }
                return false;
            }
            public override int GetHashCode() {
                // hash code must be equal for "equal" items,
                // that's why use a sum of digits.
                int sum = 0;
                for (int temp = _value; temp > 0; temp /= 10)
                    sum += temp % 10;
                return sum;
            }
    
            // be consistent
            public override bool Equals(object obj) {
                return (obj is MyInt) ? Equals((MyInt)obj) : false;
            }
            public override string ToString() {
                return _value.ToString();
            }
        }
    
        class Program {
            static void Main(string[] args) {
    
                List<MyInt> list = new List<MyInt> { 112621, 126211, 262111, 621112, 211126 };
                // make a set of unique items from list
                HashSet<MyInt> set = new HashSet<MyInt>(list);
                // print that set    
                foreach(int item in set)
                    Console.WriteLine(item);
            }
        }
    }
