using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using System.Collections;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using Google.Protobuf.Collections;
using NLog;
using Newtonsoft.Json;

namespace APTSimulator
{
    public partial class Form1 : Form
    {
        //static Logger logger = LogManager.GetCurrentClassLogger();
        public Form1()
        {
            InitializeComponent();
            //elapsedTimer.Enabled = true;
           // elapsedTimer.Tick += new System.EventHandler(elapsedTime_Tick);
            mainPanel.Controls.Remove(elementHost2);
            //questionViewWPF1.SetCategoryTimeLimit(new TimeSpan(0, 40, 0));
            questionViewWPF1.OnTimeUp += QuestionViewWPF1_OnTimeUp;
            questionViewWPF1.FirstAnswer.Click += btnFirstAnswer_Click;
            questionViewWPF1.SecondAnswer.Click += btnSecondAnswer_Click;
            questionViewWPF1.ThirdAnswer.Click += btnThirdAnswer_Click;
        }

        private void QuestionViewWPF1_OnTimeUp(object sender, EventArgs e)
        {
            questionViewWPF1.InvalidateTimer();
            this.mainPanel.Controls.Clear();
            MessageBox.Show("The test time is up!");
            this.getTestSequenceNumber(this.SCHID);
            HelperTools.markTest(this.SCHID);
            this.stopTest();
        }
        int SCHID;
        int questionCount = 0;
        //int questionsperSection = 3;
        int sectionID = 0;

        int labelStartXPosition = 450;
        int labelStartYPosition = 120;



        bool scheduleStarted = false;
        bool testStarted = false;

        Font labelFont = new Font("Georgia", 16, FontStyle.Regular);
        Font boxFont = new Font("Georgia", 14, FontStyle.Regular);
        Font textFont = new Font("Georgia", 12, FontStyle.Regular);
        Font selectImageButtonFont = new Font("Georgia", 10, FontStyle.Regular);
        Font saveQuestionButtonFont = new Font("Georgia", 16, FontStyle.Bold);


        OpenFileDialog openImageFile = new OpenFileDialog();

        ComboBox questionCategoryBox = new ComboBox();
        ComboBox questionSectionBox = new ComboBox();
        ComboBox answerChoicesBox = new ComboBox();

        TextBox questionNarrationText = new TextBox();
        Label qresponseLabel = new Label();
        PictureBox imageControl = new PictureBox();

        TextBox firstAnswertext = new TextBox();
        TextBox secondAnswertext = new TextBox();
        TextBox thirdAnswertext = new TextBox();


        TextBox candidateFname = new TextBox();
        TextBox candidateLname = new TextBox();
        DateTimePicker candidateDOB = new DateTimePicker();


        private MySqlConnection conn = null;


