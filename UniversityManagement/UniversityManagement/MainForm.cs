using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniversityManagement
{
    public partial class MainForm : Form
    {
        private IDbManager manager;
        private string StudentName;
        private DateTime StudentBirthDate;
        private string StudentAdress;
        private int StudentId;

        public MainForm(IDbManager mgr)
        {
            InitializeComponent();
            this.manager = mgr;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e) {

        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e) {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) {

        }

        private void button1_Click(object sender, EventArgs e) {
            string format = "yyyy-MM-dd";
            string modifiedDateString = dateTimePicker.Value.ToString(format);
            if (!StudentName.Equals(nameTextBox.Text) || 
                    !StudentBirthDate.ToString(format).Equals(modifiedDateString) ||
                    !StudentAdress.Equals(adressTextBox.Text)) {
                manager.AlterStudent(StudentId, nameTextBox.Text, 
                    dateTimePicker.Value.ToString("yyyy-MM-dd"),
                    adressTextBox.Text);
            }
            nameTextBox.Clear();
            dateTimePicker.Value = DateTime.Now;
            adressTextBox.Clear();
            StudentGridView.DataSource = manager.getStudentsDataTable();
            ModifyBtn.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e) {
            StudentGridView.DataSource = manager.getStudentsDataTable();
        }

        private void StudentGridView_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            DataTable table = (DataTable) StudentGridView.DataSource;
            int row = e.RowIndex;
            StudentId = int.Parse(table.Rows[row][0].ToString()); ;
            StudentName = table.Rows[row][1].ToString();
            nameTextBox.Text =  StudentName;
            StudentBirthDate = DateTime.Parse(table.Rows[row][2].ToString());
            dateTimePicker.Value = StudentBirthDate;
            StudentAdress = table.Rows[row][3].ToString();
            adressTextBox.Text = StudentAdress;
            ModifyBtn.Enabled = true;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e) {

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            manager.CloseConnection();
        }

        private void addBtn_Click(object sender, EventArgs e) {
            
        }
    }
}
