using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FileAdd
{
    public partial class Form1 : Form
    {
        string txt = "C:\\Users\\memir\\source\\repos\\FileAdd\\FileAdd\\txt\\veri.txt";


        private int currentLine = 0;
        private Timer timer;
        TimeSpan time1, time2;
        static int interval = 1000;

        public Form1()
        {
            InitializeComponent();
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            timer = new Timer();
            timer.Interval = interval;
            timer.Tick += new EventHandler(timer1_Tick);
            timer.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string[] lines = File.ReadAllLines(txt);
            Label[] labels = { label1, label2, label3, label4, label5, label6, label7, label8, label9, label10, label11, label12, label13, label14, label15, label16 };

            List<string[]> dataList = new List<string[]>();

            foreach (string line in lines)
            {
                string[] datas = line.Split(',');
                dataList.Add(datas);
            }

            if (currentLine < dataList.Count)
            {
                string[] datas = dataList[currentLine];
                string[] datasNextLine = dataList[currentLine + 1];

                if (TimeSpan.TryParse(datas[1], out time1) && TimeSpan.TryParse(datasNextLine[1], out time2))
                {
                    TimeSpan timeDifference = time2 - time1;
                    int secondsDifference = (int)timeDifference.TotalSeconds;
                    int newInterval = secondsDifference * 1000;
                    timer.Interval = newInterval;
                }

                for (int i = 0; i < datas.Length && i < labels.Length; i++)
                {
                    labels[i].Text = datas[i];
                }

                currentLine++;
            }
        }
    }
}

/*  
 text = a,b,c
        d,e,f

 lines[] => { (a,b,c), (d,e,f) } =>     dataList = { a, b, c }  ->  datas[] = { a, b, c }
                                                   { d, e, f }  ->  time[]  = { d, e, f }
 */