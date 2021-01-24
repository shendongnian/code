    public List<int> GetInts(string text){
     char[] chars = text.ToCharArray()
     bool prevIsNum = false;
     int startI = 0;
     int lenI = 0;
     List<int> ints = new List<int>();
     for(i=0;i<chars.length;i++){
     	if(Char.IsNumber(chars[i])){
     		if(prevIsNum){
     			lenI ++;
     		}else{
     			startI = i;
     			lenI ++;
     		}
     		prevIsNum = true;
     	}else if(prevIsNum){
     		prevIsNum = false;
    		ints.add(Int32.Parse(string.Concat(chars.SubArray(startI,lenI)));
     	}
     }
     return ints;
    }
