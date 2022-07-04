using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PyatnashkiwinF
{
    class History
    {
        public Stack<Memento15> history { get; set; }
        public History()
        {
            history = new Stack<Memento15>();
        }
    }
}
