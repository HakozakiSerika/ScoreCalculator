using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreCalculator
{
    class Calculate
    {
        public void Calculated(TJARead tjaRead)
        {
            if (!bFirstRead)
            {
                if (tjaRead.level <= 1)
                {
                    Score = 700000;
                }
                else if (tjaRead.level <= 2)
                {
                    Score = 750000;
                }
                else if (tjaRead.level <= 3)
                {
                    Score = 800000;
                }
                else if (tjaRead.level <= 4)
                {
                    Score = 850000;
                }
                else if (tjaRead.level <= 5)
                {
                    Score = 900000;
                }
                else if (tjaRead.level <= 6)
                {
                    Score = 950000;
                }
                else if (tjaRead.level <= 7)
                {
                    Score = 1000000;
                }
                else if (tjaRead.level <= 8)
                {
                    Score = 1050000;
                }
                else if (tjaRead.level <= 9)
                {
                    Score = 1100000;
                }
                else if (tjaRead.level <= 10)
                {
                    Score = 1200000;
                }
                else
                {
                    Score = 1000000;
                }
               
                ComboBonus = tjaRead.tja0[1].Length / 100;






                while (((calNdk[0] + calNdk[1] + calNdk[2] + calNdk[3] + calNdk[4] + calNtdk[0] + calNtdk[1] + calNtdk[2] + calNtdk[3] + calNtdk[4] + calGdk[0] + calGdk[1] + calGdk[2] + calGdk[3] + calGdk[4] + calGtdk[0] + calGtdk[1] + calGtdk[2] + calGtdk[3] + calGtdk[4]) + (ComboBonus * 10000 + (tjaRead.baAmount[0] - tjaRead.baSum[0]) * 300 + (tjaRead.baAmount[1] - tjaRead.baSum[1]) * 360 + tjaRead.baSum[0] * 5000 + tjaRead.baSum[1] * 6000)) < Score)
                {
                    int n;
                    diff用 += 1;
                    ScoreDiff = diff用 / 4;
                    if (diff用 % 10 == 0)
                        ScoreInit += 10;

                    calNdk[0] = tjaRead.ndk[0] * (ScoreInit - ScoreInit % 10);
                    calNdk[1] = tjaRead.ndk[1] * ((ScoreInit - ScoreInit % 10) + (ScoreDiff - ScoreDiff % 10));
                    calNdk[2] = tjaRead.ndk[2] * ((ScoreInit - ScoreInit % 10) + (ScoreDiff * 2 - ScoreDiff * 2 % 10));
                    calNdk[3] = tjaRead.ndk[3] * ((ScoreInit - ScoreInit % 10) + (ScoreDiff * 4 - ScoreDiff * 4 % 10));
                    calNdk[4] = tjaRead.ndk[4] * ((ScoreInit - ScoreInit % 10) + (ScoreDiff * 8 - ScoreDiff * 8 % 10));
                    calNtdk[0] = tjaRead.ntdk[0] * 2 * (ScoreInit - ScoreInit % 10);
                    calNtdk[1] = tjaRead.ntdk[1] * 2 * ((ScoreInit - ScoreInit % 10) + (ScoreDiff - ScoreDiff % 10));
                    calNtdk[2] = tjaRead.ntdk[2] * 2 * ((ScoreInit - ScoreInit % 10) + (ScoreDiff * 2 - ScoreDiff * 2 % 10));
                    calNtdk[3] = tjaRead.ntdk[3] * 2 * ((ScoreInit - ScoreInit % 10) + (ScoreDiff * 4 - ScoreDiff * 4 % 10));
                    calNtdk[4] = tjaRead.ntdk[4] * 2 * ((ScoreInit - ScoreInit % 10) + (ScoreDiff * 8 - ScoreDiff * 8 % 10));

                    calGdk[0] = tjaRead.gdk[0] * (((ScoreInit - ScoreInit % 10) * 12 / 10) - (ScoreInit - (ScoreInit % 10) * 12 / 10) % 10);
                    calGdk[1] = tjaRead.gdk[1] * (((ScoreInit - ScoreInit % 10 + (ScoreDiff - ScoreDiff % 10)) * 12 / 10) - ((ScoreInit - ScoreInit % 10 + (ScoreDiff - ScoreDiff % 10)) * 12 / 10) % 10);
                    calGdk[2] = tjaRead.gdk[2] * (((ScoreInit - ScoreInit % 10 + (ScoreDiff * 2 - ScoreDiff * 2 % 10)) * 12 / 10) - ((ScoreInit - ScoreInit % 10 + (ScoreDiff * 2 - ScoreDiff * 2 % 10)) * 12 / 10) % 10);
                    calGdk[3] = tjaRead.gdk[3] * (((ScoreInit - ScoreInit % 10 + (ScoreDiff * 4 - ScoreDiff * 4 % 10)) * 12 / 10) - ((ScoreInit - ScoreInit % 10 + (ScoreDiff * 4 - ScoreDiff * 4 % 10)) * 12 / 10) % 10);
                    calGdk[4] = tjaRead.gdk[4] * (((ScoreInit - ScoreInit % 10 + (ScoreDiff * 8 - ScoreDiff * 8 % 10)) * 12 / 10) - ((ScoreInit - ScoreInit % 10 + (ScoreDiff * 8 - ScoreDiff * 8 % 10)) * 12 / 10) % 10);
                    calGtdk[0] = tjaRead.gtdk[0] * 2 * (((ScoreInit - ScoreInit % 10) * 12 / 10) - ((ScoreInit - ScoreInit % 10) * 12 / 10 % 10));
                    calGtdk[1] = tjaRead.gtdk[1] * 2 * (((ScoreInit - ScoreInit % 10 + (ScoreDiff - ScoreDiff % 10)) * 12 / 10) - (((ScoreInit - ScoreInit % 10 + (ScoreDiff - ScoreDiff % 10)) * 12 / 10) % 10));
                    calGtdk[2] = tjaRead.gtdk[2] * 2 * (((ScoreInit - ScoreInit % 10 + (ScoreDiff * 2 - ScoreDiff * 2 % 10)) * 12 / 10) - (((ScoreInit - ScoreInit % 10 + (ScoreDiff * 2 - ScoreDiff * 2 % 10)) * 12 / 10) % 10));
                    calGtdk[3] = tjaRead.gtdk[3] * 2 * (((ScoreInit - ScoreInit % 10 + (ScoreDiff * 4 - ScoreDiff * 4 % 10)) * 12 / 10) - (((ScoreInit - ScoreInit % 10 + (ScoreDiff * 4 - ScoreDiff * 4 % 10)) * 12 / 10) % 10));
                    calGtdk[4] = tjaRead.gtdk[4] * 2 * (((ScoreInit - ScoreInit % 10 + (ScoreDiff * 8 - ScoreDiff * 8 % 10)) * 12 / 10) - (((ScoreInit - ScoreInit % 10 + (ScoreDiff * 8 - ScoreDiff * 8 % 10)) * 12 / 10) % 10));

                    n = ((calNdk[0] + calNdk[1] + calNdk[2] + calNdk[3] + calNdk[4] + calNtdk[0] + calNtdk[1] + calNtdk[2] + calNtdk[3] + calNtdk[4] + calGdk[0] + calGdk[1] + calGdk[2] + calGdk[3] + calGdk[4] + calGtdk[0] + calGtdk[1] + calGtdk[2] + calGtdk[3] + calGtdk[4]) + (ComboBonus * 10000 + (tjaRead.baAmount[0] - tjaRead.baSum[0]) * 300 + (tjaRead.baAmount[1] - tjaRead.baSum[1]) * 360 + tjaRead.baSum[0] * 5000 + tjaRead.baSum[1] * 6000));
                    if (n > Score)
                    {
                        break;
                    }
                }

                string s = null;
                for (int j = 0; j < 5; j++)
                {
                    if (tjaRead.ndk[j] != 0)
                        s += "calNdk[" + j.ToString() + "]=" + (calNdk[j]).ToString() + Environment.NewLine;
                    else
                        s += "calNdk[" + j.ToString() + "]=" + "0" + Environment.NewLine;
                    if (tjaRead.ntdk[j] != 0)
                        s += "calNtdk[" + j.ToString() + "]=" + (calNtdk[j]).ToString() + Environment.NewLine;
                    else
                        s += "calNtdk[" + j.ToString() + "]=" + "0" + Environment.NewLine;
                    if (tjaRead.gdk[j] != 0)
                        s += "calGdk[" + j.ToString() + "]=" + (calGdk[j]).ToString() + Environment.NewLine;
                    else
                        s += "calGdk[" + j.ToString() + "]=" + "0" + Environment.NewLine;
                    if (tjaRead.gtdk[j] != 0)
                        s += "calGtdk[" + j.ToString() + "]=" + (calGtdk[j]).ToString() + Environment.NewLine;
                    else
                        s += "calGtdk[" + j.ToString() + "]=" + "0" + Environment.NewLine;
                }
                bFirstRead = true;
            }







        }


        public int ScoreInit = 0, ScoreDiff = 0, Score = 0, ComboBonus = 0; //スコア計算用
        public bool bFirstRead = false;
        public int diff用 = 0;
        public int[] calNdk = new int[5];//端数処理しないと計算結果が極端に低くなってしまう...
        public int[] calNtdk = new int[5];
        public int[] calGdk = new int[5];
        public int[] calGtdk = new int[5];

    }
}
