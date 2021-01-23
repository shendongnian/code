    public int solution(int[] sizes, int[] direction)
        {
            if (sizes == null || direction == null)
                throw new ArgumentNullException();
    
            var sizesLen = sizes.Length;
            var directionLen = direction.Length;
    
            if (sizesLen != direction.Length)
                throw new ArgumentException();
    
            var len = sizesLen;
    
            if (len <= 1) return len;
    
            var survivors = new Fish[len];
            survivors[0] = new Fish(sizes[0], direction[0]);
            var curr = 0;
    
            for (int i = 1; i < len; i++)
            {
                var fish = new Fish(sizes[i], direction[i]);
    
                if (survivors[curr].Direction == 1 && fish.Direction == 0)
                {
                    if (fish.Size < survivors[curr].Size) continue;
    
                    while(curr >= 0 && 
                        fish.Size > survivors[curr].Size && 
                        survivors[curr].Direction == 1)
                    {
                        curr--;
                    }
                    if (fish.Size < survivors[curr].Size) continue; // added this line
                }
    
                survivors[++curr] = fish;
            }
    
            return ++curr;
        }
    
    }
    
    public class Fish
    {
        public Fish(int size, int direction)
        {
            Size = size;
            Direction = direction;
        }
    
        public int Size { get; set; }
        public int Direction { get; set; }
    }
