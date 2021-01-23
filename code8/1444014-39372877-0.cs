    Public Class Bird
        public Shared sub Fly
            Debug.WriteLine("Fly called from Shared")
        End sub
    
        public sub Quack
            Debug.WriteLine("Quack called from Instance")
        End sub
    
    End Class
    
    Public Class Main
        public sub Test(bird As Bird)
            bird.Fly()
            Bird.Fly()
    
            bird.Quack()
            Bird.Quack()
        End sub
    End Class
