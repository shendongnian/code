     for(int i=0;i<userinput;++i){
            int max = int.MinValue,pos=-1;
            for(int j=0;j<arr.Length;++j){
                if(max<arr[j]){
                    pos = j;
                    max = arr[j];
                }
            }
            arr[pos] = int.MinValue;
            Console.Write(max+",");
        }
