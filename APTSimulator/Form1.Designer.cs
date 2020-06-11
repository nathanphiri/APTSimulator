using System;

namespace APTSimulator
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.testManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewQuestionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifyQuestionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteQustionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.elementHost2 = new System.Windows.Forms.Integration.ElementHost();
            this.questionViewWPF1 = new APTSimulator.QuestionViewWPF();
            this.testDEtailsBox = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblSeconds = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblMinutes = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.testCandidateDetailsBox = new System.Windows.Forms.GroupBox();
            this.btnStopTest = new System.Windows.Forms.Button();
            this.btnStartTest = new System.Windows.Forms.Button();
            this.candidateListComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblAptTitle = new System.Windows.Forms.Label();
            this.candidateDetailsGroupBox = new System.Windows.Forms.GroupBox();
            this.genderComboBox = new System.Windows.Forms.ComboBox();
            this.labelGender = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.labelDOB = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.labelLname = new System.Windows.Forms.Label();
            this.fnameText = new System.Windows.Forms.TextBox();
            this.labelFname = new System.Windows.Forms.Label();
            this.candidatelabel = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.testDetailsGroup = new System.Windows.Forms.GroupBox();
            this.testCategoryComboBox = new System.Windows.Forms.ComboBox();
            this.labelTestCategory = new System.Windows.Forms.Label();
            this.buttonSaveSchdule = new System.Windows.Forms.Button();
            this.elapsedTimer = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.testDEtailsBox.SuspendLayout();
            this.testCandidateDetailsBox.SuspendLayout();
            this.candidateDetailsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.testDetailsGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testManagementToolStripMenuItem,
            this.actionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1370, 38);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // testManagementToolStripMenuItem
            // 
            this.testManagementToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewQuestionsToolStripMenuItem,
            this.modifyQuestionsToolStripMenuItem,
            this.deleteQustionsToolStripMenuItem});
            this.testManagementToolStripMenuItem.Enabled = false;
            this.testManagementToolStripMenuItem.Name = "testManagementToolStripMenuItem";
            this.testManagementToolStripMenuItem.Size = new System.Drawing.Size(199, 34);
            this.testManagementToolStripMenuItem.Text = "Test Management";
            // 
            // addNewQuestionsToolStripMenuItem
            // 
            this.addNewQuestionsToolStripMenuItem.Name = "addNewQuestionsToolStripMenuItem";
            this.addNewQuestionsToolStripMenuItem.Size = new System.Drawing.Size(282, 34);
            this.addNewQuestionsToolStripMenuItem.Text = "Add New Questions";
            this.addNewQuestionsToolStripMenuItem.Click += new System.EventHandler(this.addNewQuestionsToolStripMenuItem_Click);
            // 
            // modifyQuestionsToolStripMenuItem
            // 
            this.modifyQuestionsToolStripMenuItem.Name = "modifyQuestionsToolStripMenuItem";
            this.modifyQuestionsToolStripMenuItem.Size = new System.Drawing.Size(282, 34);
            this.modifyQuestionsToolStripMenuItem.Text = "Modify Questions";
            // 
            // deleteQustionsToolStripMenuItem
            // 
            this.deleteQustionsToolStripMenuItem.Name = "deleteQustionsToolStripMenuItem";
            this.deleteQustionsToolStripMenuItem.Size = new System.Drawing.Size(282, 34);
            this.deleteQustionsToolStripMenuItem.Text = "Delete Qustions";
            // 
            // actionsToolStripMenuItem
            // 
            this.actionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scheduleTestToolStripMenuItem,
            this.runTestToolStripMenuItem});
            this.actionsToolStripMenuItem.Name = "actionsToolStripMenuItem";
            this.actionsToolStripMenuItem.Size = new System.Drawing.Size(177, 34);
            this.actionsToolStripMenuItem.Text = "Test Operations";
            this.actionsToolStripMenuItem.Click += new System.EventHandler(this.actionsToolStripMenuItem_Click);
            // 
            // scheduleTestToolStripMenuItem
            // 
            this.scheduleTestToolStripMenuItem.Name = "scheduleTestToolStripMenuItem";
            this.scheduleTestToolStripMenuItem.Size = new System.Drawing.Size(219, 34);
            this.scheduleTestToolStripMenuItem.Text = "Schedule Test";
            this.scheduleTestToolStripMenuItem.Click += new System.EventHandler(this.scheduleTestToolStripMenuItem_Click);
            // 
            // runTestToolStripMenuItem
            // 
            this.runTestToolStripMenuItem.Name = "runTestToolStripMenuItem";
            this.runTestToolStripMenuItem.Size = new System.Drawing.Size(219, 34);
            this.runTestToolStripMenuItem.Text = "Run Test";
            this.runTestToolStripMenuItem.Click += new System.EventHandler(this.runTestToolStripMenuItem_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.White;
            this.mainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainPanel.Controls.Add(this.elementHost2);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 38);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1370, 711);
            this.mainPanel.TabIndex = 1;
            this.mainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mainPanel_Paint);
            // 
            // elementHost2
            // 
            this.elementHost2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementHost2.Location = new System.Drawing.Point(0, 0);
            this.elementHost2.Name = "elementHost2";
            this.elementHost2.Size = new System.Drawing.Size(1368, 709);
            this.elementHost2.TabIndex = 4;
            this.elementHost2.Text = "elementHost2";
            this.elementHost2.ChildChanged += new System.EventHandler<System.Windows.Forms.Integration.ChildChangedEventArgs>(this.elementHost2_ChildChanged);
            this.elementHost2.Child = this.questionViewWPF1;
            // 
            // testDEtailsBox
            // 
            this.testDEtailsBox.Controls.Add(this.label7);
            this.testDEtailsBox.Controls.Add(this.label6);
            this.testDEtailsBox.Controls.Add(this.label5);
            this.testDEtailsBox.Controls.Add(this.lblSeconds);
            this.testDEtailsBox.Controls.Add(this.label4);
            this.testDEtailsBox.Controls.Add(this.lblMinutes);
            this.testDEtailsBox.Controls.Add(this.label3);
            this.testDEtailsBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.testDEtailsBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.testDEtailsBox.Location = new System.Drawing.Point(131, 176);
            this.testDEtailsBox.Name = "testDEtailsBox";
            this.testDEtailsBox.Size = new System.Drawing.Size(1435, 678);
            this.testDEtailsBox.TabIndex = 2;
            this.testDEtailsBox.TabStop = false;
            this.testDEtailsBox.Text = "Test Details";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(56, 473);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 20);
            this.label7.TabIndex = 17;
            this.label7.Text = "C";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(56, 373);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 20);
            this.label6.TabIndex = 16;
            this.label6.Text = "B";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(56, 272);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 20);
            this.label5.TabIndex = 15;
            this.label5.Text = "A";
            // 
            // lblSeconds
            // 
            this.lblSeconds.AutoSize = true;
            this.lblSeconds.Location = new System.Drawing.Point(1146, 13);
            this.lblSeconds.Name = "lblSeconds";
            this.lblSeconds.Size = new System.Drawing.Size(29, 20);
            this.lblSeconds.TabIndex = 3;
            this.lblSeconds.Text = "00";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1136, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = ":";
            // 
            // lblMinutes
            // 
            this.lblMinutes.AutoSize = true;
            this.lblMinutes.Location = new System.Drawing.Point(1111, 13);
            this.lblMinutes.Name = "lblMinutes";
            this.lblMinutes.Size = new System.Drawing.Size(29, 20);
            this.lblMinutes.TabIndex = 1;
            this.lblMinutes.Text = "00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1053, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Time:";
            // 
            // testCandidateDetailsBox
            // 
            this.testCandidateDetailsBox.Controls.Add(this.btnStopTest);
            this.testCandidateDetailsBox.Controls.Add(this.btnStartTest);
            this.testCandidateDetailsBox.Controls.Add(this.candidateListComboBox);
            this.testCandidateDetailsBox.Controls.Add(this.label2);
            this.testCandidateDetailsBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.testCandidateDetailsBox.Location = new System.Drawing.Point(588, 50);
            this.testCandidateDetailsBox.Name = "testCandidateDetailsBox";
            this.testCandidateDetailsBox.Size = new System.Drawing.Size(505, 120);
            this.testCandidateDetailsBox.TabIndex = 1;
            this.testCandidateDetailsBox.TabStop = false;
            this.testCandidateDetailsBox.Text = "Candidate Details";
            // 
            // btnStopTest
            // 
            this.btnStopTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStopTest.ForeColor = System.Drawing.Color.Red;
            this.btnStopTest.Location = new System.Drawing.Point(370, 70);
            this.btnStopTest.Name = "btnStopTest";
            this.btnStopTest.Size = new System.Drawing.Size(111, 28);
            this.btnStopTest.TabIndex = 3;
            this.btnStopTest.Text = "Stop Test";
            this.btnStopTest.UseVisualStyleBackColor = true;
            this.btnStopTest.Visible = false;
            this.btnStopTest.Click += new System.EventHandler(this.btnStopTest_Click);
            // 
            // btnStartTest
            // 
            this.btnStartTest.Enabled = false;
            this.btnStartTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartTest.ForeColor = System.Drawing.Color.Blue;
            this.btnStartTest.Location = new System.Drawing.Point(233, 70);
            this.btnStartTest.Name = "btnStartTest";
            this.btnStartTest.Size = new System.Drawing.Size(122, 28);
            this.btnStartTest.TabIndex = 2;
            this.btnStartTest.Text = "Start Test";
            this.btnStartTest.UseVisualStyleBackColor = true;
            this.btnStartTest.Click += new System.EventHandler(this.btnStartTest_Click_1);
            // 
            // candidateListComboBox
            // 
            this.candidateListComboBox.FormattingEnabled = true;
            this.candidateListComboBox.Location = new System.Drawing.Point(233, 35);
            this.candidateListComboBox.Name = "candidateListComboBox";
            this.candidateListComboBox.Size = new System.Drawing.Size(248, 21);
            this.candidateListComboBox.TabIndex = 1;
            this.candidateListComboBox.SelectedIndexChanged += new System.EventHandler(this.candidateListComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(107, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Select Candidate";
            // 
            // lblAptTitle
            // 
            this.lblAptTitle.AutoSize = true;
            this.lblAptTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAptTitle.Location = new System.Drawing.Point(712, 16);
            this.lblAptTitle.Name = "lblAptTitle";
            this.lblAptTitle.Size = new System.Drawing.Size(240, 31);
            this.lblAptTitle.TabIndex = 0;
            this.lblAptTitle.Text = "APTITUDE TEST";
            // 
            // candidateDetailsGroupBox
            // 
            this.candidateDetailsGroupBox.BackColor = System.Drawing.SystemColors.Control;
            this.candidateDetailsGroupBox.Controls.Add(this.genderComboBox);
            this.candidateDetailsGroupBox.Controls.Add(this.labelGender);
            this.candidateDetailsGroupBox.Controls.Add(this.dateTimePicker1);
            this.candidateDetailsGroupBox.Controls.Add(this.labelDOB);
            this.candidateDetailsGroupBox.Controls.Add(this.textBox1);
            this.candidateDetailsGroupBox.Controls.Add(this.labelLname);
            this.candidateDetailsGroupBox.Controls.Add(this.fnameText);
            this.candidateDetailsGroupBox.Controls.Add(this.labelFname);
            this.candidateDetailsGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.candidateDetailsGroupBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.candidateDetailsGroupBox.Location = new System.Drawing.Point(426, 93);
            this.candidateDetailsGroupBox.Name = "candidateDetailsGroupBox";
            this.candidateDetailsGroupBox.Size = new System.Drawing.Size(723, 237);
            this.candidateDetailsGroupBox.TabIndex = 1;
            this.candidateDetailsGroupBox.TabStop = false;
            this.candidateDetailsGroupBox.Text = "Candidate Details";
            // 
            // genderComboBox
            // 
            this.genderComboBox.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.genderComboBox.FormattingEnabled = true;
            this.genderComboBox.Location = new System.Drawing.Point(242, 135);
            this.genderComboBox.Name = "genderComboBox";
            this.genderComboBox.Size = new System.Drawing.Size(228, 25);
            this.genderComboBox.TabIndex = 7;
            // 
            // labelGender
            // 
            this.labelGender.AutoSize = true;
            this.labelGender.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGender.Location = new System.Drawing.Point(173, 139);
            this.labelGender.Name = "labelGender";
            this.labelGender.Size = new System.Drawing.Size(59, 17);
            this.labelGender.TabIndex = 6;
            this.labelGender.Text = "Gender";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(242, 187);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(228, 24);
            this.dateTimePicker1.TabIndex = 5;
            // 
            // labelDOB
            // 
            this.labelDOB.AutoSize = true;
            this.labelDOB.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDOB.Location = new System.Drawing.Point(137, 187);
            this.labelDOB.Name = "labelDOB";
            this.labelDOB.Size = new System.Drawing.Size(101, 18);
            this.labelDOB.TabIndex = 4;
            this.labelDOB.Text = "Date of birth";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(242, 83);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(228, 26);
            this.textBox1.TabIndex = 3;
            // 
            // labelLname
            // 
            this.labelLname.AutoSize = true;
            this.labelLname.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLname.Location = new System.Drawing.Point(157, 86);
            this.labelLname.Name = "labelLname";
            this.labelLname.Size = new System.Drawing.Size(81, 18);
            this.labelLname.TabIndex = 2;
            this.labelLname.Text = "Lastname";
            // 
            // fnameText
            // 
            this.fnameText.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fnameText.Location = new System.Drawing.Point(242, 41);
            this.fnameText.Name = "fnameText";
            this.fnameText.Size = new System.Drawing.Size(228, 26);
            this.fnameText.TabIndex = 1;
            // 
            // labelFname
            // 
            this.labelFname.AutoSize = true;
            this.labelFname.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFname.Location = new System.Drawing.Point(153, 44);
            this.labelFname.Name = "labelFname";
            this.labelFname.Size = new System.Drawing.Size(82, 18);
            this.labelFname.TabIndex = 0;
            this.labelFname.Text = "Firstname";
            this.labelFname.Click += new System.EventHandler(this.label1_Click);
            // 
            // candidatelabel
            // 
            this.candidatelabel.AutoSize = true;
            this.candidatelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.candidatelabel.Location = new System.Drawing.Point(294, 40);
            this.candidatelabel.Name = "candidatelabel";
            this.candidatelabel.Size = new System.Drawing.Size(283, 25);
            this.candidatelabel.TabIndex = 0;
            this.candidatelabel.Text = "Scheduling Aptitude  Test";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // testDetailsGroup
            // 
            this.testDetailsGroup.Controls.Add(this.testCategoryComboBox);
            this.testDetailsGroup.Controls.Add(this.labelTestCategory);
            this.testDetailsGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.testDetailsGroup.Location = new System.Drawing.Point(426, 355);
            this.testDetailsGroup.Name = "testDetailsGroup";
            this.testDetailsGroup.Size = new System.Drawing.Size(723, 100);
            this.testDetailsGroup.TabIndex = 2;
            this.testDetailsGroup.TabStop = false;
            this.testDetailsGroup.Text = "Test Details";
            // 
            // testCategoryComboBox
            // 
            this.testCategoryComboBox.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.testCategoryComboBox.FormattingEnabled = true;
            this.testCategoryComboBox.Location = new System.Drawing.Point(242, 35);
            this.testCategoryComboBox.Name = "testCategoryComboBox";
            this.testCategoryComboBox.Size = new System.Drawing.Size(400, 25);
            this.testCategoryComboBox.TabIndex = 8;
            // 
            // labelTestCategory
            // 
            this.labelTestCategory.AutoSize = true;
            this.labelTestCategory.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTestCategory.Location = new System.Drawing.Point(126, 38);
            this.labelTestCategory.Name = "labelTestCategory";
            this.labelTestCategory.Size = new System.Drawing.Size(106, 17);
            this.labelTestCategory.TabIndex = 8;
            this.labelTestCategory.Text = "Test Category";
            // 
            // buttonSaveSchdule
            // 
            this.buttonSaveSchdule.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSaveSchdule.Location = new System.Drawing.Point(668, 479);
            this.buttonSaveSchdule.Name = "buttonSaveSchdule";
            this.buttonSaveSchdule.Size = new System.Drawing.Size(228, 29);
            this.buttonSaveSchdule.TabIndex = 3;
            this.buttonSaveSchdule.Text = "Schedule Test";
            this.buttonSaveSchdule.UseVisualStyleBackColor = true;
            this.buttonSaveSchdule.Click += new System.EventHandler(this.buttonSaveSchduleClick);
            // 
            // elapsedTimer
            // 
            this.elapsedTimer.Enabled = true;
            this.elapsedTimer.Interval = 1000;
            this.elapsedTimer.Tick += new System.EventHandler(this.elapsedTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Highway Code Test Aptitude Test Simulator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.mainPanel.ResumeLayout(false);
            this.testDEtailsBox.ResumeLayout(false);
            this.testDEtailsBox.PerformLayout();
            this.testCandidateDetailsBox.ResumeLayout(false);
            this.testCandidateDetailsBox.PerformLayout();
            this.candidateDetailsGroupBox.ResumeLayout(false);
            this.candidateDetailsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.testDetailsGroup.ResumeLayout(false);
            this.testDetailsGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem testManagementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewQuestionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifyQuestionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteQustionsToolStripMenuItem;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ToolStripMenuItem actionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scheduleTestToolStripMenuItem;
        private System.Windows.Forms.Label candidatelabel;
        private System.Windows.Forms.GroupBox candidateDetailsGroupBox;
        private System.Windows.Forms.Label labelFname;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label labelDOB;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label labelLname;
        private System.Windows.Forms.TextBox fnameText;
        private System.Windows.Forms.Label labelGender;
        private System.Windows.Forms.ComboBox genderComboBox;
        private System.Windows.Forms.Button buttonSaveSchdule;
        private System.Windows.Forms.GroupBox testDetailsGroup;
        private System.Windows.Forms.ComboBox testCategoryComboBox;
        private System.Windows.Forms.Label labelTestCategory;
        private System.Windows.Forms.ToolStripMenuItem runTestToolStripMenuItem;
        private System.Windows.Forms.Label lblAptTitle;
        private System.Windows.Forms.GroupBox testCandidateDetailsBox;
        private System.Windows.Forms.ComboBox candidateListComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox testDEtailsBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblMinutes;
        private System.Windows.Forms.Label lblSeconds;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnStartTest;
        private System.Windows.Forms.Button btnStopTest;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Timer elapsedTimer;
        private System.Windows.Forms.Integration.ElementHost elementHost2;
        private QuestionViewWPF questionViewWPF1;
    }
}

