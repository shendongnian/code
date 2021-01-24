    using System;
    using System.Collections.Generic;
    
    namespace ConsoleApplication
    {
        class Program
        {
            static void Main(string[] args)
            {
                var tweens = new List<TweenerBase>();
    
                var tween0 = new TweenerBase();
                var tween1 = new ColorTweener();
                var tween2 = new Vector3Tweener();
    
                tweens.Add(tween0);
                tweens.Add(tween1);
                tweens.Add(tween2);
    
                foreach (var tween in tweens)
                {
                    tween.Update();
                }
            }
        }
    
        public class TweenerBase
        {
            /// <summary>
            /// Make sure you mark the base implementation as 'virtual'.
            /// </summary>
            public virtual void Update()
            {
                Console.WriteLine(nameof(TweenerBase));
            }
        }
    
        public class Vector3Tweener : TweenerBase
        {
            /// <summary>
            /// Make sure to user 'override' keyword to override the base implementation.
            /// </summary>
            public override void Update()
            {
                Console.WriteLine(nameof(Vector3Tweener));
            }
        }
    
        public class ColorTweener : TweenerBase
        {
            /// <summary>
            /// Make sure to user 'override' keyword to override the base implementation.
            /// </summary>
            public override void Update()
            {
                Console.WriteLine(nameof(ColorTweener));
            }
        }
    }
