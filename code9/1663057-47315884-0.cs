        public static void MaxSpeedCarAverage(Car[] arraycar, float maxspeed, float average)
        {
            maxspeed = arraycar[0].Speed;
            for(int i=0;i<10;i++)
            {
                if(arraycar[i].Speed > maxspeed) {
                    maxspeed = arraycar[i].Speed;
                }
                average+= arraycar[i].Speed / arraycar.Length;
            }
        }
