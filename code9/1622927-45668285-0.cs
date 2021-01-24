    public class Car
    {
       //public enum Values
       //{
       //   Brand 1,
       //   Brand 2,
       //   Brand 3
       //}
       
       public Brand  _myBrand {get;set;}
       public Values _value {get; set;}
    }
    
    public sealed class Brand
    {
       public int BrandOne { get; set; }
       public int BrandTwo { get; set; }
    } 
