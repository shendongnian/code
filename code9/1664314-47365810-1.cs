        for(int i=0;i<key.Length;i++)
        {
            result+=key.Substring(i,1);
            for(int k=0; k<step; k++)
            {
               try
               {
                   result+=text.Substring(word,1);
                   word++;
               }
               catch
               {
                   /* This blok will break 
                      when the text variable's last part's character count lest then step. */
                   break;
               }
            }
    }
    
    Console.Write("Result Text : "+result);
    Console.ReadKey();
