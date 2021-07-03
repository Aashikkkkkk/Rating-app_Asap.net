using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace RatingApp
{
    public partial class FeedbackForm : Form
    {
        public string CriteriaFile = @"..\..\criteria.csv";
        public string CustomerFile = @"..\..\customer.csv";
        public List<Criteria> Criterias;
        public FeedbackForm()
        {
            InitializeComponent();
        }

        public class CriteriaDetail
        {
            public string CriteriaName { get; set; }
        }


        public List<CriteriaDetail> LoadCsvData(string CsvFile)
        {
            var query = from l in File.ReadAllLines(CsvFile)
                        let data = l.Split(',')
                        select new CriteriaDetail
                        {
                            //Id = data[0],
                            CriteriaName = data[0]
                        };

            return query.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string date = DateTime.Now.ToShortDateString();
            string time = DateTime.Now.ToShortTimeString();

            for (int i = 0; i <= feedbackData.Rows.Count - 1; i++)
            {
                string CriteriaValue = "0";

                try
                {
                    //string criteria;
                    string Excellent;
                    string Average;
                    string Good;
                    string Disatisfied;
                    //string a=Convert.ToString(dgvData.Rows[0].Cells[0].Value);
                    //bool isCellChecked = Convert.ToBoolean(dgvData.Rows[0].Cells[0].Value);
                    if (feedbackData.Rows[i].Cells[3].Value != null)
                    {
                        Excellent = feedbackData.Rows[i].Cells[3].Value.ToString(); //True
                        if (Excellent == "True")
                        {
                            CriteriaValue = "4";
                            //Console.WriteLine(CriteriaValue);

                        }
                    }
                    if (feedbackData.Rows[i].Cells[1].Value != null)
                    {

                        Average = feedbackData.Rows[i].Cells[1].Value.ToString(); //true
                        if (Average == "True")
                        {
                            CriteriaValue = "2";
                            //Console.WriteLine(CriteriaValue);

                        }
                    }
                    if (feedbackData.Rows[i].Cells[2].Value != null)
                    {

                        Good = feedbackData.Rows[i].Cells[2].Value.ToString(); //true
                        if (Good == "True")
                        {
                            CriteriaValue = "3";
                            // Console.WriteLine(CriteriaValue);

                        }
                    }
                    if (feedbackData.Rows[i].Cells[0].Value != null)
                    {

                        Disatisfied = feedbackData.Rows[i].Cells[0].Value.ToString(); //true
                        if (Disatisfied == "True")
                        {
                            CriteriaValue = "1";
                            //Console.WriteLine(CriteriaValue);

                        }
                    }


                }
                catch (InvalidCastException ex)
                {
                    MessageBox.Show(" " + ex);

                }
                //addRecord(nameTxt.Text, contactTxt.Text, emailTxt.Text, CriteriaValue, "D:\\feedback.csv");
                if (i == 0)
                {
                    addRecord(nameBox.Text, phoneBox.Text, emailBox.Text, date, time, CriteriaValue, CustomerFile);
                }
                else
                {
                    addRecord1(CriteriaValue, CustomerFile);
                }


            }
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(CustomerFile, true))
            {
                file.Write(@"" + "\n");
            }

        }
        // method to add the feedback to customer file
        public void addRecord(string name, string contact, string email, string date, string time, string feedback, string filepath)
        {
            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@filepath, true))
                {
                    //file.WriteLine();
                    file.Write(@"" + name + "," + contact + "," + email + "," + date + "," + time + "," + feedback + ",");
                }
                MessageBox.Show("Data Added");
            }
            catch (Exception ex)
            {
                throw new ApplicationException("This program is not doing well", ex);
            }

        }


        public void addRecord1(string feedback, string filepath)
        {
            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@filepath, true))
                {
                    file.Write(feedback + ",");
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("This program is not doing well", ex);
            }

        }
        private void FeedbackForm_Load_1(object sender, EventArgs e)
        {
            feedbackData.DataSource = LoadCsvData(CriteriaFile);
            Console.WriteLine("Attitude");
            Console.ReadLine();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void feedbackData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }
    }
}
