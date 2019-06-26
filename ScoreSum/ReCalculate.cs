using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScoreCalculator
{
    class ReCalculate
    {
        public ReCalculate()
        {
            ResetValue();
        }

        public ReCalculate(ScoreCal_Form1 mainForm, SelectedCourse sc)
        {
            ResetValue();
        }
        public void ReCalculated(ScoreCal_Form1 mainForm, SelectedCourse sc, int nCourseNumber)
        {
            ResetValue();

            #region 0
            if (nCourseNumber == 0)
            {
                if (sc.level <= 1)
                {
                    Score = 300000;
                }
                else if (sc.level <= 2)
                {
                    Score = 320000;
                }
                else if (sc.level <= 3)
                {
                    Score = 340000;
                }
                else if (sc.level <= 4)
                {
                    Score = 360000;
                }
                else if (sc.level <= 5)
                {
                    Score = 380000;
                }
                else
                {
                    Score = 340000;
                }
            }
            #endregion
            #region 1
            if (nCourseNumber == 1)
            {
                if (sc.level <= 1)
                {
                    Score = 400000;
                }
                else if (sc.level <= 2)
                {
                    Score = 450000;
                }
                else if (sc.level <= 3)
                {
                    Score = 500000;
                }
                else if (sc.level <= 4)
                {
                    Score = 550000;
                }
                else if (sc.level <= 5)
                {
                    Score = 600000;
                }
                else if (sc.level <= 6)
                {
                    Score = 650000;
                }
                else if (sc.level <= 7)
                {
                    Score = 700000;
                }
                else
                {
                    Score = 550000;
                }
            }
            #endregion
            #region 2
            if (nCourseNumber == 2)
            {
                if (sc.level <= 1)
                {
                    Score = 550000;
                }
                else if (sc.level <= 2)
                {
                    Score = 600000;
                }
                else if (sc.level <= 3)
                {
                    Score = 650000;
                }
                else if (sc.level <= 4)
                {
                    Score = 700000;
                }
                else if (sc.level <= 5)
                {
                    Score = 750000;
                }
                else if (sc.level <= 6)
                {
                    Score = 800000;
                }
                else if (sc.level <= 7)
                {
                    Score = 850000;
                }
                else if (sc.level <= 8)
                {
                    Score = 900000;
                }
                else
                {
                    Score = 750000;
                }
            }
            #endregion
            #region 3||4
            if (nCourseNumber >= 3 && nCourseNumber < 5)
            {
                if (sc.level <= 1)
                {
                    Score = 700000;
                }
                else if (sc.level <= 2)
                {
                    Score = 750000;
                }
                else if (sc.level <= 3)
                {
                    Score = 800000;
                }
                else if (sc.level <= 4)
                {
                    Score = 850000;
                }
                else if (sc.level <= 5)
                {
                    Score = 900000;
                }
                else if (sc.level <= 6)
                {
                    Score = 950000;
                }
                else if (sc.level <= 7)
                {
                    Score = 1000000;
                }
                else if (sc.level <= 8)
                {
                    Score = 1050000;
                }
                else if (sc.level <= 9)
                {
                    Score = 1100000;
                }
                else if (sc.level <= 10)
                {
                    Score = 1200000;
                }
                else
                {
                    Score = 1000000;
                }
            }
            #endregion

            ComboBonus = sc.nComboBonus / 100;
            mainForm.ScoreUD.Value = Score;




            //通常スコア
            while (((calNdk[0] + calNdk[1] + calNdk[2] + calNdk[3] + calNdk[4] + calNtdk[0] + calNtdk[1] + calNtdk[2] + calNtdk[3] + calNtdk[4] + calGdk[0] + calGdk[1] + calGdk[2] + calGdk[3] + calGdk[4] + calGtdk[0] + calGtdk[1] + calGtdk[2] + calGtdk[3] + calGtdk[4]) + (ComboBonus * 10000 + (sc.baAmount[0] - sc.baSum[0]) * 300 + (sc.baAmount[1] - sc.baSum[1]) * 360 + sc.baSum[0] * 5000 + sc.baSum[1] * 6000)) < Score)
            {
                int n;
                diff用 += 1;
                ScoreDiff = diff用 / 4;
                if (diff用 % 10 == 0)
                    ScoreInit += 10;

                calNdk[0] = sc.ndk[0] * (ScoreInit - ScoreInit % 10);
                calNdk[1] = sc.ndk[1] * ((ScoreInit - ScoreInit % 10) + (ScoreDiff - ScoreDiff % 10));
                calNdk[2] = sc.ndk[2] * ((ScoreInit - ScoreInit % 10) + (ScoreDiff * 2 - ScoreDiff * 2 % 10));
                calNdk[3] = sc.ndk[3] * ((ScoreInit - ScoreInit % 10) + (ScoreDiff * 4 - ScoreDiff * 4 % 10));
                calNdk[4] = sc.ndk[4] * ((ScoreInit - ScoreInit % 10) + (ScoreDiff * 8 - ScoreDiff * 8 % 10));
                calNtdk[0] = sc.ntdk[0] * 2 * (ScoreInit - ScoreInit % 10);
                calNtdk[1] = sc.ntdk[1] * 2 * ((ScoreInit - ScoreInit % 10) + (ScoreDiff - ScoreDiff % 10));
                calNtdk[2] = sc.ntdk[2] * 2 * ((ScoreInit - ScoreInit % 10) + (ScoreDiff * 2 - ScoreDiff * 2 % 10));
                calNtdk[3] = sc.ntdk[3] * 2 * ((ScoreInit - ScoreInit % 10) + (ScoreDiff * 4 - ScoreDiff * 4 % 10));
                calNtdk[4] = sc.ntdk[4] * 2 * ((ScoreInit - ScoreInit % 10) + (ScoreDiff * 8 - ScoreDiff * 8 % 10));

                calGdk[0] = sc.gdk[0] * (((ScoreInit - ScoreInit % 10) * 12 / 10) - ((ScoreInit - ScoreInit % 10) * 12 / 10 % 10));
                calGdk[1] = sc.gdk[1] * (((ScoreInit - ScoreInit % 10 + (ScoreDiff - ScoreDiff % 10)) * 12 / 10) - ((ScoreInit - ScoreInit % 10 + (ScoreDiff - ScoreDiff % 10)) * 12 / 10) % 10);
                calGdk[2] = sc.gdk[2] * (((ScoreInit - ScoreInit % 10 + (ScoreDiff * 2 - ScoreDiff * 2 % 10)) * 12 / 10) - ((ScoreInit - ScoreInit % 10 + (ScoreDiff * 2 - ScoreDiff * 2 % 10)) * 12 / 10) % 10);
                calGdk[3] = sc.gdk[3] * (((ScoreInit - ScoreInit % 10 + (ScoreDiff * 4 - ScoreDiff * 4 % 10)) * 12 / 10) - ((ScoreInit - ScoreInit % 10 + (ScoreDiff * 4 - ScoreDiff * 4 % 10)) * 12 / 10) % 10);
                calGdk[4] = sc.gdk[4] * (((ScoreInit - ScoreInit % 10 + (ScoreDiff * 8 - ScoreDiff * 8 % 10)) * 12 / 10) - ((ScoreInit - ScoreInit % 10 + (ScoreDiff * 8 - ScoreDiff * 8 % 10)) * 12 / 10) % 10);
                calGtdk[0] = sc.gtdk[0] * 2 * (((ScoreInit - ScoreInit % 10) * 12 / 10) - ((ScoreInit - ScoreInit % 10) * 12 / 10 % 10));
                calGtdk[1] = sc.gtdk[1] * 2 * (((ScoreInit - ScoreInit % 10 + (ScoreDiff - ScoreDiff % 10)) * 12 / 10) - (((ScoreInit - ScoreInit % 10 + (ScoreDiff - ScoreDiff % 10)) * 12 / 10) % 10));
                calGtdk[2] = sc.gtdk[2] * 2 * (((ScoreInit - ScoreInit % 10 + (ScoreDiff * 2 - ScoreDiff * 2 % 10)) * 12 / 10) - (((ScoreInit - ScoreInit % 10 + (ScoreDiff * 2 - ScoreDiff * 2 % 10)) * 12 / 10) % 10));
                calGtdk[3] = sc.gtdk[3] * 2 * (((ScoreInit - ScoreInit % 10 + (ScoreDiff * 4 - ScoreDiff * 4 % 10)) * 12 / 10) - (((ScoreInit - ScoreInit % 10 + (ScoreDiff * 4 - ScoreDiff * 4 % 10)) * 12 / 10) % 10));
                calGtdk[4] = sc.gtdk[4] * 2 * (((ScoreInit - ScoreInit % 10 + (ScoreDiff * 8 - ScoreDiff * 8 % 10)) * 12 / 10) - (((ScoreInit - ScoreInit % 10 + (ScoreDiff * 8 - ScoreDiff * 8 % 10)) * 12 / 10) % 10));

                n = ((calNdk[0] + calNdk[1] + calNdk[2] + calNdk[3] + calNdk[4] + calNtdk[0] + calNtdk[1] + calNtdk[2] + calNtdk[3] + calNtdk[4] + calGdk[0] + calGdk[1] + calGdk[2] + calGdk[3] + calGdk[4] + calGtdk[0] + calGtdk[1] + calGtdk[2] + calGtdk[3] + calGtdk[4]) + (ComboBonus * 10000 + (sc.baAmount[0] - sc.baSum[0]) * 300 + (sc.baAmount[1] - sc.baSum[1]) * 360 + sc.baSum[0] * 5000 + sc.baSum[1] * 6000));
                if (n > Score)
                {
                    break;
                }
            }

            //真打スコア
            for (int i = 0; i < 5; i++)
            {
                shinuchiNotes += sc.ndk[i] + sc.ntdk[i] * 2 + sc.gdk[i] + sc.gtdk[i] * 2;
            }
            while (shinuchiNotes * shinuchiInit + (sc.baAmount[0] - sc.baSum[0]) * 300 + (sc.baAmount[1] - sc.baSum[1]) * 300 + (sc.baSum[0] * 5000 + sc.baSum[1] * 5000) < 1000000)
            {
                shinuchiInit += 10;
            }

            #region 読み込み後テキスト
            mainForm.Total.Text = sc.nComboBonus.ToString();
            mainForm.Difficulty.Text = sc.level.ToString();
            mainForm.ndk0.Text = sc.ndk[0].ToString();
            mainForm.ndk1.Text = sc.ndk[1].ToString();
            mainForm.ndk2.Text = sc.ndk[2].ToString();
            mainForm.ndk3.Text = sc.ndk[3].ToString();
            mainForm.ndk4.Text = sc.ndk[4].ToString();
            mainForm.ntdk0.Text = sc.ntdk[0].ToString();
            mainForm.ntdk1.Text = sc.ntdk[1].ToString();
            mainForm.ntdk2.Text = sc.ntdk[2].ToString();
            mainForm.ntdk3.Text = sc.ntdk[3].ToString();
            mainForm.ntdk4.Text = sc.ntdk[4].ToString();
            mainForm.gdk0.Text = sc.gdk[0].ToString();
            mainForm.gdk1.Text = sc.gdk[1].ToString();
            mainForm.gdk2.Text = sc.gdk[2].ToString();
            mainForm.gdk3.Text = sc.gdk[3].ToString();
            mainForm.gdk4.Text = sc.gdk[4].ToString();
            mainForm.gtdk0.Text = sc.gtdk[0].ToString();
            mainForm.gtdk1.Text = sc.gtdk[1].ToString();
            mainForm.gtdk2.Text = sc.gtdk[2].ToString();
            mainForm.gtdk3.Text = sc.gtdk[3].ToString();
            mainForm.gtdk4.Text = sc.gtdk[4].ToString();
            mainForm.textBox1.Text = sc.str[2];
            mainForm.INITM.Text = ScoreInit.ToString();
            mainForm.DIFFM.Text = ScoreDiff.ToString();
            mainForm.ShinuchiUD.Text = shinuchiInit.ToString();
            mainForm.re.Text = ((calNdk[0] + calNdk[1] + calNdk[2] + calNdk[3] + calNdk[4] + calNtdk[0] + calNtdk[1] + calNtdk[2] + calNtdk[3] + calNtdk[4] + calGdk[0] + calGdk[1] + calGdk[2] + calGdk[3] + calGdk[4] + calGtdk[0] + calGtdk[1] + calGtdk[2] + calGtdk[3] + calGtdk[4]) + (ComboBonus * 10000 + (sc.baAmount[0] - sc.baSum[0]) * 300 + (sc.baAmount[1] - sc.baSum[1]) * 360 + sc.baSum[0] * 5000 + sc.baSum[1] * 6000)).ToString();
            mainForm.ShinuchiValue.Text = (shinuchiNotes * shinuchiInit + (sc.baAmount[0] - sc.baSum[0]) * 300 + (sc.baAmount[1] - sc.baSum[1]) * 300 + (sc.baSum[0] * 5000 + sc.baSum[1] * 5000)).ToString();
            mainForm.basum0.Text = sc.baSum[0].ToString();
            mainForm.basum1.Text = sc.baSum[1].ToString();
            mainForm.baamount0.Text = sc.baAmount[0].ToString();
            mainForm.baamount1.Text = sc.baAmount[1].ToString();

            if (sc.bKusudamaExist)
                mainForm.Kusudama.Visible = true;
            else
                mainForm.Kusudama.Visible = false;

            #endregion
            bRead = true;

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
            shinuchiInit = 0;

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
