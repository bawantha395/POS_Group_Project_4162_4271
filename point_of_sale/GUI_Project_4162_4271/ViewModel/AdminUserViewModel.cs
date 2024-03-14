using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GUI_Project_4162_4271.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using GUI_Project_4162_4271.Context;
using GUI_Project_4162_4271.Views;
using System.Windows.Input;

namespace GUI_Project_4162_4271.ViewModel
{
    public partial class AdminUserViewModel : ObservableObject
    {
        [ObservableProperty]
        public string adminusername;
        [ObservableProperty]
        public int adminuserpassword;
        [ObservableProperty]
        public int adminid;
        [ObservableProperty]
        public UserType usertype;
        [ObservableProperty]
        ObservableCollection<AdminUser> adminusers;





       
        
        public string AdminUsername { get; set; }
        public int AdminPassword { get; set; }
        public int AdminlUserId { get; set; }






        public void ShowCustomMessageBox(string message)
        {
            var messageBox = new Window()
            {
                WindowStyle = WindowStyle.None,
                ResizeMode = ResizeMode.NoResize,
                Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#545d6a")),
                Foreground = Brushes.White,
                Width = 400,
                Height = 200,
                Topmost = true,
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };

            var contentStackPanel = new StackPanel();

            var messageTextBlock = new TextBlock()
            {
                Text = message,
                FontSize = 14,
                Padding = new Thickness(20),
                TextWrapping = TextWrapping.Wrap,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };

            var closeButton = new Button()
            {
                Content = "Close",
                Width = 75,
                Height = 25,
                Margin = new Thickness(10),
                Background = Brushes.LightGray,
                Foreground = Brushes.Black
            };

            closeButton.Click += (sender, e) =>
            {
                messageBox.Close();
            };

            contentStackPanel.Children.Add(messageTextBlock);
            contentStackPanel.Children.Add(closeButton);

            messageBox.Content = contentStackPanel;

            messageBox.Show();
        }

        private ICommand loginAdminCommand;

        public ICommand LoginAdminCommand
        {
            get
            {
                if (loginAdminCommand == null)
                {
                    loginAdminCommand = new RelayCommand(LoginAdmin);
                }
                return loginAdminCommand;
            }
        }

        public void LoginAdmin()
        {
            Console.WriteLine("AdminUserName input: " + AdminUsername);
            using (var dbContext = new AdminUserContext())
            {
                var adminUser = dbContext.AdminUsers.FirstOrDefault(a => a.AdminUserName == AdminUsername);

                if (adminUser == null)
                {
                    ShowCustomMessageBox("Error: Admin user not found");
                    return;
                }

                if (adminUser.UserType == UserType.Admin)
                {
                    if (VerifyPassword(adminUser.AdminUserPassword, AdminPassword))
                    {

                        AdminWindow adminWindow = new AdminWindow();
                        adminWindow.Show();
                    }
                    else
                    {
                        ShowCustomMessageBox("Incorrect password");
                    }
                }
                else
                {
                    ShowCustomMessageBox("You do not have admin privileges");
                }
            }
        }

        private bool VerifyPassword(int storedPassword, int enteredPassword)
        {
            return storedPassword == enteredPassword;
        }


    }
}