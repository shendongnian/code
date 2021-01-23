    /// <summary>
    /// PclWeakEventManager base class
    /// </summary>
    /// <typeparam name="TEventSource">The type of the event source.</typeparam>
    /// <typeparam name="TEventHandler">The type of the event handler.</typeparam>
    /// <typeparam name="TEventArgs">The type of the event arguments.</typeparam>
    public class PclWeakEventManager<TEventSource, TEventHandler, TEventArgs>
    {
        static readonly object StaticSource = new object();
        /// <summary>
        /// Mapping between the target of the delegate (for example a Button) and the handler (EventHandler).
        /// Windows Phone needs this, otherwise the event handler gets garbage collected.
        /// </summary>
        ConditionalWeakTable<object, List<Delegate>> targetToEventHandler = new ConditionalWeakTable<object, List<Delegate>>();
        /// <summary>
        /// Mapping from the source of the event to the list of handlers. This is a CWT to ensure it does not leak the source of the event.
        /// </summary>
        ConditionalWeakTable<object, WeakHandlerList> sourceToWeakHandlers = new ConditionalWeakTable<object, WeakHandlerList>();
        /// <summary>
        /// Singleton instance
        /// </summary>
        static Lazy<PclWeakEventManager<TEventSource, TEventHandler, TEventArgs>> current =
            new Lazy<PclWeakEventManager<TEventSource, TEventHandler, TEventArgs>>(() => new PclWeakEventManager<TEventSource, TEventHandler, TEventArgs>());
        /// <summary>
        /// Get the singleton instance
        /// </summary>
        static PclWeakEventManager<TEventSource, TEventHandler, TEventArgs> Current
        {
            get { return current.Value; }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="PclWeakEventManager{TEventSource, TEventHandler, TEventArgs}"/> class.
        /// Protected to disallow instances of this class and force a subclass.
        /// </summary>
        protected PclWeakEventManager()
        {
        }
        #region Public static methods
        /// <summary>
        /// Adds a weak reference to the handler and associates it with the source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="handler">The handler.</param>
        public static void AddHandler(TEventSource source, TEventHandler handler, Func<EventHandler<TEventArgs>, TEventHandler> converter, Action<TEventHandler> add, Action<TEventHandler> remove)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (handler == null) throw new ArgumentNullException("handler");
            if (!typeof(TEventHandler).GetTypeInfo().IsSubclassOf(typeof(Delegate)))
            {
                throw new ArgumentException("Handler must be Delegate type");
            }
            var observable = Observable.FromEventPattern(converter, add, remove);
            Current.PrivateAddHandler(source, observable, handler);
        }
        /// <summary>
        /// Removes the association between the source and the handler.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="handler">The handler.</param>
        public static void RemoveHandler(TEventSource source, TEventHandler handler)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (handler == null) throw new ArgumentNullException("handler");
            if (!typeof(TEventHandler).GetTypeInfo().IsSubclassOf(typeof(Delegate)))
            {
                throw new ArgumentException("handler must be Delegate type");
            }
            Current.PrivateRemoveHandler(source, handler);
        }
        #endregion
        #region Event delivering
        /// <summary>
        /// Delivers the event to the handlers registered for the source. 
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="TEventArgs"/> instance containing the event data.</param>
        public static void DeliverEvent(TEventSource sender, TEventArgs args)
        {
            Current.PrivateDeliverEvent(sender, args);
        }
        /// <summary>
        /// Override this method to attach to an event.
        /// </summary>
        /// <param name="source">The source.</param>
        protected virtual void StartListening(TEventSource source, IObservable<EventPattern<TEventArgs>> observable, TEventHandler handler)
        {
            //The handler - proxy should be static, otherwise it will create a strong reference
            InternalSubscribeWeakly(observable, source, handler, DeliverEvent);
        }
        /// <summary>
        /// Override this method to detach from an event.
        /// </summary>
        /// <param name="source">The source.</param>
        protected virtual void StopListening(object source)
        {
            //This method is for future usage
        }
        /// <summary>
        /// Fire the event handler
        /// </summary>
        /// <param name="sender">Event publisher</param>
        /// <param name="args">Event arguments</param>
        void PrivateDeliverEvent(object sender, TEventArgs args)
        {
            object source = sender != null ? sender : StaticSource;
            var weakHandlers = default(WeakHandlerList);
            bool hasStaleEntries = false;
            if (this.sourceToWeakHandlers.TryGetValue(source, out weakHandlers))
            {
                using (weakHandlers.DeliverActive())
                {
                    hasStaleEntries = weakHandlers.DeliverEvent(source, args);
                }
            }
            if (hasStaleEntries)
            {
                this.Purge(source);
            }
        }
        #endregion
        #region Add weak handler methods
        /// <summary>
        /// Adds the event handler to WeakTables
        /// </summary>
        /// <param name="source">The event publisher source</param>
        /// <param name="observable">Observable object</param>
        /// <param name="handler">The event handler. This is used to create a weak reference</param>
        void PrivateAddHandler(TEventSource source, IObservable<EventPattern<TEventArgs>> observable, TEventHandler handler)
        {
            this.AddWeakHandler(source, observable, handler);
            this.AddTargetHandler(handler);
        }
        /// <summary>
        /// Add a weak handler
        /// </summary>
        /// <param name="source">The event publisher source</param>
        /// <param name="observable">Observable object</param>
        /// <param name="handler">The event handler. This is used to create a weak reference</param>
        void AddWeakHandler(TEventSource source, IObservable<EventPattern<TEventArgs>> observable, TEventHandler handler)
        {
            WeakHandlerList weakHandlers;
            //If for the event source table wasn't created, then it creates a new
            if (this.sourceToWeakHandlers.TryGetValue(source, out weakHandlers))
            {
                // clone list if we are currently delivering an event
                if (weakHandlers.IsDeliverActive)
                {
                    weakHandlers = weakHandlers.Clone();
                    this.sourceToWeakHandlers.Remove(source);
                    this.sourceToWeakHandlers.Add(source, weakHandlers);
                }
                weakHandlers.AddWeakHandler(source, handler);
            }
            else
            {
                weakHandlers = new WeakHandlerList();
                weakHandlers.AddWeakHandler(source, handler);
                this.sourceToWeakHandlers.Add(source, weakHandlers);
                this.StartListening(source, observable, handler);
            }
            this.Purge(source);
        }
        /// <summary>
        /// Subscribe to the event
        /// </summary>
        /// <param name="observable">Observable object</param>
        /// <param name="source">The event publisher source</param>
        /// <param name="handler">The event handler. This is used to create a weak reference</param>
        /// <param name="onNext">Event handler delegate</param>
        private static void InternalSubscribeWeakly(IObservable<EventPattern<TEventArgs>> observable, TEventSource source, TEventHandler handler, Action<TEventSource, TEventArgs> onNext)
        {
            if (onNext.Target != null)
                throw new ArgumentException("onNext must refer to a static method, or else the subscription will still hold a strong reference to target");
            // Is the delegate alive?
            var Weak_onNextReferance = new WeakReference(handler);
            //This is a link for that event, so if you want to unsubscribe from event you have to dispose this object
            IDisposable subscription = null;
            subscription = observable.Subscribe(item =>
            {
                //Purge handler if the subscriber is not alive
                Current.Purge(source);
                //So the library keeps weak reference for this object and each time event fired it tries to get that object
                var current_onNext = Weak_onNextReferance.Target;
                if (current_onNext != null)
                {
                    //If the object was found, it uses the delegate that subscriber provided and fires the event
                    onNext((TEventSource)item.Sender, item.EventArgs);
                }
                else
                {
                    //If the object is not found it disposes the link
                    subscription.Dispose();
                    Current.sourceToWeakHandlers.Remove(source);
                }
            });
        }
        /// <summary>
        /// Adds the event handler to the weak event handlers list
        /// </summary>
        /// <param name="handler">The event handler. This is used to create a weak reference</param>
        void AddTargetHandler(TEventHandler handler)
        {
            var @delegate = handler as Delegate;
            object key = @delegate.Target ?? StaticSource;
            List<Delegate> delegates;
            if (this.targetToEventHandler.TryGetValue(key, out delegates))
            {
                delegates.Add(@delegate);
            }
            else
            {
                delegates = new List<Delegate>();
                delegates.Add(@delegate);
                this.targetToEventHandler.Add(key, delegates);
            }
        }
        #endregion
        #region Remove weak handler methods
        /// <summary>
        /// Remove the event handler
        /// </summary>
        /// <param name="source">Event source object</param>
        /// <param name="handler">The event handler</param>
        void PrivateRemoveHandler(TEventSource source, TEventHandler handler)
        {
            this.RemoveWeakHandler(source, handler);
            this.RemoveTargetHandler(handler);
        }
        /// <summary>
        /// Remove the event handler
        /// </summary>
        /// <param name="source">Event source object</param>
        /// <param name="handler">The event handler</param>
        void RemoveWeakHandler(TEventSource source, TEventHandler handler)
        {
            var weakHandlers = default(WeakHandlerList);
            if (this.sourceToWeakHandlers.TryGetValue(source, out weakHandlers))
            {
                // clone list if we are currently delivering an event
                if (weakHandlers.IsDeliverActive)
                {
                    weakHandlers = weakHandlers.Clone();
                    this.sourceToWeakHandlers.Remove(source);
                    this.sourceToWeakHandlers.Add(source, weakHandlers);
                }
                if (weakHandlers.RemoveWeakHandler(source, handler) && weakHandlers.Count == 0)
                {
                    this.sourceToWeakHandlers.Remove(source);
                    this.StopListening(source);
                }
            }
        }
        /// <summary>
        /// Remove the handler from weaktable
        /// </summary>
        /// <param name="handler">The event handler</param>
        void RemoveTargetHandler(TEventHandler handler)
        {
            var @delegate = handler as Delegate;
            object key = @delegate.Target ?? StaticSource;
            var delegates = default(List<Delegate>);
            if (this.targetToEventHandler.TryGetValue(key, out delegates))
            {
                delegates.Remove(@delegate);
                if (delegates.Count == 0)
                {
                    this.targetToEventHandler.Remove(key);
                }
            }
        }
        /// <summary>
        /// Remove dead handlers
        /// </summary>
        /// <param name="source">Source object</param>
        void Purge(object source)
        {
            var weakHandlers = default(WeakHandlerList);
            if (this.sourceToWeakHandlers.TryGetValue(source, out weakHandlers))
            {
                if (weakHandlers.IsDeliverActive)
                {
                    weakHandlers = weakHandlers.Clone();
                    this.sourceToWeakHandlers.Remove(source);
                    this.sourceToWeakHandlers.Add(source, weakHandlers);
                }
                else
                {
                    weakHandlers.Purge();
                }
            }
        }
        #endregion
        #region WeakHandler table helper classes
        /// <summary>
        /// Weak handler helper class
        /// </summary>
        internal class WeakHandler
        {
            WeakReference source;
            WeakReference originalHandler;
            public bool IsActive
            {
                get { return this.source != null && this.source.IsAlive && this.originalHandler != null && this.originalHandler.IsAlive; }
            }
            public TEventHandler Handler
            {
                get
                {
                    if (this.originalHandler == null)
                    {
                        return default(TEventHandler);
                    }
                    else
                    {
                        return (TEventHandler)this.originalHandler.Target;
                    }
                }
            }
            public WeakHandler(object source, TEventHandler originalHandler)
            {
                this.source = new WeakReference(source);
                this.originalHandler = new WeakReference(originalHandler);
            }
            /// <summary>
            /// Checks if provided handler is the same
            /// </summary>
            /// <param name="source"></param>
            /// <param name="handler"></param>
            /// <returns>True if source.Target is equals to source, otherwise false</returns>
            public bool Matches(object source, TEventHandler handler)
            {
                return this.source != null &&
                    object.ReferenceEquals(this.source.Target, source) &&
                    this.originalHandler != null;
            }
        }
        /// <summary>
        /// Weak event handler manager
        /// </summary>
        internal class WeakHandlerList
        {
            int deliveries = 0;
            List<WeakHandler> handlers;
            public WeakHandlerList()
            {
                handlers = new List<WeakHandler>();
            }
            /// <summary>
            /// Adds new weak event handler to the list
            /// </summary>
            /// <param name="source">The event source</param>
            /// <param name="handler">The event handler</param>
            public void AddWeakHandler(TEventSource source, TEventHandler handler)
            {
                WeakHandler handlerSink = new WeakHandler(source, handler);
                handlers.Add(handlerSink);
            }
            /// <summary>
            /// Remove weak handler from the list
            /// </summary>
            /// <param name="source">The event source</param>
            /// <param name="handler">The event handler</param>
            /// <returns>True if the handler was removed, otherwise false</returns>
            public bool RemoveWeakHandler(TEventSource source, TEventHandler handler)
            {
                foreach (var weakHandler in handlers)
                {
                    if (weakHandler.Matches(source, handler))
                    {
                        return handlers.Remove(weakHandler);
                    }
                }
                return false;
            }
            /// <summary>
            /// Clones the list
            /// </summary>
            /// <returns></returns>
            public WeakHandlerList Clone()
            {
                WeakHandlerList newList = new WeakHandlerList();
                newList.handlers.AddRange(this.handlers.Where(h => h.IsActive));
                return newList;
            }
            /// <summary>
            /// Items count
            /// </summary>
            public int Count
            {
                get { return this.handlers.Count; }
            }
            /// <summary>
            /// True if any of the events are still in delivering process
            /// </summary>
            public bool IsDeliverActive
            {
                get { return this.deliveries > 0; }
            }
            public IDisposable DeliverActive()
            {
                Interlocked.Increment(ref this.deliveries);
                return Disposable.Create(() => Interlocked.Decrement(ref this.deliveries));
            }
            /// <summary>
            /// Fire the handler
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="args"></param>
            /// <returns></returns>
            public virtual bool DeliverEvent(object sender, TEventArgs args)
            {
                bool hasStaleEntries = false;
                foreach (var handler in handlers)
                {
                    if (handler.IsActive)
                    {
                        var @delegate = handler.Handler as Delegate;
                        @delegate.DynamicInvoke(sender, args);
                    }
                    else
                    {
                        hasStaleEntries = true;
                    }
                }
                return hasStaleEntries;
            }
            /// <summary>
            /// Removes dead handlers
            /// </summary>
            public void Purge()
            {
                for (int i = handlers.Count - 1; i >= 0; i--)
                {
                    if (!handlers[i].IsActive)
                    {
                        handlers.RemoveAt(i);
                    }
                }
            }
        }
        #endregion
    }
