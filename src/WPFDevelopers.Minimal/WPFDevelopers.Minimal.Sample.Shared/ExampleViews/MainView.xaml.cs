using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using WPFDevelopers.Minimal.Sample.Models;

namespace WPFDevelopers.Minimal.Sample.ExampleViews
{
    public partial class MainView : WPFDevelopers.Minimal.Net40.Window
    {
        #region DataSource
        public ObservableCollection<UserModel> UserCollection
        {
            get { return (ObservableCollection<UserModel>)GetValue(UserCollectionProperty); }
            set { SetValue(UserCollectionProperty, value); }
        }

        public static readonly DependencyProperty UserCollectionProperty =
            DependencyProperty.Register("UserCollection", typeof(ObservableCollection<UserModel>), typeof(MainView), new PropertyMetadata(null));


        public bool AllSelected
        {
            get { return (bool)GetValue(AllSelectedProperty); }
            set { SetValue(AllSelectedProperty, value); }
        }

        public static readonly DependencyProperty AllSelectedProperty =
            DependencyProperty.Register("AllSelected", typeof(bool), typeof(MainView), new PropertyMetadata(AllSelectedChangedCallback));

        private static void AllSelectedChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var view = d as MainView;
            var isChecked = (bool)e.NewValue;
            if ((bool)e.NewValue)
                view.UserCollection.ToList().ForEach(y => y.IsChecked = isChecked);
            else
                view.UserCollection.ToList().ForEach(y => y.IsChecked = isChecked);
        }

        #endregion

        public MainView()
        {
            InitializeComponent();
            this.Loaded += MainView_Loaded;
        }

        private void MainView_Loaded(object sender, RoutedEventArgs e)
        {
            var time = DateTime.Now;
            UserCollection = new ObservableCollection<UserModel>();
            for (int i = 0; i < 4; i++)
            {
                UserCollection.Add(new UserModel
                {
                    Date = time,
                    Name = "WPFDevelopers",
                    Address = "No. 189, Grove St, Los Angeles",
                    Children = new System.Collections.Generic.List<UserModel>()
                    {
                         new UserModel { Name= "WPFDevelopers.Minimal1.1" },
                         new UserModel { Name = "WPFDevelopers.Minimal1.2" },
                         new UserModel { Name = "WPFDevelopers.Minimal1.3" },
                          new UserModel { Name= "WPFDevelopers.Minimal1.4" },
                         new UserModel { Name = "WPFDevelopers.Minimal1.5" },
                         new UserModel { Name = "WPFDevelopers.Minimal1.6" },
                    }
                });
                time = time.AddDays(2);
            }
        }

        private void btnInformation_Click(object sender, RoutedEventArgs e)
        {
            WPFDevelopers.Minimal.Controls.MessageBox.Show("文件删除成功。", "消息",MessageBoxButton.OK,MessageBoxImage.Information);
        }
        private void btnWarning_Click(object sender, RoutedEventArgs e)
        {
            WPFDevelopers.Minimal.Controls.MessageBox.Show("当前文件不存在！", "警告", MessageBoxImage.Warning);
        }
        private void btnError_Click(object sender, RoutedEventArgs e)
        {
            WPFDevelopers.Minimal.Controls.MessageBox.Show("当前文件不存在。", "错误", MessageBoxImage.Error);
        }
        private void btnQuestion_Click(object sender, RoutedEventArgs e)
        {
            WPFDevelopers.Minimal.Controls.MessageBox.Show("当前文件不存在,是否继续?", "询问", MessageBoxButton.OKCancel, MessageBoxImage.Question);
        }
    }
}
