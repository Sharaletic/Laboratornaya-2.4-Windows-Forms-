using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using LibraryLogic;

namespace Laboratornaya_2._4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form2 = new Form2();
            form2.Form1 = this;
            form2.Show();

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Logic logicObj = new Logic();
            logicObj.GenerateText(Convert.ToInt32(textBox1.Text), checkBox1.Checked, comboBox1.Text);
            string text = logicObj.GenerationText;
            if (text == "")
            {
                MessageBox.Show("Словарь данных пустой! Загрузите данные");
            }
            else
            {
                richTextBox1.Text = text;
            }

            logicObj.NumberOfSymbols();
            string numberOfSymbols = logicObj.NumberOfSymbols();
            label3.Text = "Общее количество символов " + numberOfSymbols;

            logicObj.NumberOfWords();
            string numberOfWords = logicObj.NumberOfWords();
            label4.Text = "Общее количество слов " + numberOfWords;

            logicObj.NumberOfUniqueWords();
            string numberOfUniqueWords = logicObj.NumberOfUniqueWords();
            label5.Text = "Общее количество уникальных слов " + numberOfUniqueWords;

            var frequentWords = logicObj.FrequentWords();
            chart1.Series[0].Points.Clear();
            foreach (var word in frequentWords)
            {
                chart1.Series[0].Points.AddXY(word.Key, word.Value);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        
        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
