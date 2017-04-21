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
    /// Логика взаимодействия для Insert_Groups_Window.xaml
    /// </summary>
    public partial class Insert_Groups_Window : Window
    {
        DataBase DB;
        public Insert_Groups_Window(DataBase Db)
        {
            DB = Db;
            InitializeComponent();
        }

        private void G_TB_GotFocus(object sender, RoutedEventArgs e)
        {
            G_TB.Text = string.Empty;
        }

        private void C_TB_GotFocus(object sender, RoutedEventArgs e)
        {
            C_TB.Text = string.Empty;
        }

        private void Cnt_TB_GotFocus(object sender, RoutedEventArgs e)
        {
            Cnt_TB.Text = string.Empty;
        }

        private void OK_B_Click(object sender, RoutedEventArgs e)
        {
            DB.InsertComm(@"INSERT INTO Groups (Id_grp, group_no, course, cnt) 
                            VALUES("+ (10*int.Parse(C_TB.Text) + int.Parse(G_TB.Text)) + ", '" + G_TB.Text + "', '" + C_TB.Text + "', '" + Cnt_TB.Text + "');");
            this.Close();
        }
    }
}
