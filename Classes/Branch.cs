using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursRSPO.Classes
{
    public class Branch
    {
        public string parent { get; set; }
        public string branch { get; set; }
        public Branch(){}

        public Branch(string parent, string branch)
        {
            this.parent = parent;
            this.branch = branch;
        }
    }
}
