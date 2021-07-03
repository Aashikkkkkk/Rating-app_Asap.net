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
    public partial class Criteria : Form      
    {
        public string CriteriaFile = @"..\..\criteria.csv";
        public Criteria()
        {
            InitializeComponent();
        }

        private void addCriteria_Click(object sender, EventArgs e)
        {
            string criteraiName = criteriaBox.Text;
            AddRecord(criteraiName, CriteriaFile);
        }

        // method for add criteria to csv file
        public void AddRecord(string criteria, string filepath)
        {
            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@filepath, true))
                {
                    //file.WriteLine();
                    file.Write(@"" + criteria + "\n"); // add criteria to new line
                }
                MessageBox.Show("Data Added");
            }

            catch (Exception ex)
            {
                throw new ApplicationException("This program is not doing well", ex);
            }
        }
        


    }
}
