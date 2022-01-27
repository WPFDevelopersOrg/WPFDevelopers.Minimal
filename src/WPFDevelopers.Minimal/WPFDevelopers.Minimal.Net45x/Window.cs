using System;
using System.Windows;
using System.Windows.Input;

namespace WPFDevelopers.Minimal.Net45x
{
    public class Window : System.Windows.Window
    {

        public double TitleHeight
        {
            get { return (double)GetValue(TitleHeightProperty); }
            set { SetValue(TitleHeightProperty, value); }
        }

        public static readonly DependencyProperty TitleHeightProperty =
            DependencyProperty.Register("TitleHeight", typeof(double), typeof(Window), new PropertyMetadata(50d));

        static Window()
        {
            StyleProperty.OverrideMetadata(typeof(Window), new FrameworkPropertyMetadata(GetResourceKey<Style>("WPFDevelopersWindow")));
        }
        static T GetResourceKey<T>(string key)
        {
            if (Application.Current.TryFindResource(key) is T resource)
            {
                return resource;
            }

            return default;
        }
        public Window()
        {
            CommandBindings.Add(new CommandBinding(SystemCommands.CloseWindowCommand, CloseWindow));
            CommandBindings.Add(new CommandBinding(SystemCommands.MaximizeWindowCommand, MaximizeWindow, CanResizeWindow));
            CommandBindings.Add(new CommandBinding(SystemCommands.MinimizeWindowCommand, MinimizeWindow, CanMinimizeWindow));
            CommandBindings.Add(new CommandBinding(SystemCommands.RestoreWindowCommand, RestoreWindow, CanResizeWindow));
            //CommandBindings.Add(new CommandBinding(SystemCommands.ShowSystemMenuCommand, ShowSystemMenu));
        }

        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);
            if (SizeToContent == SizeToContent.WidthAndHeight)
                InvalidateMeasure();
        }

        #region Window Commands

        private void CanResizeWindow(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ResizeMode == ResizeMode.CanResize || ResizeMode == ResizeMode.CanResizeWithGrip;
        }

        private void CanMinimizeWindow(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ResizeMode != ResizeMode.NoResize;
        }

        private void CloseWindow(object sender, ExecutedRoutedEventArgs e)
        {
            //Close();
            SystemCommands.CloseWindow(this);
        }

        private void MaximizeWindow(object sender, ExecutedRoutedEventArgs e)
        {
            SystemCommands.MaximizeWindow(this);
        }

        private void MinimizeWindow(object sender, ExecutedRoutedEventArgs e)
        {
            SystemCommands.MinimizeWindow(this);
        }

        private void RestoreWindow(object sender, ExecutedRoutedEventArgs e)
        {
            SystemCommands.RestoreWindow(this);
        }
      
        private void ShowSystemMenu(object sender, ExecutedRoutedEventArgs e)
        {
            var element = e.OriginalSource as FrameworkElement;
            if (element == null)
                return;

            var point = WindowState == WindowState.Maximized ? new Point(0, element.ActualHeight)
                : new Point(Left + BorderThickness.Left, element.ActualHeight + Top + BorderThickness.Top);
            point = element.TransformToAncestor(this).Transform(point);
            SystemCommands.ShowSystemMenu(this, point);
        }

        #endregion

    }
}
