    for(int i = 0; i < strArr2.Length; i++)
    {
        if(strArr2.Any(_r => _r.Split('|').Any(_rS => _rS.Contains(strArr1[i])))) 
        {
            var menu = strArr2[i];
            var alternate = strArr2.Where(_rs => _rs.Split('|').Any(_rS => _rS.Contains(strArr1[i]))).First().Split('|').Last();
        }
    }
    
