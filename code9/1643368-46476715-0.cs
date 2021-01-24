    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    namespace WpfStackOverflow.Models
    {
    /// <summary>
    /// Abstract class that provides common functionality accross all View Models.
    /// </summary>
    public abstract class modelBase : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        /// <summary>
        /// Provides a simplefied INotifyPropertyChanged interface.
        /// requires System.Runtime.CompilerServices and
        /// System.ComponentModel.
        /// </summary>
        /// <param name="property"></param>
        public void SetPropertyChanged([CallerMemberName] string property = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
    #endregion
    }
    namespace WpfStackOverflow.ViewModels
    {
        /// <summary>
        /// Abstract class that provides common functionality accross all View     Models.
        /// </summary>
        public abstract class ViewModelBase : INotifyPropertyChanged
        {
            #region INotifyPropertyChanged
            /// <summary>
            /// Provides a simplefied INotifyPropertyChanged interface.
            /// requires System.Runtime.CompilerServices and
            /// System.ComponentModel.
            /// </summary>
            /// <param name="property"></param>
            public void SetPropertyChanged([CallerMemberName] string property = null)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
            public event PropertyChangedEventHandler PropertyChanged;
            #endregion
        }
    }
