using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ulei
{
    public partial class Form1 : Form
    {
        private Queen queen;
        public Form1()
        {
            InitializeComponent();
            workerBeeJob.SelectedIndex = 0;
            Worker[] worker = new Worker[4];
            worker[0] = new Worker(new string[] { "Сборщик нектара", "Изготовление меда" });
            worker[1] = new Worker(new string[] { "Охрана яиц", "Обучение личинок" });
            worker[2] = new Worker(new string[] { "Охрана улья", "Патруль" });
            worker[3] = new Worker(new string[] { "Сборщик нектара", "Изготовление меда", "Охрана яиц", "Обучение личинок", "Охрана улья", "Патруль" });
            queen = new Queen(worker);
        }

        private void assignJob_Click(object sender, EventArgs e)
        {
            if (queen.AssignWork(workerBeeJob.Text, (int)shifts.Value) == false)
            {
                MessageBox.Show("Для этого задания рабочих нет" + workerBeeJob.Text, "Матка говорит");
            }
            else
            {
                MessageBox.Show("Задание" + workerBeeJob.Text + " будет закончено через " + shifts.Value + " смен", "Матка говорит");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            report.Text = queen.WorkTheNextShift();
        }
    }
}
