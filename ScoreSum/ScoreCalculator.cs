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

namespace ScoreCalculator

    /*
     このコードを見ているあなたへ
     このクソコードは自分が無茶ぶりで「SCOREINITとSCOREDIFF簡単にもとめられねーかな～」
     と思い、見様見真似で製作中のものです。よって
     ・マジクソコード
     ・Formアプリの作り方教わってないから抜けあるよ！多分
     ・ミスを見つけたら「ああ～...こいつもまだまだだな」って感じで修正してくれるとありがたいです
     */





{
    public partial class ScoreCal_Form1 : Form
    {
        TJARead tjaRead = new TJARead();
        Calculate calculate = new Calculate();
        CScoreInit scoreInit = new CScoreInit();
        CScoreDiff scoreDiff = new CScoreDiff();

        public ScoreCal_Form1()
        {
            InitializeComponent();
        }

        public ScoreCal_Form1(string filePath)
            : this()
        {
            if (!tjaRead.TJAReader(filePath))
            {
                return;
            }
            calculate.Calculated(this, tjaRead);
        }

        private void TJAReader_Click(object sender, EventArgs e)
        {
            //初期化

            if (!tjaRead.TJAReader())
            {
                return;
            }
            calculate.Calculated(this, tjaRead);
        }

        private void button2_click(object sender, EventArgs e)
        {

        }

        private void ScoreUD_ValueChanged(object sender, EventArgs e)
        {
            if (calculate.bRead)
            {
                calculate.Score = (int)ScoreUD.Value;

                for (int i = 0; i < 5; i++)
                {
                    calculate.calNdk[i] = 0;
                    calculate.calNtdk[i] = 0;
                    calculate.calGdk[i] = 0;
                    calculate.calGtdk[i] = 0;
                }

                calculate.ScoreInit = 0;
                calculate.ScoreDiff = 0;
                calculate.diff用 = 0;

                while (((calculate.calNdk[0] + calculate.calNdk[1] + calculate.calNdk[2] + calculate.calNdk[3] + calculate.calNdk[4] + calculate.calNtdk[0] + calculate.calNtdk[1] + calculate.calNtdk[2] + calculate.calNtdk[3] + calculate.calNtdk[4] + calculate.calGdk[0] + calculate.calGdk[1] + calculate.calGdk[2] + calculate.calGdk[3] + calculate.calGdk[4] + calculate.calGtdk[0] + calculate.calGtdk[1] + calculate.calGtdk[2] + calculate.calGtdk[3] + calculate.calGtdk[4]) + (calculate.ComboBonus * 10000 + ( tjaRead.baAmount[0] - tjaRead.baSum[0]) * 300 + (tjaRead.baAmount[1] - tjaRead.baSum[1]) * 360 + tjaRead.baSum[0] * 5000 + tjaRead.baSum[1] * 6000)) < calculate.Score)
                {
                    int diff比率 = 4;
                    #region diff比率用
                    double n = (double)Diff比率.Value * 2, d = (double)Diff比率.Value * 10;
                    switch (n)
                    {
                        case 1:
                            diff比率 = 5;
                            break;
                        case 2:
                            diff比率 = 10;
                            break;
                        case 3:
                            diff比率 = 15;
                            break;
                        case 4:
                            diff比率 = 20;
                            break;
                        case 5:
                            diff比率 = 25;
                            break;
                        case 6:
                            diff比率 = 30;
                            break;
                        case 7:
                            diff比率 = 35;
                            break;
                        case 8:
                            diff比率 = 40;
                            break;
                        case 9:
                            diff比率 = 45;
                            break;
                        case 10:
                            diff比率 = 50;
                            break;
                        case 11:
                            diff比率 = 55;
                            break;
                        case 12:
                            diff比率 = 60;
                            break;
                        case 13:
                            diff比率 = 65;
                            break;
                        case 14:
                            diff比率 = 70;
                            break;
                        case 15:
                            diff比率 = 75;
                            break;
                        case 16:
                            diff比率 = 80;
                            break;
                        case 17:
                            diff比率 = 85;
                            break;
                        case 18:
                            diff比率 = 90;
                            break;
                        case 19:
                            diff比率 = 95;
                            break;
                        case 20:
                            diff比率 = 100;
                            break;

                        default:
                            diff比率 = (int)d;
                            break;

                    }
                    #endregion
                    calculate.diff用 += 1;
                    calculate.ScoreDiff = calculate.diff用 * 10 / diff比率;
                    if (calculate.diff用 % 10 == 0)
                        calculate.ScoreInit += 10;

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
                }

                INITM.Text = calculate.ScoreInit.ToString();
                DIFFM.Text = calculate.ScoreDiff.ToString();
                re.Text = ((calculate.calNdk[0] + calculate.calNdk[1] + calculate.calNdk[2] + calculate.calNdk[3] + calculate.calNdk[4] + calculate.calNtdk[0] + calculate.calNtdk[1] + calculate.calNtdk[2] + calculate.calNtdk[3] + calculate.calNtdk[4] + calculate.calGdk[0] + calculate.calGdk[1] + calculate.calGdk[2] + calculate.calGdk[3] + calculate.calGdk[4] + calculate.calGtdk[0] + calculate.calGtdk[1] + calculate.calGtdk[2] + calculate.calGtdk[3] + calculate.calGtdk[4]) + (calculate.ComboBonus * 10000 + (tjaRead.baAmount[0] - tjaRead.baSum[0]) * 300 + (tjaRead.baAmount[1] - tjaRead.baSum[1]) * 360 + tjaRead.baSum[0] * 5000 + tjaRead.baSum[1] * 6000)).ToString();
            }
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //リンク先に移動したことにする
            linkLabel1.LinkVisited = true;
            //ブラウザで開く
            System.Diagnostics.Process.Start("https://twitter.com/yume1610rein");
        }

        private void INITM_ValueChanged(object sender, EventArgs e)
        {
            scoreInit.ScoreInitValueChanged(this, tjaRead, calculate);
        }
        private void INITM_TextChanged(object sender, EventArgs e)
        {
            scoreInit.ScoreInitTextChanged(this, tjaRead, calculate);
        }

        private void DIFFM_ValueChanged(object sender, EventArgs e)
        {
            scoreDiff.ScoreDiffValueChanged(this, tjaRead, calculate);
        }
        private void DIFFM_TextChanged(object sender, EventArgs e)
        {
            scoreDiff.ScoreDiffTextChanged(this, tjaRead, calculate);
        }

        private void Diff比率_ValueChanged(object sender, EventArgs e)
        {
            scoreDiff.Diff比率Changed(this, tjaRead, calculate);
        }

　　}
    

}
