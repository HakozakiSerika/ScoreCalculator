using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ScoreCalculator
{
    class Write
    {
        public void WriteScore(TJARead tjaRead, Calculate calculate, ScoreCal_Form1 mainForm)
        {
            TJAW = new StreamWriter(string.IsNullOrWhiteSpace(tjaRead.fileNameWrite) ? tjaRead.ofd.FileName : tjaRead.fileNameWrite, false, Encoding.GetEncoding("shift_jis"));
            writeText = tjaRead.str[2];
            Start = writeText.IndexOf("#START");

            SI = writeText.IndexOf("SCOREINIT:");
            SD = writeText.IndexOf("SCOREDIFF:");

            if (SI >= 0)
            {
                scoreInitExist = true;
            }

            if (SD >= 0)
            {
                scoreDiffExist = true;
            }

            if (!scoreInitExist && !scoreDiffExist)
            {
                nSI = Start - 1;
                nSD = nSI + 12 + calculate.ScoreInit.ToString().Length;

                writeText = writeText.Insert(nSI, "SCOREINIT:" + calculate.ScoreInit + Environment.NewLine);
                writeText = writeText.Insert(nSD, "SCOREDIFF:" + calculate.ScoreDiff + Environment.NewLine);
            }
            else
            {
                nSI = writeText.IndexOf("SCOREINIT:");
                nSD = writeText.IndexOf("SCOREDIFF:");

                writeText = writeText.Remove(nSD, tjaRead.strScoreDiff.Length);
                writeText = writeText.Remove(nSI, tjaRead.strScoreInit.Length);

                writeText = writeText.Insert(nSI, "SCOREINIT:" + calculate.ScoreInit);
                writeText = writeText.Insert(nSD, "SCOREDIFF:" + calculate.ScoreDiff);

            }

            if (calculate.bRead)
            {
                TJAW.Write(writeText);
                TJAW.Close();
            }
            
            mainForm.textBox1.Text = writeText;
        }

        public StreamWriter TJAW = null;
        public string writeText, strSI, strSD;
        public int Start, nSI, nSD;
        public bool b;
        public bool scoreInitExist, scoreDiffExist;
        public int SI, SD;

    }
}
