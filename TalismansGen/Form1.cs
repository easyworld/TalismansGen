using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TalismansGen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.ValueMember = "Value";
            comboBox1.DisplayMember = "Key";
            comboBox1.DataSource = GameDatasource.GetItems();
            comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;

            comboBox2.ValueMember = "Value";
            comboBox2.DisplayMember = "Key";
            comboBox2.DataSource = GameDatasource.GetItems();
            comboBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox2.AutoCompleteSource = AutoCompleteSource.ListItems;

            comboBox3.SelectedIndex = 2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int first = ((KeyValuePair<string, int>)comboBox1.SelectedItem).Value;
            int second = ((KeyValuePair<string, int>)comboBox2.SelectedItem).Value;
            int level1 = Convert.ToInt32(numericUpDown1.Value);
            int level2 = Convert.ToInt32(numericUpDown2.Value);

            var holeMap = GameDatasource.GetHoleMap();
            var skillMap = GameDatasource.GetSkillRuleMap();
            var skill1 = skillMap[first];
            var skill2 = skillMap[second];
            if (level1 > skill1.first) { level1 = skill1.first; numericUpDown1.Value = skill1.first; }
            if (level2 > skill2.second) { level2 = skill2.second; numericUpDown2.Value = skill2.second; }
            var hole = holeMap[skill1.level + skill2.level];

            int hole1 = hole.first;
            int hole2 = hole.second;
            int hole3 = hole.third;

            textBox1.Text = "";

            textBox1.Text += $"[{skill1.name}{level1} {skill2.name}{level2} {hole.raw}]\r\n";

            var version = comboBox3.SelectedIndex;
            switch (version)
            {
                case 0: textBox1.Text += "580F0000 0D68A2D8\r\n";break;
                case 1: textBox1.Text += "580F0000 0D68C2D8\r\n"; break;
                case 2: textBox1.Text += "580F0000 0D9674B8\r\n"; break;
                default: 
                    textBox1.Text += "580F0000 0D9674B8\r\n"; break;
            }
            
            textBox1.Text += "580F1000 00000080\r\n";
            textBox1.Text += "580F1000 00000088\r\n";
            textBox1.Text += "580F1000 00000010\r\n";
            textBox1.Text += "580F1000 00000020\r\n";
            textBox1.Text += "780F0000 00000030\r\n";
            textBox1.Text += "640F0000 00000000 10100006\r\n";
            textBox1.Text += "780F0000 00000160\r\n";
            textBox1.Text += $"610F1000 00000000 000000{string.Format("{0:X2}",first)}\r\n";
            textBox1.Text += $"610F1000 00000000 000000{string.Format("{0:X2}",second)}\r\n";
            textBox1.Text += "780F0000 0000002E\r\n";
            textBox1.Text += $"680F0000 000000{string.Format("{0:X2}", level2)} 000000{string.Format("{0:X2}", level1)}\r\n";
            textBox1.Text += "780F0000 00000030\r\n";
            textBox1.Text += "640F1000 00000000 00000000\r\n";
            textBox1.Text += "640F1000 00000000 00000000\r\n";
            textBox1.Text += "640F1000 00000000 00000000\r\n";
            switch (version)
            {
                case 0: textBox1.Text += "580F0000 0D68A2D8\r\n"; break;
                case 1: textBox1.Text += "580F0000 0D68C2D8\r\n"; break;
                case 2: textBox1.Text += "580F0000 0D9674B8\r\n"; break;
                default:
                    textBox1.Text += "580F0000 0D9674B8\r\n"; break;
            }
            textBox1.Text += "580F1000 00000080\r\n";
            textBox1.Text += "580F1000 00000088\r\n";
            textBox1.Text += "580F1000 00000010\r\n";
            textBox1.Text += "580F1000 00000020\r\n";
            textBox1.Text += "580F1000 00000070\r\n";
            textBox1.Text += "780F0000 00000020\r\n";
            textBox1.Text += $"680F1000 000000{string.Format("{0:X2}", hole1)} 00000000\r\n";
            textBox1.Text += $"680F0000 000000{string.Format("{0:X2}", hole3)} 000000{string.Format("{0:X2}", hole2)}\r\n";
        }
    }
}
