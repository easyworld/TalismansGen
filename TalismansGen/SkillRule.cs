using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalismansGen
{
    class SkillRule
    {
        public int id { get; set; }
        public string name { get; set; }
        public string level { get; set; }
        public int first { get; set; }
        public int second { get; set; }

        public SkillRule(string str)
        {
            var strings = str.Split(' ');
            id = Convert.ToInt32(strings[0]);
            name = strings[1];
            level = strings[2];
            first = Convert.ToInt32(strings[3]);
            second = Convert.ToInt32(strings[4]);
        }
    }
}
