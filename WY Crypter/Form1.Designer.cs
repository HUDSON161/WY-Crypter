namespace WY_47_89
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pi = new System.Windows.Forms.CheckBox();
            this.native = new System.Windows.Forms.CheckBox();
            this.startup = new System.Windows.Forms.CheckBox();
            this.key = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.ENCRYPT = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.fpath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.managed = new System.Windows.Forms.CheckBox();
            this.si = new System.Windows.Forms.CheckBox();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.icopath = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ObfBox = new System.Windows.Forms.CheckBox();
            this.DeepPolyBox = new System.Windows.Forms.CheckBox();
            this.VMBox = new System.Windows.Forms.CheckBox();
            this.ProcessBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BitBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.AssemblyPusher = new System.Windows.Forms.CheckBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.DictionaryBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pi
            // 
            this.pi.AutoSize = true;
            this.pi.Enabled = false;
            this.pi.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pi.Location = new System.Drawing.Point(604, 322);
            this.pi.Name = "pi";
            this.pi.Size = new System.Drawing.Size(139, 19);
            this.pi.TabIndex = 1;
            this.pi.Text = "Process injection";
            this.pi.UseVisualStyleBackColor = true;
            this.pi.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // native
            // 
            this.native.AutoSize = true;
            this.native.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.native.Location = new System.Drawing.Point(575, 421);
            this.native.Name = "native";
            this.native.Size = new System.Drawing.Size(68, 19);
            this.native.TabIndex = 2;
            this.native.Text = "Native";
            this.native.UseVisualStyleBackColor = true;
            this.native.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // startup
            // 
            this.startup.AutoSize = true;
            this.startup.BackColor = System.Drawing.Color.Transparent;
            this.startup.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startup.Location = new System.Drawing.Point(575, 371);
            this.startup.Name = "startup";
            this.startup.Size = new System.Drawing.Size(140, 19);
            this.startup.TabIndex = 3;
            this.startup.Text = "Self Destroy After";
            this.startup.UseVisualStyleBackColor = false;
            this.startup.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // key
            // 
            this.key.Location = new System.Drawing.Point(60, 321);
            this.key.Name = "key";
            this.key.Size = new System.Drawing.Size(203, 20);
            this.key.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(313, 322);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(58, 19);
            this.button1.TabIndex = 8;
            this.button1.Text = "choise";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Agency FB", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 318);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 25);
            this.label2.TabIndex = 9;
            this.label2.Text = "Key";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(313, 359);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(58, 20);
            this.button2.TabIndex = 10;
            this.button2.Text = "choise";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ENCRYPT
            // 
            this.ENCRYPT.BackColor = System.Drawing.Color.LightSeaGreen;
            this.ENCRYPT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ENCRYPT.Font = new System.Drawing.Font("Agency FB", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ENCRYPT.ForeColor = System.Drawing.Color.Indigo;
            this.ENCRYPT.Location = new System.Drawing.Point(12, 446);
            this.ENCRYPT.Name = "ENCRYPT";
            this.ENCRYPT.Size = new System.Drawing.Size(835, 55);
            this.ENCRYPT.TabIndex = 11;
            this.ENCRYPT.Text = "ENCRYPT";
            this.ENCRYPT.UseVisualStyleBackColor = false;
            this.ENCRYPT.Click += new System.EventHandler(this.button3_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // fpath
            // 
            this.fpath.Location = new System.Drawing.Point(60, 362);
            this.fpath.Name = "fpath";
            this.fpath.Size = new System.Drawing.Size(203, 20);
            this.fpath.TabIndex = 12;
            this.fpath.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Agency FB", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 357);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 25);
            this.label3.TabIndex = 13;
            this.label3.Text = "File";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // managed
            // 
            this.managed.AutoSize = true;
            this.managed.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.managed.Location = new System.Drawing.Point(575, 396);
            this.managed.Name = "managed";
            this.managed.Size = new System.Drawing.Size(60, 19);
            this.managed.TabIndex = 17;
            this.managed.Text = ". NET";
            this.managed.UseVisualStyleBackColor = true;
            this.managed.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged_1);
            // 
            // si
            // 
            this.si.AutoSize = true;
            this.si.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.si.Location = new System.Drawing.Point(604, 296);
            this.si.Name = "si";
            this.si.Size = new System.Drawing.Size(111, 19);
            this.si.TabIndex = 18;
            this.si.Text = "Self injection";
            this.si.UseVisualStyleBackColor = true;
            this.si.CheckedChanged += new System.EventHandler(this.si_CheckedChanged);
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Agency FB", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 398);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 25);
            this.label4.TabIndex = 16;
            this.label4.Text = "Icon";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(313, 400);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(58, 20);
            this.button3.TabIndex = 15;
            this.button3.Text = "choise";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // icopath
            // 
            this.icopath.Location = new System.Drawing.Point(60, 401);
            this.icopath.Name = "icopath";
            this.icopath.Size = new System.Drawing.Size(203, 20);
            this.icopath.TabIndex = 14;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.Image = global::WY_47_89.Properties.Resources.hudson;
            this.pictureBox1.Location = new System.Drawing.Point(645, 34);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(176, 216);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // ObfBox
            // 
            this.ObfBox.AutoSize = true;
            this.ObfBox.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ObfBox.Location = new System.Drawing.Point(388, 371);
            this.ObfBox.Name = "ObfBox";
            this.ObfBox.Size = new System.Drawing.Size(95, 19);
            this.ObfBox.TabIndex = 20;
            this.ObfBox.Text = "Obfuscate ";
            this.ObfBox.UseVisualStyleBackColor = true;
            // 
            // DeepPolyBox
            // 
            this.DeepPolyBox.AutoSize = true;
            this.DeepPolyBox.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeepPolyBox.Location = new System.Drawing.Point(388, 421);
            this.DeepPolyBox.Name = "DeepPolyBox";
            this.DeepPolyBox.Size = new System.Drawing.Size(119, 19);
            this.DeepPolyBox.TabIndex = 21;
            this.DeepPolyBox.Text = "Deep Garbage";
            this.DeepPolyBox.UseVisualStyleBackColor = true;
            // 
            // VMBox
            // 
            this.VMBox.AutoSize = true;
            this.VMBox.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VMBox.Location = new System.Drawing.Point(388, 396);
            this.VMBox.Name = "VMBox";
            this.VMBox.Size = new System.Drawing.Size(75, 19);
            this.VMBox.TabIndex = 22;
            this.VMBox.Text = "Anti VM";
            this.VMBox.UseVisualStyleBackColor = true;
            // 
            // ProcessBox
            // 
            this.ProcessBox.Location = new System.Drawing.Point(388, 345);
            this.ProcessBox.Name = "ProcessBox";
            this.ProcessBox.Size = new System.Drawing.Size(374, 20);
            this.ProcessBox.TabIndex = 23;
            this.ProcessBox.Text = "C:\\\\Windows\\\\System32\\\\attrib.exe";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Agency FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(383, 318);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 24);
            this.label1.TabIndex = 24;
            this.label1.Text = "Process exe Path";
            // 
            // BitBox
            // 
            this.BitBox.FormattingEnabled = true;
            this.BitBox.Items.AddRange(new object[] {
            "x86",
            "AMD64"});
            this.BitBox.Location = new System.Drawing.Point(546, 227);
            this.BitBox.Name = "BitBox";
            this.BitBox.Size = new System.Drawing.Size(59, 21);
            this.BitBox.TabIndex = 25;
            this.BitBox.Text = "x86";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Agency FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(542, 200);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 24);
            this.label5.TabIndex = 26;
            this.label5.Text = "Bitness";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(93, 227);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(270, 20);
            this.textBox6.TabIndex = 27;
            this.textBox6.Text = "ConfuserEx";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(93, 201);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(270, 20);
            this.textBox5.TabIndex = 28;
            this.textBox5.Text = "Ki";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(93, 175);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(270, 20);
            this.textBox4.TabIndex = 29;
            this.textBox4.Text = "ConfuserEx";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(93, 149);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(270, 20);
            this.textBox3.TabIndex = 30;
            this.textBox3.Text = "1.0.0";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(93, 123);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(270, 20);
            this.textBox2.TabIndex = 31;
            this.textBox2.Text = "1.0.0";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(93, 97);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(270, 20);
            this.textBox1.TabIndex = 32;
            this.textBox1.Text = "ConfuserEx GUI";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Agency FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(89, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 24);
            this.label6.TabIndex = 33;
            this.label6.Text = "Assembly Info";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Agency FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(369, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 24);
            this.label7.TabIndex = 34;
            this.label7.Text = "Title";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Agency FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(369, 170);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 24);
            this.label8.TabIndex = 35;
            this.label8.Text = "Description";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Agency FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(369, 197);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 24);
            this.label9.TabIndex = 36;
            this.label9.Text = "Company";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Agency FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(369, 224);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 24);
            this.label10.TabIndex = 37;
            this.label10.Text = "Product";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Agency FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(369, 119);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 24);
            this.label11.TabIndex = 38;
            this.label11.Text = "Version";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Agency FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(369, 145);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 24);
            this.label12.TabIndex = 39;
            this.label12.Text = "File Version";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(17, 97);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(61, 17);
            this.checkBox1.TabIndex = 40;
            this.checkBox1.Text = "Include";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Location = new System.Drawing.Point(17, 123);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(61, 17);
            this.checkBox2.TabIndex = 41;
            this.checkBox2.Text = "Include";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Checked = true;
            this.checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox3.Location = new System.Drawing.Point(17, 149);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(61, 17);
            this.checkBox3.TabIndex = 42;
            this.checkBox3.Text = "Include";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Checked = true;
            this.checkBox4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox4.Location = new System.Drawing.Point(17, 177);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(61, 17);
            this.checkBox4.TabIndex = 43;
            this.checkBox4.Text = "Include";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Checked = true;
            this.checkBox5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox5.Location = new System.Drawing.Point(17, 203);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(61, 17);
            this.checkBox5.TabIndex = 44;
            this.checkBox5.Text = "Include";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Checked = true;
            this.checkBox6.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox6.Location = new System.Drawing.Point(17, 228);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(61, 17);
            this.checkBox6.TabIndex = 45;
            this.checkBox6.Text = "Include";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // AssemblyPusher
            // 
            this.AssemblyPusher.AutoSize = true;
            this.AssemblyPusher.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AssemblyPusher.Location = new System.Drawing.Point(17, 12);
            this.AssemblyPusher.Name = "AssemblyPusher";
            this.AssemblyPusher.Size = new System.Drawing.Size(197, 19);
            this.AssemblyPusher.TabIndex = 46;
            this.AssemblyPusher.Text = "Enable User Assembly Info";
            this.AssemblyPusher.UseVisualStyleBackColor = true;
            this.AssemblyPusher.CheckedChanged += new System.EventHandler(this.EnableUserAssembly);
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(93, 47);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(270, 20);
            this.textBox7.TabIndex = 47;
            this.textBox7.Text = "FunnyBug";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Agency FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(369, 47);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(66, 24);
            this.label13.TabIndex = 48;
            this.label13.Text = "File Name";
            // 
            // DictionaryBox
            // 
            this.DictionaryBox.AutoSize = true;
            this.DictionaryBox.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DictionaryBox.Location = new System.Drawing.Point(387, 296);
            this.DictionaryBox.Name = "DictionaryBox";
            this.DictionaryBox.Size = new System.Drawing.Size(171, 19);
            this.DictionaryBox.TabIndex = 49;
            this.DictionaryBox.Text = "Dictionary Names Generate";
            this.DictionaryBox.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.ClientSize = new System.Drawing.Size(859, 513);
            this.Controls.Add(this.DictionaryBox);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.AssemblyPusher);
            this.Controls.Add(this.checkBox6);
            this.Controls.Add(this.checkBox5);
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.BitBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ProcessBox);
            this.Controls.Add(this.VMBox);
            this.Controls.Add(this.DeepPolyBox);
            this.Controls.Add(this.ObfBox);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.si);
            this.Controls.Add(this.managed);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.icopath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.fpath);
            this.Controls.Add(this.ENCRYPT);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.key);
            this.Controls.Add(this.startup);
            this.Controls.Add(this.native);
            this.Controls.Add(this.pi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "WY Crypter";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox pi;
        private System.Windows.Forms.CheckBox native;
        private System.Windows.Forms.CheckBox startup;
        private System.Windows.Forms.TextBox key;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button ENCRYPT;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox fpath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox managed;
        private System.Windows.Forms.CheckBox si;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox icopath;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox ObfBox;
        private System.Windows.Forms.CheckBox DeepPolyBox;
        private System.Windows.Forms.CheckBox VMBox;
        private System.Windows.Forms.TextBox ProcessBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox BitBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox AssemblyPusher;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox DictionaryBox;
    }
}

