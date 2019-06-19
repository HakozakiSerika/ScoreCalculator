using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreCalculator
{
    class CShinuchi
    {
        Calculate calculate = new Calculate();
        public void ShinuchiUDValueChanged(ScoreCal_Form1 mainForm, TJARead tjaRead, Calculate calculate)
        {
            calculate.shinuchiInit = (int)mainForm.ShinuchiUD.Value;
            mainForm.ShinuchiValue.Text = (calculate.shinuchiNotes * calculate.shinuchiInit + (tjaRead.baAmount[0] - tjaRead.baSum[0]) * 300 + (tjaRead.baAmount[1] - tjaRead.baSum[1]) * 300 + (tjaRead.baSum[0] * 5000 + tjaRead.baSum[1] * 5000)).ToString();
        }
    }
}