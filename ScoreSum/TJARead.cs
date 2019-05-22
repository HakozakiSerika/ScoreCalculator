using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;


namespace ScoreCalculator
{
    class TJARead
    {
        public void TJAReader()
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

                string[] scoreStrEditBe = new string[7] { null, null, null, null, null, null, null };
                string[] scoreStrEditAf = new string[7] { null, null, null, null, null, null, null };

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

        public OpenFileDialog ofd = new OpenFileDialog();
        public StreamReader TJA = null;

        public string tja = null, tjacom = null; //読み込み用変数 tjacomはコメントがついている行の処理用
        public string[] str = new string[3] { null, null, null }; //読み取った文字列を保存する用 0:総ノーツ用 1:GOGO判別用 2:表示用
        public string[] scoreStr = new string[2] { null, null }; //0や5～9がない「ノーツのみ」のものを作る用
        public int nballoonEnumCount = 0, nbEComp = 0; //これなんだっけ...
        public bool[] bbalgogo = new bool[999]; //ふうせんがゴーゴーか判別するもの。これ一番どうにかしたい
        public string strballoon, balloon, strlevel; //ヘッダ情報抜き出し用。
        public int n1, n2, n3, n4, n5, n6, n7, n8, n9, n10, nGoGoCount; //n1～10:その行に対象の文字があるかどうか判別するためのもの nGogoCount：ゴーゴーの回数を数える
        public int balloonCount, level; //風船の数を数える。
        public bool bGogo, bStart, bEnd;//tjaの行がゴーゴーかどうか、#START～#END内かどうか。

        public string[] tja12 = new string[2] { null, null };//1,2のみの譜面。3,4は0に置き換え
        public string[] tja34 = new string[2] { null, null };//3,4のみの譜面。1,2は0に置き換え
        public string[] tja0 = new string[2] { null, null };//最大コンボ数の数だけ0が出力される文字列。これ使えないかなあ...

        public string[] NORMALCombo = new string[5] { null, null, null, null, null };//譜面解析用
        public string[] GOGOCombo = new string[5] { null, null, null, null, null };

        public int[] Nd = new int[5] { 0, 0, 0, 0, 0 };//N:非ゴーゴー G:ゴーゴー
        public int[] Nk = new int[5] { 0, 0, 0, 0, 0 };//d:ドン k:カッ t:特音符
        public int[] Ntd = new int[5] { 0, 0, 0, 0, 0 };
        public int[] Ntk = new int[5] { 0, 0, 0, 0, 0 };
        public int[] Gd = new int[5] { 0, 0, 0, 0, 0 };
        public int[] Gk = new int[5] { 0, 0, 0, 0, 0 };
        public int[] Gtd = new int[5] { 0, 0, 0, 0, 0 };
        public int[] Gtk = new int[5] { 0, 0, 0, 0, 0 };

        public int[] ndk = new int[5] { 0, 0, 0, 0, 0 }; //普通小音符合計
        public int[] ntdk = new int[5] { 0, 0, 0, 0, 0 };//普通大音符合計
        public int[] gdk = new int[5] { 0, 0, 0, 0, 0 };//ゴーゴー小音符合計
        public int[] gtdk = new int[5] { 0, 0, 0, 0, 0 };//ゴーゴー大音符合計

        public int[] balAmount = new int[2];
        public int[] baAmount = new int[2] { 0, 0 };//風船打数
        public int[] baSum = new int[2] { 0, 0 };//風船個数


    }
}
    