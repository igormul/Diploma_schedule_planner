using System;
using System.Collections.Generic;
using System.IO;
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

namespace Diplom
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static public Random rand = new Random();
        DataBase DB = new DataBase();
        Dictionary DC = new Dictionary();
        Generation GN = new Generation();
        public MainWindow()
        {
            InitializeComponent();
            StartUp();
        }


        private void StartUp()
        {
            ComboBox.Items.Add("Викладачі");
            ComboBox.Items.Add("Студенти");
            ComboBox.Items.Add("Аудиторії");
            ComboBox.Items.Add("Предмети");
            ComboBox.SelectedIndex = 3;
            string query = File.ReadAllText(@"./SQL_subjects.sql");
            MainGrid.ItemsSource = DB.Ex_Select_Comm(query).DefaultView;
        }

        private void ComboBox_DropDownClosed(object sender, EventArgs e)
        {
            string query;
            if (ComboBox.Text == "Викладачі")
            {
                query = File.ReadAllText(@"./SQL_teachers.sql");
                MainGrid.ItemsSource = DB.Ex_Select_Comm(query).DefaultView;
            }

            if (ComboBox.Text == "Студенти")
            {
                query = File.ReadAllText(@"./SQL_groups.sql");
                MainGrid.ItemsSource = DB.Ex_Select_Comm(query).DefaultView;
            }

            if (ComboBox.Text == "Аудиторії")
            {
                query = File.ReadAllText(@"./SQL_rooms.sql");
                MainGrid.ItemsSource = DB.Ex_Select_Comm(query).DefaultView;
            }

            if (ComboBox.Text == "Предмети")
            {
                query = File.ReadAllText(@"./SQL_subjects.sql");
                MainGrid.ItemsSource = DB.Ex_Select_Comm(query).DefaultView;
            }
        }

        private void Add_t_b_Click(object sender, RoutedEventArgs e)
        {
            Insert_Teacher_Window insert_t_window = new Insert_Teacher_Window(DB);
            insert_t_window.Show();
        }

        private void Add_g_b_Click(object sender, RoutedEventArgs e)
        {
            Insert_Groups_Window insert_g_window = new Insert_Groups_Window(DB);
            insert_g_window.Show();
        }

        private void Add_r_b_Click(object sender, RoutedEventArgs e)
        {
            Insert_Rooms_Window insert_r_window = new Insert_Rooms_Window(DB);
            insert_r_window.Show();
        }

        private void Add_s_b_Click(object sender, RoutedEventArgs e)
        {
            Insert_Subject_Window insert_s_window = new Insert_Subject_Window(DB);
            insert_s_window.Show();
        }

        private void Gen_b_Click(object sender, RoutedEventArgs e)
        {
            Requirements_Window requ_window = new Requirements_Window(GN, DC);
            requ_window.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Help_window help_win = new Help_window();
            help_win.Show();
        }
    }
}
