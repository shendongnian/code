    using System.Linq;
    private int CntPref(List<string> prefs, string aword) {
        int cnt = 0;
        prefs.Select((s)=>{
            if(aword.StartsWith(s)) {
                cnt++;
                cnt+=CntPrefs(prefs, aword.Substring(s.Length));
            }
        });
        return cnt,
    }
