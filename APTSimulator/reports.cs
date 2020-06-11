using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APTSimulator
{
    public partial class reports : Form
    {
        public reports()
        {
            InitializeComponent();
            this.comboBox1.SelectedItem= "Select";
        }
        private MySqlConnection conn = null;
        private void reports_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 f1 = new APTSimulator.Form1();
            f1.Visible = true;
            this.Hide();

        }

        private void reports_Load(object sender, EventArgs e)
        {

            conn = HelperTools.dbConnection();
            try
            {
                conn.Open();
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
                    comboBox2.DataSource = ds.Tables[0];
                    comboBox2.DisplayMember = "CATEGORY_DESC";
                    comboBox2.ValueMember = "CATEGORY_ID";


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            catch (MySqlException ex) { MessageBox.Show("Failed to connect to the server \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);this.Dispose(); }
            catch (InvalidOperationException ex) { MessageBox.Show("An error occured while running the reporting service:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); this.Dispose(); }
            catch (Exception ex) { MessageBox.Show("An error occured while running the reporing service:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); this.Dispose(); }
            finally
            {
                if ((conn.State & ConnectionState.Open) != 0) conn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn = HelperTools.dbConnection();
            try
            {
                conn.Open();
                if (comboBox1.SelectedItem.ToString() != "Select")
                {
                    if (comboBox2.SelectedIndex > -1)
                    {
                        DateTime sDate = dateTimePicker1.Value;
                        DateTime eDate = dateTimePicker2.Value;
                        if (sDate < eDate)
                        {
                            int catID = Int32.Parse(comboBox2.SelectedValue.ToString());

                            string query = "";
                            if (comboBox1.SelectedItem.ToString() == "Test Results")
                            {
                                query = query + "  SELECT ";
                                query = query + "  CONCAT(test_schedule.CANDIDATE_FNAME, '  ', test_schedule.CANDIDATE_LNAME) AS NAME,";
                                query = query + "   section.SECTION_DESC AS TEST_SECTION, ";
                                query = query + "  test_results.PASS AS RESULT,";
                                query = query + "  test_results.TEST_DATE";
                                query = query + "  FROM test_results";
                                query = query + "  INNER JOIN section ON test_results.SECTION_ID = section.SECTION_ID";
                                query = query + "  INNER JOIN test_schedule ON test_schedule.SCHEDULE_ID = test_results.TEST_SCHEDULE_ID";
                                query = query + "  ORDER BY test_results.TEST_DATE DESC";
                            }
                            else if (comboBox1.SelectedItem.ToString() == "Test Schedules")
                            {
                                MessageBox.Show("Test Schedules");
                            }
                           
                                MySqlDataAdapter mySqlDataAdapter; 
                                mySqlDataAdapter = new MySqlDataAdapter(query, conn);
                                DataSet DS = new DataSet();
                                mySqlDataAdapter.Fill(DS);
                                dataGridView1.DataSource = DS.Tables[0];
                                if (dataGridView1.RowCount>0)
                                    {
                                    dataGridView1.Visible = true;
                                    }
                                else
                                    {
                                        MessageBox.Show("There is no data matching specified criteria", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                




                        }
                        else
                        {
                            MessageBox.Show("The start date cannot be equal to or later than end date", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please select report category", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("Please select report type", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    comboBox1.Focus();
                }

            }
            catch (MySqlException ex) { MessageBox.Show("Failed to connect to the server \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); this.Dispose(); }
            catch (InvalidOperationException ex) { MessageBox.Show("An error occured while running the reporting service:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); this.Dispose(); }
            catch (Exception ex) { MessageBox.Show("An error occured while running the reporing service:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); this.Dispose(); }
            finally
            {
                if ((conn.State & ConnectionState.Open) != 0) conn.Close();
            }


        }
    }
}
