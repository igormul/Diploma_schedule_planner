using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom
{
    public class Dictionary
    {
        DataBase DB = new DataBase();
        public List<Subj> subj_list { get; set; }
        public List<Room> rooms_list { get; set; }
        public List<Grp> grp_list { get; set; }
        public List<Teacher> teachers_list { get; set; }

        

        public Dictionary()
        {
            fillSubj();
            fillRooms();
            fillGrps();
            fillTeachers();
        }

        static public int Conv(string s)
        {
            int code = 0;
            for (int i = 0; i < s.Length; i++)
            {
                code += (int)s[i];
            }
            return code;
        }

        public void fillSubj()
        {
            subj_list = new List<Subj>();
            int i = int.Parse(DB.Ex_Select_Comm("SELECT count(*) FROM Discipline;").Rows[0][0].ToString());
            int lectures;
            int practice;
            int labs;
            while (i!=0)
            {
                lectures = int.Parse(DB.Ex_Select_Comm("SELECT lectures FROM Discipline WHERE Id_disc = '" + i + "';").Rows[0][0].ToString());
                practice = int.Parse(DB.Ex_Select_Comm("SELECT practice FROM Discipline WHERE Id_disc = '" + i + "';").Rows[0][0].ToString());
                labs = int.Parse(DB.Ex_Select_Comm("SELECT labs FROM Discipline WHERE Id_disc = '" + i + "';").Rows[0][0].ToString());
                int iter = lectures + practice + labs;
                while (iter != 0)
                {
                    for (int j = 0; j < lectures; j++)
                    {
                        Subj new_subj = new Subj(DB.Ex_Select_Comm("SELECT disc_name FROM Discipline WHERE Id_disc = '" + i + "';").Rows[0][0].ToString(),
                                         1,
                                         int.Parse(DB.Ex_Select_Comm("SELECT course FROM Discipline WHERE Id_disc = '" + i + "';").Rows[0][0].ToString()),
                                         int.Parse(DB.Ex_Select_Comm("SELECT group_no FROM Discipline WHERE Id_disc = '" + i + "';").Rows[0][0].ToString())
                                         );
                        subj_list.Add(new_subj);
                        iter--;
                    }

                    for (int j = 0; j < practice; j++)
                    {
                        Subj new_subj = new Subj(DB.Ex_Select_Comm("SELECT disc_name FROM Discipline WHERE Id_disc = '" + i + "';").Rows[0][0].ToString(),
                                         2,
                                         int.Parse(DB.Ex_Select_Comm("SELECT course FROM Discipline WHERE Id_disc = '" + i + "';").Rows[0][0].ToString()),
                                         int.Parse(DB.Ex_Select_Comm("SELECT group_no FROM Discipline WHERE Id_disc = '" + i + "';").Rows[0][0].ToString())
                                         );
                        subj_list.Add(new_subj);
                        iter--;
                    }

                    for (int j = 0; j < labs; j++)
                    {
                        Subj new_subj = new Subj(DB.Ex_Select_Comm("SELECT disc_name FROM Discipline WHERE Id_disc = '" + i + "';").Rows[0][0].ToString(),
                                         3,
                                         int.Parse(DB.Ex_Select_Comm("SELECT course FROM Discipline WHERE Id_disc = '" + i + "';").Rows[0][0].ToString()),
                                         int.Parse(DB.Ex_Select_Comm("SELECT group_no FROM Discipline WHERE Id_disc = '" + i + "';").Rows[0][0].ToString())
                                         );
                        subj_list.Add(new_subj);
                        iter--;
                    }
                }
                i--;
            } 
        }

        public void fillRooms()
        {
            rooms_list = new List<Room>();
            int i = int.Parse(DB.Ex_Select_Comm("SELECT count(*) FROM Rooms;").Rows[0][0].ToString());
            while (i != 0)
            {

                    Room new_room = new Room(int.Parse(DB.Ex_Select_Comm("SELECT Id_room FROM Rooms;").Rows[i-1][0].ToString()),
                                     int.Parse(DB.Ex_Select_Comm("SELECT places FROM Rooms;").Rows[i-1][0].ToString()),
                                     int.Parse(DB.Ex_Select_Comm("SELECT type FROM Rooms;").Rows[i-1][0].ToString())
                                     );
                    rooms_list.Add(new_room);                    
                i--;
            }
        }

        public void fillGrps()
        {
            grp_list = new List<Grp>();
            int i = int.Parse(DB.Ex_Select_Comm("SELECT count(*) FROM Groups;").Rows[0][0].ToString());
            while (i != 0)
            {

                Grp new_group = new Grp(int.Parse(DB.Ex_Select_Comm("SELECT group_no FROM Groups;").Rows[i - 1][0].ToString()),
                                 int.Parse(DB.Ex_Select_Comm("SELECT course FROM Groups;").Rows[i - 1][0].ToString()),
                                 int.Parse(DB.Ex_Select_Comm("SELECT cnt FROM Groups;").Rows[i - 1][0].ToString())
                                 );
                grp_list.Add(new_group);
                i--;
            }
        }

        public void fillTeachers()
        {
            teachers_list = new List<Teacher>();
            int i = int.Parse(DB.Ex_Select_Comm("SELECT count(*) FROM Teacher;").Rows[0][0].ToString());
            while (i != 0)
            {

                Teacher new_teacher = new Teacher(DB.Ex_Select_Comm("SELECT pib FROM Teacher;").Rows[i - 1][0].ToString(),
                                           DB.Ex_Select_Comm("SELECT disc_name FROM Teacher;").Rows[i - 1][0].ToString(),
                                 int.Parse(DB.Ex_Select_Comm("SELECT lectures FROM Teacher;").Rows[i - 1][0].ToString()),
                                 int.Parse(DB.Ex_Select_Comm("SELECT practice FROM Teacher;").Rows[i - 1][0].ToString()),
                                 int.Parse(DB.Ex_Select_Comm("SELECT labs FROM Teacher;").Rows[i - 1][0].ToString())
                                 );
                teachers_list.Add(new_teacher);
                i--;
            }
        }
        public int findMaxRoom()
        {
            int maxvalue = 0;
            foreach(Room room in rooms_list)
            {
                if (room.room > maxvalue) maxvalue = room.room;
            }
            return maxvalue;
        }
        public int findRoom_count(int room)
        {
            for (int i = 0; i < rooms_list.Count(); i++)
            {
                if (rooms_list[i].room == room)
                    return rooms_list[i].cnt;
            }
            return 0;
        }
        public int findGrp_count(int grp_code)
        {
            for (int i = 0; i < grp_list.Count(); i++)
            {
                if (grp_list[i].grp_code == grp_code)
                    return grp_list[i].count;
            }
            return 0;
        }
    }
}
