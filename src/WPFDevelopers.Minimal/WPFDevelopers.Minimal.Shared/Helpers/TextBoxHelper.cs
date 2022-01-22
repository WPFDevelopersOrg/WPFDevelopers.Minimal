using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace WPFDevelopers.Minimal.Helpers
{
    public class TextBoxHelper : DependencyObject
    {
        public static bool GetIsClearTextButton(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsClearTextButtonProperty);
        }

        public static void SetIsClearTextButton(DependencyObject obj, bool value)
        {
            obj.SetValue(IsClearTextButtonProperty, value);
        }

        public static readonly DependencyProperty IsClearTextButtonProperty =
            DependencyProperty.RegisterAttached("IsClearTextButton", typeof(bool), typeof(TextBoxHelper), new UIPropertyMetadata(false, OnIsClearTextButtonChanged));



        public static int GetTextLength(DependencyObject obj)
        {
            return (int)obj.GetValue(TextLengthProperty);
        }

        public static void SetTextLength(DependencyObject obj, int value)
        {
            obj.SetValue(TextLengthProperty, value);
        }

        public static readonly DependencyProperty TextLengthProperty =
            DependencyProperty.RegisterAttached("TextLength", typeof(int), typeof(TextBoxHelper), new UIPropertyMetadata(0));

        private static void OnIsClearTextButtonChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //var pb = d as PasswordBox;
            //if (pb == null)
            //{
            //    return;
            //}
            //if ((bool)e.NewValue)
            //{
            //    pb.PasswordChanged += PasswordChanged;
            //}
            //else
            //{
            //    pb.PasswordChanged -= PasswordChanged;
            //}
            if (d is TextBox textBox)
            {

            }
            else if (d is PasswordBox passwordBox)
            {
                //if (passwordBox == null)
                //{
                //    return;
                //}
                //if ((bool)e.NewValue)
                //{
                //    passwordBox.PasswordChanged += PasswordChanged;
                //}
                //else
                //{
                //    passwordBox.PasswordChanged -= PasswordChanged;
                //}
                passwordBox.Loaded -= PasswordChanged;
                passwordBox.Loaded += PasswordChanged;
                if (passwordBox.IsLoaded)
                {
                    PasswordChanged(passwordBox, new RoutedEventArgs());
                }
            }
        }
        private static void PasswordChanged(object sender, RoutedEventArgs e)
        {
        }
        
        //static void PasswordChanged(object sender, RoutedEventArgs e)
        //{
        //    var pb = sender as PasswordBox;
        //    if (pb == null)
        //        return;
        //    SetTextLength(pb, pb.Password.Length);

        //}
        
    }
}
