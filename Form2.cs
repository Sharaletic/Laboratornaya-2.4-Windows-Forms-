using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryLogic;

namespace Laboratornaya_2._4
{
    public partial class Form2 : Form
    {
        public Form Form1 { get; set; }
        public Form2()
        {
            InitializeComponent();
            Logic logicObj = new Logic();
            richTextBox1.Text = logicObj.GetPhrase()[0];
            richTextBox2.Text = logicObj.GetPhrase()[1];
            richTextBox3.Text = logicObj.GetPhrase()[2];
            richTextBox4.Text = logicObj.GetPhrase()[3];

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TextDictionary textDictionary = new TextDictionary();
            var srcEncodding1 = Encoding.GetEncoding("windows-1251");
            string path1 = @"C:\Users\User\OneDrive\Рабочий стол\project 1\Laboratornaya 2.4\File\1.txt";
            System.IO.File.WriteAllText(path1, richTextBox1.Text, encoding: srcEncodding1);

            string path2 = @"C:\Users\User\OneDrive\Рабочий стол\project 1\Laboratornaya 2.4\File\2.txt";
            System.IO.File.WriteAllText(path2, richTextBox2.Text, encoding: srcEncodding1);

            string path3 = @"C:\Users\User\OneDrive\Рабочий стол\project 1\Laboratornaya 2.4\File\3.txt";
            System.IO.File.WriteAllText(path3, richTextBox3.Text, encoding: srcEncodding1);
            
            string path4 = @"C:\Users\User\OneDrive\Рабочий стол\project 1\Laboratornaya 2.4\File\4.txt";
            System.IO.File.WriteAllText(path4, richTextBox4.Text, encoding: srcEncodding1);
        }
    }
}
