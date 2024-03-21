using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MakdoknekEntities contex = new MakdoknekEntities();
        bool ClientTableIsEnabled = false;
        bool MenuTableIsEnabled = false;
        bool BookingTableIsEnabled = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) // поиск
        {
            if (ClientTableIsEnabled == true)
                ClientDgr.ItemsSource = contex.Client.ToList().Where(item => item.Client_fName.Contains(SearchTxt.Text));
            if (MenuTableIsEnabled == true)
                ClientDgr.ItemsSource = contex.Menu.ToList().Where(item => item.Dish_name.Contains(SearchTxt.Text));
            if (BookingTableIsEnabled == true)
                ClientDgr.ItemsSource = contex.Booking.ToList().Where(item => item.Booking_date.Contains(SearchTxt.Text));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) // клиенты
        {
            ClientDgr.ItemsSource = contex.Client.ToList();

            ClientTableIsEnabled = true;
            MenuTableIsEnabled = false;
            BookingTableIsEnabled = false;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) // меню
        {
            ClientDgr.ItemsSource = contex.Menu.ToList();

            ClientTableIsEnabled = false;
            MenuTableIsEnabled = true;
            BookingTableIsEnabled = false;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e) // заказы
        {
            ClientDgr.ItemsSource = contex.Booking.ToList();

            ClientCbx.ItemsSource = contex.Client.ToList();

            ClientTableIsEnabled = false;
            MenuTableIsEnabled = false;
            BookingTableIsEnabled = true;
        }

        private void ClientCbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ClientCbx.SelectedItem != null)
            {
                var selected = ClientCbx.SelectedItem as Client;
                ClientDgr.ItemsSource = contex.Booking.ToList().Where(item => item.Client == selected);
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e) // очистка
        {
            ClientDgr.ItemsSource = contex.Booking.ToList();
        }
    }
}
