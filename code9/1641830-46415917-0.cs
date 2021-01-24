    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    namespace EFExposeForeignKey
    {
        public class A
        {
            public A()
            {
                Id = Guid.NewGuid();
            }
            [Key]
            public Guid Id { get; set; }
            /* Other properties of A goes here */
            // Navigation property
            public B B { get; set; }
            // Navigation property
            public C C { get; set; }
        }
        public class B
        {
            [Key]
            [ForeignKey(nameof(EFExposeForeignKey.A.B))]
            // Or simply [ForeignKey("B")]
            // I wanted to emphasize here that "B" is NOT the type name but the name of a property in class "A"
            public Guid Id { get; set; }
            /* Other properties of B goes here */
            // Navigation property
            public A A { get; set; }
        }
        public class C
        {
            [Key]
            [ForeignKey(nameof(EFExposeForeignKey.A.C))]
            public Guid Id { get; set; }
            /* Other properties of C goes here */
            // Navigation property
            public A A { get; set; }
        }
    }
