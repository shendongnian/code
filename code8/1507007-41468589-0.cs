    class Character : MonoBehavior, IActor
    {
         public float Hp {get;set;}
         private float _damage;
         public float Damage
         {
              get {return _damage;}
              set {_damage = value;}
         }
         //implemetation of IActor
    }
    class Monster : MonoBehavior, IActor
    {
        //implemetation of IActor
    }
    interface IActor
    {
        float Hp {get;set;}
        float Damage {get;set;}
    }
    public Combat (IActor character, IActor character2)
