using MySql.Data.MySqlClient;
using NLog;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APTSimulator
{
   public static class HelperTools
    {
        //static Logger logger = LogManager.GetCurrentClassLogger();
      public static  Dictionary<int, int> questionIDSectionID = new Dictionary<int, int>();
        public static ArrayList questionList = new ArrayList();
        public static ArrayList sectionList = new ArrayList();
        public static int testSequenceNumber = 0;

        public static ArrayList allScheduleResults = new ArrayList();
        public static Dictionary<int, int> allQuestionIDansID = new Dictionary<int, int>();
        public static Dictionary<int, int> questionIDansID = new Dictionary<int, int>();
        public static Dictionary<int, int> scorePerSection = new Dictionary<int, int>();
        public static Dictionary<int, int> correctAnswers = new Dictionary<int, int>();
        public static Dictionary<int, int> sectionScores = new Dictionary<int, int>();
        public static Dictionary<int, string> sectionDescription = new Dictionary<int, string>();
        public static Dictionary<int, int> questionsPerSection = new Dictionary<int, int>();
        public static Dictionary<int, string> questionDescription = new Dictionary<int, string>();




        public static MySqlConnection dbConnection()
        {

            string server = "localhost";
            string database = "aptsimulator";
            string uid = "root";
            string password = "zikomo257";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            var conn = new MySqlConnection(connectionString);
            return conn;
            

        }


        


        public static void getScoreperSection(int catID)
        {
            var conn = HelperTools.dbConnection();
            try
            {
                scorePerSection.Clear();
                conn.Open();
                //string query = "SELECT questions_per_section.SECTION_ID,questions_per_section.REQUIRED_SCORE,section.SECTION_DESC FROM questions_per_section INNER JOIN section ON section.SECTION_ID = questions_per_section.SECTION_ID WHERE questions_per_section.CATEGORY_ID=@catID;";
                string query = "SELECT question_section_mapping.SECTION_ID,question_section_mapping.REQUIRED_SCORE,";
                query = query + " section.SECTION_DESC FROM question_section_mapping ";
                query = query + " INNER JOIN section ON section.SECTION_ID=question_section_mapping.SECTION_ID ";
                query = query + " WHERE question_section_mapping.CATEGORY_ID=@catID; ";
              

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@catID", catID);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    scorePerSection.Add(Convert.ToInt32(reader.GetString("SECTION_ID")), Convert.ToInt32(reader.GetString("REQUIRED_SCORE")));
                    sectionDescription.Add(Convert.ToInt32(reader.GetString("SECTION_ID")), reader.GetString("SECTION_DESC"));
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

        public static void markTest(int ScheduleID)
        {

            allScheduleResults.Clear();
            string message = "";
            
            ArrayList scheduleResult = new ArrayList();
            bool oneSectionFailed = false;
            decimal percentage_score = 0;
            int attemptedSectionsCount = 0;
            StringBuilder insertQuery = new StringBuilder("INSERT INTO test_results (TEST_SCHEDULE_ID,TEST_SEQ_NO,SECTION_ID,TEST_SCORE,PASS) VALUES"); 
            string savevalues = "";
            foreach (var SECTION_SCORE in sectionScores)
            {
                savevalues += "(";
                attemptedSectionsCount++;
                scheduleResult.Clear();
                string section_result = "FAILED";
                
                int SID = Convert.ToInt32(SECTION_SCORE.Key);
                string SDE = sectionDescription[SID];
                int SEC_SCORE = Convert.ToInt32(SECTION_SCORE.Value);
                int MIN_SEC_SCORE = scorePerSection[SID];
                int totalSectionQuestions = questionsPerSection[SID];               

                if (SEC_SCORE >= MIN_SEC_SCORE)
                {
                    section_result = "PASSED";
                }
                else
                {
                    oneSectionFailed = true;
                }
                decimal markPercent = Decimal.Divide(SECTION_SCORE.Value,totalSectionQuestions)*100;
                percentage_score += markPercent;
              
                message += "Section: "+SDE+" , Score: "+ SECTION_SCORE.Value+"/"+totalSectionQuestions+" , Result: "+section_result+"\n";

                scheduleResult.Add(ScheduleID);
                scheduleResult.Add(SID);
                scheduleResult.Add(markPercent);
                scheduleResult.Add(section_result);
                allScheduleResults.Add(scheduleResult);
                

                savevalues += scheduleResult[0].ToString() + "," + HelperTools.testSequenceNumber + "," + scheduleResult[1].ToString() + "," + Math.Round(Convert.ToDecimal(scheduleResult[2].ToString()),2) + "," +"'"+ scheduleResult[3].ToString() + "'),";

            }
         
            message += "OVERALL RESULT:"+ Math.Round(Decimal.Divide(percentage_score, sectionScores.Count),2) + "%,  ("+ (oneSectionFailed || attemptedSectionsCount == 0 ? "FAILED" : "PASS") + ")\n";            
            MessageBox.Show(message, "Test Results");            
            
            //saving results;
            insertQuery.Append(string.Join(",", savevalues).TrimEnd(','));
            insertQuery.Append(";");
            MessageBox.Show(insertQuery.ToString());
            var conn = HelperTools.dbConnection();
            try
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(insertQuery.ToString(), conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Test results successfully submitted","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }


                
            }
            catch (MySqlException ex) { MessageBox.Show("Failed to save results \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            catch (InvalidOperationException ex) { MessageBox.Show("An error occured while saving results:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            catch (Exception ex) { MessageBox.Show("An error occured while saving results:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally
            {
                if ((conn.State & ConnectionState.Open) != 0) conn.Close();
            }
            


        }

       

        public static void getSectionDescription()
        {
           var conn = HelperTools.dbConnection();
            try
            {
                conn.Open();
                string query = "SELECT SECTION_ID,SECTION_DESC FROM section";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.CommandText = query;
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    HelperTools.sectionDescription.Add(Convert.ToInt32(reader.GetString("SECTION_ID")), reader.GetString("SECTION_DESC"));
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

    }
}
