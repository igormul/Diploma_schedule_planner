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
    /// Логика взаимодействия для Insert_Teacher_Window.xaml
    /// </summary>
    public partial class Insert_Teacher_Window : Window
    {
        DataBase DB;
        public Insert_Teacher_Window(DataBase Db)
        {
            DB = Db;
            InitializeComponent();
        }

        private void PIB_TB_GotFocus(object sender, RoutedEventArgs e)
        {
            PIB_TB.Text = string.Empty;
        }

        private void Degree_TB_GotFocus(object sender, RoutedEventArgs e)
        {
            Degree_TB.Text = string.Empty;
        }

        private void Subj_TB_GotFocus(object sender, RoutedEventArgs e)
        {
            Subj_TB.Text = string.Empty;
        }

        private void OK_B_Click(object sender, RoutedEventArgs e)
        {
            int lec, pra, lab;
            if (Lec_CHK.IsChecked == true)
                lec = 1;
            else lec = 0;
            if (Pra_CHK.IsChecked == true)
                pra = 1;
            else pra = 0;
            if (Lab_CHK.IsChecked == true)
                lab = 1;
            else lab = 0;
            int i = int.Parse(DB.Ex_Select_Comm("SELECT max(Id_tchr) from Teacher;").Rows[0][0].ToString());
            DB.InsertComm(@"INSERT INTO Teacher (Id_tchr, pib, degree, disc_name, lectures, practice, labs) 
                            VALUES("+ (i+1) +", '"+ PIB_TB.Text +"', '"+ Degree_TB.Text+"', '"+ Subj_TB.Text +"', "+ lec +", "+ pra +", "+ lab +");");
            this.Close();
        }
    }
}
