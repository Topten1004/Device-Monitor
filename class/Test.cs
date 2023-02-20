using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace devicemonitoring
{
    class Test
    {
        public int area;
        public int x;
        public int Area
        {
            get { return area; }
            set { area = value + 1; }
        }

        public int Age (int usia)
        {
            return usia + 10;
        }
        
    }
}
