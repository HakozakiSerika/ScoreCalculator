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
        private string tja, tjacom;
        private string[] str = new string[2] { null, null }; //0:総ノーツ用 1:GOGO判別用
        private string[] scoreStr = new string[2] {null,null };
        private string strb = null;
        private int nballoonEnumCount = 0, nbEComp = 0;
        private bool[] bbalgogo = new bool[999];
        private string strballoon, balloon, strlevel;
        private int n1, n2, n3, n4, n5, n6, n7, n8, n9, n10, nGoGoCount;

        private int balloonCount, level;
        private bool bGogo, bStart, bEnd;
        private string[] tja12 = new string[2] { null, null };//1,2のみの譜面。3,4は0に置き換え
        private string[] tja34 = new string[2] { null, null };//3,4のみの譜面。1,2は0に置き換え
        private string[] tja0 = new string[2] { null, null };//最大コンボ数の数だけ0が出力される文字列。これ使えないかなあ...
        private int[] Nd = new int[5] { 0, 0, 0, 0, 0 };
        private int[] Nk = new int[5] { 0, 0, 0, 0, 0 };
        private int[] Ntd = new int[5] { 0, 0, 0, 0, 0 };
        private int[] Ntk = new int[5] { 0, 0, 0, 0, 0 };



        private int[] Gd = new int[5] { 0, 0, 0, 0, 0 };
        private int[] Gk = new int[5] { 0, 0, 0, 0, 0 };
        private int[] Gtd = new int[5] { 0, 0, 0, 0, 0 };
        private int[] Gtk = new int[5] { 0, 0, 0, 0, 0 };
        private int[] ndk = new int[5] { 0, 0, 0, 0, 0 }; //普通小音符
        private int[] ntdk = new int[5] { 0, 0, 0, 0, 0 };//普通大音符

        private int[] gdk = new int[5] { 0, 0, 0, 0, 0 };//ゴーゴー小音符
        private int[] gtdk = new int[5] { 0, 0, 0, 0, 0 };//ゴーゴー大音符
        private int[] baSum = new int[2] { 0, 0 };
        private int[] baAmount = new int[2] { 0, 0 };
        private string[] NORMALCombo = new string[5] { null, null, null, null, null };
        private string[] GOGOCombo = new string[5] { null, null, null, null, null };
        private int ScoreInit = 0, ScoreDiff = 0 ,Score = 0, ComboBonus = 0, ScoreCor = 0;
        private bool b = false;




        OpenFileDialog ofd = new OpenFileDialog();
        StreamReader TJA = null;

        int[] balAmount = new int[2];
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
                                strb += tjacom + Environment.NewLine;
                            }
                            else
                            {
                                strb += tja + Environment.NewLine;
                            }
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
                
                balloonCount = CountChar(strballoon, ',') + 1;
                balloon = strballoon.Replace("BALLOON:", "");
                level = int.Parse(strlevel.Replace("LEVEL:", ""));
                if (balloon != "")
                    balAmount = strToInt(balloon);
                else
                {
                    balAmount[0] = 0;
                    balAmount[1] = 0;
                }

                //balAmount = 
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
                            baSum[0] += balAmount[i];
                            baAmount[0]++;
                        }
                        else
                        {
                            baSum[1] += balAmount[i];
                            baAmount[1]++;
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
                    ScoreInit = (Score - ComboBonus * 10000 - baSum[0] * 5000 - baSum[1] * 6000 - baAmount[0] * 300 - baAmount[1] * 300) /
                    (ndk[0] + ndk[1] * 5 / 4 + ndk[2] * 3 / 2 + ndk[3] * 2 + ndk[4] * 3 + ntdk[0] * 2 + ntdk[1] * 2 * 5 / 4 + ntdk[2] * 2 * 3 / 2 + ntdk[3] * 2 * 2 + ntdk[4] * 2 * 3 +
                    gdk[0] * 12 / 10 + gdk[1] * 12 / 10 * 5 / 4 + gdk[2] * 12 / 10 * 3 / 2 + gdk[3] * 12 / 10 * 2 + gdk[4] * 12 / 10 * 3 + gtdk[0] * 12 / 10 * 2 + gtdk[1] * 12 / 10 * 2 * 5 / 4 + gtdk[2] * 12 / 10 * 2 * 3 / 2 + gtdk[3] * 12 / 10 * 2 * 2 + gtdk[4] * 12 / 10 * 2 * 3);

                    ScoreDiff = ScoreInit / 4;

                    si.Text = ScoreInit.ToString();
                    sd.Text = ScoreDiff.ToString();
                    re.Text = ((ndk[0] * ScoreInit + ndk[1] * ScoreInit + ndk[1] * ScoreDiff + ndk[2] * ScoreInit + ndk[2] * ScoreDiff * 2 + ndk[3] * ScoreInit + ndk[3] * ScoreDiff * 4 + ndk[4] * ScoreInit + ndk[4] * ScoreDiff * 8 + ntdk[0] * ScoreInit * 2 + (ntdk[1] * ScoreInit + ntdk[1] * ScoreDiff) * 2 + (ntdk[2] * ScoreInit + ntdk[2] * ScoreDiff * 2) * 2 + (ntdk[3] * ScoreInit + ntdk[3] * ScoreDiff * 4) * 2 + (ntdk[4] * ScoreInit + ntdk[4] * ScoreDiff * 8) * 2 +
                        gdk[0] * ScoreInit * 12 / 10 + (gdk[1] * ScoreInit + gdk[1] * ScoreDiff) * 12 / 10 + (gdk[2] * ScoreInit + gdk[2] * ScoreDiff * 2) * 12 / 10 + (gdk[3] * ScoreInit + gdk[3] * ScoreDiff * 4) * 12 / 10 + (gdk[4] * ScoreInit + gdk[4] * ScoreDiff * 8) * 12 / 10 + (gtdk[0] * ScoreInit) * 2 * 12 / 10 + (gtdk[1] * ScoreInit + gtdk[1] * ScoreDiff) * 2 * 12 / 10 + (gtdk[2] * ScoreInit + gtdk[2] * ScoreDiff * 2) * 2 * 12 / 10 + (gtdk[3] * ScoreInit + gtdk[3] * ScoreDiff * 4) * 2 * 12 / 10 + (gtdk[4] * ScoreInit + gtdk[4] * ScoreDiff * 8) * 2 * 12 / 10) + (ComboBonus * 10000 + baSum[0] * 5000 + baSum[1] * 6000 + baAmount[0] * 300 + baAmount[1] * 300)).ToString();
                    textBox1.Text = ScoreUD.Value.ToString();

                    button1.Visible = false;
                    label1.Text = ofd.FileName;
                    b = true;
                }

                int[] n = new int[20];






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
            strb = null;
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

                ScoreInit = (Score - ComboBonus * 10000 - baSum[0] * 5000 - baSum[1] * 6000 - baAmount[0] * 300 - baAmount[1] * 300) /
                    (ndk[0] + ndk[1] * 5 / 4 + ndk[2] * 3 / 2 + ndk[3] * 2 + ndk[4] * 3 + ntdk[0] * 2 + ntdk[1] * 2 * 5 / 4 + ntdk[2] * 2 * 3 / 2 + ntdk[3] * 2 * 2 + ntdk[4] * 2 * 3 +
                    gdk[0] * 12 / 10 + gdk[1] * 12 / 10 * 5 / 4 + gdk[2] * 12 / 10 * 3 / 2 + gdk[3] * 12 / 10 * 2 + gdk[4] * 12 / 10 * 3 + gtdk[0] * 12 / 10 * 2 + gtdk[1] * 12 / 10 * 2 * 5 / 4 + gtdk[2] * 12 / 10 * 2 * 3 / 2 + gtdk[3] * 12 / 10 * 2 * 2 + gtdk[4] * 12 / 10 * 2 * 3);

                ScoreDiff = ScoreInit / 4;

                si.Text = ScoreInit.ToString();
                sd.Text = ScoreDiff.ToString();
                re.Text = ((ndk[0] * ScoreInit + ndk[1] * ScoreInit + ndk[1] * ScoreDiff + ndk[2] * ScoreInit + ndk[2] * ScoreDiff * 2 + ndk[3] * ScoreInit + ndk[3] * ScoreDiff * 4 + ndk[4] * ScoreInit + ndk[4] * ScoreDiff * 8 + ntdk[0] * ScoreInit * 2 + (ntdk[1] * ScoreInit + ntdk[1] * ScoreDiff) * 2 + (ntdk[2] * ScoreInit + ntdk[2] * ScoreDiff * 2) * 2 + (ntdk[3] * ScoreInit + ntdk[3] * ScoreDiff * 4) * 2 + (ntdk[4] * ScoreInit + ntdk[4] * ScoreDiff * 8) * 2 +
                    gdk[0] * ScoreInit * 12 / 10 + (gdk[1] * ScoreInit + gdk[1] * ScoreDiff) * 12 / 10 + (gdk[2] * ScoreInit + gdk[2] * ScoreDiff * 2) * 12 / 10 + (gdk[3] * ScoreInit + gdk[3] * ScoreDiff * 4) * 12 / 10 + (gdk[4] * ScoreInit + gdk[4] * ScoreDiff * 8) * 12 / 10 + (gtdk[0] * ScoreInit) * 2 * 12 / 10 + (gtdk[1] * ScoreInit + gtdk[1] * ScoreDiff) * 2 * 12 / 10 + (gtdk[2] * ScoreInit + gtdk[2] * ScoreDiff * 2) * 2 * 12 / 10 + (gtdk[3] * ScoreInit + gtdk[3] * ScoreDiff * 4) * 2 * 12 / 10 + (gtdk[4] * ScoreInit + gtdk[4] * ScoreDiff * 8) * 2 * 12 / 10) + (ComboBonus * 10000 + baSum[0] * 5000 + baSum[1] * 6000 + baAmount[0] * 300 + baAmount[1] * 300)).ToString();
                textBox1.Text = ScoreUD.Value.ToString();

            }
        }

    }
}
