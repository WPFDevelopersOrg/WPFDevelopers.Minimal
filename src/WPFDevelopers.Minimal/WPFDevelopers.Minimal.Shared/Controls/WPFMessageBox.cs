using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WPFDevelopers.Minimal.Controls
{
    [TemplatePart(Name = TitleTemplateName, Type = typeof(TextBlock))]
    [TemplatePart(Name = CloseButtonTemplateName, Type = typeof(Button))]
    [TemplatePart(Name = MessageTemplateName, Type = typeof(TextBlock))]
    [TemplatePart(Name = ButtonCancelTemplateName, Type = typeof(Button))]
    [TemplatePart(Name = ButtonCancelTemplateName, Type = typeof(Button))]
    public sealed class WPFMessageBox : Window
    {

        private const string TitleTemplateName = "PART_Title";
        private const string CloseButtonTemplateName = "PART_CloseButton";
        private const string MessageTemplateName = "PART_Message";
        private const string ButtonCancelTemplateName = "PART_ButtonCancel";
        private const string ButtonOKTemplateName = "PART_ButtonOK";

        private string _messageString;
        private string _titleString;

        private TextBlock _title;
        private TextBlock _message;
        private Button _closeButton;
        private Button _buttonCancel;
        private Button _buttonOK;


        static WPFMessageBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(WPFMessageBox), new FrameworkPropertyMetadata(typeof(WPFMessageBox)));
            //DefaultStyleKeyProperty.OverrideMetadata(typeof(WPFMessageBox), new FrameworkPropertyMetadata(GetResourceKey<Style>("MessageBoxKey")));
        }

        //static T GetResourceKey<T>(string key)
        //{
        //    if (Application.Current.TryFindResource(key) is T resource)
        //    {
        //        return resource;
        //    }

        //    return default;
        //}

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _title = GetTemplateChild(TitleTemplateName) as TextBlock;
            _message = GetTemplateChild(MessageTemplateName) as TextBlock;

            if (_title == null || _message == null)
                throw new InvalidOperationException("the title or message control is null!");

            _title.Text = _titleString;
            _message.Text = _messageString;

            _closeButton = GetTemplateChild(CloseButtonTemplateName) as Button;
            if(_closeButton != null)
                _closeButton.Click += _closeButton_Click;
            _buttonCancel = GetTemplateChild(ButtonCancelTemplateName) as Button;
            _buttonOK = GetTemplateChild(ButtonOKTemplateName) as Button;
        }

        private void _closeButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            var grid = this.Owner.Content as Grid;
            UIElement original = VisualTreeHelper.GetChild(grid, 0) as UIElement;
            grid.Children.Remove(original);
            this.Owner.Content = original;
        }

        public MessageBoxResult Result { get; set; }

        public WPFMessageBox(string message)
        {
            //Message = message;
            //DisplayButtons(MessageBoxButton.OK);
            //_message.Text = message;
            _messageString = message;
        }

        public WPFMessageBox(string message, string caption)
        {
            _titleString = caption;
            _messageString = message;
            //_title.Text = caption;
            //_message.Text = message;
            //Message = message;
            //Caption = caption;
            //DisplayButtons(MessageBoxButton.OK);
        }

        public WPFMessageBox(string message, string caption, MessageBoxButton button)
        {
            _title.Text = caption;
            _message.Text = message;

            //Message = message;
            //Caption = caption;
            //Image_MessageBox.Visibility = System.Windows.Visibility.Collapsed;

            //DisplayButtons(button);
        }

        public WPFMessageBox(string message, string caption, MessageBoxImage image)
        {
            _title.Text = caption;
            _message.Text = message;
            //Message = message;
            //Caption = caption;
            //DisplayImage(image);
            //DisplayButtons(MessageBoxButton.OK);
        }

        public WPFMessageBox(string message, string caption, MessageBoxButton button, MessageBoxImage image)
        {
            _title.Text = caption;
            _message.Text = message;

            //Message = message;
            //Caption = caption;

            //DisplayButtons(button);
            //DisplayImage(image);
        }
    }
}
