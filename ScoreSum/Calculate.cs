using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScoreCalculator
{
    class Calculate
    {
        public void Calculated(ScoreCal_Form1 mainForm, TJARead tjaRead)
        {
            if(bRead)
            {
                ResetValue();
                bRead = false;
            }

            if (!bRead)
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
               
                ComboBonus = tjaRead.nComboBonus / 100;
                mainForm.ScoreUD.Value = Score;




                //通常スコア
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

                    calGdk[0] = tjaRead.gdk[0] * (((ScoreInit - ScoreInit % 10) * 12 / 10) - ((ScoreInit - ScoreInit % 10) * 12 / 10 % 10));
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

                //真打スコア
                for (int i = 0; i < 5; i++)
                {
                    shinuchiNotes += tjaRead.ndk[i] + tjaRead.ntdk[i] * 2 + tjaRead.gdk[i] + tjaRead.gtdk[i] * 2;
                }
                while (shinuchiNotes * shinuchiInit + (tjaRead.baAmount[0] - tjaRead.baSum[0]) * 300 + (tjaRead.baAmount[1] - tjaRead.baSum[1]) * 300 + (tjaRead.baSum[0] * 5000 + tjaRead.baSum[1] * 5000) < 1000000)
                {
                    shinuchiInit += 10;
                }

                #region 読み込み後テキスト
                mainForm.Total.Text = tjaRead.nComboBonus.ToString();
                mainForm.Difficulty.Text = tjaRead.level.ToString();
                mainForm.ndk0.Text = tjaRead.ndk[0].ToString();
                mainForm.ndk1.Text = tjaRead.ndk[1].ToString();
                mainForm.ndk2.Text = tjaRead.ndk[2].ToString();
                mainForm.ndk3.Text = tjaRead.ndk[3].ToString();
                mainForm.ndk4.Text = tjaRead.ndk[4].ToString();
                mainForm.ntdk0.Text = tjaRead.ntdk[0].ToString();
                mainForm.ntdk1.Text = tjaRead.ntdk[1].ToString();
                mainForm.ntdk2.Text = tjaRead.ntdk[2].ToString();
                mainForm.ntdk3.Text = tjaRead.ntdk[3].ToString();
                mainForm.ntdk4.Text = tjaRead.ntdk[4].ToString();
                mainForm.gdk0.Text = tjaRead.gdk[0].ToString();
                mainForm.gdk1.Text = tjaRead.gdk[1].ToString();
                mainForm.gdk2.Text = tjaRead.gdk[2].ToString();
                mainForm.gdk3.Text = tjaRead.gdk[3].ToString();
                mainForm.gdk4.Text = tjaRead.gdk[4].ToString();
                mainForm.gtdk0.Text = tjaRead.gtdk[0].ToString();
                mainForm.gtdk1.Text = tjaRead.gtdk[1].ToString();
                mainForm.gtdk2.Text = tjaRead.gtdk[2].ToString();
                mainForm.gtdk3.Text = tjaRead.gtdk[3].ToString();
                mainForm.gtdk4.Text = tjaRead.gtdk[4].ToString();
                mainForm.textBox1.Text = tjaRead.str[2];
                mainForm.TJAName.Text = tjaRead.ofd.SafeFileName;
                mainForm.INITM.Text = ScoreInit.ToString();
                mainForm.DIFFM.Text = ScoreDiff.ToString();
                mainForm.ShinuchiUD.Text = shinuchiInit.ToString();
                mainForm.re.Text = ((calNdk[0] + calNdk[1] + calNdk[2] + calNdk[3] + calNdk[4] + calNtdk[0] + calNtdk[1] + calNtdk[2] + calNtdk[3] + calNtdk[4] + calGdk[0] + calGdk[1] + calGdk[2] + calGdk[3] + calGdk[4] + calGtdk[0] + calGtdk[1] + calGtdk[2] + calGtdk[3] + calGtdk[4]) + (ComboBonus * 10000 + (tjaRead.baAmount[0] - tjaRead.baSum[0]) * 300 + (tjaRead.baAmount[1] - tjaRead.baSum[1]) * 360 + tjaRead.baSum[0] * 5000 + tjaRead.baSum[1] * 6000)).ToString();
                mainForm.ShinuchiValue.Text = (shinuchiNotes * shinuchiInit + (tjaRead.baAmount[0] - tjaRead.baSum[0]) * 300 + (tjaRead.baAmount[1] - tjaRead.baSum[1]) * 300 + (tjaRead.baSum[0] * 5000 + tjaRead.baSum[1] * 5000)).ToString();
                mainForm.basum0.Text = tjaRead.baSum[0].ToString();
                mainForm.basum1.Text = tjaRead.baSum[1].ToString();
                mainForm.baamount0.Text = tjaRead.baAmount[0].ToString();
                mainForm.baamount1.Text = tjaRead.baAmount[1].ToString();
                #endregion
                bRead = true;
            }

            if (bRead)
            {
                mainForm.TJAReader.Text = "別のTJAファイルを読み込む";
                mainForm.Text = "TJAScoreCalculator..." + tjaRead.ofd.SafeFileName;
            }






        }

        private void ResetValue()
        {
            ScoreInit = 0; ScoreDiff = 0; Score = 0; ComboBonus = 0; //スコア計算用
            diff用 = 0;
            for (int i = 0; i < 5; i++)
            {
                calNdk[i] = 0;
                calNtdk[i] = 0;
                calGdk[i] = 0;
                calGtdk[i] = 0;
            }
            shinuchiNotes = 0;

        }

        public int ScoreInit = 0, ScoreDiff = 0, Score = 0, ComboBonus = 0; //スコア計算用
        public bool bRead = false;
        public int diff用 = 0;
        public int[] calNdk = new int[5];//端数処理しないと計算結果が極端に低くなってしまう...
        public int[] calNtdk = new int[5];
        public int[] calGdk = new int[5];
        public int[] calGtdk = new int[5];
        public int shinuchiNotes, shinuchiInit;

    }
}
