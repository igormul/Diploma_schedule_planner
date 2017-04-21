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
    /// Логика взаимодействия для Requirements_WIndow.xaml
    /// </summary>
    public partial class Requirements_Window : Window
    {
        Generation GN;
        Dictionary DC = new Dictionary();
        public Requirements_Window(Generation Gn, Dictionary Dc)
        {
            GN = Gn;
            InitializeComponent();
            foreach (Teacher teacher in DC.teachers_list)
            {
                CB_Subject1.Items.Add(teacher.name);
                CB_Subject2.Items.Add(teacher.name);
                CB_Subject3.Items.Add(teacher.name);
                CB_Subject4.Items.Add(teacher.name);
                CB_Subject5.Items.Add(teacher.name);
            }

            foreach (Grp grp in DC.grp_list)
            {
                CB_Subject1.Items.Add(grp.grp_code);
                CB_Subject2.Items.Add(grp.grp_code);
                CB_Subject3.Items.Add(grp.grp_code);
                CB_Subject4.Items.Add(grp.grp_code);
                CB_Subject5.Items.Add(grp.grp_code);
            }

            CB_Day1.Items.Add("none");
            CB_Day1.Items.Add("all");
            CB_Day1.Items.Add("mon");
            CB_Day1.Items.Add("tue");
            CB_Day1.Items.Add("wed");
            CB_Day1.Items.Add("thu");
            CB_Day1.Items.Add("fri");
            CB_Day1.Items.Add("sat");

            CB_Day2.Items.Add("none");
            CB_Day2.Items.Add("all");
            CB_Day2.Items.Add("mon");
            CB_Day2.Items.Add("tue");
            CB_Day2.Items.Add("wed");
            CB_Day2.Items.Add("thu");
            CB_Day2.Items.Add("fri");
            CB_Day2.Items.Add("sat");

            CB_Day3.Items.Add("none");
            CB_Day3.Items.Add("all");
            CB_Day3.Items.Add("mon");
            CB_Day3.Items.Add("tue");
            CB_Day3.Items.Add("wed");
            CB_Day3.Items.Add("thu");
            CB_Day3.Items.Add("fri");
            CB_Day3.Items.Add("sat");

            CB_Day4.Items.Add("none");
            CB_Day4.Items.Add("all");
            CB_Day4.Items.Add("mon");
            CB_Day4.Items.Add("tue");
            CB_Day4.Items.Add("wed");
            CB_Day4.Items.Add("thu");
            CB_Day4.Items.Add("fri");
            CB_Day4.Items.Add("sat");
 
            CB_Day5.Items.Add("none");
            CB_Day5.Items.Add("all");
            CB_Day5.Items.Add("mon");
            CB_Day5.Items.Add("tue");
            CB_Day5.Items.Add("wed");
            CB_Day5.Items.Add("thu");
            CB_Day5.Items.Add("fri");
            CB_Day5.Items.Add("sat");

            CB_Para1.Items.Add("none");
            CB_Para1.Items.Add("all");
            CB_Para1.Items.Add("1");
            CB_Para1.Items.Add("2");
            CB_Para1.Items.Add("3");
            CB_Para1.Items.Add("4");
            CB_Para1.Items.Add("5");

            CB_Para2.Items.Add("none");
            CB_Para2.Items.Add("all");
            CB_Para2.Items.Add("1");
            CB_Para2.Items.Add("2");
            CB_Para2.Items.Add("3");
            CB_Para2.Items.Add("4");
            CB_Para2.Items.Add("5");

            CB_Para3.Items.Add("none");
            CB_Para3.Items.Add("all");
            CB_Para3.Items.Add("1");
            CB_Para3.Items.Add("2");
            CB_Para3.Items.Add("3");
            CB_Para3.Items.Add("4");
            CB_Para3.Items.Add("5");

            CB_Para4.Items.Add("none");
            CB_Para4.Items.Add("all");
            CB_Para4.Items.Add("1");
            CB_Para4.Items.Add("2");
            CB_Para4.Items.Add("3");
            CB_Para4.Items.Add("4");
            CB_Para4.Items.Add("5");

            CB_Para5.Items.Add("none");
            CB_Para5.Items.Add("all");
            CB_Para5.Items.Add("1");
            CB_Para5.Items.Add("2");
            CB_Para5.Items.Add("3");
            CB_Para5.Items.Add("4");
            CB_Para5.Items.Add("5");

            CB_Logic1.Items.Add("=");
            CB_Logic1.Items.Add("=/=");
            CB_Logic1.Items.Add("<=");
            CB_Logic1.Items.Add("=>");

            CB_Logic2.Items.Add("=");
            CB_Logic2.Items.Add("=/=");
            CB_Logic2.Items.Add("<=");
            CB_Logic2.Items.Add("=>");

            CB_Logic3.Items.Add("=");
            CB_Logic3.Items.Add("=/=");
            CB_Logic3.Items.Add("<=");
            CB_Logic3.Items.Add("=>");

            CB_Logic4.Items.Add("=");
            CB_Logic4.Items.Add("=/=");
            CB_Logic4.Items.Add("<=");
            CB_Logic4.Items.Add("=>");

            CB_Logic5.Items.Add("=");
            CB_Logic5.Items.Add("=/=");
            CB_Logic5.Items.Add("<=");
            CB_Logic5.Items.Add("=>");
            
            CB_Val1.Items.Add("0");
            CB_Val1.Items.Add("1");
            CB_Val1.Items.Add("2");
            CB_Val1.Items.Add("3");
            CB_Val1.Items.Add("4");
            CB_Val1.Items.Add("5");

            CB_Val2.Items.Add("0");
            CB_Val2.Items.Add("1");
            CB_Val2.Items.Add("2");
            CB_Val2.Items.Add("3");
            CB_Val2.Items.Add("4");
            CB_Val2.Items.Add("5");

            CB_Val3.Items.Add("0");
            CB_Val3.Items.Add("1");
            CB_Val3.Items.Add("2");
            CB_Val3.Items.Add("3");
            CB_Val3.Items.Add("4");
            CB_Val3.Items.Add("5");

            CB_Val4.Items.Add("0");
            CB_Val4.Items.Add("1");
            CB_Val4.Items.Add("2");
            CB_Val4.Items.Add("3");
            CB_Val4.Items.Add("4");
            CB_Val4.Items.Add("5");

            CB_Val5.Items.Add("0");
            CB_Val5.Items.Add("1");
            CB_Val5.Items.Add("2");
            CB_Val5.Items.Add("3");
            CB_Val5.Items.Add("4");
            CB_Val5.Items.Add("5");

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GN.generate(DC, 4);
            int steps = 0;
            double delta = GN.getDelta(DC);
            while ((delta > 0.00001) && (steps != 50))
            {
                GN.newGen(DC);
                if (steps == 30)
                    GN.shakeGen(DC);
                GN.getBest(DC);
                delta = GN.getDelta(DC);
                steps++;
            }
            GN.outputRozklad(GN.gen_list[0].rozklad, DC);
            MessageBox.Show("Успішно згенеровано в файл Rozlkad.xlsx");
        }
    }
}
