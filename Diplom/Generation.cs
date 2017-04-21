using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Excel = Microsoft.Office.Interop.Excel;


namespace Diplom
{
    public class Generation
    {
        int count;
        public List<RF> main_gen = new List<RF>();
        public List<RF> gen_list = new List<RF>();
        public List<RF> new_gen_list = new List<RF>();

       

        public void generate(Dictionary DC, int cnt)
        {
            count = cnt;
            Rozklad new_roz;
            for (int i = 0; i < count; i++)
            {
                new_roz = new Rozklad(DC);
                gen_list.Add(new RF(new_roz, targetFunction(new_roz, DC)));
            }
            /*for (int i = 0; i < count; i++)
            {
                gen_list[i].value = targetFunction(gen_list[i].rozklad, DC);
            }*/
        }
        public double targetFunction(Rozklad schedule, Dictionary DC)
        {
            Dictionary<int, int[]> dict = new Dictionary<int, int[]>();
            Dictionary<int, int> count_d = new Dictionary<int, int>();
            double res_1 = 0;
            foreach (Grp grp in DC.grp_list)
            {
                count_d.Add(grp.grp_code, 0);
            }
            foreach (Grp grp in DC.grp_list)
            {
                dict.Add(grp.grp_code, new int[6] { 0, 0, 0, 0, 0, 0 });
            }
            for (int i = 0; i < schedule.schedule.GetLength(0); i++)
                for (int j = 0; j < schedule.schedule.GetLength(1); j++)
                    for (int k = 0; k < schedule.schedule.GetLength(2); k++)
                    {
                        if (schedule.schedule[i, j, k] != null)
                        {
                            dict[schedule.schedule[i, j, k].subject.grp_code][i]++;
                        }
                    }
            foreach (Grp grp in DC.grp_list)
                for (int j = 0; j < dict[grp.grp_code].GetLength(0); j++)
                    if(dict[grp.grp_code][j] == 0)
                    {
                        count_d[grp.grp_code]++;
                    }
            foreach(Grp grp in DC.grp_list)
            {
                res_1 += count_d[grp.grp_code];
            }
            res_1 = 1 / (res_1 + 1);
            int saturnday = 0;
            for (int j = 0; j < schedule.schedule.GetLength(1); j++)
                for (int k = 0; k < schedule.schedule.GetLength(2); k++)
                {
                    if (schedule.schedule[5, j, k] != null)
                    {
                        saturnday++;
                    }
                }
            double res_2 = 0;
            if (saturnday == 0)
                res_2 = 1;
            return (res_1 + res_2);
        }

        public Rozklad[] mixGen(Rozklad r1_old, Rozklad r2_old)
        {
            Rozklad r1 = r1_old;
            Rozklad r2 = r2_old;
            int x1, y1, z1;
            int x2, y2, z2;
            int counter = 0;
            Node node1;
            do
            {
                x1 = MainWindow.rand.Next(0, 6);
                y1 = MainWindow.rand.Next(0, 6);
                z1 = MainWindow.rand.Next(0, r1.schedule.GetLength(2));
                if (counter != 50000)
                    counter++;
                else return null;
            } while (r1.schedule[x1, y1, z1] == null);
            node1 = r1.schedule[x1, y1, z1];

            counter = 0;
            do
            {
                x2 = MainWindow.rand.Next(0, 6);
                y2 = MainWindow.rand.Next(0, 6);
                z2 = MainWindow.rand.Next(0, r1.schedule.GetLength(2));
                if (counter != 50000)
                    counter++;
                else return null;
            } while (!(node1.Compare(r2.schedule[x2, y2, z2])));

            Node buff = null;
            buff = r1.schedule[x1, y1, z1];
            r1.schedule[x1, y1, z1] = r1.schedule[x2, y2, z2];
            r1.schedule[x2, y2, z2] = buff;
            r2.schedule[x1, y1, z1] = r2.schedule[x2, y2, z2];
            r2.schedule[x2, y2, z2] = buff;
            Rozklad[] res = new Rozklad[2];
            res[0] = r1;
            res[1] = r2;
            return res;
        }

        public void newGen(Dictionary DC)
        {
            new_gen_list.Clear();
            var TF = new double[4];
            for (int i = 0; i < 4; i++)
            {
                TF[i] = targetFunction(gen_list[i].rozklad, DC);
            }
            Rozklad[] mix = new Rozklad[2];
            int first_par, second_par;
            int steps = 0;
            //
            //var check = new bool[2];
            //
            while (new_gen_list.Count() < gen_list.Count())
            {
                first_par = choosePar(TF);
                second_par = choosePar(TF);
                do
                {
                    mix = mixGen(gen_list[first_par].rozklad, gen_list[second_par].rozklad);
                    steps++;
                    if (steps == 5000)
                    {
                        generate(DC, count);
                        shakeGen(DC);
                        MessageBox.Show("Сталась дуже малоймовірна помилка! Спробуйте ще раз.");
                    }
                    if (steps == 100000)
                    {
                        MessageBox.Show("Сталась дуже малоймовірна помилка! Спробуйте ще раз.");
                        break;
                    }
                } while (mix == null);

                for (int i = 0; i < 2; i++)
                {
                    if (new_gen_list.Count() == gen_list.Count())
                        break;
                    if (mix[i].checkAll(DC))
                        new_gen_list.Add(new RF(mix[i], targetFunction(mix[i],DC)));
                }
                
                steps++;
                if (steps == 5000)
                {
                    generate(DC, count);
                    shakeGen(DC);
                    MessageBox.Show("Сталась дуже малоймовірна помилка! Спробуйте ще раз.");
                }
                if (steps == 100000)
                {
                    MessageBox.Show("Сталась дуже малоймовірна помилка! Спробуйте ще раз.");
                    break;
                }
                /*Стерти
                for (int i = 0; i < 2; i++)
                {
                    check[i] = mix[i].checkAll(DC);
                }
                */
            }
        }

