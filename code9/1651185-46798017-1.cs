    using UnityEngine;
    
    public class Encryption : MonoBehaviour {
    
        public interface IEncryption {
            void Encrypt();
        }
        
        public class TextEncryption : IEncryption {
            public void Encrypt() {
            }
        }
        
        public abstract class EncryptionDecorator : IEncryption {
    
            protected IEncryption tempEncryption;
    
            public EncryptionDecorator(IEncryption newEncryption) {
                //this will be called when you override the constructor
                Debug.Log("In EncryptionDecorator constructor: " + newEncryption.GetType());
                tempEncryption = newEncryption;
            }
    
            //if you are going to override a method, declare it either abstract ("passes implementation to child") or virtual ("allows for a base implementation")
            public virtual void Encrypt() {
    
                Debug.Log("In EncryptionDecorator.Encrypt(): " + tempEncryption.GetType());
                tempEncryption.Encrypt();
            }
        }
    
        public class L337EncryptionDecorator : EncryptionDecorator {
    
            public L337EncryptionDecorator(IEncryption newEncryption) : base(newEncryption) {
                
                //newEncryption is a parameter, think of it as sort of a local variable.
                //but since you pass it down to the parent class, it gets assigned to tempEncryption
                //the base-class constructor is called first!
                Debug.Log("In L337EncryptionDecorator constructor: " + newEncryption.GetType());
            }
    
            //this overrides the base implementation. you can call it with 
            //base.Encrypt() though.
            public override void Encrypt() {
                //you have no parameters here, but you could use the inherited variable tempEncryption because you declared it protected
                Debug.Log("In L337EncrytionDecorator.Encrypt(): " + tempEncryption.GetType());
    
                //base refers to the base class
                base.Encrypt();
            }
    
        }
    
        void Start() {
    
            IEncryption encryption = new L337EncryptionDecorator(new TextEncryption());
    
            encryption.Encrypt();
    
        }
    }
