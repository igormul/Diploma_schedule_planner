using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom
{
    public class Node
    {
        public Subj subject { get; set; }
        public Teacher teacher { get; set; }

        

        public Node(Subj new_s, Teacher new_t)
        {
            subject = new_s;
            teacher = new_t;
        }
        public bool Compare(Node other)
        {
            if (other != null)
            {
                if ((this.subject == other.subject) && (this.teacher == other.teacher))
                    return true;
                else return false;
            }
            else return false;
        }
    }

}
