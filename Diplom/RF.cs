using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom
{
    public class RF
    {
        public Rozklad rozklad { get; set; }
        public double value { get; set; }

        

        public RF(Rozklad roz, double f)
        {
            rozklad = roz;
            value = f;
        }
    }
}
