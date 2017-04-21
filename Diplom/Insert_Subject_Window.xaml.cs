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
    /// Логика взаимодействия для Insert_Subject_Window.xaml
    /// </summary>
    public partial class Insert_Subject_Window : Window
    {
        DataBase DB;
        public Insert_Subject_Window(DataBase Db)
        {
            DB = Db;
            InitializeComponent();
        }

        private void D_TB_GotFocus(object sender, RoutedEventArgs e)
        {
            D_TB.Text = string.Empty;
        }

        private void G_TB_GotFocus(object sender, RoutedEventArgs e)
        {
            G_TB.Text = string.Empty;
        }

        private void C_TB_GotFocus(object sender, RoutedEventArgs e)
        {
            C_TB.Text = string.Empty;
        }

        private void Lec_TB_GotFocus(object sender, RoutedEventArgs e)
        {
            Lec_TB.Text = string.Empty;
        }

        private void Pra_TB_GotFocus(object sender, RoutedEventArgs e)
        {
            Pra_TB.Text = string.Empty;
        }

        private void Lab_TB_GotFocus(object sender, RoutedEventArgs e)
        {
            Lab_TB.Text = string.Empty;
        }

        private void OK_B_Click(object sender, RoutedEventArgs e)
        {
            int i = int.Parse(DB.Ex_Select_Comm("SELECT max(Id_disc) from Discipline;").Rows[0][0].ToString());
            DB.InsertComm(@"INSERT INTO Discipline (Id_disc, disc_name, course, group_no, lectures, practice, labs) 
                            VALUES(" + (i + 1) + ", '" + D_TB.Text + "', '" + C_TB.Text + "', '" + G_TB.Text + "', " + Lec_TB.Text + ", " + Pra_TB.Text + ", " + Lab_TB.Text + ");");
            this.Close();
        }
    }
}
