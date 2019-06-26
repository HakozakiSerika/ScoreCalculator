using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ScoreCalculator
{
    /// <summary>
    /// 
    /// </summary>
    class SelectedCourse
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public SelectedCourse()
        {

        }

        public void Selected(int courseNumber, TJARead tjaRead)
        {
            ResetValue(tjaRead);
            nSelectCourse = courseNumber;
            TJA = new StringReader(tjaRead.str[2]);
            //ここに各種情報を書き込みなおしてcalにわたす
            //Course変更のひつような値の初期化をするメソッドを作る(のちほど
            while (TJA.Peek() > -1)
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
                n11 = tja.IndexOf("SCOREINIT:");
                n12 = tja.IndexOf("SCOREDIFF:");
                n13 = tja.IndexOf("COURSE:");
                n14 = tja.IndexOf("9");
                n15 = tja.IndexOf("8");


                str[2] += tja + Environment.NewLine;
                if (n13 >= 0)
                {
                    string sCourseNumber = tja.Substring(n13 + 7);

                    switch (sCourseNumber)
                    {
                        case "Easy":
                        case "easy":
                        case "0":
                            nCourseNumber = 0;
                            break;
                        case "Normal":
                        case "normal":
                        case "1":
                            nCourseNumber = 1;
                            break;
                        case "Hard":
                        case "hard":
                        case "2":
                            nCourseNumber = 2;
                            break;
                        case "Oni":
                        case "oni":
                        case "3":
                            nCourseNumber = 3;
                            break;
                        case "Edit":
                        case "edit":
                        case "4":
                            nCourseNumber = 4;
                            break;
                    }

                }

                if (nCourseNumber != courseNumber)
                {
                    continue;
                }

                //#STARTと#ENDの間の文字列を取得する用
                if (n9 >= 0)
                {
                    bStart = true;
                }
                else if (n10 >= 0)
                {
                    bEnd = true;
                }

                //コメントがある場合は取り除いたものを別の変数に入れる
                if (n3 >= 0)
                {
                    tjacom = tja.Remove(n3);
                }

                //SCOREINIT,DIFFの文字列保存
                if (n11 >= 0)
                {
                    strScoreInit = tja;
                }
                if (n12 >= 0)
                {
                    strScoreDiff = tja;
                }
                if (!bEnd && nSelectCourse == nCourseNumber)
                {
                    //GOGOかどうか
                    if (n4 >= 0)
                    {
                        bGogo = true;
                        bGogoExist = true;
                        nGoGoCount++;
                    }
                    if (n5 >= 0)
                    {
                        bGogo = false;
                    }

                    //命令やヘッダがある行は文字列に追加しない
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

                    //GOGOのみの文字列を作るため#GOGOSTARTと#GOGOENDを残した文字列も作成しておく。
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

                    //風船用文字列
                    if (n6 >= 0)
                    {
                        strballoon += tja;
                    }

                    //レベル用文字列
                    if (n7 >= 0)
                    {
                        strlevel += tja;
                    }

                    //GOGO用文字列に文字を入れる
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

                    //風船の個数を数える。(77777778などの記述には未対応)
                    if ((bStart && n1 == -1 && n2 == -1 && n8 >= 0))
                    {
                        if (n3 >= 0)
                        {
                            nballoonEnumCount += tjaRead.CountChar(tjacom, '7');
                        }
                        else
                        {
                            nballoonEnumCount += tjaRead.CountChar(tja, '7');
                        }

                        //ゴーゴーで得点が違うのでこちらも分ける。
                        if (bGogo)
                        {
                            for (int i = nbEComp; i < nballoonEnumCount; i++)
                            {
                                bbalgogo.Add(true);
                            }
                        }
                        else
                        {
                            for (int i = nbEComp; i < nballoonEnumCount; i++)
                            {
                                bbalgogo.Add(false);
                            }
                        }
                        nbEComp = nballoonEnumCount;
                    }

                    if ((bStart && n1 == -1 && n2 == -1 && n14 >= 0) && !bRoll)
                    {
                        if (n3 >= 0)
                        {
                            nballoonEnumCount += 1;
                        }
                        else
                        {
                            nballoonEnumCount += 1;
                        }

                        //ゴーゴーで得点が違うのでこちらも分ける。
                        if (bGogo)
                        {
                            for (int i = nbEComp; i < nballoonEnumCount; i++)
                            {
                                bbalgogo.Add(true);
                            }
                        }
                        else
                        {
                            for (int i = nbEComp; i < nballoonEnumCount; i++)
                            {
                                bbalgogo.Add(false);
                            }
                        }
                        nbEComp = nballoonEnumCount;
                        bKusudamaExist = true;
                        bRoll = true;
                    }

                    if (n15 >= 0 && bRoll)
                    {
                        bRoll = false;
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
            //ヘッダからいらない文字を抜く
            balloon = strballoon?.Replace("BALLOON:", "");
            level = int.Parse(strlevel?.Replace("LEVEL:", ""));

            if (balloon != null && balloon.Length > 0)
            {
                if (balloon.Substring(balloon.Length - 1) == ",") //10,50,30, ←こんな感じに書かれてた時に後ろのカンマを削除する
                {
                    balloon = balloon.Remove(balloon.Length - 1);
                }
            }


            //風船の個数を求める
            if (!string.IsNullOrWhiteSpace(balloon))
                balloonCount = tjaRead.CountChar(balloon, ',') + 1;
            else
                balloonCount = 0;

            //風船打数を求める
            if (!string.IsNullOrWhiteSpace(balloon))
            {
                for (int i = 0; i < balloonCount; i++)
                {
                    balValue.Add(tjaRead.strToInt(balloon)[i]);
                }
            }
            else
            {
                baAmount[0] = 0;
                baAmount[1] = 0;
            }


            if (bGogoExist)
            {
                string[] gogo = new string[nGoGoCount];
                string[] normal = new string[nGoGoCount];

                for (int i = 0; i < nGoGoCount; i++)
                {
                    gogo[i] = null;
                    normal[i] = null;
                }
            }



            //風船のゴーゴーor非ゴーゴーの結び付け
            if (balValue != null)
            {
                for (int i = 0; i < balloonCount; i++)
                {
                    if (!bbalgogo[i])
                    {
                        baAmount[0] += balValue[i];
                        baSum[0]++;
                    }
                    else
                    {
                        baAmount[1] += balValue[i];
                        baSum[1]++;
                    }
                }
            }


            string[] strGOGOTJA = new string[8] { null, null, null, null, null, null, null, null };

            strGOGOTJA[0] = scoreStr[1].Replace(",", "");
            strGOGOTJA[1] = strGOGOTJA[0].Replace("0", "");
            strGOGOTJA[2] = strGOGOTJA[1].Replace("5", "");
            strGOGOTJA[3] = strGOGOTJA[2].Replace("6", "");
            strGOGOTJA[4] = strGOGOTJA[3].Replace("7", "");
            strGOGOTJA[5] = strGOGOTJA[4].Replace("8", "");
            strGOGOTJA[6] = strGOGOTJA[5].Replace("9", "");//譜面から「1234」以外を取り除く

            if (bGogoExist)
            {
                string[] RemoveGogo = new string[nGoGoCount + 1];
                string RemovePause = null;
                int[] GogoPosS = new int[nGoGoCount]; //GOGOSTARTの位置記憶用
                int[] GogoPosE = new int[nGoGoCount]; //GOGOENDの位置記憶用

                for (int i = 0; i < nGoGoCount; i++)
                {
                    GogoPosS[i] = 0;
                    GogoPosE[i] = 0;
                }
                RemoveGogo[0] = strGOGOTJA[6];


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

                for (int i = 0; i < 2; i++)
                {
                    tja12[i] = null;
                    tja34[i] = null;
                    tja0[i] = null;
                }

                tja12[0] = RemoveGogo[nGoGoCount].Replace("3", "0");
                tja12[1] = tja12[0].Replace("4", "0");//1,2のみの譜面
                tja34[0] = RemoveGogo[nGoGoCount].Replace("1", "0");
                tja34[1] = tja34[0].Replace("2", "0");//3,4のみの譜面

                tja0[0] = tja12[1].Replace("1", "0");
                tja0[1] = tja0[0].Replace("2", "0");//すべて0の譜面。総音符数用(別に用意する必要あったかなこれ...)

                nComboBonus = tja0[1].Replace(" ", "").Length;


                string strG = null;//GOGOのみの譜面

                string[] G = new string[nGoGoCount];
                string[] GOGO = new string[nGoGoCount];

                for (int i = 0; i < nGoGoCount; i++)
                {
                    G[i] = null;
                    GOGO[i] = null;
                }


                strG = RemoveGogo[nGoGoCount];

                if (GOGO[0] != null)
                    GOGO[0] = tja0[1];

                //ゴーゴーの位置を計測。コンボごとのノーツ数計算に使われる
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

                //コンボごとのノーツ取得。
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
                    NORMALCombo[1] = strG.Substring(9, tja0[1].Length - 9);

                }
                else if (tja0[1].Length < 50)
                {
                    GOGOCombo[0] = GOGO[nGoGoCount - 1].Substring(0, 9);
                    GOGOCombo[1] = GOGO[nGoGoCount - 1].Substring(9, 20);
                    GOGOCombo[2] = GOGO[nGoGoCount - 1].Substring(29, tja0[0].Length - 29);
                    NORMALCombo[0] = strG.Substring(0, 9);
                    NORMALCombo[1] = strG.Substring(9, 20);
                    NORMALCombo[2] = strG.Substring(29, tja0[1].Length - 29);
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
                    NORMALCombo[3] = strG.Substring(49, tja0[1].Length - 49);
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

                //コンボごとのノーツ数計算
                for (int i = 0; i < 5; i++)
                {
                    Nd[i] = tjaRead.CountChar(NORMALCombo[i], '1');
                    Nk[i] = tjaRead.CountChar(NORMALCombo[i], '2');
                    Ntd[i] = tjaRead.CountChar(NORMALCombo[i], '3');
                    Ntk[i] = tjaRead.CountChar(NORMALCombo[i], '4');

                    Gd[i] = tjaRead.CountChar(GOGOCombo[i], '1');
                    Gk[i] = tjaRead.CountChar(GOGOCombo[i], '2');
                    Gtd[i] = tjaRead.CountChar(GOGOCombo[i], '3');
                    Gtk[i] = tjaRead.CountChar(GOGOCombo[i], '4');

                }


                for (int i = 0; i < 5; i++)
                {
                    gdk[i] = Gd[i] + Gk[i];
                    gtdk[i] = Gtd[i] + Gtk[i];

                    ndk[i] = Nd[i] + Nk[i] - gdk[i];
                    ntdk[i] = Ntd[i] + Ntk[i] - gtdk[i];
                }
            }
            else
            {
                string strG = strGOGOTJA[6];
                nComboBonus = strGOGOTJA[6].Replace(" ", "").Length;

                if (strGOGOTJA[6].Length < 10)
                {
                    NORMALCombo[0] = strG.Substring(0, strGOGOTJA[6].Length);
                }
                else if (strGOGOTJA[6].Length < 30)
                {
                    NORMALCombo[0] = strG.Substring(0, 9);
                    NORMALCombo[1] = strG.Substring(9, strGOGOTJA[6].Length - 9);

                }
                else if (strGOGOTJA[6].Length < 50)
                {
                    NORMALCombo[0] = strG.Substring(0, 9);
                    NORMALCombo[1] = strG.Substring(9, 20);
                    NORMALCombo[2] = strG.Substring(29, strGOGOTJA[6].Length - 29);
                }
                else if (strGOGOTJA[6].Length < 100)
                {
                    NORMALCombo[0] = strG.Substring(0, 9);
                    NORMALCombo[1] = strG.Substring(9, 20);
                    NORMALCombo[2] = strG.Substring(29, 20);
                    NORMALCombo[3] = strG.Substring(49, strGOGOTJA[6].Length - 49);
                }
                else
                {
                    NORMALCombo[0] = strG.Substring(0, 9);
                    NORMALCombo[1] = strG.Substring(9, 20);
                    NORMALCombo[2] = strG.Substring(29, 20);
                    NORMALCombo[3] = strG.Substring(49, 50);
                    NORMALCombo[4] = strG.Substring(99, strGOGOTJA[6].Length - 99);
                }

                //コンボごとのノーツ数計算
                for (int i = 0; i < 5; i++)
                {
                    Nd[i] = tjaRead.CountChar(NORMALCombo[i], '1');
                    Nk[i] = tjaRead.CountChar(NORMALCombo[i], '2');
                    Ntd[i] = tjaRead.CountChar(NORMALCombo[i], '3');
                    Ntk[i] = tjaRead.CountChar(NORMALCombo[i], '4');

                    Gd[i] = 0;
                    Gk[i] = 0;
                    Gtd[i] = 0;
                    Gtk[i] = 0;

                }


                for (int i = 0; i < 5; i++)
                {
                    gdk[i] = 0;
                    gtdk[i] = 0;

                    ndk[i] = Nd[i] + Nk[i];
                    ntdk[i] = Ntd[i] + Ntk[i];
                }


            }
        }

        public void ResetValue(TJARead tjaRead)
        {
            tja = null;
            tjacom = null;
            nballoonEnumCount = 0;
            nbEComp = 0; //これなんだっけ...
            strballoon = null;
            balloon = null;
            strlevel = null; //ヘッダ情報抜き出し用。
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
            n11 = 0;
            n12 = 0;
            n13 = 0;

            nGoGoCount = 0; //n1～10:その行に対象の文字があるかどうか判別するためのもの nGogoCount：ゴーゴーの回数を数える
            balloonCount = 0;
            level = 0;
            bGogo = false; bStart = false; bEnd = false;//tjaの行がゴーゴーかどうか、#START～#END内かどうか。
        
            for (int i = 0; i < 2; i++)
            {
                scoreStr[i] = null;


                baAmount[i] = 0;
                baSum[i] = 0;

            }

            for (int i = 0; i < 3; i++)
            {
                str[i] = null;
            }
            for (int i = 0; i < 5; i++)
            {
                NORMALCombo[i] = null;
                GOGOCombo[i] = null;

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
            /*
            for (int i = 0; i < bbalgogo.Count; i++)
            {
                bbalgogo[i] = false;
            }
            */
            /*
            for (int i = 0; i < bbalgogo.Count; i++)
            {
                bbalgogo[i] = false;
                bbalgogo.RemoveAt(i);
            }
            for (int i = 0; i < balValue.Count; i++)
            {
                balValue[i] = 0;
                balValue.RemoveAt(i);
            }
            */
            bbalgogo.Clear();
            balValue.Clear();


            strScoreInit = null;
            strScoreDiff = null;
            bGogoExist = false;
            bKusudamaExist = false;
            nCourseNumber = 0;
            nSelectCourse = 0;
        }

        public StringReader TJA;
        public string tja;
        public string tjacom = null;
        public int nballoonEnumCount = 0;
        public int nbEComp = 0; //これなんだっけ...
        public string strballoon = null;
        public string balloon = null;
        public string strlevel = null; //ヘッダ情報抜き出し用。
        public int n1 = 0;
        public int n2 = 0;
        public int n3 = 0;
        public int n4 = 0;
        public int n5 = 0;
        public int n6 = 0;
        public int n7 = 0;
        public int n8 = 0;
        public int n9 = 0;
        public int n10 = 0;
        public int n11 = 0;
        public int n12 = 0;
        public int n13 = 0;
        public int n14 = 0;
        public int n15 = 0;

        public int nGoGoCount = 0; //n1～10:その行に対象の文字があるかどうか判別するためのもの nGogoCount：ゴーゴーの回数を数える
        public int balloonCount = 0;
        public int level = 0;
        public bool bGogo = false, bStart = false, bEnd = false;//tjaの行がゴーゴーかどうか、#START～#END内かどうか。
        public bool bRoll = false;

        public string[] scoreStr = new string[2];


        public int[] baAmount = new int[2];
        public int[] baSum = new int[2];

        public string[] tja12 = new string[2] { null, null };//1,2のみの譜面。3,4は0に置き換え
        public string[] tja34 = new string[2] { null, null };//3,4のみの譜面。1,2は0に置き換え
        public string[] tja0 = new string[2] { null, null };//最大コンボ数の数だけ0が出力される文字列。これ使えないかなあ...



        public string[] str = new string[3];
        public string[] NORMALCombo = new string[5];
        public string[] GOGOCombo = new string[5];

        public int[] Nd = new int[5];
        public int[] Nk = new int[5];
        public int[] Ntd = new int[5];
        public int[] Ntk = new int[5];
        public int[] Gd = new int[5];
        public int[] Gk = new int[5];
        public int[] Gtd = new int[5];
        public int[] Gtk = new int[5];

        public int[] ndk = new int[5];
        public int[] ntdk = new int[5];
        public int[] gdk = new int[5];
        public int[] gtdk = new int[5];

        public int nComboBonus = 0;
        /*
        for (int i = 0; i < bbalgogo.Count; i++)
        {
            bbalgogo[i] = false;
        }
        */
        /*
        for (int i = 0; i < bbalgogo.Count; i++)
        {
            bbalgogo[i] = false;
            bbalgogo.RemoveAt(i);
        }
        for (int i = 0; i < balValue.Count; i++)
        {
            balValue[i] = 0;
            balValue.RemoveAt(i);
        }
        */
        List<bool> bbalgogo = new List<bool>();
        List<int> balValue = new List<int>();

        public string strScoreInit = null;
        public string strScoreDiff = null;
        public bool bGogoExist = false, bKusudamaExist = false;
        public int nSelectCourse = 0, nCourseNumber = 0;
        public bool[] bCourseStart = new bool[5];

    }
}

