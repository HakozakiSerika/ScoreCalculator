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

namespace ScoreSum

    /*
     このコードを見ているあなたへ
     このクソコードは自分が無茶ぶりで「SCOREINITとSCOREDIFF簡単にもとめられねーかな～」
     と思い、見様見真似で製作中のものです。よって
     ・マジクソコード
     ・Formアプリの作り方教わってないから抜けあるよ！多分
     ・ミスを見つけたら「ああ～...こいつもまだまだだな」って感じで修正してくれるとありがたいです
     */





{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            t初期化();
            t初期化2();
            ofd.Dispose();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ofd.FileName = "TJA.tja";
            ofd.InitialDirectory = @"C:\";
            ofd.Filter = "TJAファイル(*.tja)|*.tja;";
            ofd.Title = "ファイルを開く";
            ofd.RestoreDirectory = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                StreamReader TJA = new StreamReader(ofd.OpenFile(), Encoding.GetEncoding("shift_jis"));

                while (TJA.EndOfStream == false)
                {
                    tja = TJA.ReadLine();

                    n1 = tja.IndexOf("#");
                    n2 = tja.IndexOf(":");
                    n3 = tja.IndexOf("//");
                    n4 = tja.IndexOf("#GOGOSTART");
                    n5 = tja.IndexOf("#GOGOEND");
                    n6 = tja.IndexOf("BALLOON:");
                    n7 = tja.IndexOf("LEVEL:");
                    n8 = tja.IndexOf("7");
                    n9 = tja.IndexOf("#START");
                    n10 = tja.IndexOf("#END");

                    str[2] += tja + Environment.NewLine;

                    if (n9 >= 0)
                    {
                        bStart = true;
                    }
                    else if (n10 >= 0)
                    {
                        bEnd = true;
                    }

                    if (n3 >= 0)
                    {
                        tjacom = tja.Remove(n3);
                    }

                    if (!bEnd)
                    {
                        if (n4 >= 0)
                        {
                            bGogo = true;
                            nGoGoCount++;
                        }
                        if (n5 >= 0)
                        {
                            bGogo = false;
                        }
                        if ((n1 == -1 && n2 == -1))
                        {

                            if (n3 >= 0)
                            {
                                str[0] += tjacom + Environment.NewLine;
                                scoreStr[0] += tjacom;
                            }
                            else
                            {
                                str[0] += tja + Environment.NewLine;
                                scoreStr[0] += tja;
                            }
                        }
                        if ((n1 == -1 && n2 == -1) || n4 >= 0 || n5 >= 0)
                        {
                            if (n3 >= 0)
                            {
                                scoreStr[1] += tjacom;
                            }
                            else
                            {
                                scoreStr[1] += tja;
                            }
                        }

                        if (n6 >= 0)
                        {
                            strballoon += tja;
                        }

                        if (n7 >= 0)
                        {
                            strlevel += tja;
                        }

                        if ((n1 == -1 && n2 == -1 && bGogo))
                        {
                            if (n3 >= 0)
                            {
                                str[1] += tjacom + Environment.NewLine;
                            }
                            else
                            {
                                str[1] += tja + Environment.NewLine;
                            }
                        }

                        if ((bStart && n1 == -1 && n2 == -1 && n8 >= 0))
                        {
                            if (n3 >= 0)
                            {
                                nballoonEnumCount += CountChar(tjacom, '7');
                            }
                            else
                            {
                                nballoonEnumCount += CountChar(tja, '7');
                            }
                            if (bGogo)
                            {
                                for (int i = nbEComp; i < nballoonEnumCount; i++)
                                {
                                    bbalgogo[i] = true;
                                }
                            }
                            else
                            {
                                for (int i = nbEComp; i < nballoonEnumCount; i++)
                                {
                                    bbalgogo[i] = false;
                                }
                            }
                            nbEComp = nballoonEnumCount;

                        }
                        /*
                        if ((n1 == -1 && n2 == -1 && n3 == -1 && bGogo == false) || (n4 >= 0) || (n5 >= 0))
                        {
                            str[1] += tja + Environment.NewLine;
                            if (n4 >= 0)
                            {
                                bGogo = true;
                            }
                        }
                        else if (bGogo = true && n5 >= 0)
                        {
                            bGogo = false;
                        }
                        if (n6 >= 0)
                        {
                            strb[1] += tja;
                        }
                        */
                    }
                }

                balloon = strballoon.Replace("BALLOON:", "");
                level = int.Parse(strlevel.Replace("LEVEL:", ""));
                if (balloon != "")
                    balAmount = strToInt(balloon);
                else
                {
                    balAmount[0] = 0;
                    balAmount[1] = 0;
                }

                if (balloon != "")
                    balloonCount = CountChar(strballoon, ',') + 1;
                else
                    balloonCount = 0;

                string[] gogo = new string[nGoGoCount];
                string[] normal = new string[nGoGoCount];

                for (int i = 0; i < nGoGoCount; i++)
                {
                    gogo[i] = null;
                    normal[i] = null;
                }




                //風船のゴーゴーor非ゴーゴーの結び付け
                if (balAmount != null)
                {
                    for (int i = 0; i < balloonCount; i++)
                    {
                        if (!bbalgogo[i])
                        {
                            baAmount[0] += balAmount[i];
                            baSum[0]++;
                        }
                        else
                        {
                            baAmount[1] += balAmount[i];
                            baSum[1]++;
                        }
                    }
                }

                string[] scoreStrEditBe = new string[7] { null, null, null, null, null, null, null};
                string[] scoreStrEditAf = new string[7] { null, null, null, null, null, null, null};

                scoreStrEditBe[0] = scoreStr[0].Replace(",", "");
                scoreStrEditBe[1] = scoreStrEditBe[0].Replace("0", "");
                scoreStrEditBe[2] = scoreStrEditBe[1].Replace("5", "");
                scoreStrEditBe[3] = scoreStrEditBe[2].Replace("6", "");
                scoreStrEditBe[4] = scoreStrEditBe[3].Replace("7", "");
                scoreStrEditBe[5] = scoreStrEditBe[4].Replace("8", "");
                scoreStrEditBe[6] = scoreStrEditBe[5].Replace("9", "");

                scoreStrEditAf[0] = scoreStr[1].Replace(",", "");
                scoreStrEditAf[1] = scoreStrEditAf[0].Replace("0", "");
                scoreStrEditAf[2] = scoreStrEditAf[1].Replace("5", "");
                scoreStrEditAf[3] = scoreStrEditAf[2].Replace("6", "");
                scoreStrEditAf[4] = scoreStrEditAf[3].Replace("7", "");
                scoreStrEditAf[5] = scoreStrEditAf[4].Replace("8", "");//譜面から「1234」以外を取り除く
                scoreStrEditAf[6] = scoreStrEditAf[5].Replace("9", "");

                string[] RemoveGogo = new string[nGoGoCount + 1];
                string RemovePause = null;
                int[] GogoPosS = new int[nGoGoCount]; //GOGOSTARTの位置記憶用
                int[] GogoPosE = new int[nGoGoCount]; //GOGOENDの位置記憶用

                for (int i = 0; i < nGoGoCount; i++)
                {
                    GogoPosS[i] = 0;
                    GogoPosE[i] = 0;
                }
                RemoveGogo[0] = scoreStrEditAf[6];


                for (int i = 0; i < nGoGoCount + 1; i++)
                {
                    if (i != nGoGoCount)
                    {
                        GogoPosS[i] = RemoveGogo[i].IndexOf("#GOGOSTART");
                        RemovePause = RemoveGogo[i].Remove(GogoPosS[i], 10);
                        GogoPosE[i] = RemovePause.IndexOf("#GOGOEND");
                        if (GogoPosE[i] == -1)
                        {
                            RemoveGogo[i + 1] = RemovePause;
                        }
                        else
                        {
                            RemoveGogo[i + 1] = RemovePause.Remove(GogoPosE[i], 8);
                        }
                    }
                }//ゴーゴーの位置確認、命令削除


                tja12[0] = RemoveGogo[nGoGoCount].Replace("3", "0");
                tja12[1] = tja12[0].Replace("4", "0");
                tja34[0] = RemoveGogo[nGoGoCount].Replace("1", "0");
                tja34[1] = tja34[0].Replace("2", "0");

                tja0[0] = tja12[1].Replace("1", "0");
                tja0[1] = tja0[0].Replace("2", "0");

                /*
                string[] dk = new string[5];//[コンボ帯]
                int[] dkg = new int[5];//[コンボ帯][GOGO？]
                string[] dkSum = new string[2];
                string[] tdk = new string[5];
                int[] tdkg = new int[5];
                string[] tdkSum = new string[2];
                string Copy;

                if (tja12[1] != null)
                {
                    if (tja12[1].Length >= 10)
                    {
                        dk[0] = tja12[1].Remove(9);
                        if (tja12[1].Length < 30)
                        {
                            dk[1] = tja12[1].Remove(0, 10);
                        }
                    }               
                    if (tja12[1].Length >= 30)
                    {
                        Copy = tja12[1].Remove(29);
                        dk[1] = Copy.Remove(0, 10);
                        if (tja12[1].Length < 50)
                        {
                            dk[2] = tja12[1].Remove(0, 30);
                        }
                    }                    
                    if (tja12[1].Length >= 50)
                    {
                        Copy = tja12[1].Remove(49);
                        dk[2] = Copy.Remove(0, 30);
                        if (tja12[1].Length < 100)
                        {
                            dk[3] = tja12[1].Remove(0, 50);
                        }
                    }                    
                    if (tja12[1].Length >= 100)
                    {
                        Copy = tja12[1].Remove(99);
                        dk[3] = Copy.Remove(0, 50);
                        dk[4] = tja12[1].Remove(0, 100);
                    }
                    
                }

                if (tja34[1] != null)
                {
                    if (tja34[1].Length >= 10)
                    {
                        tdk[0] = tja34[1].Remove(9);
                        if (tja34[1].Length < 30)
                        {
                            tdk[1] = tja34[1].Remove(0, 10);
                        }
                    }
                    if (tja34[1].Length >= 30)
                    {
                        Copy = tja34[1].Remove(29);
                        tdk[1] = Copy.Remove(0, 10);
                        if (tja34[1].Length < 50)
                        {
                            tdk[2] = tja34[1].Remove(0, 30);
                        }
                    }
                    if (tja34[1].Length >= 50)
                    {
                        Copy = tja34[1].Remove(49);
                        tdk[2] = Copy.Remove(0, 30);
                        if (tja34[1].Length < 100)
                        {
                            tdk[3] = tja34[1].Remove(0, 50);
                        }
                    }
                    if (tja34[1].Length >= 100)
                    {
                        Copy = tja34[1].Remove(99);
                        tdk[3] = Copy.Remove(0, 50);
                        tdk[4] = tja34[1].Remove(0, 100);
                    }

                }
                */
                string strG = null;
                string[] G = new string[nGoGoCount];
                string[] GOGO = new string[nGoGoCount];

                for (int i = 0; i < nGoGoCount; i++)
                {
                    G[i] = null;
                    GOGO[i] = null;
                }


                strG = RemoveGogo[nGoGoCount];

                GOGO[0] = tja0[1];


                for (int i = 0; i < nGoGoCount; i++)
                {
                    if (GogoPosE[i] == -1)
                    {
                        G[i] = strG.Substring(GogoPosS[i], RemoveGogo[nGoGoCount].Length - GogoPosS[i]);
                    }
                    else
                    {
                        G[i] = strG.Substring(GogoPosS[i], GogoPosE[i] - GogoPosS[i]);
                    }
                    if (i == 0)
                    {
                        GOGO[0] = tja0[1].Insert(GogoPosS[i], G[i]);
                    }
                    else
                    {
                        GOGO[i] = GOGO[i - 1].Insert(GogoPosS[i], G[i]);
                    }
                }

                if (tja0[1].Length < 10)
                {
                    GOGOCombo[0] = GOGO[nGoGoCount - 1].Substring(0, tja0[1].Length);
                    NORMALCombo[0] = strG.Substring(0, tja0[1].Length);
                }
                else if (tja0[1].Length < 30)
                {
                    GOGOCombo[0] = GOGO[nGoGoCount - 1].Substring(0, 9);
                    GOGOCombo[1] = GOGO[nGoGoCount - 1].Substring(9, tja0[0].Length - 9);
                    NORMALCombo[0] = strG.Substring(0, 9);
                    NORMALCombo[1] = strG.Substring(9, tja0[0].Length - 9);

                }
                else if (tja0[1].Length < 50)
                {
                    GOGOCombo[0] = GOGO[nGoGoCount - 1].Substring(0, 9);
                    GOGOCombo[1] = GOGO[nGoGoCount - 1].Substring(9, 20);
                    GOGOCombo[2] = GOGO[nGoGoCount - 1].Substring(29, tja0[0].Length - 29);
                    NORMALCombo[0] = strG.Substring(0, 9);
                    NORMALCombo[1] = strG.Substring(9, 20);
                    NORMALCombo[2] = strG.Substring(29, tja0[0].Length - 29);
                }
                else if (tja0[1].Length < 100)
                {
                    GOGOCombo[0] = GOGO[nGoGoCount - 1].Substring(0, 9);
                    GOGOCombo[1] = GOGO[nGoGoCount - 1].Substring(9, 20);
                    GOGOCombo[2] = GOGO[nGoGoCount - 1].Substring(29, 20);
                    GOGOCombo[3] = GOGO[nGoGoCount - 1].Substring(49, tja0[0].Length - 49);
                    NORMALCombo[0] = strG.Substring(0, 9);
                    NORMALCombo[1] = strG.Substring(9, 20);
                    NORMALCombo[2] = strG.Substring(29, 20);
                    NORMALCombo[3] = strG.Substring(49, tja0[0].Length - 49);
                }
                else
                {
                    GOGOCombo[0] = GOGO[nGoGoCount - 1].Substring(0, 9);
                    GOGOCombo[1] = GOGO[nGoGoCount - 1].Substring(9, 20);
                    GOGOCombo[2] = GOGO[nGoGoCount - 1].Substring(29, 20);
                    GOGOCombo[3] = GOGO[nGoGoCount - 1].Substring(49, 50);
                    GOGOCombo[4] = GOGO[nGoGoCount - 1].Substring(99, tja0[1].Length - 99);
                    NORMALCombo[0] = strG.Substring(0, 9);
                    NORMALCombo[1] = strG.Substring(9, 20);
                    NORMALCombo[2] = strG.Substring(29, 20);
                    NORMALCombo[3] = strG.Substring(49, 50);
                    NORMALCombo[4] = strG.Substring(99, tja0[1].Length - 99);
                }

                //GOGOCombo[0～4] = 0 0～9コンボ 1 10～29コンボ......4 100～コンボのゴーゴー音符のみ抜き出したもの

                //GOGO[nGoGoCount - 1] === ゴーゴーの譜面以外0にしたもの
                //こいつ...かなり使えるぞ...!!!!!!!!!!!!!!!!!!!!!!!!!!!

                for (int i = 0; i < 5; i++)
                {
                    Nd[i] = CountChar(NORMALCombo[i], '1');
                    Nk[i] = CountChar(NORMALCombo[i], '2');
                    Ntd[i] = CountChar(NORMALCombo[i], '3');
                    Ntk[i] = CountChar(NORMALCombo[i], '4');

                    Gd[i] = CountChar(GOGOCombo[i], '1');
                    Gk[i] = CountChar(GOGOCombo[i], '2');
                    Gtd[i] = CountChar(GOGOCombo[i], '3');
                    Gtk[i] = CountChar(GOGOCombo[i], '4');

                }


                for (int i = 0; i < 5; i++)
                {
                    gdk[i] = Gd[i] + Gk[i];
                    gtdk[i] = Gtd[i] + Gtk[i];

                    ndk[i] = Nd[i] + Nk[i] - gdk[i];
                    ntdk[i] = Ntd[i] + Ntk[i] - gtdk[i];
                }



                //ゴーゴーノーツ数

                /*
                 ノーツ周りの必要な情報
                 普通dkの1～9,10～29...100～の数
                 普通tdkの1～9,10～29...100～の数
                 ゴーゴーdkの1～9,10～29...100～の数
                 ゴーゴーtdkの1～9,10～29...100～の数

                 
                 
                 
                 */

                label3.Text = tja0[1].Length.ToString();
                label17.Text = level.ToString();
                ndk0.Text = ndk[0].ToString();
                ndk1.Text = ndk[1].ToString();
                ndk2.Text = ndk[2].ToString();
                ndk3.Text = ndk[3].ToString();
                ndk4.Text = ndk[4].ToString();
                ntdk0.Text = ntdk[0].ToString();
                ntdk1.Text = ntdk[1].ToString();
                ntdk2.Text = ntdk[2].ToString();
                ntdk3.Text = ntdk[3].ToString();
                ntdk4.Text = ntdk[4].ToString();
                gdk0.Text = gdk[0].ToString();
                gdk1.Text = gdk[1].ToString();
                gdk2.Text = gdk[2].ToString();
                gdk3.Text = gdk[3].ToString();
                gdk4.Text = gdk[4].ToString();
                gtdk0.Text = gtdk[0].ToString();
                gtdk1.Text = gtdk[1].ToString();
                gtdk2.Text = gtdk[2].ToString();
                gtdk3.Text = gtdk[3].ToString();
                gtdk4.Text = gtdk[4].ToString();

                //計算
                if (!b)
                {
                    if (level <= 1)
                    {
                        Score = 700000;
                    }
                    else if (level <= 2)
                    {
                        Score = 750000;
                    }
                    else if (level <= 3)
                    {
                        Score = 800000;
                    }
                    else if (level <= 4)
                    {
                        Score = 850000;
                    }
                    else if (level <= 5)
                    {
                        Score = 900000;
                    }
                    else if (level <= 6)
                    {
                        Score = 950000;
                    }
                    else if (level <= 7)
                    {
                        Score = 1000000;
                    }
                    else if (level <= 8)
                    {
                        Score = 1050000;
                    }
                    else if (level <= 9)
                    {
                        Score = 1100000;
                    }
                    else if (level <= 10)
                    {
                        Score = 1200000;
                    }
                    else
                    {
                        Score = 1000000;
                    }

                    ScoreUD.Value = Score;
                    ComboBonus = tja0[1].Length / 100;






                    while (((calNdk[0] + calNdk[1] + calNdk[2] + calNdk[3] + calNdk[4] + calNtdk[0] + calNtdk[1] + calNtdk[2] + calNtdk[3] + calNtdk[4] + calGdk[0] + calGdk[1] + calGdk[2] + calGdk[3] + calGdk[4] + calGtdk[0] + calGtdk[1] + calGtdk[2] + calGtdk[3] + calGtdk[4]) + (ComboBonus * 10000 + (baAmount[0] - baSum[0]) * 300 + (baAmount[1] - baSum[1]) * 360 + baSum[0] * 5000 + baSum[1] * 6000)) < Score)
                    {
                        int n;
                        diff用 += 1;
                        ScoreDiff = diff用 / 4;
                        if (diff用 % 10 == 0)
                            ScoreInit += 10;

                        calNdk[0] = ndk[0] * (ScoreInit - ScoreInit % 10);
                        calNdk[1] = ndk[1] * ((ScoreInit - ScoreInit % 10) + (ScoreDiff - ScoreDiff % 10));
                        calNdk[2] = ndk[2] * ((ScoreInit - ScoreInit % 10) + (ScoreDiff * 2 - ScoreDiff * 2 % 10));
                        calNdk[3] = ndk[3] * ((ScoreInit - ScoreInit % 10) + (ScoreDiff * 4 - ScoreDiff * 4 % 10));
                        calNdk[4] = ndk[4] * ((ScoreInit - ScoreInit % 10) + (ScoreDiff * 8 - ScoreDiff * 8 % 10));
                        calNtdk[0] = ntdk[0] * 2 * (ScoreInit - ScoreInit % 10);
                        calNtdk[1] = ntdk[1] * 2 * ((ScoreInit - ScoreInit % 10) + (ScoreDiff - ScoreDiff % 10));
                        calNtdk[2] = ntdk[2] * 2 * ((ScoreInit - ScoreInit % 10) + (ScoreDiff * 2 - ScoreDiff * 2 % 10));
                        calNtdk[3] = ntdk[3] * 2 * ((ScoreInit - ScoreInit % 10) + (ScoreDiff * 4 - ScoreDiff * 4 % 10));
                        calNtdk[4] = ntdk[4] * 2 * ((ScoreInit - ScoreInit % 10) + (ScoreDiff * 8 - ScoreDiff * 8 % 10));

                        calGdk[0] = gdk[0] * (((ScoreInit - ScoreInit % 10) * 12 / 10) - (ScoreInit - (ScoreInit % 10) * 12 / 10) % 10);
                        calGdk[1] = gdk[1] * (((ScoreInit - ScoreInit % 10 + (ScoreDiff - ScoreDiff % 10)) * 12 / 10) - ((ScoreInit - ScoreInit % 10 + (ScoreDiff - ScoreDiff % 10)) * 12 / 10) % 10);
                        calGdk[2] = gdk[2] * (((ScoreInit - ScoreInit % 10 + (ScoreDiff * 2 - ScoreDiff * 2 % 10)) * 12 / 10) - ((ScoreInit - ScoreInit % 10 + (ScoreDiff * 2 - ScoreDiff * 2 % 10)) * 12 / 10) % 10);
                        calGdk[3] = gdk[3] * (((ScoreInit - ScoreInit % 10 + (ScoreDiff * 4 - ScoreDiff * 4 % 10)) * 12 / 10) - ((ScoreInit - ScoreInit % 10 + (ScoreDiff * 4 - ScoreDiff * 4 % 10)) * 12 / 10) % 10);
                        calGdk[4] = gdk[4] * (((ScoreInit - ScoreInit % 10 + (ScoreDiff * 8 - ScoreDiff * 8 % 10)) * 12 / 10) - ((ScoreInit - ScoreInit % 10 + (ScoreDiff * 8 - ScoreDiff * 8 % 10)) * 12 / 10) % 10);
                        calGtdk[0] = gtdk[0] * 2 * (((ScoreInit - ScoreInit % 10) * 12 / 10) - ((ScoreInit - ScoreInit % 10) * 12 / 10 % 10));
                        calGtdk[1] = gtdk[1] * 2 * (((ScoreInit - ScoreInit % 10 + (ScoreDiff - ScoreDiff % 10)) * 12 / 10) - (((ScoreInit - ScoreInit % 10 + (ScoreDiff - ScoreDiff % 10)) * 12 / 10) % 10));
                        calGtdk[2] = gtdk[2] * 2 * (((ScoreInit - ScoreInit % 10 + (ScoreDiff * 2 - ScoreDiff * 2 % 10)) * 12 / 10) - (((ScoreInit - ScoreInit % 10 + (ScoreDiff * 2 - ScoreDiff * 2 % 10)) * 12 / 10) % 10));
                        calGtdk[3] = gtdk[3] * 2 * (((ScoreInit - ScoreInit % 10 + (ScoreDiff * 4 - ScoreDiff * 4 % 10)) * 12 / 10) - (((ScoreInit - ScoreInit % 10 + (ScoreDiff * 4 - ScoreDiff * 4 % 10)) * 12 / 10) % 10));
                        calGtdk[4] = gtdk[4] * 2 * (((ScoreInit - ScoreInit % 10 + (ScoreDiff * 8 - ScoreDiff * 8 % 10)) * 12 / 10) - (((ScoreInit - ScoreInit % 10 + (ScoreDiff * 8 - ScoreDiff * 8 % 10)) * 12 / 10) % 10));


                    }
                    si.Text = ScoreInit.ToString();
                    sd.Text = ScoreDiff.ToString();
                    re.Text = ((calNdk[0] + calNdk[1] + calNdk[2] + calNdk[3] + calNdk[4] + calNtdk[0] + calNtdk[1] + calNtdk[2] + calNtdk[3] + calNtdk[4] + calGdk[0] + calGdk[1] + calGdk[2] + calGdk[3] + calGdk[4] + calGtdk[0] + calGtdk[1] + calGtdk[2] + calGtdk[3] + calGtdk[4]) + (ComboBonus * 10000 + (baAmount[0] - baSum[0]) * 300 + (baAmount[1] - baSum[1]) * 360 + baSum[0] * 5000 + baSum[1] * 6000)).ToString();
                    basum0.Text = baSum[0].ToString();
                    basum1.Text = baSum[1].ToString();
                    baamount0.Text = baAmount[0].ToString();
                    baamount1.Text = baAmount[1].ToString();


                    string s = null;
                    for (int j = 0; j < 5; j++)
                    {
                        if (ndk[j] != 0)
                            s += "calNdk[" + j.ToString() + "]=" + (calNdk[j]).ToString() + Environment.NewLine;
                        else
                            s += "calNdk[" + j.ToString() + "]=" + "0" + Environment.NewLine;
                        if (ntdk[j] != 0)
                            s += "calNtdk[" + j.ToString() + "]=" + (calNtdk[j]).ToString() + Environment.NewLine;
                        else
                            s += "calNtdk[" + j.ToString() + "]=" + "0" + Environment.NewLine;
                        if (gdk[j] != 0)
                            s += "calGdk[" + j.ToString() + "]=" + (calGdk[j]).ToString() + Environment.NewLine;
                        else
                            s += "calGdk[" + j.ToString() + "]=" + "0" + Environment.NewLine;
                        if (gtdk[j] != 0)
                            s += "calGtdk[" + j.ToString() + "]=" + (calGtdk[j]).ToString() + Environment.NewLine;
                        else
                            s += "calGtdk[" + j.ToString() + "]=" + "0" + Environment.NewLine;
                    }
                    textBox1.Text = str[2];
                    button1.Visible = false;
                    label1.Text = ofd.SafeFileName;
                    b = true;
                }

            }

        }





        public string GetBetweenStrings(string str1, string str2, string orgStr)
        {
            int orgLen = orgStr.Length;
            int str1Len = str1.Length;

            int str1Num = orgStr.IndexOf(str1);

            string s = "";

            try
            {
                s = orgStr.Remove(0, str1Num + str1Len);
                int str2Num = s.IndexOf(str2);
                s = s.Remove(str2Num);
            }
            catch (Exception)
            {
                return orgStr;
            }

            return s;
        }
        public static int CountChar(string s, char c)
        {
            return s.Length - s.Replace(c.ToString(), "").Length;
        }

        public static int[] strToInt(string str)
        {
            if (String.IsNullOrEmpty(str))
                return null;

            string[] strArray = str.Split(',');
            List<int> listIntArray;
            listIntArray = new List<int>();

            for (int n = 0; n < strArray.Length; n++)
            {
                int n1 = Convert.ToInt32(strArray[n]);
                listIntArray.Add(n1);
            }
            int[] nArray = new int[] { 1 };
            nArray = listIntArray.ToArray();

            return nArray;
        }
        public void t初期化()
        {
            tja = null;
            tjacom = null;
            str[0] = null;
            str[1] = null;
            nballoonEnumCount = 0;
            nbEComp = 0;
            for (int i = 0; i < 999; i++)
            {
                bbalgogo[i] = false;
            }
            strballoon = null;
            balloon = null;
            strlevel = null;
            level = 0;
            n1 = 0;
            n2 = 0;
            n3 = 0;
            n4 = 0;
            n5 = 0;
            n6 = 0;
            n7 = 0;
            n8 = 0;
            n9 = 0;
            n10 = 0;
            nGoGoCount = 0;
            balloonCount = 0;
            bGogo = false;
            bStart = false;
            bEnd = false;
            balAmount[0] = 0;
            balAmount[1] = 0;
            if (TJA != null)
            TJA.Dispose();

        }
        public void t初期化2()
        {
            for (int i = 0; i < 5; i++)
            {
                Nd[i] = 0;
                Nk[i] = 0;
                Ntd[i] = 0;
                Ntk[i] = 0;
                Gd[i] = 0;
                Gk[i] = 0;
                Gtd[i] = 0;
                Gtk[i] = 0;

                ndk[i] = 0;
                ntdk[i] = 0;
                gdk[i] = 0;
                gtdk[i] = 0;
            }
        }

        private void ScoreUD_ValueChanged(object sender, EventArgs e)
        {
            if (b)
            {
                Score = (int)ScoreUD.Value;

                for (int i = 0; i < 5; i++)
                {
                    calNdk[i] = 0;
                    calNtdk[i] = 0;
                    calGdk[i] = 0;
                    calGtdk[i] = 0;
                }

                ScoreInit = 0;
                ScoreDiff = 0;
                diff用 = 0;

                while (((calNdk[0] + calNdk[1] + calNdk[2] + calNdk[3] + calNdk[4] + calNtdk[0] + calNtdk[1] + calNtdk[2] + calNtdk[3] + calNtdk[4] + calGdk[0] + calGdk[1] + calGdk[2] + calGdk[3] + calGdk[4] + calGtdk[0] + calGtdk[1] + calGtdk[2] + calGtdk[3] + calGtdk[4]) + (ComboBonus * 10000 + (baAmount[0] - baSum[0]) * 300 + (baAmount[1] - baSum[1]) * 360 + baSum[0] * 5000 + baSum[1] * 6000)) < Score)
                {
                    diff用 += 1;
                    ScoreDiff = diff用 / 4;
                    if (diff用 % 10 == 0)
                        ScoreInit += 10;

                    calNdk[0] = ndk[0] * (ScoreInit - ScoreInit % 10);
                    calNdk[1] = ndk[1] * ((ScoreInit - ScoreInit % 10) + (ScoreDiff - ScoreDiff % 10));
                    calNdk[2] = ndk[2] * ((ScoreInit - ScoreInit % 10) + (ScoreDiff * 2 - ScoreDiff * 2 % 10));
                    calNdk[3] = ndk[3] * ((ScoreInit - ScoreInit % 10) + (ScoreDiff * 4 - ScoreDiff * 4 % 10));
                    calNdk[4] = ndk[4] * ((ScoreInit - ScoreInit % 10) + (ScoreDiff * 8 - ScoreDiff * 8 % 10));
                    calNtdk[0] = ntdk[0] * 2 * (ScoreInit - ScoreInit % 10);
                    calNtdk[1] = ntdk[1] * 2 * ((ScoreInit - ScoreInit % 10) + (ScoreDiff - ScoreDiff % 10));
                    calNtdk[2] = ntdk[2] * 2 * ((ScoreInit - ScoreInit % 10) + (ScoreDiff * 2 - ScoreDiff * 2 % 10));
                    calNtdk[3] = ntdk[3] * 2 * ((ScoreInit - ScoreInit % 10) + (ScoreDiff * 4 - ScoreDiff * 4 % 10));
                    calNtdk[4] = ntdk[4] * 2 * ((ScoreInit - ScoreInit % 10) + (ScoreDiff * 8 - ScoreDiff * 8 % 10));

                    calGdk[0] = gdk[0] * (((ScoreInit - ScoreInit % 10) * 12 / 10) - (ScoreInit - (ScoreInit % 10) * 12 / 10) % 10);
                    calGdk[1] = gdk[1] * (((ScoreInit - ScoreInit % 10 + (ScoreDiff - ScoreDiff % 10)) * 12 / 10) - ((ScoreInit - ScoreInit % 10 + (ScoreDiff - ScoreDiff % 10)) * 12 / 10) % 10);
                    calGdk[2] = gdk[2] * (((ScoreInit - ScoreInit % 10 + (ScoreDiff * 2 - ScoreDiff * 2 % 10)) * 12 / 10) - ((ScoreInit - ScoreInit % 10 + (ScoreDiff * 2 - ScoreDiff * 2 % 10)) * 12 / 10) % 10);
                    calGdk[3] = gdk[3] * (((ScoreInit - ScoreInit % 10 + (ScoreDiff * 4 - ScoreDiff * 4 % 10)) * 12 / 10) - ((ScoreInit - ScoreInit % 10 + (ScoreDiff * 4 - ScoreDiff * 4 % 10)) * 12 / 10) % 10);
                    calGdk[4] = gdk[4] * (((ScoreInit - ScoreInit % 10 + (ScoreDiff * 8 - ScoreDiff * 8 % 10)) * 12 / 10) - ((ScoreInit - ScoreInit % 10 + (ScoreDiff * 8 - ScoreDiff * 8 % 10)) * 12 / 10) % 10);
                    calGtdk[0] = gtdk[0] * 2 * (((ScoreInit - ScoreInit % 10) * 12 / 10) - ((ScoreInit - ScoreInit % 10) * 12 / 10 % 10));
                    calGtdk[1] = gtdk[1] * 2 * (((ScoreInit - ScoreInit % 10 + (ScoreDiff - ScoreDiff % 10)) * 12 / 10) - (((ScoreInit - ScoreInit % 10 + (ScoreDiff - ScoreDiff % 10)) * 12 / 10) % 10));
                    calGtdk[2] = gtdk[2] * 2 * (((ScoreInit - ScoreInit % 10 + (ScoreDiff * 2 - ScoreDiff * 2 % 10)) * 12 / 10) - (((ScoreInit - ScoreInit % 10 + (ScoreDiff * 2 - ScoreDiff * 2 % 10)) * 12 / 10) % 10));
                    calGtdk[3] = gtdk[3] * 2 * (((ScoreInit - ScoreInit % 10 + (ScoreDiff * 4 - ScoreDiff * 4 % 10)) * 12 / 10) - (((ScoreInit - ScoreInit % 10 + (ScoreDiff * 4 - ScoreDiff * 4 % 10)) * 12 / 10) % 10));
                    calGtdk[4] = gtdk[4] * 2 * (((ScoreInit - ScoreInit % 10 + (ScoreDiff * 8 - ScoreDiff * 8 % 10)) * 12 / 10) - (((ScoreInit - ScoreInit % 10 + (ScoreDiff * 8 - ScoreDiff * 8 % 10)) * 12 / 10) % 10));
                }

                si.Text = ScoreInit.ToString();
                sd.Text = ScoreDiff.ToString();
                re.Text = ((calNdk[0] + calNdk[1] + calNdk[2] + calNdk[3] + calNdk[4] + calNtdk[0] + calNtdk[1] + calNtdk[2] + calNtdk[3] + calNtdk[4] + calGdk[0] + calGdk[1] + calGdk[2] + calGdk[3] + calGdk[4] + calGtdk[0] + calGtdk[1] + calGtdk[2] + calGtdk[3] + calGtdk[4]) + (ComboBonus * 10000 + (baAmount[0] - baSum[0]) * 300 + (baAmount[1] - baSum[1]) * 360 + baSum[0] * 5000 + baSum[1] * 6000)).ToString();
                string s = null;
                for (int j = 0; j < 5; j++)
                {
                    if (ndk[j] != 0)
                        s += "calNdk[" + j.ToString() + "]=" + (calNdk[j]).ToString() + Environment.NewLine;
                    else
                        s += "calNdk[" + j.ToString() + "]=" + "0" + Environment.NewLine;
                    if (ntdk[j] != 0)
                        s += "calNtdk[" + j.ToString() + "]=" + (calNtdk[j]).ToString() + Environment.NewLine;
                    else
                        s += "calNtdk[" + j.ToString() + "]=" + "0" + Environment.NewLine;
                    if (gdk[j] != 0)
                        s += "calGdk[" + j.ToString() + "]=" + (calGdk[j]).ToString() + Environment.NewLine;
                    else
                        s += "calGdk[" + j.ToString() + "]=" + "0" + Environment.NewLine;
                    if (gtdk[j] != 0)
                        s += "calGtdk[" + j.ToString() + "]=" + (calGtdk[j]).ToString() + Environment.NewLine;
                    else
                        s += "calGtdk[" + j.ToString() + "]=" + "0" + Environment.NewLine;
                }
                //textBox1.Text = s;

            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //リンク先に移動したことにする
            linkLabel1.LinkVisited = true;
            //ブラウザで開く
            System.Diagnostics.Process.Start("https://twitter.com/yume1610rein");
        }

        private void INITM_TextChanged(object sender, EventArgs e)
        {
            int i = 0;
            bool b = int.TryParse(INITM.Text, out i);
            if (b)
            {
                ScoreInit = i;
                calNdk[0] = ndk[0] * (ScoreInit - ScoreInit % 10);
                calNdk[1] = ndk[1] * ((ScoreInit - ScoreInit % 10) + (ScoreDiff - ScoreDiff % 10));
                calNdk[2] = ndk[2] * ((ScoreInit - ScoreInit % 10) + (ScoreDiff * 2 - ScoreDiff * 2 % 10));
                calNdk[3] = ndk[3] * ((ScoreInit - ScoreInit % 10) + (ScoreDiff * 4 - ScoreDiff * 4 % 10));
                calNdk[4] = ndk[4] * ((ScoreInit - ScoreInit % 10) + (ScoreDiff * 8 - ScoreDiff * 8 % 10));
                calNtdk[0] = ntdk[0] * 2 * (ScoreInit - ScoreInit % 10);
                calNtdk[1] = ntdk[1] * 2 * ((ScoreInit - ScoreInit % 10) + (ScoreDiff - ScoreDiff % 10));
                calNtdk[2] = ntdk[2] * 2 * ((ScoreInit - ScoreInit % 10) + (ScoreDiff * 2 - ScoreDiff * 2 % 10));
                calNtdk[3] = ntdk[3] * 2 * ((ScoreInit - ScoreInit % 10) + (ScoreDiff * 4 - ScoreDiff * 4 % 10));
                calNtdk[4] = ntdk[4] * 2 * ((ScoreInit - ScoreInit % 10) + (ScoreDiff * 8 - ScoreDiff * 8 % 10));

                calGdk[0] = gdk[0] * (((ScoreInit - ScoreInit % 10) * 12 / 10) - (ScoreInit - (ScoreInit % 10) * 12 / 10) % 10);
                calGdk[1] = gdk[1] * (((ScoreInit - ScoreInit % 10 + (ScoreDiff - ScoreDiff % 10)) * 12 / 10) - ((ScoreInit - ScoreInit % 10 + (ScoreDiff - ScoreDiff % 10)) * 12 / 10) % 10);
                calGdk[2] = gdk[2] * (((ScoreInit - ScoreInit % 10 + (ScoreDiff * 2 - ScoreDiff * 2 % 10)) * 12 / 10) - ((ScoreInit - ScoreInit % 10 + (ScoreDiff * 2 - ScoreDiff * 2 % 10)) * 12 / 10) % 10);
                calGdk[3] = gdk[3] * (((ScoreInit - ScoreInit % 10 + (ScoreDiff * 4 - ScoreDiff * 4 % 10)) * 12 / 10) - ((ScoreInit - ScoreInit % 10 + (ScoreDiff * 4 - ScoreDiff * 4 % 10)) * 12 / 10) % 10);
                calGdk[4] = gdk[4] * (((ScoreInit - ScoreInit % 10 + (ScoreDiff * 8 - ScoreDiff * 8 % 10)) * 12 / 10) - ((ScoreInit - ScoreInit % 10 + (ScoreDiff * 8 - ScoreDiff * 8 % 10)) * 12 / 10) % 10);
                calGtdk[0] = gtdk[0] * 2 * (((ScoreInit - ScoreInit % 10) * 12 / 10) - ((ScoreInit - ScoreInit % 10) * 12 / 10 % 10));
                calGtdk[1] = gtdk[1] * 2 * (((ScoreInit - ScoreInit % 10 + (ScoreDiff - ScoreDiff % 10)) * 12 / 10) - (((ScoreInit - ScoreInit % 10 + (ScoreDiff - ScoreDiff % 10)) * 12 / 10) % 10));
                calGtdk[2] = gtdk[2] * 2 * (((ScoreInit - ScoreInit % 10 + (ScoreDiff * 2 - ScoreDiff * 2 % 10)) * 12 / 10) - (((ScoreInit - ScoreInit % 10 + (ScoreDiff * 2 - ScoreDiff * 2 % 10)) * 12 / 10) % 10));
                calGtdk[3] = gtdk[3] * 2 * (((ScoreInit - ScoreInit % 10 + (ScoreDiff * 4 - ScoreDiff * 4 % 10)) * 12 / 10) - (((ScoreInit - ScoreInit % 10 + (ScoreDiff * 4 - ScoreDiff * 4 % 10)) * 12 / 10) % 10));
                calGtdk[4] = gtdk[4] * 2 * (((ScoreInit - ScoreInit % 10 + (ScoreDiff * 8 - ScoreDiff * 8 % 10)) * 12 / 10) - (((ScoreInit - ScoreInit % 10 + (ScoreDiff * 8 - ScoreDiff * 8 % 10)) * 12 / 10) % 10));

                si.Text = ScoreInit.ToString();
                sd.Text = ScoreDiff.ToString();
                re.Text = ((calNdk[0] + calNdk[1] + calNdk[2] + calNdk[3] + calNdk[4] + calNtdk[0] + calNtdk[1] + calNtdk[2] + calNtdk[3] + calNtdk[4] + calGdk[0] + calGdk[1] + calGdk[2] + calGdk[3] + calGdk[4] + calGtdk[0] + calGtdk[1] + calGtdk[2] + calGtdk[3] + calGtdk[4]) + (ComboBonus * 10000 + (baAmount[0] - baSum[0]) * 300 + (baAmount[1] - baSum[1]) * 360 + baSum[0] * 5000 + baSum[1] * 6000)).ToString();

                string s = null;
                for (int j = 0; j < 5; j++)
                {
                    if (ndk[j] != 0)
                        s += "calNdk[" + j.ToString() + "]=" + (calNdk[j]).ToString() + Environment.NewLine;
                    else
                        s += "calNdk[" + j.ToString() + "]=" + "0" + Environment.NewLine;
                    if (ntdk[j] != 0)
                        s += "calNtdk[" + j.ToString() + "]=" + (calNtdk[j]).ToString() + Environment.NewLine;
                    else
                        s += "calNtdk[" + j.ToString() + "]=" + "0" + Environment.NewLine;
                    if (gdk[j] != 0)
                        s += "calGdk[" + j.ToString() + "]=" + (calGdk[j]).ToString() + Environment.NewLine;
                    else
                        s += "calGdk[" + j.ToString() + "]=" + "0" + Environment.NewLine;
                    if (gtdk[j] != 0)
                        s += "calGtdk[" + j.ToString() + "]=" + (calGtdk[j]).ToString() + Environment.NewLine;
                    else
                        s += "calGtdk[" + j.ToString() + "]=" + "0" + Environment.NewLine;

                }
                //textBox1.Text = s;

            }
        }
        private void DIFFM_TextChanged(object sender, EventArgs e)
        {
            int i = 0;
            bool b = int.TryParse(DIFFM.Text, out i);
            if (b)
            {
                ScoreDiff = i;

                calNdk[0] = ndk[0] * (ScoreInit - ScoreInit % 10);
                calNdk[1] = ndk[1] * ((ScoreInit - ScoreInit % 10) + (ScoreDiff - ScoreDiff % 10));
                calNdk[2] = ndk[2] * ((ScoreInit - ScoreInit % 10) + (ScoreDiff * 2 - ScoreDiff * 2 % 10));
                calNdk[3] = ndk[3] * ((ScoreInit - ScoreInit % 10) + (ScoreDiff * 4 - ScoreDiff * 4 % 10));
                calNdk[4] = ndk[4] * ((ScoreInit - ScoreInit % 10) + (ScoreDiff * 8 - ScoreDiff * 8 % 10));
                calNtdk[0] = ntdk[0] * 2 * (ScoreInit - ScoreInit % 10);
                calNtdk[1] = ntdk[1] * 2 * ((ScoreInit - ScoreInit % 10) + (ScoreDiff - ScoreDiff % 10));
                calNtdk[2] = ntdk[2] * 2 * ((ScoreInit - ScoreInit % 10) + (ScoreDiff * 2 - ScoreDiff * 2 % 10));
                calNtdk[3] = ntdk[3] * 2 * ((ScoreInit - ScoreInit % 10) + (ScoreDiff * 4 - ScoreDiff * 4 % 10));
                calNtdk[4] = ntdk[4] * 2 * ((ScoreInit - ScoreInit % 10) + (ScoreDiff * 8 - ScoreDiff * 8 % 10));

                calGdk[0] = gdk[0] * (((ScoreInit - ScoreInit % 10) * 12 / 10) - (ScoreInit - (ScoreInit % 10) * 12 / 10) % 10);
                calGdk[1] = gdk[1] * (((ScoreInit - ScoreInit % 10 + (ScoreDiff - ScoreDiff % 10)) * 12 / 10) - ((ScoreInit - ScoreInit % 10 + (ScoreDiff - ScoreDiff % 10)) * 12 / 10) % 10);
                calGdk[2] = gdk[2] * (((ScoreInit - ScoreInit % 10 + (ScoreDiff * 2 - ScoreDiff * 2 % 10)) * 12 / 10) - ((ScoreInit - ScoreInit % 10 + (ScoreDiff * 2 - ScoreDiff * 2 % 10)) * 12 / 10) % 10);
                calGdk[3] = gdk[3] * (((ScoreInit - ScoreInit % 10 + (ScoreDiff * 4 - ScoreDiff * 4 % 10)) * 12 / 10) - ((ScoreInit - ScoreInit % 10 + (ScoreDiff * 4 - ScoreDiff * 4 % 10)) * 12 / 10) % 10);
                calGdk[4] = gdk[4] * (((ScoreInit - ScoreInit % 10 + (ScoreDiff * 8 - ScoreDiff * 8 % 10)) * 12 / 10) - ((ScoreInit - ScoreInit % 10 + (ScoreDiff * 8 - ScoreDiff * 8 % 10)) * 12 / 10) % 10);
                calGtdk[0] = gtdk[0] * 2 * (((ScoreInit - ScoreInit % 10) * 12 / 10) - ((ScoreInit - ScoreInit % 10) * 12 / 10 % 10));
                calGtdk[1] = gtdk[1] * 2 * (((ScoreInit - ScoreInit % 10 + (ScoreDiff - ScoreDiff % 10)) * 12 / 10) - (((ScoreInit - ScoreInit % 10 + (ScoreDiff - ScoreDiff % 10)) * 12 / 10) % 10));
                calGtdk[2] = gtdk[2] * 2 * (((ScoreInit - ScoreInit % 10 + (ScoreDiff * 2 - ScoreDiff * 2 % 10)) * 12 / 10) - (((ScoreInit - ScoreInit % 10 + (ScoreDiff * 2 - ScoreDiff * 2 % 10)) * 12 / 10) % 10));
                calGtdk[3] = gtdk[3] * 2 * (((ScoreInit - ScoreInit % 10 + (ScoreDiff * 4 - ScoreDiff * 4 % 10)) * 12 / 10) - (((ScoreInit - ScoreInit % 10 + (ScoreDiff * 4 - ScoreDiff * 4 % 10)) * 12 / 10) % 10));
                calGtdk[4] = gtdk[4] * 2 * (((ScoreInit - ScoreInit % 10 + (ScoreDiff * 8 - ScoreDiff * 8 % 10)) * 12 / 10) - (((ScoreInit - ScoreInit % 10 + (ScoreDiff * 8 - ScoreDiff * 8 % 10)) * 12 / 10) % 10));


                si.Text = ScoreInit.ToString();
                sd.Text = ScoreDiff.ToString();
                re.Text = ((calNdk[0] + calNdk[1] + calNdk[2] + calNdk[3] + calNdk[4] + calNtdk[0] + calNtdk[1] + calNtdk[2] + calNtdk[3] + calNtdk[4] + calGdk[0] + calGdk[1] + calGdk[2] + calGdk[3] + calGdk[4] + calGtdk[0] + calGtdk[1] + calGtdk[2] + calGtdk[3] + calGtdk[4]) + (ComboBonus * 10000 + (baAmount[0] - baSum[0]) * 300 + (baAmount[1] - baSum[1]) * 360 + baSum[0] * 5000 + baSum[1] * 6000)).ToString();

                string s = null;
                for (int j = 0; j < 5; j++)
                {
                    if (ndk[j] != 0)
                        s += "calNdk[" + j.ToString() + "]=" + (calNdk[j]).ToString() + Environment.NewLine;
                    else
                        s += "calNdk[" + j.ToString() + "]=" + "0" + Environment.NewLine;
                    if (ntdk[j] != 0)
                        s += "calNtdk[" + j.ToString() + "]=" + (calNtdk[j]).ToString() + Environment.NewLine;
                    else
                        s += "calNtdk[" + j.ToString() + "]=" + "0" + Environment.NewLine;
                    if (gdk[j] != 0)
                        s += "calGdk[" + j.ToString() + "]=" + (calGdk[j]).ToString() + Environment.NewLine;
                    else
                        s += "calGdk[" + j.ToString() + "]=" + "0" + Environment.NewLine;
                    if (gtdk[j] != 0)
                        s += "calGtdk[" + j.ToString() + "]=" + (calGtdk[j]).ToString() + Environment.NewLine;
                    else
                        s += "calGtdk[" + j.ToString() + "]=" + "0" + Environment.NewLine;

                }
                //textBox1.Text = s;

            }
        }

        #region 定義
        private string tja = null, tjacom = null; //読み込み用変数 tjacomはコメントがついている行の処理用
        private string[] str = new string[3] { null, null, null}; //読み取った文字列を保存する用 0:総ノーツ用 1:GOGO判別用 2:表示用
        private string[] scoreStr = new string[2] { null, null }; //0や5～9がない「ノーツのみ」のものを作る用
        private int nballoonEnumCount = 0, nbEComp = 0; //これなんだっけ...
        private bool[] bbalgogo = new bool[999]; //ふうせんがゴーゴーか判別するもの。これ一番どうにかしたい
        private string strballoon, balloon, strlevel; //ヘッダ情報抜き出し用。
        private int n1, n2, n3, n4, n5, n6, n7, n8, n9, n10, nGoGoCount; //n1～10:その行に対象の文字があるかどうか判別するためのもの nGogoCount：ゴーゴーの回数を数える
        private int balloonCount, level; //風船の数を数える。
        private bool bGogo, bStart, bEnd;//tjaの行がゴーゴーかどうか、#START～#END内かどうか。

        private string[] tja12 = new string[2] { null, null };//1,2のみの譜面。3,4は0に置き換え
        private string[] tja34 = new string[2] { null, null };//3,4のみの譜面。1,2は0に置き換え
        private string[] tja0 = new string[2] { null, null };//最大コンボ数の数だけ0が出力される文字列。これ使えないかなあ...

        private string[] NORMALCombo = new string[5] { null, null, null, null, null };//譜面解析用
        private string[] GOGOCombo = new string[5] { null, null, null, null, null };

        private int[] Nd = new int[5] { 0, 0, 0, 0, 0 };//N:非ゴーゴー G:ゴーゴー
        private int[] Nk = new int[5] { 0, 0, 0, 0, 0 };//d:ドン k:カッ t:特音符

        private int[] Ntd = new int[5] { 0, 0, 0, 0, 0 };

        private int[] Ntk = new int[5] { 0, 0, 0, 0, 0 };
        private int[] Gd = new int[5] { 0, 0, 0, 0, 0 };
        private int[] Gk = new int[5] { 0, 0, 0, 0, 0 };
        private int[] Gtd = new int[5] { 0, 0, 0, 0, 0 };
        private int[] Gtk = new int[5] { 0, 0, 0, 0, 0 };

        private int[] ndk = new int[5] { 0, 0, 0, 0, 0 }; //普通小音符合計
        private int[] ntdk = new int[5] { 0, 0, 0, 0, 0 };//普通大音符合計
        private int[] gdk = new int[5] { 0, 0, 0, 0, 0 };//ゴーゴー小音符合計
        private int[] gtdk = new int[5] { 0, 0, 0, 0, 0 };//ゴーゴー大音符合計

        private int[] baAmount = new int[2] { 0, 0 };//風船打数
        private int[] baSum = new int[2] { 0, 0 };//風船個数

        private int ScoreInit = 0, ScoreDiff = 0, Score = 0, ComboBonus = 0; //スコア計算用
        private bool b = false;
        private int diff用 = 0;
        private int[] calNdk = new int[5];//端数処理しないと計算結果が極端に低くなってしまう...
        private int[] calNtdk = new int[5];
        private int[] calGdk = new int[5];
        private int[] calGtdk = new int[5];




        OpenFileDialog ofd = new OpenFileDialog();
        StreamReader TJA = null;

        int[] balAmount = new int[2];

        #endregion
    }
}
