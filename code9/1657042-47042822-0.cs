    public List&ltVector2&gtGetContainedVectors(int radius, Vector2 offset)
    {
       List&lt;Vector2&gt; returnValues = new List&ltVector2&gt();
       for (int x = radius; x > -radius; x--)
       {
          for (int y = radius; y &gt; -radius; y--)
          {
             if(Vector2.Distance(new Vector2(x,y), Vector2.zero) &lt;= radius)
             {
                returnValues.Add(new Vector2(x + offset.x, y + offset.y));  
             }
          }   
       } 
       return returnValues;
    }
