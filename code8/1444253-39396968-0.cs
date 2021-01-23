    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Autofac;
    using Autofac.Core;
    
    namespace DiagnosticDemo
    {
      public class TrackingModule : Module
      {
        private readonly IDictionary<Type, int> _activations = new Dictionary<Type, int>();
    
        private readonly object _syncRoot = new object();
    
        public void WriteActivations()
        {
          foreach (var pair in this._activations.Where(p => p.Value > 0))
          {
            Console.WriteLine("* {0} = {1}", pair.Key, pair.Value);
          }
        }
    
        protected override void AttachToComponentRegistration(
          IComponentRegistry componentRegistry,
          IComponentRegistration registration)
        {
          if (registration.Ownership == InstanceOwnership.OwnedByLifetimeScope)
          {
            registration.Activated += this.OnRegistrationActivated;
          }
        }
    
        private void OnRegistrationActivated(
          object sender,
          ActivatedEventArgs<object> e)
        {
          if (e.Instance is IDisposable)
          {
            var type = e.Instance.GetType();
            Console.WriteLine("Activating {0}", type);
            lock (this._syncRoot)
            {
              if (this._activations.ContainsKey(type))
              {
                this._activations[type] = this._activations[type]++;
              }
              else
              {
                this._activations[type] = 1;
              }
            }
          }
        }
      }
    }
