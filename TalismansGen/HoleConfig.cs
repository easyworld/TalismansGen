using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalismansGen
{
    class HoleConfig
    {
        static int CountChar(string str, char c)
        {
            int count = 0;
            for(int i = 0; i < str.Length; i++)
                if (str[i] == c) count++;
            return count;
        }

        public HoleConfig(string str)
        {
            var strings = str.Split('\t');
            key = strings[0];
            raw = strings[1];
            first = CountChar(strings[1], '1');
            second = CountChar(strings[1], '2');
            third = CountChar(strings[1], '3');
        }
        public string key { get; set; }
        public int first { get; set; }
        public int second { get; set; }
        public int third { get; set; }
        public string raw { get; set; }
    }
}
