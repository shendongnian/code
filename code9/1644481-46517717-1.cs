     public int Accelerate(int step = 10, int new_speed = 5, int hpov = 15)
        {
            if (hp >= 200)
            {
                this.speed += hpov;
                if (brand == "BMW")
                {
                    this.speed += step;
                    return this.speed;
                }
                return this.speed;
            }
            else
            {
                this.speed += new_speed;
                return this.speed;
            
            }
            
        }
