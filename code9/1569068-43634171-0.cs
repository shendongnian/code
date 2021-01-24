    items.Select (item => new 
                             { 
                               x = item.y == cond ? item.y : Sort(item.y);
                               // if item.y == condition, then item.y ELSE Sort item.y
                               ...
                             }
                  );
