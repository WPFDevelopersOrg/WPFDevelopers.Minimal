using WPFDevelopers.Minimal.Helpers;

namespace WPFDevelopers.Minimal.Controls
{
    public class ThemeModel : ViewModelBase
    {
        private bool _isChecked;

        /// <summary>
        ///     whether to choose
        /// </summary>
        public bool IsChecked
        {
            get => _isChecked;
            set
            {
                _isChecked = value;
                NotifyPropertyChange("IsChecked");
            }
        }

        /// <summary>
        ///     display color
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        ///     resource path
        /// </summary>
        public string ResourcePath { get; set; }
    }
}