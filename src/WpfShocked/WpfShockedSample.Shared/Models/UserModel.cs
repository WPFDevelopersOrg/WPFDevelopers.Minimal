using System;

namespace WpfShockedSample.Models
{
    public class UserModel : ViewModelBase
    {
        private bool _isChecked;
        public bool IsChecked 
        {
            get { return _isChecked; }
            set
            {
                _isChecked = value;
                NotifyPropertyChange("IsChecked");
            }
        }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
