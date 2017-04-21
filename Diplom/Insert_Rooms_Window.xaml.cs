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
using System.Windows.Shapes;

namespace Diplom
{
    /// <summary>
    /// Логика взаимодействия для Insert_Rooms_Window.xaml
    /// </summary>
    public partial class Insert_Rooms_Window : Window
    {
        DataBase DB;
        public Insert_Rooms_Window(DataBase Db)
        {
            DB = Db;
            InitializeComponent();
        }

        private void N_TB_GotFocus(object sender, RoutedEventArgs e)
        {
            N_TB.Text = string.Empty;
        }

        private void T_TB_GotFocus(object sender, RoutedEventArgs e)
        {
            T_TB.Text = string.Empty;
        }

        private void C_TB_GotFocus(object sender, RoutedEventArgs e)
        {
            C_TB.Text = string.Empty;
        }

        private void OK_B_Click(object sender, RoutedEventArgs e)
        {
            DB.InsertComm(@"INSERT INTO Rooms (Id_room, type, places) 
                            VALUES('" + N_TB.Text + "', '" + T_TB.Text + "', '" + C_TB.Text + "');");
            this.Close();
        }
    }
}
