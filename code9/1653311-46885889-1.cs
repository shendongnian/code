    (int)2 == (double)2.0            - True because the compiler promotes int to double when comparing via ==.
    ((int)2).Equals( (double)2.0)    - False because this is calling object.Equals(object) and the types are different.
    (float)2.0 == (double)2.0        - True because the compiler promotes float to double when comparing via ==.
    ((float)2.0).Equals((double)2.0) - False becaue this is calling object.Equals(object) and the types are different.
    (double)2.0 == (int)2            - True because the compiler promotes int to double when comparing via ==.
    ((double)2.0).Equals((int)2)     - True because there exists double.Equals(double) and the compiler
                                       promotes the integer parameter 2 to double to call double.Equals(2.0).
    (float)2.0 == (int)2.0           - True because the compiler promotes int to float when comparing via ==.
    ((float)2.0).Equals((int)2.0)    - True because there exists float.Equals(float) and the compiler
                                       promotes the integer parameter 2 to float to call float.Equals(2.0f).
    (double)2.0 == (float)2.0)       - True because the compiler promotes float to double when comparing via ==.
    ((double)2.0).Equals((float)2.0) - True because there exists double.Equals(double) and the compiler
                                       promotes the float parameter 2.0f to double to call double.Equals(2.0).
    (int)2 == (float)2.0             - True because the compiler promotes int to float when comparing via ==.
    ((int)2).Equals((float)2.0)      - False because this is calling object.Equals(object) and the types are different.
