using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScoreCalculator
{
    class CScoreDiff
    {
        Calculate calculate = new Calculate();
        public void ScoreDiffValueChanged(ScoreCal_Form1 mainForm, TJARead tjaRead, Calculate calculate)
        {
            calculate.ScoreDiff = (int)mainForm.DIFFM.Value;
            calculate.calNdk[0] = tjaRead.ndk[0] * (calculate.ScoreInit - calculate.ScoreInit % 10);
            calculate.calNdk[1] = tjaRead.ndk[1] * ((calculate.ScoreInit - calculate.ScoreInit % 10) + (calculate.ScoreDiff - calculate.ScoreDiff % 10));
            calculate.calNdk[2] = tjaRead.ndk[2] * ((calculate.ScoreInit - calculate.ScoreInit % 10) + (calculate.ScoreDiff * 2 - calculate.ScoreDiff * 2 % 10));
            calculate.calNdk[3] = tjaRead.ndk[3] * ((calculate.ScoreInit - calculate.ScoreInit % 10) + (calculate.ScoreDiff * 4 - calculate.ScoreDiff * 4 % 10));
            calculate.calNdk[4] = tjaRead.ndk[4] * ((calculate.ScoreInit - calculate.ScoreInit % 10) + (calculate.ScoreDiff * 8 - calculate.ScoreDiff * 8 % 10));
            calculate.calNtdk[0] = tjaRead.ntdk[0] * 2 * (calculate.ScoreInit - calculate.ScoreInit % 10);
            calculate.calNtdk[1] = tjaRead.ntdk[1] * 2 * ((calculate.ScoreInit - calculate.ScoreInit % 10) + (calculate.ScoreDiff - calculate.ScoreDiff % 10));
            calculate.calNtdk[2] = tjaRead.ntdk[2] * 2 * ((calculate.ScoreInit - calculate.ScoreInit % 10) + (calculate.ScoreDiff * 2 - calculate.ScoreDiff * 2 % 10));
            calculate.calNtdk[3] = tjaRead.ntdk[3] * 2 * ((calculate.ScoreInit - calculate.ScoreInit % 10) + (calculate.ScoreDiff * 4 - calculate.ScoreDiff * 4 % 10));
            calculate.calNtdk[4] = tjaRead.ntdk[4] * 2 * ((calculate.ScoreInit - calculate.ScoreInit % 10) + (calculate.ScoreDiff * 8 - calculate.ScoreDiff * 8 % 10));

            calculate.calGdk[0] = tjaRead.gdk[0] * (((calculate.ScoreInit - calculate.ScoreInit % 10) * 12 / 10) - ((calculate.ScoreInit - calculate.ScoreInit % 10) * 12 / 10 % 10));
            calculate.calGdk[1] = tjaRead.gdk[1] * (((calculate.ScoreInit - calculate.ScoreInit % 10 + (calculate.ScoreDiff - calculate.ScoreDiff % 10)) * 12 / 10) - ((calculate.ScoreInit - calculate.ScoreInit % 10 + (calculate.ScoreDiff - calculate.ScoreDiff % 10)) * 12 / 10) % 10);
            calculate.calGdk[2] = tjaRead.gdk[2] * (((calculate.ScoreInit - calculate.ScoreInit % 10 + (calculate.ScoreDiff * 2 - calculate.ScoreDiff * 2 % 10)) * 12 / 10) - ((calculate.ScoreInit - calculate.ScoreInit % 10 + (calculate.ScoreDiff * 2 - calculate.ScoreDiff * 2 % 10)) * 12 / 10) % 10);
            calculate.calGdk[3] = tjaRead.gdk[3] * (((calculate.ScoreInit - calculate.ScoreInit % 10 + (calculate.ScoreDiff * 4 - calculate.ScoreDiff * 4 % 10)) * 12 / 10) - ((calculate.ScoreInit - calculate.ScoreInit % 10 + (calculate.ScoreDiff * 4 - calculate.ScoreDiff * 4 % 10)) * 12 / 10) % 10);
            calculate.calGdk[4] = tjaRead.gdk[4] * (((calculate.ScoreInit - calculate.ScoreInit % 10 + (calculate.ScoreDiff * 8 - calculate.ScoreDiff * 8 % 10)) * 12 / 10) - ((calculate.ScoreInit - calculate.ScoreInit % 10 + (calculate.ScoreDiff * 8 - calculate.ScoreDiff * 8 % 10)) * 12 / 10) % 10);
            calculate.calGtdk[0] = tjaRead.gtdk[0] * 2 * (((calculate.ScoreInit - calculate.ScoreInit % 10) * 12 / 10) - ((calculate.ScoreInit - calculate.ScoreInit % 10) * 12 / 10 % 10));
            calculate.calGtdk[1] = tjaRead.gtdk[1] * 2 * (((calculate.ScoreInit - calculate.ScoreInit % 10 + (calculate.ScoreDiff - calculate.ScoreDiff % 10)) * 12 / 10) - (((calculate.ScoreInit - calculate.ScoreInit % 10 + (calculate.ScoreDiff - calculate.ScoreDiff % 10)) * 12 / 10) % 10));
            calculate.calGtdk[2] = tjaRead.gtdk[2] * 2 * (((calculate.ScoreInit - calculate.ScoreInit % 10 + (calculate.ScoreDiff * 2 - calculate.ScoreDiff * 2 % 10)) * 12 / 10) - (((calculate.ScoreInit - calculate.ScoreInit % 10 + (calculate.ScoreDiff * 2 - calculate.ScoreDiff * 2 % 10)) * 12 / 10) % 10));
            calculate.calGtdk[3] = tjaRead.gtdk[3] * 2 * (((calculate.ScoreInit - calculate.ScoreInit % 10 + (calculate.ScoreDiff * 4 - calculate.ScoreDiff * 4 % 10)) * 12 / 10) - (((calculate.ScoreInit - calculate.ScoreInit % 10 + (calculate.ScoreDiff * 4 - calculate.ScoreDiff * 4 % 10)) * 12 / 10) % 10));
            calculate.calGtdk[4] = tjaRead.gtdk[4] * 2 * (((calculate.ScoreInit - calculate.ScoreInit % 10 + (calculate.ScoreDiff * 8 - calculate.ScoreDiff * 8 % 10)) * 12 / 10) - (((calculate.ScoreInit - calculate.ScoreInit % 10 + (calculate.ScoreDiff * 8 - calculate.ScoreDiff * 8 % 10)) * 12 / 10) % 10));

            mainForm.INITM.Text = calculate.ScoreInit.ToString();
            mainForm.DIFFM.Text = calculate.ScoreDiff.ToString();
            mainForm.re.Text = ((calculate.calNdk[0] + calculate.calNdk[1] + calculate.calNdk[2] + calculate.calNdk[3] + calculate.calNdk[4] + calculate.calNtdk[0] + calculate.calNtdk[1] + calculate.calNtdk[2] + calculate.calNtdk[3] + calculate.calNtdk[4] + calculate.calGdk[0] + calculate.calGdk[1] + calculate.calGdk[2] + calculate.calGdk[3] + calculate.calGdk[4] + calculate.calGtdk[0] + calculate.calGtdk[1] + calculate.calGtdk[2] + calculate.calGtdk[3] + calculate.calGtdk[4]) + (calculate.ComboBonus * 10000 + (tjaRead.baAmount[0] - tjaRead.baSum[0]) * 300 + (tjaRead.baAmount[1] - tjaRead.baSum[1]) * 360 + tjaRead.baSum[0] * 5000 + tjaRead.baSum[1] * 6000)).ToString();
        }
        public void ScoreDiffTextChanged(ScoreCal_Form1 mainForm, TJARead tjaRead, Calculate calculate)
        {
            int i = 0;
            bool b = int.TryParse(mainForm.DIFFM.Text, out i);
            if (b)
            {
                calculate.ScoreDiff = i;
                calculate.calNdk[0] = tjaRead.ndk[0] * (calculate.ScoreInit - calculate.ScoreInit % 10);
                calculate.calNdk[1] = tjaRead.ndk[1] * ((calculate.ScoreInit - calculate.ScoreInit % 10) + (calculate.ScoreDiff - calculate.ScoreDiff % 10));
                calculate.calNdk[2] = tjaRead.ndk[2] * ((calculate.ScoreInit - calculate.ScoreInit % 10) + (calculate.ScoreDiff * 2 - calculate.ScoreDiff * 2 % 10));
                calculate.calNdk[3] = tjaRead.ndk[3] * ((calculate.ScoreInit - calculate.ScoreInit % 10) + (calculate.ScoreDiff * 4 - calculate.ScoreDiff * 4 % 10));
                calculate.calNdk[4] = tjaRead.ndk[4] * ((calculate.ScoreInit - calculate.ScoreInit % 10) + (calculate.ScoreDiff * 8 - calculate.ScoreDiff * 8 % 10));
                calculate.calNtdk[0] = tjaRead.ntdk[0] * 2 * (calculate.ScoreInit - calculate.ScoreInit % 10);
                calculate.calNtdk[1] = tjaRead.ntdk[1] * 2 * ((calculate.ScoreInit - calculate.ScoreInit % 10) + (calculate.ScoreDiff - calculate.ScoreDiff % 10));
                calculate.calNtdk[2] = tjaRead.ntdk[2] * 2 * ((calculate.ScoreInit - calculate.ScoreInit % 10) + (calculate.ScoreDiff * 2 - calculate.ScoreDiff * 2 % 10));
                calculate.calNtdk[3] = tjaRead.ntdk[3] * 2 * ((calculate.ScoreInit - calculate.ScoreInit % 10) + (calculate.ScoreDiff * 4 - calculate.ScoreDiff * 4 % 10));
                calculate.calNtdk[4] = tjaRead.ntdk[4] * 2 * ((calculate.ScoreInit - calculate.ScoreInit % 10) + (calculate.ScoreDiff * 8 - calculate.ScoreDiff * 8 % 10));

                calculate.calGdk[0] = tjaRead.gdk[0] * (((calculate.ScoreInit - calculate.ScoreInit % 10) * 12 / 10) - ((calculate.ScoreInit - calculate.ScoreInit % 10) * 12 / 10 % 10));
                calculate.calGdk[1] = tjaRead.gdk[1] * (((calculate.ScoreInit - calculate.ScoreInit % 10 + (calculate.ScoreDiff - calculate.ScoreDiff % 10)) * 12 / 10) - ((calculate.ScoreInit - calculate.ScoreInit % 10 + (calculate.ScoreDiff - calculate.ScoreDiff % 10)) * 12 / 10) % 10);
                calculate.calGdk[2] = tjaRead.gdk[2] * (((calculate.ScoreInit - calculate.ScoreInit % 10 + (calculate.ScoreDiff * 2 - calculate.ScoreDiff * 2 % 10)) * 12 / 10) - ((calculate.ScoreInit - calculate.ScoreInit % 10 + (calculate.ScoreDiff * 2 - calculate.ScoreDiff * 2 % 10)) * 12 / 10) % 10);
                calculate.calGdk[3] = tjaRead.gdk[3] * (((calculate.ScoreInit - calculate.ScoreInit % 10 + (calculate.ScoreDiff * 4 - calculate.ScoreDiff * 4 % 10)) * 12 / 10) - ((calculate.ScoreInit - calculate.ScoreInit % 10 + (calculate.ScoreDiff * 4 - calculate.ScoreDiff * 4 % 10)) * 12 / 10) % 10);
                calculate.calGdk[4] = tjaRead.gdk[4] * (((calculate.ScoreInit - calculate.ScoreInit % 10 + (calculate.ScoreDiff * 8 - calculate.ScoreDiff * 8 % 10)) * 12 / 10) - ((calculate.ScoreInit - calculate.ScoreInit % 10 + (calculate.ScoreDiff * 8 - calculate.ScoreDiff * 8 % 10)) * 12 / 10) % 10);
                calculate.calGtdk[0] = tjaRead.gtdk[0] * 2 * (((calculate.ScoreInit - calculate.ScoreInit % 10) * 12 / 10) - ((calculate.ScoreInit - calculate.ScoreInit % 10) * 12 / 10 % 10));
                calculate.calGtdk[1] = tjaRead.gtdk[1] * 2 * (((calculate.ScoreInit - calculate.ScoreInit % 10 + (calculate.ScoreDiff - calculate.ScoreDiff % 10)) * 12 / 10) - (((calculate.ScoreInit - calculate.ScoreInit % 10 + (calculate.ScoreDiff - calculate.ScoreDiff % 10)) * 12 / 10) % 10));
                calculate.calGtdk[2] = tjaRead.gtdk[2] * 2 * (((calculate.ScoreInit - calculate.ScoreInit % 10 + (calculate.ScoreDiff * 2 - calculate.ScoreDiff * 2 % 10)) * 12 / 10) - (((calculate.ScoreInit - calculate.ScoreInit % 10 + (calculate.ScoreDiff * 2 - calculate.ScoreDiff * 2 % 10)) * 12 / 10) % 10));
                calculate.calGtdk[3] = tjaRead.gtdk[3] * 2 * (((calculate.ScoreInit - calculate.ScoreInit % 10 + (calculate.ScoreDiff * 4 - calculate.ScoreDiff * 4 % 10)) * 12 / 10) - (((calculate.ScoreInit - calculate.ScoreInit % 10 + (calculate.ScoreDiff * 4 - calculate.ScoreDiff * 4 % 10)) * 12 / 10) % 10));
                calculate.calGtdk[4] = tjaRead.gtdk[4] * 2 * (((calculate.ScoreInit - calculate.ScoreInit % 10 + (calculate.ScoreDiff * 8 - calculate.ScoreDiff * 8 % 10)) * 12 / 10) - (((calculate.ScoreInit - calculate.ScoreInit % 10 + (calculate.ScoreDiff * 8 - calculate.ScoreDiff * 8 % 10)) * 12 / 10) % 10));

                mainForm.INITM.Text = calculate.ScoreInit.ToString();
                mainForm.DIFFM.Text = calculate.ScoreDiff.ToString();
                mainForm.re.Text = ((calculate.calNdk[0] + calculate.calNdk[1] + calculate.calNdk[2] + calculate.calNdk[3] + calculate.calNdk[4] + calculate.calNtdk[0] + calculate.calNtdk[1] + calculate.calNtdk[2] + calculate.calNtdk[3] + calculate.calNtdk[4] + calculate.calGdk[0] + calculate.calGdk[1] + calculate.calGdk[2] + calculate.calGdk[3] + calculate.calGdk[4] + calculate.calGtdk[0] + calculate.calGtdk[1] + calculate.calGtdk[2] + calculate.calGtdk[3] + calculate.calGtdk[4]) + (calculate.ComboBonus * 10000 + (tjaRead.baAmount[0] - tjaRead.baSum[0]) * 300 + (tjaRead.baAmount[1] - tjaRead.baSum[1]) * 360 + tjaRead.baSum[0] * 5000 + tjaRead.baSum[1] * 6000)).ToString();
            }
        }

        public void Diff比率Changed(ScoreCal_Form1 mainForm, TJARead tjaRead, Calculate calculate)
        {
            double n = (double)mainForm.Diff比率.Value * 2, d = (double)mainForm.Diff比率.Value * 10;
            switch (n)
            {
                case 1:
                    calculate.ScoreDiff = calculate.ScoreInit * 10 / 5;
                    break;
                case 2:
                    calculate.ScoreDiff = calculate.ScoreInit / 1;
                    break;
                case 3:
                    calculate.ScoreDiff = calculate.ScoreInit * 10 / 15;
                    break;
                case 4:
                    calculate.ScoreDiff = calculate.ScoreInit / 2;
                    break;
                case 5:
                    calculate.ScoreDiff = calculate.ScoreInit * 10 / 25;
                    break;
                case 6:
                    calculate.ScoreDiff = calculate.ScoreInit / 3;
                    break;
                case 7:
                    calculate.ScoreDiff = calculate.ScoreInit * 10 / 35;
                    break;
                case 8:
                    calculate.ScoreDiff = calculate.ScoreInit / 4;
                    break;
                case 9:
                    calculate.ScoreDiff = calculate.ScoreInit * 10 / 45;
                    break;
                case 10:
                    calculate.ScoreDiff = calculate.ScoreInit / 5;
                    break;
                case 11:
                    calculate.ScoreDiff = calculate.ScoreInit * 10 / 55;
                    break;
                case 12:
                    calculate.ScoreDiff = calculate.ScoreInit / 6;
                    break;
                case 13:
                    calculate.ScoreDiff = calculate.ScoreInit * 10 / 65;
                    break;
                case 14:
                    calculate.ScoreDiff = calculate.ScoreInit / 7;
                    break;
                case 15:
                    calculate.ScoreDiff = calculate.ScoreInit * 10 / 75;
                    break;
                case 16:
                    calculate.ScoreDiff = calculate.ScoreInit / 8;
                    break;
                case 17:
                    calculate.ScoreDiff = calculate.ScoreInit * 10 / 85;
                    break;
                case 18:
                    calculate.ScoreDiff = calculate.ScoreInit / 90;
                    break;
                case 19:
                    calculate.ScoreDiff = calculate.ScoreInit * 10 / 95;
                    break;
                case 20:
                    calculate.ScoreDiff = calculate.ScoreInit / 10;
                    break;

                default:
                    calculate.ScoreDiff = calculate.ScoreInit * 10 / (int)d;
                    break;

            }
            calculate.calNdk[0] = tjaRead.ndk[0] * (calculate.ScoreInit - calculate.ScoreInit % 10);
            calculate.calNdk[1] = tjaRead.ndk[1] * ((calculate.ScoreInit - calculate.ScoreInit % 10) + (calculate.ScoreDiff - calculate.ScoreDiff % 10));
            calculate.calNdk[2] = tjaRead.ndk[2] * ((calculate.ScoreInit - calculate.ScoreInit % 10) + (calculate.ScoreDiff * 2 - calculate.ScoreDiff * 2 % 10));
            calculate.calNdk[3] = tjaRead.ndk[3] * ((calculate.ScoreInit - calculate.ScoreInit % 10) + (calculate.ScoreDiff * 4 - calculate.ScoreDiff * 4 % 10));
            calculate.calNdk[4] = tjaRead.ndk[4] * ((calculate.ScoreInit - calculate.ScoreInit % 10) + (calculate.ScoreDiff * 8 - calculate.ScoreDiff * 8 % 10));
            calculate.calNtdk[0] = tjaRead.ntdk[0] * 2 * (calculate.ScoreInit - calculate.ScoreInit % 10);
            calculate.calNtdk[1] = tjaRead.ntdk[1] * 2 * ((calculate.ScoreInit - calculate.ScoreInit % 10) + (calculate.ScoreDiff - calculate.ScoreDiff % 10));
            calculate.calNtdk[2] = tjaRead.ntdk[2] * 2 * ((calculate.ScoreInit - calculate.ScoreInit % 10) + (calculate.ScoreDiff * 2 - calculate.ScoreDiff * 2 % 10));
            calculate.calNtdk[3] = tjaRead.ntdk[3] * 2 * ((calculate.ScoreInit - calculate.ScoreInit % 10) + (calculate.ScoreDiff * 4 - calculate.ScoreDiff * 4 % 10));
            calculate.calNtdk[4] = tjaRead.ntdk[4] * 2 * ((calculate.ScoreInit - calculate.ScoreInit % 10) + (calculate.ScoreDiff * 8 - calculate.ScoreDiff * 8 % 10));

            calculate.calGdk[0] = tjaRead.gdk[0] * (((calculate.ScoreInit - calculate.ScoreInit % 10) * 12 / 10) - (calculate.ScoreInit - (calculate.ScoreInit % 10) * 12 / 10) % 10);
            calculate.calGdk[1] = tjaRead.gdk[1] * (((calculate.ScoreInit - calculate.ScoreInit % 10 + (calculate.ScoreDiff - calculate.ScoreDiff % 10)) * 12 / 10) - ((calculate.ScoreInit - calculate.ScoreInit % 10 + (calculate.ScoreDiff - calculate.ScoreDiff % 10)) * 12 / 10) % 10);
            calculate.calGdk[2] = tjaRead.gdk[2] * (((calculate.ScoreInit - calculate.ScoreInit % 10 + (calculate.ScoreDiff * 2 - calculate.ScoreDiff * 2 % 10)) * 12 / 10) - ((calculate.ScoreInit - calculate.ScoreInit % 10 + (calculate.ScoreDiff * 2 - calculate.ScoreDiff * 2 % 10)) * 12 / 10) % 10);
            calculate.calGdk[3] = tjaRead.gdk[3] * (((calculate.ScoreInit - calculate.ScoreInit % 10 + (calculate.ScoreDiff * 4 - calculate.ScoreDiff * 4 % 10)) * 12 / 10) - ((calculate.ScoreInit - calculate.ScoreInit % 10 + (calculate.ScoreDiff * 4 - calculate.ScoreDiff * 4 % 10)) * 12 / 10) % 10);
            calculate.calGdk[4] = tjaRead.gdk[4] * (((calculate.ScoreInit - calculate.ScoreInit % 10 + (calculate.ScoreDiff * 8 - calculate.ScoreDiff * 8 % 10)) * 12 / 10) - ((calculate.ScoreInit - calculate.ScoreInit % 10 + (calculate.ScoreDiff * 8 - calculate.ScoreDiff * 8 % 10)) * 12 / 10) % 10);
            calculate.calGtdk[0] = tjaRead.gtdk[0] * 2 * (((calculate.ScoreInit - calculate.ScoreInit % 10) * 12 / 10) - ((calculate.ScoreInit - calculate.ScoreInit % 10) * 12 / 10 % 10));
            calculate.calGtdk[1] = tjaRead.gtdk[1] * 2 * (((calculate.ScoreInit - calculate.ScoreInit % 10 + (calculate.ScoreDiff - calculate.ScoreDiff % 10)) * 12 / 10) - (((calculate.ScoreInit - calculate.ScoreInit % 10 + (calculate.ScoreDiff - calculate.ScoreDiff % 10)) * 12 / 10) % 10));
            calculate.calGtdk[2] = tjaRead.gtdk[2] * 2 * (((calculate.ScoreInit - calculate.ScoreInit % 10 + (calculate.ScoreDiff * 2 - calculate.ScoreDiff * 2 % 10)) * 12 / 10) - (((calculate.ScoreInit - calculate.ScoreInit % 10 + (calculate.ScoreDiff * 2 - calculate.ScoreDiff * 2 % 10)) * 12 / 10) % 10));
            calculate.calGtdk[3] = tjaRead.gtdk[3] * 2 * (((calculate.ScoreInit - calculate.ScoreInit % 10 + (calculate.ScoreDiff * 4 - calculate.ScoreDiff * 4 % 10)) * 12 / 10) - (((calculate.ScoreInit - calculate.ScoreInit % 10 + (calculate.ScoreDiff * 4 - calculate.ScoreDiff * 4 % 10)) * 12 / 10) % 10));
            calculate.calGtdk[4] = tjaRead.gtdk[4] * 2 * (((calculate.ScoreInit - calculate.ScoreInit % 10 + (calculate.ScoreDiff * 8 - calculate.ScoreDiff * 8 % 10)) * 12 / 10) - (((calculate.ScoreInit - calculate.ScoreInit % 10 + (calculate.ScoreDiff * 8 - calculate.ScoreDiff * 8 % 10)) * 12 / 10) % 10));


            mainForm.INITM.Text = calculate.ScoreInit.ToString();
            mainForm.DIFFM.Text = calculate.ScoreDiff.ToString();
            mainForm.re.Text = ((calculate.calNdk[0] + calculate.calNdk[1] + calculate.calNdk[2] + calculate.calNdk[3] + calculate.calNdk[4] + calculate.calNtdk[0] + calculate.calNtdk[1] + calculate.calNtdk[2] + calculate.calNtdk[3] + calculate.calNtdk[4] + calculate.calGdk[0] + calculate.calGdk[1] + calculate.calGdk[2] + calculate.calGdk[3] + calculate.calGdk[4] + calculate.calGtdk[0] + calculate.calGtdk[1] + calculate.calGtdk[2] + calculate.calGtdk[3] + calculate.calGtdk[4]) + (calculate.ComboBonus * 10000 + (tjaRead.baAmount[0] - tjaRead.baSum[0]) * 300 + (tjaRead.baAmount[1] - tjaRead.baSum[1]) * 360 + tjaRead.baSum[0] * 5000 + tjaRead.baSum[1] * 6000)).ToString();
        }

    }
}
