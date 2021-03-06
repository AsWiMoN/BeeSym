﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ulei
{
    class Queen
    {
        private Worker[] workers;
        private int shiftNumbers;

        public Queen(Worker[] worker)
        {
            this.workers = worker;
        }

        public bool AssignWork(string job, int numberOfShifts)
        {
            for (int i = 0; i < workers.Length; i++)
            {
                if (workers[i].DoThisJob(job, numberOfShifts))
                {
                    return true;
                }
            }
            return false;
        }

        public string WorkTheNextShift()
        {
            shiftNumbers++;
            string report = "Отчет для смены №" + shiftNumbers + "\r\n";
            for (int i = 0; i < workers.Length; i++)
            {
                if (workers[i].DidYouFinish())
                {
                    report += "Рабочий №" + (i + 1) + " закончил работу\r\n";
                }
                if (String.IsNullOrEmpty(workers[i].CurrentJob))
                {
                    report += "Рабочий №" + (i + 1) + " не работает\r\n";
                }
                else
                {
                    if (workers[i].ShiftsLeft > 0)
                    {
                        report += "Рабочий №" + (i + 1) + " выполняет " + workers[i].CurrentJob + " еще " + workers[i].ShiftsLeft + " смен \r\n";
                    }
                    else
                    {
                        report += "Рабочий №" + (i + 1) + " закончит " + workers[i].CurrentJob + " этой смены\r\n";
                    }
                }
            }
            return report;
        }
    }
}