        public void getQuestionsPerSection(int catID)
        {
            HelperTools.questionsPerSection.Clear();
            conn = HelperTools.dbConnection();
            try
            {
                conn.Open();
                string query = "SELECT SECTION_ID,NUMBER_OF_QUESTIONS FROM question_section_mapping WHERE CATEGORY_ID=@CATID order by SECTION_ID;";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CATID", catID);
                cmd.CommandText = query;
                MySqlDataReader reader = cmd.ExecuteReader();
                HelperTools.sectionDescription.Clear();
                while (reader.Read())
                {
                    HelperTools.questionsPerSection.Add(Convert.ToInt32(reader.GetString("SECTION_ID")), Convert.ToInt32(reader.GetString("NUMBER_OF_QUESTIONS")));

                }

            }
            catch (MySqlException ex) { MessageBox.Show("Failed to connect to the server \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            catch (InvalidOperationException ex) { MessageBox.Show("An error occured while running  the test:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            catch (Exception ex) { MessageBox.Show("An error occured while running the the test:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally
            {
                if ((conn.State & ConnectionState.Open) != 0) conn.Close();
            }

        }

        private void addNewQuestionsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.mainPanel.Controls.Clear();
            conn = HelperTools.dbConnection();
            try
            {

                conn.Open();

                Label title = new Label();
                title.Location = new Point(400, 53);
                title.Text = "ADDING NEW QUESTION";
                title.Font = labelFont;
                title.Size = new System.Drawing.Size(950, 30);

                Label questionCategoryLabel = new Label();
                questionCategoryLabel.Text = "Question Category:";
                questionCategoryLabel.Location = new Point(labelStartXPosition + 10, labelStartYPosition + 10);
                questionCategoryLabel.Font = labelFont;
                questionCategoryLabel.Size = new System.Drawing.Size(200, 26);
                questionCategoryBox.Location = new Point(labelStartXPosition + 220, labelStartYPosition + 10);
                questionCategoryBox.Size = new System.Drawing.Size(500, 26);
                questionCategoryBox.Font = boxFont;

                questionCategoryBox.SelectedIndexChanged += new EventHandler(questionCategoryBox_Click);

                //populating Question category 
                string query = "SELECT CATEGORY_ID,CATEGORY_DESC FROM question_category ORDER BY CATEGORY_ID";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                DataSet ds = new DataSet();
                adapter.SelectCommand = cmd;
                adapter.Fill(ds);
                adapter.Dispose();
                cmd.Dispose();
                try
                {
                    questionCategoryBox.DataSource = ds.Tables[0];
                    questionCategoryBox.DisplayMember = "CATEGORY_DESC";
                    questionCategoryBox.ValueMember = "CATEGORY_ID";


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                Label questionSectionLabel = new Label();
                questionSectionLabel.Text = "Question Section:";
                questionSectionLabel.Location = new Point(labelStartXPosition + 25, labelStartYPosition + 60);
                questionSectionLabel.Font = labelFont;
                questionSectionLabel.Size = new System.Drawing.Size(190, 26);
                questionSectionBox.Location = new Point(labelStartXPosition + 220, labelStartYPosition + 60);
                questionSectionBox.Size = new System.Drawing.Size(500, 26);
                questionSectionBox.Font = boxFont;


                //populating Question Section              
                string query2 = "SELECT SECTION_ID,SECTION_DESC FROM section WHERE CATEGORY_ID=1 ORDER BY SECTION_ID";
                MySqlCommand cmd2 = new MySqlCommand(query2, conn);
                MySqlDataAdapter adapter2 = new MySqlDataAdapter();
                DataSet ds2 = new DataSet();
                adapter2.SelectCommand = cmd2;
                adapter2.Fill(ds2);
                adapter2.Dispose();
                cmd2.Dispose();
                try
                {
                    questionSectionBox.DataSource = ds2.Tables[0];
                    questionSectionBox.DisplayMember = "SECTION_DESC";
                    questionSectionBox.ValueMember = "SECTION_ID";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }




                Label questionNarration = new Label();
                questionNarration.Text = "Narration:";
                questionNarration.Location = new Point(labelStartXPosition + 90, labelStartYPosition + 100);
                questionNarration.Font = labelFont;
                questionNarration.Size = new System.Drawing.Size(120, 26);

                questionNarrationText.Location = new Point(labelStartXPosition + 220, labelStartYPosition + 105);
                questionNarrationText.Size = new System.Drawing.Size(300, 26);
                questionNarrationText.Font = textFont;
                questionNarrationText.Multiline = true;
                questionNarrationText.Width = 500;
                questionNarrationText.Height = 100;
                questionNarrationText.AcceptsTab = true;
                questionNarrationText.WordWrap = true;

                Label questionImage = new Label();
                questionImage.Text = "Image:";
                questionImage.Location = new Point(labelStartXPosition + 120, labelStartYPosition + 220);
                questionImage.Font = labelFont;
                questionImage.Size = new System.Drawing.Size(100, 26);

                Button openImageButton = new Button();
                openImageButton.Width = 120;
                openImageButton.Height = 30;
                openImageButton.Font = selectImageButtonFont;
                openImageButton.Text = "Select Image";
                openImageButton.Location = new Point(labelStartXPosition + 220, labelStartYPosition + 220);
                openImageButton.BackColor = System.Drawing.Color.DarkGray;

                openImageButton.Click += new EventHandler(openImageButton_Click);



                imageControl.Location = new Point(labelStartXPosition + 220, labelStartYPosition + 250);
                imageControl.BackColor = Color.Wheat;
                imageControl.Size = new System.Drawing.Size(140, 140);
                imageControl.SizeMode = PictureBoxSizeMode.StretchImage;
                imageControl.BorderStyle = BorderStyle.Fixed3D;




                //answers

                qresponseLabel.Text = "Capture three possible answers for the question. One of the answers should be selected as correct";
                qresponseLabel.Location = new Point(labelStartXPosition + 20, labelStartYPosition + 400);
                qresponseLabel.Font = labelFont;
                qresponseLabel.Size = new System.Drawing.Size(1000, 26);

                Label firstAnswer = new Label();
                firstAnswer.Text = "1st Answer:";
                firstAnswer.Location = new Point(labelStartXPosition + 70, labelStartYPosition + 450);
                firstAnswer.Font = labelFont;
                firstAnswer.Size = new System.Drawing.Size(150, 26);

                firstAnswertext.Location = new Point(labelStartXPosition + 220, labelStartYPosition + 450);
                firstAnswertext.Width = 500;
                firstAnswertext.Height = 60;
                firstAnswertext.Font = textFont;
                firstAnswertext.Multiline = true;
                firstAnswertext.AcceptsTab = true;
                firstAnswertext.WordWrap = true;


                Label secondAnswer = new Label();
                secondAnswer.Text = "2nd Answer:";
                secondAnswer.Location = new Point(labelStartXPosition + 70, labelStartYPosition + 530);
                secondAnswer.Font = labelFont;
                secondAnswer.Size = new System.Drawing.Size(150, 26);

                secondAnswertext.Location = new Point(labelStartXPosition + 220, labelStartYPosition + 530);
                secondAnswertext.Width = 500;
                secondAnswertext.Height = 60;
                secondAnswertext.Font = textFont;
                secondAnswertext.Multiline = true;
                secondAnswertext.AcceptsTab = true;
                secondAnswertext.WordWrap = true;


                Label thirdAnswer = new Label();
                thirdAnswer.Text = "3rd Answer:";
                thirdAnswer.Location = new Point(labelStartXPosition + 70, labelStartYPosition + 610);
                thirdAnswer.Font = labelFont;
                thirdAnswer.Size = new System.Drawing.Size(150, 26);

                thirdAnswertext.Location = new Point(labelStartXPosition + 220, labelStartYPosition + 610);
                thirdAnswertext.Width = 500;
                thirdAnswertext.Height = 60;
                thirdAnswertext.Font = textFont;
                thirdAnswertext.Multiline = true;
                thirdAnswertext.AcceptsTab = true;
                thirdAnswertext.WordWrap = true;

                //correct answer choice
                Label correctAnswer = new Label();
                correctAnswer.Text = "Correct Answer:";
                correctAnswer.Location = new Point(labelStartXPosition + 40, labelStartYPosition + 700);
                correctAnswer.Font = labelFont;
                correctAnswer.Size = new System.Drawing.Size(200, 26);

                answerChoicesBox.Location = new Point(labelStartXPosition + 220, labelStartYPosition + 700);
                answerChoicesBox.Size = new System.Drawing.Size(250, 26);
                answerChoicesBox.Font = boxFont;

                //populating answer choice         
                string query3 = "SELECT CHOICE_ID,CHOICE_DESCRIPTION FROM correct_response_choices ORDER BY CHOICE_ID";
                MySqlCommand cmd3 = new MySqlCommand(query3, conn);
                MySqlDataAdapter adapter3 = new MySqlDataAdapter();
                DataSet ds3 = new DataSet();
                adapter3.SelectCommand = cmd3;
                adapter3.Fill(ds3);
                adapter3.Dispose();
                cmd3.Dispose();
                try
                {
                    answerChoicesBox.DataSource = ds3.Tables[0];
                    answerChoicesBox.DisplayMember = "CHOICE_DESCRIPTION";
                    answerChoicesBox.ValueMember = "CHOICE_ID";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


                Button saveButton = new Button();
                saveButton.Width = 400;
                saveButton.Height = 60;
                saveButton.Font = saveQuestionButtonFont;
                saveButton.Text = "Save question";
                saveButton.Location = new Point(labelStartXPosition + 220, labelStartYPosition + 800);
                saveButton.BackColor = System.Drawing.Color.DarkSeaGreen;

                saveButton.Click += new EventHandler(saveButton_Click);




                this.mainPanel.Controls.Add(title);
                this.mainPanel.Controls.Add(questionCategoryLabel);
                this.mainPanel.Controls.Add(questionSectionLabel);
                this.mainPanel.Controls.Add(questionNarration);
                this.mainPanel.Controls.Add(questionCategoryBox);
                this.mainPanel.Controls.Add(questionSectionBox);
                this.mainPanel.Controls.Add(questionNarrationText);
                this.mainPanel.Controls.Add(questionImage);
                this.mainPanel.Controls.Add(openImageButton);

                this.mainPanel.Controls.Add(imageControl);
                this.mainPanel.Controls.Add(qresponseLabel);

                this.mainPanel.Controls.Add(firstAnswer);
                this.mainPanel.Controls.Add(secondAnswer);
                this.mainPanel.Controls.Add(thirdAnswer);

                this.mainPanel.Controls.Add(firstAnswertext);
                this.mainPanel.Controls.Add(secondAnswertext);
                this.mainPanel.Controls.Add(thirdAnswertext);

                this.mainPanel.Controls.Add(answerChoicesBox);
                this.mainPanel.Controls.Add(correctAnswer);
                this.mainPanel.Controls.Add(saveButton);

                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to connect to the server. ");
            }


        }
        private void openImageButton_Click(object sender, EventArgs e)
        {

            openImageFile.Title = "Open Image";
            openImageFile.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png, *.gif) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png; *.gif";
            openImageFile.ShowDialog();

            if (openImageFile.ShowDialog() == DialogResult.OK)
            {

                this.imageControl.Image = new Bitmap(openImageFile.FileName);
            }

        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = HelperTools.dbConnection();
                conn.Open();
                string base64ImageString = null;

                if (questionCategoryBox.SelectedIndex > -1)
                {
                    if (questionSectionBox.SelectedIndex > -1)
                    {
                        if (questionNarrationText.Text.Trim().Length > 20)
                        {

                            if (firstAnswertext.Text.Trim().Length > 0)
                            {
                                if (secondAnswertext.Text.Trim().Length > 0)
                                {
                                    if (thirdAnswertext.Text.Trim().Length > 0)
                                    {
                                        if (Int32.Parse(answerChoicesBox.SelectedValue.ToString()) > 0)
                                        {
                                            //VALIDATION COMPLETED
                                            string qNarration = questionNarrationText.Text.Trim();

                                            //CONFIRMING ADDING 
                                            DialogResult dialogResult;
                                            if (this.imageControl.Image != null)
                                            {
                                                dialogResult = MessageBox.Show("Confirm adding the following question with the selected image:\n" + qNarration + ",\nCategory:" + questionCategoryBox.GetItemText(this.questionCategoryBox.SelectedItem) + ", \n Section:" + questionSectionBox.GetItemText(this.questionSectionBox.SelectedItem), "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                            }
                                            else
                                            {
                                                dialogResult = MessageBox.Show("Confirm adding the following question with no image:\n" + qNarration + ",\nCategory:" + questionCategoryBox.GetItemText(this.questionCategoryBox.SelectedItem) + ", \n Section:" + questionSectionBox.GetItemText(this.questionSectionBox.SelectedItem), "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                            }
                                            if (dialogResult == DialogResult.Yes)
                                            {  //confirmed question adding 
                                               //extracting all details                                                            
                                                int qCatID = Int32.Parse(questionCategoryBox.SelectedValue.ToString());
                                                int qSecID = Int32.Parse(questionSectionBox.SelectedValue.ToString());




                                                string qans1 = firstAnswertext.Text.Trim();
                                                string qans2 = secondAnswertext.Text.Trim();
                                                string qans3 = thirdAnswertext.Text.Trim();
                                                int cAndID = Int32.Parse(answerChoicesBox.SelectedValue.ToString());

                                                // int qc ID = Int32.Parse(questionSectionBox.SelectedValue.ToString());

                                                string qesInsertQuery = "insert into question(CATEGORY_ID,SECTION_ID,NARATION,IMG) VALUES(@qCatID,@qSecID,@qNarration,@img)";

                                                MySqlCommand qInsertcmd = new MySqlCommand(qesInsertQuery, conn);
                                                qInsertcmd.CommandText = qesInsertQuery;
                                                try
                                                {

                                                    if (this.imageControl.Image != null)
                                                    {
                                                        MemoryStream ms = new MemoryStream();
                                                        imageControl.Image.Save(ms, imageControl.Image.RawFormat);
                                                        base64ImageString = Convert.ToBase64String(ms.ToArray());
                                                        qInsertcmd.Parameters.AddWithValue("@img", base64ImageString);

                                                    }

                                                    qInsertcmd.Parameters.AddWithValue("@qCatID", qCatID);
                                                    qInsertcmd.Parameters.AddWithValue("@qSecID", qSecID);
                                                    qInsertcmd.Parameters.AddWithValue("@qNarration", qNarration);

                                                    //inserting  into database
                                                    qInsertcmd.ExecuteNonQuery();

                                                    //getting value of last insert ID
                                                    qInsertcmd.Parameters.Add(new MySqlParameter("newId", qInsertcmd.LastInsertedId));
                                                    int qID = Convert.ToInt32(qInsertcmd.Parameters["@newId"].Value);

                                                    int ans1_resTPID = 2;
                                                    int ans2_resTPID = 2;
                                                    int ans3_resTPID = 2;

                                                    switch (cAndID)
                                                    {
                                                        case 1:
                                                            ans1_resTPID = 1;
                                                            break;
                                                        case 2:
                                                            ans2_resTPID = 1;
                                                            break;
                                                        case 3:
                                                            ans3_resTPID = 1;
                                                            break;

                                                    }

                                                    string resInsertQuery1 = "INSERT INTO response (QUESTION_ID,RESPONSE_TYPE_ID,SEQUENSE_NUMBER_IN_QUESTION,NARATION) VALUES ('" + qID + "', '" + ans1_resTPID + "','" + 1 + "','" + qans1 + "')";
                                                    MySqlCommand resInsertcmd1 = new MySqlCommand(resInsertQuery1, conn);
                                                    resInsertcmd1.CommandText = resInsertQuery1;
                                                    resInsertcmd1.ExecuteNonQuery();

                                                    string resInsertQuery2 = "INSERT INTO response (QUESTION_ID,RESPONSE_TYPE_ID,SEQUENSE_NUMBER_IN_QUESTION,NARATION) VALUES ('" + qID + "', '" + ans2_resTPID + "','" + 2 + "','" + qans2 + "')";
                                                    MySqlCommand resInsertcmd2 = new MySqlCommand(resInsertQuery2, conn);
                                                    resInsertcmd2.CommandText = resInsertQuery2;
                                                    resInsertcmd2.ExecuteNonQuery();

                                                    string resInsertQuery3 = "INSERT INTO response (QUESTION_ID,RESPONSE_TYPE_ID,SEQUENSE_NUMBER_IN_QUESTION,NARATION) VALUES ('" + qID + "', '" + ans3_resTPID + "','" + 3 + "','" + qans3 + "')";
                                                    MySqlCommand resInsertcmd3 = new MySqlCommand(resInsertQuery3, conn);
                                                    resInsertcmd3.CommandText = resInsertQuery3;
                                                    resInsertcmd3.ExecuteNonQuery();





                                                    MessageBox.Show("Question successfully saved in the question bank.", "Success:", MessageBoxButtons.OK, MessageBoxIcon.Information);




                                                    //clearing controls
                                                    questionNarrationText.Text = "";
                                                    firstAnswertext.Text = "";
                                                    secondAnswertext.Text = "";
                                                    thirdAnswertext.Text = "";
                                                    imageControl.Image = null;



                                                }
                                                catch (MySqlException ex) { MessageBox.Show("Error:" + ex.Message, "Error:", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                                catch (Exception ex) { MessageBox.Show("Error:" + ex.Message, "Error:", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                                            }


                                        }
                                        else
                                        {
                                            MessageBox.Show("Select at least correct answer for the question", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            answerChoicesBox.Focus();
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Enter valid response for 3rd  answer", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        thirdAnswertext.Focus();
                                    }

                                }
                                else
                                {
                                    MessageBox.Show("Enter valid response for 2nd answer", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    secondAnswertext.Focus();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Enter valid response for 1st answer", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                firstAnswertext.Focus();
                            }

                        }
                        else
                        {
                            MessageBox.Show("Enter valid question narration with at least 20 characters", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            questionNarrationText.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Select question section", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        questionSectionBox.Focus();
                    }

                }
                else
                {
                    MessageBox.Show("Select question category", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    questionCategoryBox.Focus();
                }

                conn.Close();

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }


        }
        private void questionCategoryBox_Click(object sender, EventArgs e)
        {
            try
            {
                string questionCategoryID = "";

                if (questionCategoryBox.SelectedValue.ToString() != "")
                {
                    questionCategoryID = questionCategoryBox.SelectedValue.ToString();
                    questionSectionBox.DataSource = null;
                    questionSectionBox.Items.Clear();
                    conn.Open();
                    string query = "SELECT SECTION_ID,SECTION_DESC FROM section WHERE CATEGORY_ID=@CATID;";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.Add(new MySqlParameter("@CATID", questionCategoryID));

                    MySqlDataAdapter adapter = new MySqlDataAdapter();
                    DataSet ds = new DataSet();
                    adapter.SelectCommand = cmd;
                    adapter.Fill(ds);
                    adapter.Dispose();
                    cmd.Dispose();
                    try
                    {
                        questionSectionBox.DataSource = ds.Tables[0];
                        questionSectionBox.DisplayMember = "SECTION_DESC";
                        questionSectionBox.ValueMember = "SECTION_ID";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    conn.Close();

                }

            }
            catch (NullReferenceException ex)
            {
                // Do something with e, please.
            }


        }




        private void Form1_Load(object sender, EventArgs e)
        {

            WindowState = FormWindowState.Maximized;
        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void buttonSaveSchduleClick(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = HelperTools.dbConnection();
                conn.Open();


                if (fnameText.Text.Trim() != "")
                {
                    if (textBox1.Text.Trim() != "")
                    {
                        DialogResult d = MessageBox.Show("Confirm scheduling the test for the candidate?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (d == DialogResult.Yes)
                        {
                            string fname = fnameText.Text.Trim().ToUpper();
                            string lname = textBox1.Text.ToUpper();
                            DateTime dob = dateTimePicker1.Value;
                            int genderID = Int32.Parse(genderComboBox.SelectedValue.ToString());
                            int testCategoryID = Int32.Parse(testCategoryComboBox.SelectedValue.ToString());


                            //saving schedule  into database
                            string qesInsertQuery = "INSERT INTO test_schedule(CATEGORY_ID,CANDIDATE_FNAME,CANDIDATE_LNAME,CANDIDATE_DOB,CANDIDATE_GENDER) VALUES(@catID,@fname,@lname,@dob,@gender)";
                            MySqlCommand scheduleInsertcmd = new MySqlCommand(qesInsertQuery, conn);
                            scheduleInsertcmd.CommandText = qesInsertQuery;
                            scheduleInsertcmd.Parameters.AddWithValue("@catID", testCategoryID);
                            scheduleInsertcmd.Parameters.AddWithValue("@fname", fname);
                            scheduleInsertcmd.Parameters.AddWithValue("@lname", lname);
                            scheduleInsertcmd.Parameters.AddWithValue("@dob", dob);
                            scheduleInsertcmd.Parameters.AddWithValue("@gender", genderID);
                            scheduleInsertcmd.ExecuteNonQuery();

                            MessageBox.Show("The test has been  successfully scheduled.", "Success:", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            fnameText.Text = "";
                            textBox1.Text = "";
                            this.scheduleStarted = false;

                        }
                    }
                    else
                    {
                        MessageBox.Show("Enter candidate's last name", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox1.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Enter candidate's first name", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    fnameText.Focus();
                }

            }
            catch (MySqlException ex) { MessageBox.Show("An error occured while scheduling the test:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }


            catch (Exception ex) { MessageBox.Show("An error occured while scheduling the test:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        public void scheduleTest()
        {
            conn = HelperTools.dbConnection();
            this.mainPanel.Controls.Clear();

            this.lblMinutes.Text = "00";
            this.lblSeconds.Text = "00";


            try
            {

                conn.Open();
                this.dateTimePicker1.MinDate = new System.DateTime(DateTime.Now.Year - 80, 1, 1);
                this.dateTimePicker1.MaxDate = new System.DateTime(DateTime.Now.Year - 16, 12, 31);
                this.mainPanel.Controls.Add(this.candidatelabel);
                this.mainPanel.Controls.Add(this.buttonSaveSchdule);
                this.mainPanel.Controls.Add(this.testDetailsGroup);
                this.mainPanel.Controls.Add(this.candidateDetailsGroupBox);
                this.mainPanel.Controls.Add(this.candidatelabel);


                //populating gender          
                string query = "SELECT CANDIDATE_GENDER_ID,GENDER_DESC FROM gender ORDER BY gender.CANDIDATE_GENDER_ID ASC";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                DataSet ds = new DataSet();
                adapter.SelectCommand = cmd;
                adapter.Fill(ds);
                adapter.Dispose();
                cmd.Dispose();
                try
                {
                    this.genderComboBox.DataSource = ds.Tables[0];
                    this.genderComboBox.DisplayMember = "GENDER_DESC";
                    this.genderComboBox.ValueMember = "CANDIDATE_GENDER_ID";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                //populating gender          
                query = "SELECT CATEGORY_ID,CATEGORY_DESC FROM question_category WHERE CATEGORY_ID IN (SELECT DISTINCT(CATEGORY_ID) FROM question_section_mapping)";
                MySqlCommand cmd2 = new MySqlCommand(query, conn);
                MySqlDataAdapter adapter2 = new MySqlDataAdapter();
                DataSet ds2 = new DataSet();
                adapter2.SelectCommand = cmd2;
                adapter2.Fill(ds2);
                adapter2.Dispose();
                cmd2.Dispose();
                try
                {
                    this.testCategoryComboBox.DataSource = ds2.Tables[0];
                    this.testCategoryComboBox.DisplayMember = "CATEGORY_DESC";
                    this.testCategoryComboBox.ValueMember = "CATEGORY_ID";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                conn.Close();


            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Failed to shedule the test."+ ex.Message, "Error!", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void scheduleTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scheduleStarted = true;
            if (!this.testStarted)
            {
                this.runTestToolStripMenuItem.Enabled = true;
                this.scheduleTestToolStripMenuItem.Enabled = false;
                scheduleTest();
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("The test is still in session. Are you sure you want to cancel? ", "Confirm", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    //do something
                    this.stopTest();
                    scheduleTest();
                    this.scheduleTestToolStripMenuItem.Enabled = false;
                    this.runTestToolStripMenuItem.Enabled = true;

                }
                else if (dialogResult == DialogResult.No)
                {
                    this.runTestToolStripMenuItem.Enabled = true;
                }
            }


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void actionsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        public void runTest()
        {
            this.scheduleTestToolStripMenuItem.Enabled = true;
            scheduleStarted = false;
            this.mainPanel.Controls.Clear();
            HelperTools.questionIDSectionID.Clear();
            HelperTools.questionList.Clear();
            conn = HelperTools.dbConnection();
            
            try
            {
                conn.Open();


                string query = "SELECT * FROM question WHERE question.QUESTION_STATUS_ID=1";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.CommandText = query;
                if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                {
                    try
                    {
                        //question bank has valid questions
                        //attempting to schedule--------------------------------------------------------------------------------
                        query = "SELECT SCHEDULE_ID,CATEGORY_ID, CONCAT(CANDIDATE_FNAME,' ',CANDIDATE_LNAME) AS NAME FROM test_schedule WHERE test_schedule.SCHEDULE_STATUS_ID = 1";
                        MySqlCommand cmd2 = new MySqlCommand(query, conn);
                        int numberOfRecords = Convert.ToInt32(cmd2.ExecuteScalar());

                        MySqlDataAdapter adapter2 = new MySqlDataAdapter();
                        DataSet ds2 = new DataSet();
                        adapter2.SelectCommand = cmd2;
                        int rows = adapter2.Fill(ds2);
                        adapter2.Dispose();
                        cmd2.Dispose();
                        if (numberOfRecords > 0)
                        {
                            try
                            {
                                this.mainPanel.Controls.Add(this.lblAptTitle);
                                mainPanel.Controls.Add(candidateListComboBox);
                                mainPanel.Controls.Add(btnStartTest);
                                this.candidateListComboBox.DataSource = ds2.Tables[0];
                                this.candidateListComboBox.DisplayMember = "NAME".ToUpper();
                                this.candidateListComboBox.ValueMember = "SCHEDULE_ID";
                            }
                            catch (MySqlException ex) { MessageBox.Show("Failed to connect to the server", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                            catch (Exception ex) { MessageBox.Show("An error occured while initilizing the test:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        }
                        else
                        {
                            MessageBox.Show("There are no candidates scheduled for an aptitude test", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        //end of scheduling--------------------------------------------------------------------------------------                   
                    }
                    catch (MySqlException ex) { MessageBox.Show("Failed to connect to the server", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    catch (Exception ex) { MessageBox.Show("An error occured while initilizing the test:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                else
                {
                    MessageBox.Show("The test could not be scheduled because there are no valid questions in the question bank.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                conn.Close();
            }
            catch (MySqlException ex) { MessageBox.Show("Failed to connect to the server", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            catch (Exception ex) { MessageBox.Show("An error occured while initilizing the test:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void runTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!scheduleStarted)
            {
                this.scheduleTestToolStripMenuItem.Enabled = false;
                this.runTestToolStripMenuItem.Enabled = false;
                this.getCategoryDescription();
                runTest();
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("The test scheduling has not been completed. Are you sure you want to cancel scheduling?", "Confirm", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    runTest();
                    this.scheduleTestToolStripMenuItem.Enabled = true;
                    this.runTestToolStripMenuItem.Enabled = true;
                }
                else if (dialogResult == DialogResult.No)
                {
                    //donot anything
                    this.runTestToolStripMenuItem.Enabled = false;
                    this.scheduleTestToolStripMenuItem.Enabled = false;
                }
            }



        }

        private void btnStartTest_Click_1(object sender, EventArgs e)
        {

            if (candidateListComboBox.SelectedIndex > -1)
            {
                this.runTestToolStripMenuItem.Enabled = false;
                HelperTools.questionIDSectionID.Clear();
                HelperTools.questionList.Clear();
                HelperTools.getSectionDescription();
                HelperTools.sectionDescription.Clear();
                String query = "";
                int categoryID = 0;

                bool schedule_valid = false;
                bool question_for_sections_prepared = false;
                bool question_and_section_list_prepared = false;

                //checking if the selected candidate's schedule is still valid
                try
                {
                    conn = HelperTools.dbConnection();
                    conn.Open();
                    this.SCHID = Int32.Parse(this.candidateListComboBox.SelectedValue.ToString());
                    query = "SELECT CATEGORY_ID FROM test_schedule WHERE test_schedule.SCHEDULE_STATUS_ID = 1 AND  SCHEDULE_ID=@SCHID;";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@SCHID", SCHID);
                    categoryID = Convert.ToInt32(cmd.ExecuteScalar());
                    if (categoryID > 0)
                    {
                        schedule_valid = true;
                    }
                    else
                    {
                        schedule_valid = false;
                    }
                }
                catch (MySqlException ex) { MessageBox.Show("Failed to connect to the server \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                catch (InvalidOperationException ex) { MessageBox.Show("An error occured while initilizing the test:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                catch (Exception ex) { MessageBox.Show("An error occured while initilizing the test:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                finally
                {
                    if ((conn.State & ConnectionState.Open) != 0) conn.Close();
                }

                if (schedule_valid)
                {
                    //schedule is valid
                    //populating questions for the sections
                    getQuestionsPerSection(categoryID);
                    //HelperTools.questionsPerSection should be  populated                           
                    if (HelperTools.questionsPerSection.Count > 0)
                    {
                        question_for_sections_prepared = true;
                    }
                    else
                    {
                        MessageBox.Show("Failed to retrieve questions for sections", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }

                else
                {
                    MessageBox.Show("The selected candidate does not have a valid test schedule", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                //preparing questions and randomizing them
                if (question_for_sections_prepared)
                {                    
                    try
                    {
                        conn = HelperTools.dbConnection();
                        conn.Open();
                        query = "SELECT QUESTION_ID,SECTION_ID FROM question WHERE QUESTION_STATUS_ID=1 AND SECTION_ID IN(SELECT SECTION_ID FROM question_section_mapping WHERE CATEGORY_ID = @CATID) AND SECTION_ID!= 1 ORDER BY QUESTION_ID ASC;";
                        MySqlCommand cmd4 = new MySqlCommand(query, conn);
                        cmd4.CommandText = query;
                        cmd4.Parameters.AddWithValue("@CATID", categoryID);
                        MySqlDataReader reader = cmd4.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                HelperTools.questionIDSectionID.Add(Convert.ToInt32(reader.GetString(0)), Convert.ToInt32(reader.GetString(1)));
                            }
                            //questionIDSectionID.OrderBy(i => i.Key);
                            foreach (int sectionID in (HelperTools.questionIDSectionID.Values.Distinct()))
                            {
                                int number_of_questions_Per_Section = HelperTools.questionsPerSection[sectionID];
                                foreach (var questionID in (HelperTools.questionIDSectionID.Where(d => d.Value.Equals(sectionID)).Select(d => d.Key).Take(number_of_questions_Per_Section).OrderBy(x => Guid.NewGuid()).ToList()))
                                {
                                    HelperTools.questionList.Add(questionID);

                                }
                                HelperTools.sectionList.Add(sectionID);
                            }
                            reader.Close();
                            cmd4.Dispose();
                            if (true)
                            {
                                question_and_section_list_prepared = true;
                            }
                        }
                        else
                        {
                            question_and_section_list_prepared = false;
                        }

                    }

                    catch (MySqlException ex) { MessageBox.Show("Failed to connect to the server \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    catch (InvalidOperationException ex) { MessageBox.Show("An error occured while initilizing the test:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    catch (Exception ex) { MessageBox.Show("An error occured while initilizing the test:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    finally
                    {
                        if ((conn.State & ConnectionState.Open) != 0) conn.Close();
                    }
                }
                //displaying  first question and answer details
                if (question_and_section_list_prepared)
                     {
                        //MessageBox.Show("Finished preparing questions and randomizing them");
                        try
                        {
                            conn = HelperTools.dbConnection();
                            conn.Open();
                            //------------------------------------------------------------------------------------
                            query = "select question.SECTION_ID, ";
                            query = query + " section.SECTION_DESC, ";
                            query = query + " question.NARATION AS QNA, ";
                            query = query + " question.IMG AS IMG, ";
                            query = query + " response.RESPONSE_ID AS RID, ";
                            query = query + " response.RESPONSE_TYPE_ID AS R_TP_ID, ";
                            query = query + " response.SEQUENSE_NUMBER_IN_QUESTION AS RES_SEQ_ID, ";
                            query = query + " response.NARATION  ";
                            query = query + " FROM  ";
                            query = query + " question  ";
                            query = query + " inner join response ON question.QUESTION_ID = response.QUESTION_ID  ";
                            query = query + " inner join section on section.SECTION_ID=question.SECTION_ID  ";
                            query = query + "  where  question.QUESTION_ID ='" + HelperTools.questionList[0] + "'; ";

                            MySqlCommand cmd5 = new MySqlCommand(query, conn);
                            cmd5.CommandText = query;


                            MySqlDataReader reader2 = cmd5.ExecuteReader();

                            string SectionDesc = "";
                            string questionNarration = "";
                            string base64ImageString = null;

                            ArrayList answerList = new ArrayList();
                            if (reader2.HasRows)
                                  {
                                        while (reader2.Read())
                                        {
                                            answerList.Add(reader2.GetString("NARATION"));
                                            SectionDesc = reader2.GetString("SECTION_DESC");
                                            questionNarration = reader2.GetString("QNA");
                                            sectionID = Convert.ToInt32(reader2.GetString("SECTION_ID"));
                                                try
                                                {
                                                    base64ImageString = reader2.GetString("IMG");
                                                }
                                                catch (Exception)
                                                {

                                                }
                                         }
                            questionViewWPF1.SetCategoryTimeLimit(new TimeSpan(0, HelperTools.questionList.Count, 0));

                            //questionViewWPF1.SetCategoryTimeLimit(new TimeSpan(0, HelperTools.questionList.Count, 0));
                                        questionViewWPF1.SetCategory("Theoretical Test Questions for " + HelperTools.questionDescription[categoryID]);

                                        questionViewWPF1.SetSectionDescription(SectionDesc.ToUpper());
                                        questionViewWPF1.QuestionNo.Content = 1;
                                        questionViewWPF1.Question.Text = questionNarration;
                                        questionViewWPF1.firstAnsertext.Text = answerList[0].ToString();
                                        questionViewWPF1.secondAnsertext.Text = answerList[1].ToString();
                                        questionViewWPF1.thirdAnswertext.Text = answerList[2].ToString();
                                    if (!string.IsNullOrEmpty(base64ImageString))
                                    {

                                        byte[] imageBytes = Convert.FromBase64String(base64ImageString);
                                        MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
                                        ms.Write(imageBytes, 0, imageBytes.Length);
                                        questionViewWPF1.setIllustration(System.Drawing.Image.FromStream(ms, true));

                                    }
                                    else
                                    {
                                        questionViewWPF1.setIllustration(null);
                                    }

                                    HelperTools.getScoreperSection(categoryID);
                                    this.mainPanel.Controls.Add(this.testDEtailsBox);
                                    this.testStarted = true;
                                    this.candidateListComboBox.Enabled = false;
                                    this.btnStartTest.Visible = false;
                                    this.btnStopTest.Visible = true;

                            HelperTools.correctAnswers = getCorrectAnswer();

                            mainPanel.Controls.Clear();
                            this.StartTest();

                        }
                            else
                                {
                                    MessageBox.Show("Failed to load questions from the question bank.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }

                            //----------------------------------------------------------------------------------

                    }
                        catch (MySqlException ex) { MessageBox.Show("Failed to connect to the server \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        catch (InvalidOperationException ex) { MessageBox.Show("An error occured while initilizing the test:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        catch (Exception ex) { MessageBox.Show("An error occured while initilizing the test:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        finally
                        {
                            if ((conn.State & ConnectionState.Open) != 0) conn.Close();
                        }
                    }
                else
                    {
                    MessageBox.Show("The application failed to prepare question list for the test", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }

                }
                else
                {
                    this.mainPanel.Controls.Remove(this.testDEtailsBox);
                }
            }

        private void StartTest()
        {
            this.testStarted = true;
            elapsedTimer.Start();
            elapsed = new TimeSpan();
            mainPanel.Controls.Add(elementHost2);
        }

        private void candidateListComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (candidateListComboBox.SelectedIndex > -1)
            {
                this.btnStartTest.Enabled = true;
                this.btnStartTest.ForeColor = System.Drawing.Color.Blue;
            }
            else
            {
                this.btnStartTest.Enabled = false;
            }
        }

        private void btnStopTest_Click(object sender, EventArgs e)
        {

            DialogResult d = MessageBox.Show("Are you sure you want to stop the test?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d == DialogResult.Yes)
            {
                this.testStarted = false;
                questionCount = 0;
                HelperTools.questionIDSectionID.Clear();
                HelperTools.questionIDSectionID.Clear();
                HelperTools.questionList.Clear();
                HelperTools.questionIDansID.Clear();
                HelperTools.sectionList.Clear();
                HelperTools.scorePerSection.Clear();
                HelperTools.sectionScores.Clear();
                HelperTools.sectionDescription.Clear();
                HelperTools.questionsPerSection.Clear();


                
                this.lblSeconds.Text = "00";
                this.lblMinutes.Text = "00";
                this.scheduleTestToolStripMenuItem.Enabled = true;
                this.runTestToolStripMenuItem.Enabled = true;
                this.candidateListComboBox.Enabled = true;
                this.btnStartTest.Visible = true;
                this.btnStopTest.Visible = false;
                this.mainPanel.Controls.Remove(this.testDEtailsBox);
                questionViewWPF1.setIllustration(null);
            }
        }


        private void stopTest()
        {

            questionCount = 0;
            HelperTools.questionIDSectionID.Clear();
            HelperTools.questionList.Clear();
            HelperTools.questionIDansID.Clear();
            HelperTools.sectionList.Clear();
            HelperTools.sectionScores.Clear();
            HelperTools.sectionDescription.Clear();
            HelperTools.questionsPerSection.Clear();


            this.scheduleTestToolStripMenuItem.Enabled = true;
            this.runTestToolStripMenuItem.Enabled = true;
            this.candidateListComboBox.Enabled = true;
            this.btnStartTest.Visible = true;
            this.btnStopTest.Visible = false;
            this.mainPanel.Controls.Remove(this.testDEtailsBox);

            questionViewWPF1.setIllustration(null);

        }

       
        private void showNextQuestion(int QID, int qCount)
        {

            try
            {

                conn = HelperTools.dbConnection();
                conn.Open();
                //querying question and answer details
                string query = "select question.SECTION_ID, ";
                query = query + " section.SECTION_DESC, ";
                query = query + " question.NARATION AS QNA, ";
                query = query + " question.IMG AS IMG, ";
                query = query + " response.RESPONSE_ID AS RID, ";
                query = query + " response.RESPONSE_TYPE_ID AS R_TP_ID, ";
                query = query + " response.SEQUENSE_NUMBER_IN_QUESTION AS RES_SEQ_ID, ";
                query = query + " response.NARATION  ";
                query = query + " FROM  ";
                query = query + " question  ";
                query = query + " inner join response ON question.QUESTION_ID = response.QUESTION_ID  ";
                query = query + " inner join section on section.SECTION_ID=question.SECTION_ID  ";
                query = query + "  where  question.QUESTION_ID =@QID; ";


               
                
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@QID", QID);
                MySqlDataReader reader = cmd.ExecuteReader();

              
                string SectionDesc = "";
                string questionNarration = "";
                string base64ImageString = null;
                ArrayList answerList = new ArrayList();


                while (reader.Read())
                {

                    answerList.Add(reader.GetString("NARATION"));                    
                    SectionDesc = reader.GetString("SECTION_DESC");
                    questionNarration = reader.GetString("QNA");
                    sectionID = Convert.ToInt32(reader.GetString("SECTION_ID"));
                    try
                    {
                        base64ImageString = reader.GetString("IMG");
                    }
                    catch (Exception)
                    {


                    }

                }

                questionViewWPF1.SetSectionDescription(SectionDesc.ToUpper());
                questionViewWPF1.QuestionNo.Content = (qCount + 1);
                questionViewWPF1.Question.Text = questionNarration;
                questionViewWPF1.firstAnsertext.Text = answerList[0].ToString();
                questionViewWPF1.secondAnsertext.Text = answerList[1].ToString();
                questionViewWPF1.thirdAnswertext.Text = answerList[2].ToString();

                if (!string.IsNullOrEmpty(base64ImageString))
                {


                    byte[] imageBytes = Convert.FromBase64String(base64ImageString);
                    MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
                    ms.Write(imageBytes, 0, imageBytes.Length);
                    questionViewWPF1.setIllustration(System.Drawing.Image.FromStream(ms, true));
                }
                else
                {
                    questionViewWPF1.setIllustration(null);
                }


            }
            catch (MySqlException ex) { MessageBox.Show("Failed to connect to the server \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            catch (InvalidOperationException ex) { MessageBox.Show("An error occured while running  the test:\n" + ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            catch (Exception ex) { MessageBox.Show("An error occured while running the the test:\n" + ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally
            {
                if ((conn.State & ConnectionState.Open) != 0) conn.Close();
            }


        }

        private void btnFirstAnswer_Click(object sender, EventArgs e)
        {
            ProcessAnswerButton(1);
        }
        private void btnSecondAnswer_Click(object sender, EventArgs e)
        {
            ProcessAnswerButton(2);
        }

        private void btnThirdAnswer_Click(object sender, EventArgs e)
        {
            ProcessAnswerButton(3);
        }

        private void ProcessAnswerButton(int answerNo)
        {
            //Initialize section score to zero if not set 
           if( !HelperTools.sectionScores.ContainsKey(sectionID))
            {
                HelperTools.sectionScores.Add(sectionID, 0);
            }

            if (questionCount < HelperTools.questionList.Count)
            {
                HelperTools.questionIDansID.Add(Convert.ToInt32(HelperTools.questionList[questionCount]), answerNo);
       
                if (HelperTools.correctAnswers[Convert.ToInt32(HelperTools.questionList[questionCount])] == answerNo)
                {

                    int currentScore;
                    if (HelperTools.sectionScores.Keys.Any(key => key.Equals(sectionID)))
                    {
                        currentScore = Convert.ToInt32(HelperTools.sectionScores[sectionID]);
                    }
                    else
                    {
                        currentScore = 0;
                    }
                    HelperTools.sectionScores[sectionID] = currentScore + 1;
                }
                else
                {
                }
                //logger.Info(JsonConvert.
                   // SerializeObject(HelperTools.sectionScores,
                   // Formatting.Indented));
            }


            questionCount = questionCount + 1;
            try
            {
                if (questionCount < HelperTools.questionList.Count)
                {
                    showNextQuestion(Convert.ToInt32(HelperTools.questionList[questionCount]), questionCount);
                }
                else
                {
                    elapsedTimer.Stop();
                    this.mainPanel.Controls.Clear();
                    questionViewWPF1.InvalidateTimer();
                    this.getTestSequenceNumber(this.SCHID);
                    HelperTools.markTest(this.SCHID);
                    this.stopTest();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void  getTestSequenceNumber(int ScheduleID)
        {
            conn = HelperTools.dbConnection();
            conn.Open();
            try
            {
                string query = "SELECT MAX(test_results.TEST_SEQ_NO) AS MAX_SCHEDULE_ID FROM test_results WHERE test_results.TEST_SCHEDULE_ID =@SCHID; ";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@SCHID", ScheduleID);
                MySqlDataReader reader = cmd.ExecuteReader();
                int seqNumPos = reader.GetOrdinal("MAX_SCHEDULE_ID");
                while (reader.Read())
                {
                    string seqNo= reader.IsDBNull(seqNumPos)? "0":reader.GetString("MAX_SCHEDULE_ID");
                    HelperTools.testSequenceNumber=Convert.ToInt32(seqNo) +1;
                }
                //MessageBox.Show(HelperTools.testSequenceNumber.ToString());

            }
            catch (MySqlException ex) { MessageBox.Show("Failed to connect to the server \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            catch (InvalidOperationException ex) { MessageBox.Show("An error occured retrieving test sequence number:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            catch (Exception ex) { MessageBox.Show("An error occured while retrieving test sequence number:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally
            {
                if ((conn.State & ConnectionState.Open) != 0) conn.Close();
            }
           
        }
        public Dictionary<int, string> getCategoryDescription()
        {
            conn = HelperTools.dbConnection();
            try
            {
                HelperTools.questionDescription.Clear();
                conn.Open();
                string query = "SELECT CATEGORY_ID,CATEGORY_DESC FROM question_category ";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.CommandText = query;               
                MySqlDataReader reader = cmd.ExecuteReader();
                ArrayList answerList = new ArrayList();
                while (reader.Read())
                {                 
                    HelperTools.questionDescription.Add(Convert.ToInt32(reader.GetString(0)), reader.GetString(1));

                }
                reader.Close();
                cmd.Dispose();
            }           

            catch (MySqlException ex) { MessageBox.Show("Failed to connect to the server \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            catch (InvalidOperationException ex) { MessageBox.Show("An error occured retrieving category descriptions:\n" + ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            catch (Exception ex) { MessageBox.Show("An error occured while retrieving category descriptions:\n" + ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally
            {
                if ((conn.State & ConnectionState.Open) != 0) conn.Close();
            }
            return null;
        }


        public Dictionary<int, int> getCorrectAnswer()
        {
            Dictionary<int, int> correctAnswerList = new Dictionary<int, int>();
            try
            {

                conn = HelperTools.dbConnection();
                conn.Open();

                string questionIDs = " (";
                for (int index = 0; index < HelperTools.questionList.Count; index++)
                {
                    if (index < HelperTools.questionList.Count - 1)
                    {
                        questionIDs += HelperTools.questionList[index] + ",";
                    }
                    else
                    {
                        questionIDs += HelperTools.questionList[index];
                    }

                }
                questionIDs += ")";

                string query = "SELECT question.QUESTION_ID, response.SEQUENSE_NUMBER_IN_QUESTION  FROM response INNER JOIN question ON question.QUESTION_ID=response.QUESTION_ID AND RESPONSE_TYPE_ID = 1 AND question.QUESTION_ID IN " + questionIDs;
              
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.CommandText = query;
                MySqlDataReader reader = cmd.ExecuteReader();

                ArrayList answerList = new ArrayList();


                while (reader.Read())
                {

                    // correctAnswerList.Add(reader.GetString("NARATION"));
                    correctAnswerList.Add(Convert.ToInt32(reader.GetString(0)), Convert.ToInt32(reader.GetString(1)));

                }
            }
            catch (MySqlException ex) { MessageBox.Show("Failed to connect to the server \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            catch (InvalidOperationException ex) { MessageBox.Show("An error occured while running  the test:\n" + ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            catch (Exception ex) { MessageBox.Show("An error occured while running the the test:\n" + ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally
            {
                if ((conn.State & ConnectionState.Open) != 0) conn.Close();
            }
            return correctAnswerList;
        }

        TimeSpan elapsed = new TimeSpan();
        private void elapsedTime_Tick(object sender, EventArgs e)
        {

           

        }



        private void elementHost2_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void testResultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void elapsedTimer_Tick(object sender, EventArgs e)
        {
            if (this.testStarted)
            {
                elapsed = elapsed.Add(new TimeSpan(0, 0, 0, 0, (sender as Timer).Interval));
                questionViewWPF1.SetElapsedTime(elapsed);
            }
          
        }

        private void testResultsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            reports rp = new reports();
            this.Hide();
            rp.ShowDialog();
        }
    }
}
