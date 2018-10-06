using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DESFullScreen
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            EDUtility.txt = textBoxLog;
        }

        private void textBoxLog_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        
        private void buttonEncr_Click(object sender, EventArgs e)
        {
            textBoxLog.Clear();
            #region DESEncr
            {
                EDUtility.MsgToLog("--------------------------");
                EDUtility.MsgToLog("Шифрование DES");
                EDUtility.MsgToLog("--------------------------");
                if (textBoxKey.Text.Length != 8)
                {
                    MessageBox.Show("Ключ должен содержать 8 символов!");
                }
                else
                {
                    while (textBoxMsg.Text.Length % 8 != 0)
                    {
                        textBoxMsg.Text += " ";
                    }

                    var MsgByte = new byte[textBoxMsg.Text.Length / 8][];
                    for (var i = 0; i < MsgByte.Length; i++)
                    {
                        MsgByte[i] = new byte[8];
                        for (var j = 0; j < 8; j++)
                        {
                            MsgByte[i][j] = Convert.ToByte(textBoxMsg.Text[8 * i + j]);
                        }
                    }

                    var Key = new byte[8];
                    for (var i = 0; i < 8; i++)
                    {
                        Key[i] = Convert.ToByte(textBoxKey.Text[i]);
                    }
                    var KeyBlock = EDUtility.ByteToBlocks(Key);

                    textBoxRes.Clear();

                    foreach (var a in MsgByte)
                    {
                        EDUtility.MsgToLog("**************************");
                        EDUtility.MsgToLog("Шифрование блока");
                        EDUtility.MsgToLog("**************************");
                        var bytestolog = "Исходные байты: ";
                        foreach (var b in a)
                        {
                            bytestolog += Convert.ToString(b) + " ";
                        }
                        EDUtility.MsgToLog(bytestolog);
                        EDUtility.MsgToLog("");

                        var Block = EDUtility.ByteToBlocks(a);
                        Block = DESEncryptDecrypt.Encrypth(Block, KeyBlock);
                        var EncrBlock = EDUtility.BlockToBytes(Block);

                        foreach (var b in EncrBlock)
                        {
                            textBoxRes.Text += Convert.ToChar(b);
                        }

                        EDUtility.MsgToLog("");
                        bytestolog = "Зашифрованные байты: ";
                        foreach (var b in EncrBlock)
                        {
                            bytestolog += Convert.ToString(b) + " ";
                        }
                        EDUtility.MsgToLog(bytestolog);
                        EDUtility.MsgToLog("**************************");
                        EDUtility.MsgToLog("Шифрование блока завершено");
                        EDUtility.MsgToLog("**************************");
                    }
                    EDUtility.MsgToLog("--------------------------");
                    EDUtility.MsgToLog("Шифрование DES завершено");
                    EDUtility.MsgToLog("--------------------------");
                }
            }
            #endregion DesEncr
        }

        private void buttonDecr_Click(object sender, EventArgs e)
        {
            textBoxLog.Clear();
            #region DESDecr
            {
                if (textBoxKey.Text.Length != 8 || textBoxMsg.Text.Length % 8 != 0)
                {
                    if (textBoxKey.Text.Length != 8)
                        MessageBox.Show("Ключ должен содержать 8 символов!");
                    else
                        MessageBox.Show("Кол-во символов в сообщении не кратно 8!");
                }
                else
                {
                    EDUtility.MsgToLog("--------------------------");
                    EDUtility.MsgToLog("Расшифровка DES");
                    EDUtility.MsgToLog("--------------------------");
                    var MsgByte = new byte[textBoxMsg.Text.Length / 8][];
                    for (var i = 0; i < MsgByte.Length; i++)
                    {
                        MsgByte[i] = new byte[8];
                        for (var j = 0; j < 8; j++)
                        {
                            MsgByte[i][j] = Convert.ToByte(textBoxMsg.Text[8 * i + j]);
                        }
                    }

                    var Key = new byte[8];
                    for (var i = 0; i < 8; i++)
                    {
                        Key[i] = Convert.ToByte(textBoxKey.Text[i]);
                    }
                    var KeyBlock = EDUtility.ByteToBlocks(Key);

                    textBoxRes.Clear();

                    foreach (var a in MsgByte)
                    {
                        EDUtility.MsgToLog("**************************");
                        EDUtility.MsgToLog("Расшифровка блока");
                        EDUtility.MsgToLog("**************************");
                        var bytestolog = "Исходные байты: ";
                        foreach (var b in a)
                        {
                            bytestolog += Convert.ToString(b) + " ";
                        }
                        EDUtility.MsgToLog(bytestolog);
                        EDUtility.MsgToLog("");

                        var Block = EDUtility.ByteToBlocks(a);
                        Block = DESEncryptDecrypt.Decrypth(Block, KeyBlock);
                        var EncrBlock = EDUtility.BlockToBytes(Block);

                        foreach (var b in EncrBlock)
                        {
                            textBoxRes.Text += Convert.ToChar(b);
                        }

                        EDUtility.MsgToLog("");
                        bytestolog = "Расшифрованные байты: ";
                        foreach (var b in EncrBlock)
                        {
                            bytestolog += Convert.ToString(b) + " ";
                        }
                        EDUtility.MsgToLog(bytestolog);
                        EDUtility.MsgToLog("**************************");
                        EDUtility.MsgToLog("Расшифровка блока завершена");
                        EDUtility.MsgToLog("**************************");
                    }

                    EDUtility.MsgToLog("--------------------------");
                    EDUtility.MsgToLog("Расшифровка DES завершена");
                    EDUtility.MsgToLog("--------------------------");
                }
            }
            #endregion DESDecr
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
                EDUtility.DebugKeyGen = true;
            else
                EDUtility.DebugKeyGen = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                EDUtility.DebugCycles = true;
            else
                EDUtility.DebugCycles = false;
        }

    }

    static class EDUtility
    {
        public static bool DebugCycles = false;
        public static bool DebugKeyGen = false;
        public static TextBox txt;

        //--------------------------------
        //             Лог
        //--------------------------------

        public static void MsgToLog(string msg)
        {
            txt.AppendText(msg + Environment.NewLine);
        }

        //--------------------------------
        //     Преобразования
        //--------------------------------

        public static string ByteToStr(byte b)
        {
            var strtmp = "00000000";
            var strtmp2 = Convert.ToString(b, 2);
            strtmp = strtmp.Remove(0, strtmp2.Length);
            return strtmp + strtmp2;
        }

        public static bool[] ByteToBlocks(byte[] Block, string DebugMessage = "")
        {
            var NewBlock = new bool[8 * Block.Length];
            var strtmp = "";
            foreach (var i in Block)
            {
                strtmp += ByteToStr(i);
            }
            if (DebugMessage != "")
                MsgToLog(DebugMessage + " " + strtmp);
            var a = 0;
            foreach (var c in strtmp)
            {
                if (c == '0')
                    NewBlock[a] = false;
                else
                    NewBlock[a] = true;
                a++;
            }
            return NewBlock;
        }

        public static bool[] ByteToBlocks(byte Block, string DebugMessage = "")
        {
            var NewBlock = new bool[8];
            var strtmp = "";
            strtmp += ByteToStr(Block);

            if (DebugMessage != "")
                MsgToLog(DebugMessage + " " + strtmp);
            var a = 0;
            foreach (var c in strtmp)
            {
                if (c == '0')
                    NewBlock[a] = false;
                else
                    NewBlock[a] = true;
                a++;
            }
            return NewBlock;
        }

        public static byte[] BlockToBytes(bool[] Block, string DebugMessage = "")
        {
            var NewBlock = new byte[Block.Length / 8];
            var strtmp = "";
            foreach (var i in Block)
            {
                if (!i)
                    strtmp += '0';
                else
                    strtmp += '1';
            }
            if (DebugMessage != "")
                MsgToLog(DebugMessage + " " + strtmp);
            int step = strtmp.Length / 8;
            for (int i = 0; i < step; i++)
            {
                NewBlock[i] = Convert.ToByte(strtmp.Substring(i * 8, 8), 2);
            }
            return NewBlock;
        }

        //--------------------------------
        //     Циклический сдвиг
        //--------------------------------

        public static void PushToLeft(ref bool[] Block, int count)
        {
            if (DebugKeyGen)
                BlockToBytes(Block, "До сдвига влево:"); //Debug
            for (var i = 0; i < count; i++)
            {
                var temp = Block[0];
                for (var j = 0; j < Block.Length - 1; j++)
                {
                    Block[j] = Block[j + 1];
                }
                Block[Block.Length - 1] = temp;
            }
            if (DebugKeyGen)
                BlockToBytes(Block, "После сдвига:   "); //Debug
        }

        public static void PushToRight(ref bool[] Block, int count)
        {
            if (DebugKeyGen)
                BlockToBytes(Block, "До сдвига вправо:"); //Debug
            for (var i = 0; i < count; i++)
            {
                var temp = Block[Block.Length - 1];
                for (var j = Block.Length - 1; j > 0; j--)
                {
                    Block[j] = Block[j - 1];
                }
                Block[0] = temp;
            }
            if (DebugKeyGen)
                BlockToBytes(Block, "После сдвига:    "); //Debug
        }
    }

    static class DESEncryptDecrypt
    {

        //--------------------------------
        //          Константы
        //--------------------------------

        private static readonly byte[] IP =
        {58,50,42,34,26,18,10,2,
         60,52,44,36,28,20,12,4,
         62,54,46,38,30,22,14,6,
         64,56,48,40,32,24,16,8,
         57,49,41,33,25,17,9,1,
         59,51,43,35,27,19,11,3,
         61,53,45,37,29,21,13,5,
         63,55,47,39,31,23,15,7
        };

        private static readonly byte[] IP_REVERSE =
        {40,8,48,16,56,24,64,32,
         39,7,47,15,55,23,63,31,
         38,6,46,14,54,22,62,30,
         37,5,45,13,53,21,61,29,
         36,4,44,12,52,20,60,28,
         35,3,43,11,51,19,59,27,
         34,2,42,10,50,18,58,26,
         33,1,41,9,49,17,57,25
        };

        private static readonly byte[] KEYGEN_C0 =
        {57,49,41,33,25,17,9,
         1,58,50,42,34,26,18,
         10,2,59,51,43,35,27,
         19,11,3,60,52,44,36
        };

        private static readonly byte[] KEYGEN_D0 =
        {63,55,47,39,31,23,15,
         7,62,54,46,38,30,22,
         14,6,61,53,45,37,29,
         21,13,5,28,20,12,4
        };

        private static readonly byte[] KEYGEN_CDSDVIG = { 1, 1, 2, 2, 2, 2, 2, 2, 1, 2, 2, 2, 2, 2, 2, 1 };

        private static readonly byte[] KEYGEN_CDSDVIG_REVERSE = { 0, 1, 2, 2, 2, 2, 2, 2, 1, 2, 2, 2, 2, 2, 2, 1 };

        private static readonly byte[] KEYGEN_VIBORKA =
        {14,17,11,24,1,5,
         3,28,15,6,21,10,
         23,19,12,4,26,8,
         16,7,27,20,13,2,
         41,52,31,37,47,55,
         30,40,51,45,33,48,
         44,49,39,56,34,53,
         46,42,50,36,29,32
        };

        private static readonly byte[] ENCRYPT_RASHIRENIE =
        {32,1,2,3,4,5,
         4,5,6,7,8,9,
         8,9,10,11,12,13,
         12,13,14,15,16,17,
         16,17,18,19,20,21,
         20,21,22,23,24,25,
         24,25,26,27,28,29,
         28,29,30,31,32,1
        };

        private static readonly byte[, ,] ENCRYPT_S =
        {{{14,04,13,01,02,15,11,08,03,10,06,12,05,09,00,07 },
         { 00,15,07,04,14,02,13,01,10,06,12,11,09,05,03,08 },
         { 04,01,14,08,13,06,02,11,15,12,09,07,03,10,05,00 },
         { 15,12,08,02,04,09,01,07,05,11,03,14,10,00,06,13}},
        {{15,01,08,14,06,11,03,04,09,07,02,13,12,00,05,10  },
         { 03,13,04,07,15,02,08,14,12,00,01,10,06,09,11,05 },
         { 00,14,07,11,10,04,13,01,05,08,12,06,09,03,02,15 },
         { 13,08,10,01,03,15,04,02,11,06,07,12,00,05,14,09}},
        {{10,00,09,14,06,03,15,05,01,13,12,07,11,04,02,08  },
         { 13,07,00,09,03,04,06,10,02,08,05,14,12,11,15,01 },
         { 13,06,04,09,08,15,03,00,11,01,02,12,05,10,14,07 },
         { 01,10,13,00,06,09,08,07,04,15,14,03,11,05,02,12}},
        {{07,13,14,03,00,06,09,10,01,02,08,05,11,12,04,15  },
         { 13,08,11,05,06,15,00,03,04,07,02,12,01,10,14,09 },
         { 10,06,09,00,12,11,07,13,15,01,03,14,05,02,08,04 },
         { 13,15,00,06,10,01,13,08,09,04,05,11,12,07,02,14}},
        {{02,12,04,01,07,10,11,06,08,05,03,15,13,00,14,09  },
         { 14,11,02,12,04,07,13,01,05,00,15,10,03,08,09,06 },
         { 04,02,01,11,10,13,07,08,15,09,12,05,06,03,00,14 },
         { 11,08,12,07,01,14,02,13,06,15,00,09,10,04,05,03}},
        {{12,01,10,15,09,02,06,08,00,13,03,04,14,07,05,11  },
         { 10,15,04,02,07,12,09,05,06,01,13,14,00,11,03,08 },
         { 09,14,15,05,02,08,12,03,07,00,04,10,01,13,11,06 },
         { 04,03,02,12,09,05,15,10,11,14,01,04,06,00,08,13}},
        {{04,11,02,14,15,00,08,13,03,12,09,07,05,10,06,01  },
         { 13,00,11,07,04,09,01,10,14,03,05,12,02,15,08,06 },
         { 01,04,11,13,12,03,07,14,10,15,06,08,00,05,09,02 },
         { 06,11,13,08,01,04,10,07,09,05,00,15,14,02,03,12}},
        {{13,02,08,04,06,15,11,01,10,09,03,14,05,00,12,07  },
         { 01,15,13,08,10,03,07,04,12,05,06,11,00,14,09,02 },
         { 07,11,04,01,09,12,14,02,00,06,10,13,15,03,05,08 },
         { 02,01,14,07,04,10,08,13,15,12,09,00,03,05,06,11}}
        };

        private static readonly byte[] ENCRYPT_PERESTANOVKA =
        {16,7,20,21,
         29,12,28,17,
         1,15,23,26,
         5,18,31,10,
         2,8,24,14,
         32,27,3,9,
         19,13,30,6,
         22,11,4,25
        };

        //--------------------------------
        //     Начальная перестановка
        //--------------------------------

        private static bool[] FirstPerest(bool[] Block)
        {
            EDUtility.BlockToBytes(Block, "Перестановка массива по IP:"); //Debug
            var NewBlock = new bool[64];
            for (var i = 0; i < 64; i++)
            {
                NewBlock[i] = Block[IP[i] - 1];
            }
            EDUtility.BlockToBytes(NewBlock, "Результат:"); //Debug
            return NewBlock;
        }

        //--------------------------------
        //     Цикл шифрования
        //--------------------------------

        private static bool[] EncrypthCycle(bool[] Block, bool[] Key)
        {
            var NewKeys = GenerateKeys(Key, false);
            var LPred = new bool[32];
            var RPred = new bool[32];
            var L = new bool[32];
            var R = new bool[32];
            for (var i = 0; i < 64; i++)
            {
                if (i < 32)
                    LPred[i] = Block[i];
                else
                    RPred[i - 32] = Block[i];
            }

            if (EDUtility.DebugCycles)
                EDUtility.MsgToLog("");
            EDUtility.BlockToBytes(LPred, "Исходный L:");  //Debug
            EDUtility.BlockToBytes(RPred, "Исходный R:");  //Debug
            if (EDUtility.DebugCycles)
                EDUtility.MsgToLog("");

            for (var i = 1; i <= 16; i++)
            {
                var f = FFunction(RPred, NewKeys[i - 1]);
                RPred.CopyTo(L, 0);
                for (var j = 0; j < 32; j++)
                {
                    R[j] = LPred[j] ^ f[j];
                }

                L.CopyTo(LPred, 0);
                R.CopyTo(RPred, 0);

                if (EDUtility.DebugCycles)
                    EDUtility.MsgToLog("");
                EDUtility.BlockToBytes(LPred, "L" + Convert.ToString(i) + ":");  //Debug
                EDUtility.BlockToBytes(RPred, "R" + Convert.ToString(i) + ":");  //Debug
                if (EDUtility.DebugCycles)
                    EDUtility.MsgToLog("");
            }

            var NewBlock = new bool[64];
            L.CopyTo(NewBlock, 0);
            R.CopyTo(NewBlock, L.Length);

            return NewBlock;
        }

        //--------------------------------
        //     Цикл расшифровки
        //--------------------------------

        private static bool[] DecrypthCycle(bool[] Block, bool[] Key)
        {
            var NewKeys = GenerateKeys(Key, true);
            var LPred = new bool[32];
            var RPred = new bool[32];
            var L = new bool[32];
            var R = new bool[32];
            for (var i = 0; i < 64; i++)
            {
                if (i < 32)
                    LPred[i] = Block[i];
                else
                    RPred[i - 32] = Block[i];
            }

            if (EDUtility.DebugCycles)
                EDUtility.MsgToLog("");
            EDUtility.BlockToBytes(LPred, "Исходный L:");  //Debug
            EDUtility.BlockToBytes(RPred, "Исходный R:");  //Debug
            if (EDUtility.DebugCycles)
                EDUtility.MsgToLog("");

            for (var i = 1; i <= 16; i++)
            {
                var f = FFunction(LPred, NewKeys[i - 1]);
                LPred.CopyTo(R, 0);
                for (var j = 0; j < 32; j++)
                {
                    L[j] = RPred[j] ^ f[j];
                }

                L.CopyTo(LPred, 0);
                R.CopyTo(RPred, 0);

                if (EDUtility.DebugCycles)
                    EDUtility.MsgToLog("");
                EDUtility.BlockToBytes(LPred, "L" + Convert.ToString(i) + ":");  //Debug
                EDUtility.BlockToBytes(RPred, "R" + Convert.ToString(i) + ":");  //Debug
                if (EDUtility.DebugCycles)
                    EDUtility.MsgToLog("");
            }

            var NewBlock = new bool[64];
            L.CopyTo(NewBlock, 0);
            R.CopyTo(NewBlock, L.Length);

            return NewBlock;
        }

        //--------------------------------
        //     Конечная перестановка
        //--------------------------------

        private static bool[] LastPerest(bool[] Block)
        {
            EDUtility.BlockToBytes(Block, "Перестановка массива по обратной IP:"); //Debug
            var NewBlock = new bool[64];
            for (var i = 0; i < 64; i++)
            {
                NewBlock[i] = Block[IP_REVERSE[i] - 1];
            }
            EDUtility.BlockToBytes(NewBlock, "Результат:"); //Debug
            return NewBlock;
        }

        //--------------------------------
        //     Функция F
        //--------------------------------

        private static bool[] FFunction(bool[] Block, bool[] Key)
        {
            var NewBlock = EFunction(Block);

            for (var i = 0; i < 48; i++)
            {
                NewBlock[i] = NewBlock[i] ^ Key[i];
            }
            if (EDUtility.DebugCycles)
                EDUtility.BlockToBytes(NewBlock, "Block XOR Key:"); //Debug

            var ResultBlock = SixToFourFunction(NewBlock);

            ResultBlock = PFunction(ResultBlock);

            return ResultBlock;
        }

        //--------------------------------
        //     Функция расширения E
        //--------------------------------

        private static bool[] EFunction(bool[] Block)
        {
            if (EDUtility.DebugCycles)
                EDUtility.BlockToBytes(Block, "Расширение массива по E:"); //Debug
            var NewBlock = new bool[48];

            for (var i = 0; i < 48; i++)
            {
                NewBlock[i] = Block[ENCRYPT_RASHIRENIE[i] - 1];
            }
            if (EDUtility.DebugCycles)
                EDUtility.BlockToBytes(NewBlock, "Результат:"); //Debug
            return NewBlock;
        }

        //--------------------------------
        //     Функция перестановки P
        //--------------------------------

        private static bool[] PFunction(bool[] Block)
        {
            if (EDUtility.DebugCycles)
                EDUtility.BlockToBytes(Block, "Перестановка массива по P:"); //Debug
            var NewBlock = new bool[32];
            for (var i = 0; i < 32; i++)
            {
                NewBlock[i] = Block[ENCRYPT_PERESTANOVKA[i] - 1];
            }
            if (EDUtility.DebugCycles)
                EDUtility.BlockToBytes(NewBlock, "Результат:"); //Debug
            return NewBlock;
        }

        //--------------------------------
        //     Функция преобразования 6-бит блоков в 4-бит
        //--------------------------------

        private static bool[] SixToFourFunction(bool[] Block)
        {
            if (EDUtility.DebugCycles)
                EDUtility.BlockToBytes(Block, "Преобразование 6-бит блоков в 4-бит по S:"); //Debug
            var BBlocks = new bool[8][];
            for (var i = 0; i < 8; i++)
            {
                BBlocks[i] = new bool[4];
            }

            for (var i = 0; i < 8; i++)
            {
                var row = "";
                var col = "";
                for (var j = 0; j < 6; j++)
                {
                    if (j == 0 || j == 5)
                    {
                        if (Block[i * 6 + j])
                            row += '1';
                        else
                            row += '0';
                    }
                    else
                    {
                        if (Block[i * 6 + j])
                            col += '1';
                        else
                            col += '0';
                    }
                }

                var Row = Convert.ToInt32(row, 2);
                var Col = Convert.ToInt32(col, 2);
                var NewByte = "0000";
                NewByte += Convert.ToString(ENCRYPT_S[i, Row, Col], 2);
                NewByte = NewByte.Remove(0, NewByte.Length - 4);

                var a = 0;
                foreach (var c in NewByte)
                {
                    if (c == '0')
                        BBlocks[i][a] = false;
                    else
                        BBlocks[i][a] = true;
                    a++;
                }

            }

            var NewBlock = new bool[32];
            for (var i = 0; i < 8; i++)
            {
                BBlocks[i].CopyTo(NewBlock, i * 4);
            }
            if (EDUtility.DebugCycles)
                EDUtility.BlockToBytes(NewBlock, "Результат:"); //Debug
            return NewBlock;
        }

        //--------------------------------
        //     Генерация ключей
        //--------------------------------

        private static bool[][] GenerateKeys(bool[] Key, bool IsDecrypth)
        {
            var KeyC = new bool[28];
            var KeyD = new bool[28];
            for (var i = 0; i < 56; i++)
            {
                if (i < 28)
                    KeyC[i] = Key[KEYGEN_C0[i] - 1];
                else
                    KeyD[i - 28] = Key[KEYGEN_D0[i - 28] - 1];
            }
            if (EDUtility.DebugKeyGen)
            {
                EDUtility.BlockToBytes(KeyC, "C0:");  //Debug
                EDUtility.BlockToBytes(KeyD, "D0:");  //Debug
            }
            var Keys = new bool[16][];
            for (var i = 0; i < 16; i++)
            {
                if (IsDecrypth)
                {
                    EDUtility.PushToRight(ref KeyC, KEYGEN_CDSDVIG_REVERSE[i]);
                    EDUtility.PushToRight(ref KeyD, KEYGEN_CDSDVIG_REVERSE[i]);
                }
                else
                {
                    EDUtility.PushToLeft(ref KeyC, KEYGEN_CDSDVIG[i]);
                    EDUtility.PushToLeft(ref KeyD, KEYGEN_CDSDVIG[i]);
                }
                Keys[i] = new bool[48];

                var TmpKey = new bool[56];
                KeyC.CopyTo(TmpKey, 0);
                KeyD.CopyTo(TmpKey, 28);

                Keys[i] = KeyGenVibor(TmpKey);

                if (EDUtility.DebugKeyGen)
                    EDUtility.MsgToLog("");
                EDUtility.BlockToBytes(Keys[i], "Ключ " + Convert.ToString(i + 1) + ":"); //Debug
                if (EDUtility.DebugKeyGen)
                    EDUtility.MsgToLog("");
            }

            return Keys;
        }

        //--------------------------------
        //     Функция выборки 48-бит ключа
        //--------------------------------

        private static bool[] KeyGenVibor(bool[] Block)
        {
            if (EDUtility.DebugKeyGen)
                EDUtility.BlockToBytes(Block, "Выборка ключа 48-бит:");  //Debug
            var NewBlock = new bool[48];

            for (var i = 0; i < 48; i++)
            {
                NewBlock[i] = Block[KEYGEN_VIBORKA[i] - 1];
            }
            if (EDUtility.DebugKeyGen)
                EDUtility.BlockToBytes(NewBlock, "Результат:");  //Debug
            return NewBlock;
        }

        //--------------------------------
        //     Шифрование
        //--------------------------------

        public static bool[] Encrypth(bool[] Block, bool[] Key)
        {
            //var NewKey = ParseKey(Key);
            var NewBlock = FirstPerest(Block);
            NewBlock = EncrypthCycle(NewBlock, Key);
            NewBlock = LastPerest(NewBlock);
            return NewBlock;
        }

        //--------------------------------
        //     Расшифровка
        //--------------------------------

        public static bool[] Decrypth(bool[] Block, bool[] Key)
        {
            //var NewKey = ParseKey(Key);
            var NewBlock = FirstPerest(Block);
            NewBlock = DecrypthCycle(NewBlock, Key);
            NewBlock = LastPerest(NewBlock);
            return NewBlock;
        }
    }
}
