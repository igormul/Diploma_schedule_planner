using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom
{
    public class Rozklad
    {
        public Node[,,] schedule;
        public Rozklad(Dictionary DC)
        {
            schedule = new Node[6, 6, DC.rooms_list.Count()];
            //Викладач
            Teacher chsn_teacher;
            //День
            int x;
            //Пара
            int y; ;
            //Аудиторія
            int z;
            foreach (Subj subj in DC.subj_list)
            {
                do
                    {
                        x = MainWindow.rand.Next(0, 6);
                        y = MainWindow.rand.Next(0, 6);
                        z = findRoom(subj, DC);
                        chsn_teacher = findTeacher(subj, DC);
                    }
                while ((schedule[x, y, z] != null) 
                           || (checkGrp(x, y, subj.grp_code)) 
                           || (checkTchr(x, y, chsn_teacher)));
                Node new_node = new Node(subj, chsn_teacher);
                schedule[x, y, z] = new_node;
            }
        }

        

        public bool checkAll(Dictionary DC)
        {
            int check;
            foreach(Teacher teacher in DC.teachers_list)
            {
                for(int i = 0; i < schedule.GetLength(0); i++)
                    for(int j = 0; j < schedule.GetLength(1); j++)
                    {
                        check = 0;
                        for (int z = 0; z < schedule.GetLength(2); z++)
                        {
                            if (schedule[i, j, z] == null) continue;
                            if (schedule[i, j, z].teacher == teacher)
                                check++;
                        }
                        if (check > 1) return false;
                    }
            }
            foreach (Grp group in DC.grp_list)
            {
                for (int i = 0; i < schedule.GetLength(0); i++)
                    for (int j = 0; j < schedule.GetLength(1); j++)
                    {
                        check = 0;
                        for (int z = 0; z < schedule.GetLength(2); z++)
                        {
                            if (schedule[i, j, z] == null) continue;
                            if (schedule[i, j, z].subject.grp_code == group.grp_code)
                                check++;
                        }
                        if (check > 1) return false;
                    }
            }
            //if (!(checkRooms(DC)))
                return true; //false
            //else return true;
        }

        private bool checkTchr(int x, int y, Teacher chsn_teacher)
        {
            for (int i = 0; i < schedule.GetLength(2); i++)
            {
                if (schedule[x, y, i] != null)
                {
                    if ((schedule[x, y, i].teacher == chsn_teacher))
                        return true;
                }
            }
            return false;
        }

        private bool checkGrp(int x, int y, int grp_code)
        {
            for (int i = 0; i < schedule.GetLength(2); i ++ )
            {
                if (schedule[x, y, i] != null)
                {
                    if ((schedule[x, y, i].subject.grp_code == grp_code))
                        return true;
                }
            }
            return false;
        }

        public bool checkRooms(Dictionary DC)
        {
            for (int i = 0; i < schedule.GetLength(0); i++)
                for (int j = 0; j < schedule.GetLength(1); j++)
                {
                    for (int z = 0; z < schedule.GetLength(2); z++)
                    {
                        if (schedule[i, j, z] == null) continue;
                        if (schedule[i, j, z].subject.subj_type != DC.rooms_list[z].type)
                            return true;
                    }
                }
            return false;
          }

        public Teacher findTeacher(Subj subj, Dictionary DC)
        {
            int[] help = new int[3];
            int choose;
            List<Teacher> subj_oriented_teachers = new List<Teacher>();
            foreach (Teacher teacher in DC.teachers_list)
            {
                if (subj.subj == teacher.subj)
                {
                    help[0] = teacher.lectures;
                    help[1] = teacher.practice;
                    help[2] = teacher.labs;
                    if (help[subj.subj_type - 1] == 1)
                    {
                        subj_oriented_teachers.Add(teacher);
                    }
                }
            }
            choose = MainWindow.rand.Next(0, subj_oriented_teachers.Count());
            return subj_oriented_teachers[choose];
        }
        public int findRoom(Subj subj, Dictionary DC)
        {
            int room_no;
            do
            {
                room_no = MainWindow.rand.Next(0, DC.rooms_list.Count());
            }
            while ((DC.rooms_list[room_no].cnt < DC.findGrp_count(subj.grp_code)) || (DC.rooms_list[room_no].type != subj.subj_type));      
            return room_no;
            
        }   
    }
}
