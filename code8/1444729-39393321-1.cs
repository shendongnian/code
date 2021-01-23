               char[] splits = new char[] { ',', '|', ';' };//add whatever delimiters you want here, surrounded by single quotes and separated by commas
            string[] parts;
            bool splitFound = false;//you could just test for parts==null but I'm adding this anyway. It allows handling a situation where no delimiters are found
            foreach(char splitter in splits)
            {
                parts = allrecords[index].Split(splitter);//this assumes that the text will never have any of the delimeters in it unless they are delimiting. If so, you need to handle first
                if (parts.Length > 0)
                {
                    splitFound=true;
                    break;
                }
            }
            if(splitFound){
            //process parts
                 cmd.Parameters["@uid"].Value = items[0];
                cmd.Parameters["@code"].Value = items[1];
                cmd.Parameters["@description"].Value = items[2];
                cmd.ExecuteNonQuery();
            }else{
                //handle no splits found
            }
