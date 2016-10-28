using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using WPF.Command;

namespace WPF.ViewModel
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public RelayCommand<Window> CloseWindowCommand { get; } = new RelayCommand<Window>(window => window?.Close());

        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }

        protected void RaisePropertyChanged(string propertyName)
        {
            VerifyPropertyName(propertyName);
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        /// <summary> 
        /// Warns the developer if this Object does not have a public property with 
        /// the specified name. This method does not exist in a Release build. 
        /// </summary> 
        [Conditional("DEBUG")]
        [DebuggerStepThrough]
        public void VerifyPropertyName(string propertyName)
        {
            // verify that the property name matches a real,   
            // public, instance property on this Object. 
            if (TypeDescriptor.GetProperties(this)[propertyName] == null)
            {
                Debug.Fail("Invalid property name: " + propertyName);
            }
        }
    }
}
