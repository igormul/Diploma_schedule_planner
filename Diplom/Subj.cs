using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom
{
    public class Subj
    {
        public int subj_code { get; set; }
        public string subj { get; set; }
        public int subj_type { get; set; }
        public int grp_code { get; set; }

        public Subj() { }
        public Subj(string subj_new, int subj_type_new, int course, int group)
        {
            subj = subj_new;
            subj_type = subj_type_new;
            subj_code = Dictionary.Conv(subj) + subj_type ;
            grp_code = course * 10 + group;
        }
    }

    public class Grp
    {
        public int grp_code { get; set; }
        public int grp { get; set; }
        public int course { get; set; }
        public int count { get; set; }
        public Grp() { }
        public Grp(int grp_new, int course_new, int count_new)
        {
            grp = grp_new;
            course = course_new;
            grp_code = course * 10 + grp;
            count = count_new;
        }
    }

    public class Room
    {
        public int room { get; set; }
        public int type { get; set; }
        public int cnt { get; set; }
        public Room(int new_room, int count, int new_type)
        {
            room = new_room;
            cnt = count;
            type = new_type;
        }
    }
    public class Teacher
    {
        public string name { get; set; }
        public string subj { get; set; }
        public int lectures { get; set; }
        public int practice { get; set; }
        public int labs { get; set; }
        public Teacher(string name_n, string subj_n, int l, int p, int lab )
        {
            name = name_n;
            subj = subj_n;
            lectures = l;
            practice = p;
            labs = lab;
        }
    }

}