        public void getBest(Dictionary DC)
        {
            main_gen.Clear();
            foreach(RF rf in gen_list)
            {
                main_gen.Add(new RF(rf.rozklad, targetFunction(rf.rozklad, DC)));
            }
            foreach(RF rf in new_gen_list)
            {
                main_gen.Add(new RF(rf.rozklad, targetFunction(rf.rozklad, DC)));
            }
            main_gen = main_gen.OrderByDescending(RF => RF.value).ToList();
            for(int i = 0; i < main_gen.Count()/2; i++)
            {
                gen_list[i].rozklad = main_gen[i].rozklad;
                gen_list[i].value = main_gen[i].value;
            }
        }

        public void shakeGen(Dictionary DC)
        {
            new_gen_list.Clear();
            Rozklad new_roz;
            for (int i = 0; i < count; i++)
            {
                new_roz = new Rozklad(DC);
                new_gen_list.Add(new RF(new_roz, targetFunction(new_roz, DC)));
            }
        }

        public double getDelta(Dictionary DC)
        {
            var TF = new double[gen_list.Count()];
            for(int i = 0; i < gen_list.Count(); i++)
            {
                TF[i] = gen_list[i].value;
            }
            return TF.Max() - TF.Min();
        }

        public int choosePar(double[] TF)
        {
            normalize(ref TF);
            change(ref TF);
            TF[TF.GetLength(0) - 1 ] = 1;
            int rand_num = MainWindow.rand.Next(0, 101);
            for (int i = 0; i < 4; i++)
            {
                if (((double)rand_num / 100) <= TF[i])
                    return i;
            }
            return -1;
        }

        public void change(ref double[] mass)
        {
            for (int i = 0; i < mass.GetLength(0) - 1; i++)
            {
                mass[i + 1] += mass[i];
            }
        }

        public void normalize(ref double[] mass)
        {
            double sum = mass.Sum();
            for (int i = 0; i < mass.GetLength(0); i++)
                mass[i] /= sum;
        }

        public void outputRozklad(Rozklad roz, Dictionary DC)
        {
            string file = @"C:\Users\igorm_000\Documents\Visual Studio 2015\Projects\Diplom\Diplom\bin\Debug\Rozklad.xlsx";
            List<string> type_list = new List<string>();
            type_list.Add("лекція");
            type_list.Add("практика");
            type_list.Add("лабораторна");
            Excel.Application MyApp = new Excel.Application();
            //MyApp.Visible = false;
            Excel.Workbook MyBook = MyApp.Workbooks.Open(file);
            Excel.Worksheet MySheet = (Excel.Worksheet)MyBook.Sheets[1];
            MySheet.Cells.ClearContents();
            MySheet.Columns.AutoFit();
            foreach(Grp grp in DC.grp_list)
            {
                MySheet.Cells[1, 1 + grp.grp] = "Група " + (grp.grp_code);
            }
            for(int i = 0; i < roz.schedule.GetLength(0); i++)
                for (int j = 0; j < roz.schedule.GetLength(1); j++)
                {
                    switch (i)
                    {
                        case 0:
                            MySheet.Cells[2 + 6 * i + j, 1] = "Понеділок " + (j + 1) + " пара";
                            break;
                        case 1:
                            MySheet.Cells[2 + 6 * i + j, 1] = "Вівторок " + (j + 1) + " пара";
                            break;
                        case 2:
                            MySheet.Cells[2 + 6 * i + j, 1] = "Середа " + (j + 1) + " пара";
                            break;
                        case 3:
                            MySheet.Cells[2 + 6 * i + j, 1] = "Четвер " + (j + 1) + " пара";
                            break;
                        case 4:
                            MySheet.Cells[2 + 6 * i + j, 1] = "П'ятниця " + (j + 1) + " пара";
                            break;
                        case 5:
                            MySheet.Cells[2 + 6 * i + j, 1] = "Субота " + (j + 1) + " пара";
                            break;
                    }
                }
            for (int i = 0; i < roz.schedule.GetLength(0); i++)
                for (int j = 0; j < roz.schedule.GetLength(1); j++)
                    for (int k = 0; k < roz.schedule.GetLength(2); k++)
                    {
                        if(roz.schedule[i, j, k] != null)
                        MySheet.Cells[2 + 6 * i + j, 1 + roz.schedule[i, j, k].subject.grp_code - 10] = roz.schedule[i, j, k].subject.subj + " " + type_list[roz.schedule[i, j, k].subject.subj_type - 1] + "\n" + roz.schedule[i, j, k].teacher.name + "\n" + DC.rooms_list[k].room;
                    }
            MySheet.Columns.AutoFit();
            MySheet.Rows.AutoFit();
            MyBook.Save();
            MyBook.Close();
            MyApp.Quit();
        }
    }
}
