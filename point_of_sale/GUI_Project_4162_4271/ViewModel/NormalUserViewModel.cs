using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GUI_Project_4162_4271.Context;
using GUI_Project_4162_4271.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows;
using GUI_Project_4162_4271.Views;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Controls.Primitives;

namespace GUI_Project_4162_4271.ViewModel
{
    public partial class NormalUserViewModel : ObservableObject
    {


        [ObservableProperty]
        public int id;
        [ObservableProperty]
        public string itemName;
        [ObservableProperty]
        public double unitPrice ;
        [ObservableProperty]
        public int unit;
        [ObservableProperty]
        public double totalPrice;

        [ObservableProperty]
        public string normalUsername;
        [ObservableProperty]
        public int normaluserpassword;
        [ObservableProperty]
        public int normaluserid;
        public UserType usertype;
        [ObservableProperty]
        

        


        ObservableCollection<NormalUser> normalusers;


        public string NormalUserName { get; set; }
        public int NormalUserPassword { get; set; }
        public UserType Usertype { get; set; }
        // public int NormalUserId { get; set; }
        /*
        public string NormalUsername
        {
            get { return normalusername; }
            set { normalusername = value; }
        }
        public int NormalUserPassword
        {
            get { return normaluserpassword; }
            set { normaluserpassword = value; }
        }
        public int NormalUserId
        {
            get { return normaluserid; }
            set { normaluserid = value; }
        }
        public UserType UserType
        {
            get { return usertype; }
            set { usertype = value; }
        }

        */
        public void ShowCustomMessageBox(string message)
        {
            var messageBox = new Window()
            {
                WindowStyle = WindowStyle.None,
                ResizeMode = ResizeMode.NoResize,
                Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#545d6a")),
                Foreground = Brushes.White,
                Width = 300,
                Height = 150,
                Topmost = true,
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };

            var contentStackPanel = new StackPanel();

            var messageTextBlock = new TextBlock()
            {
                Text = message,
                FontSize = 16,
                Padding = new Thickness(20),
                TextWrapping = TextWrapping.Wrap,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };

            var closeButton = new Button()
            {
                Content = "Close",
                Width = 80,
                Height = 30,
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





        

        [RelayCommand]
        public void LoginNormal()
        {
            using (var dbContext = new NormalUserContext())
            {
                var n = dbContext.NormalUsers.FirstOrDefault(a => a.NormalUsername == NormalUsername);

                if (n != null)
                {

                    // Verify the password against the stored password

                    if (VerifyPassword(n.NormalUserPassword, NormalUserPassword))
                    {
                        // Password is correct, perform the login action
                        // You can navigate to the appropriate view here

                        UserWindow userWindow = new UserWindow();
                        userWindow.Show();
                        

                    }
                    else
                    {
                        // Incorrect password, show error message
                        // MessageBox.Show($"Error2");
                        ShowCustomMessageBox("Incorrect Password!");
                    }

                }

                else
                {
                    // User not found, show error message
                    // MessageBox.Show($"Error1");
                    ShowCustomMessageBox("Error");
                }


            }
        }

        private bool VerifyPassword(int storedPassword, int enteredPassword)
        {
            return storedPassword == enteredPassword;
        }

        // Other code...

        




        [ObservableProperty]
        ObservableCollection<Item> items;
        

        public Item? SelectedItem { get; set; }
        

        [RelayCommand]
        public void InsertItem()
        {
            if (string.IsNullOrWhiteSpace(ItemName))
            {
                ShowCustomMessageBox("Item Name is required.");
                return;
            }

            if (UnitPrice <= 0)
            {
                ShowCustomMessageBox("Unit Price must be greater than 0.");
                return;
            }

            if (Unit <= 0)
            {
                ShowCustomMessageBox("Unit must be greater than 0.");
                return;
            }


            Item p = new Item()
            {
                Id = Id,
                ItemName = ItemName,
                UnitPrice = UnitPrice,
                Unit = Unit,
                TotalPrice = TotalPriceCalc(Unit, UnitPrice)
            };

            using (var db = new ItemContext())
            {
                db.Items.Add(p);
                db.SaveChanges();
            }

            LoadItem();

            // Clear the properties
            Id = 0;
            ItemName = string.Empty;
            UnitPrice = 0;
            Unit = 0;
            TotalPrice = 0;

            ShowCustomMessageBox("Item added successfully!");
        }

        public double TotalPriceCalc(double unit, double price) { 
            return unit* price;
        }


        [RelayCommand]
        public void DeleteItem()
        {
            if (SelectedItem != null && SelectedItem.Id != 0) 
            {
                using (var db = new ItemContext())
                {
                    var itemToDelete = db.Items.Find(SelectedItem.Id);
                    if (itemToDelete != null)
                    {
                        db.Items.Remove(itemToDelete);
                        db.SaveChanges();
                        LoadItem();
                    }
                    else
                    {
                        ShowCustomMessageBox("Item not found in the database.");
                    }
                }
            }
            else
            {
                ShowCustomMessageBox("Please select an item to delete.");
            }
        }


        private bool isEditing;

        [RelayCommand]
        public void EditItem()
        {
            if (!isEditing)
            {
                if (SelectedItem == null)
                {
                    ShowCustomMessageBox("Please select an item to update.");
                    return;
                }

                ItemName = SelectedItem.ItemName;
                UnitPrice = SelectedItem.UnitPrice;
                Id = SelectedItem.Id;
                Unit = SelectedItem.Unit;
                TotalPrice = SelectedItem.TotalPrice;

                isEditing = true; 
            }
            else
            {
                using (var db = new ItemContext())
                {
                    Item selectedItemFromDb = db.Items.Find(Id); 

                    if (selectedItemFromDb != null)
                    {
                        selectedItemFromDb.ItemName = ItemName;
                        selectedItemFromDb.UnitPrice = UnitPrice;
                        selectedItemFromDb.Unit = Unit;
                        selectedItemFromDb.TotalPrice = Unit*UnitPrice;

                        db.SaveChanges();

                        LoadItem();
                    }
                    else
                    {
                        ShowCustomMessageBox("Selected item is not found in the database.");
                    }
                }

                isEditing = false; 

                ItemName = string.Empty;
                UnitPrice = 0;
                Id = 0;
                Unit = 0;
                TotalPrice = 0;
            }
        }


        public Item GetItemById(int id)
        {
            using (var db = new ItemContext())
            {
                return db.Items.FirstOrDefault(p => p.Id == id);
            }
        }
        public void LoadItem()
        {
            using (var db = new ItemContext())
            {
                var list = db.Items.ToList();
                Items = new ObservableCollection<Item>(list);
            }
        }
        public NormalUserViewModel()
        {
            LoadItem();
        }



        private ICommand insertNormalUserCommand;

        public ICommand InsertNormalUserCommand
        {
            get
            {
                if (insertNormalUserCommand == null)
                {
                    insertNormalUserCommand = new RelayCommand(InsertNormalUser);
                }
                return insertNormalUserCommand;
            }
        }
        public void InsertNormalUser()
        {
            NormalUser n = new NormalUser()
            {
                NormalUsername = NormalUsername,
                NormalUserPassword = NormalUserPassword,
                //UserType = UserType
            };
            using (var db = new NormalUserContext())
            {
                db.NormalUsers.Add(n);
                db.SaveChanges();
                //MessageBox.Show($"Added");
                ShowCustomMessageBox("User name and Password added to the database successfully!");
            }

        }
    }



}

