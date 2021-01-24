    if(ts == null || ts.LongLength ==0 )
        return 0;
    double a = ts[0];
    double b;
    for(int i = 0; i <= ts.LongLength-1; i++){
        if(Math.Abs(a) > Math.Abs(ts[i])){
            a = ts[i];
        }
        else if(Math.Abs(a) == Math.Abs(ts[i]))
        {  
            a = a > ts[i] ? a : Maths.Abs(ts[i]); 
        }
    }
    return a;
}
