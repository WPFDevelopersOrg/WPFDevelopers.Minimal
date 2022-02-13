using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace WPFDevelopers.Minimal.Helpers
{
    public class MaskAdorner : Adorner
    {
        private UIElement child;

        public MaskAdorner(UIElement adornedElement) : base(adornedElement)
        {

        }
      
        public UIElement Child
        {
            get => child;
            set
            {
                if (value == null)
                {
                    RemoveVisualChild(child);
                }
                else
                {
                    AddVisualChild(value);
                }
                child = value;
            }
        }
        protected override int VisualChildrenCount => 1;
        protected override Size ArrangeOverride(Size finalSize)
        {
            child?.Arrange(new Rect(finalSize));
            return finalSize;
        }
        protected override Visual GetVisualChild(int index)
        {
            if (index == 0 && child != null) return child;
            return base.GetVisualChild(index);
        }
    }
}
