                if(chars.Count>0){
                //for all characters(aka snake segments)
                        //take the position of the segment before you
                        for (int i = chars.Count - 1; i > 0; i++) {
                            chars [i].transform.position = chars [i - 1].transform.position;
                        }
                }
                else{
                   Debug.Log("Warning:: chars Count is less than 1");
    }
