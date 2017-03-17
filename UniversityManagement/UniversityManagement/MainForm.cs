using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniversityManagement {
    
    public partial class MainForm : Form {
        private IDbManager dbManager;
        private Student student;       

        public MainForm() {
            dbManager = new MySqlDbManager();
            student = null;
            InitializeComponent();
        }

        public void ReloadStudentsTable() {
            StudentGridView.DataSource = dbManager.getStudents();
            ModifyBtn.Enabled = false;
            ModifyBtn.Text = "Modify";
            DeleteBtn.Enabled = false;
            DeleteBtn.Text = "Delete";
        }

        private void MainForm_Load(object sender, EventArgs e) {
            ReloadStudentsTable();
        }

        private void DeleteBtn_Click(object sender, EventArgs e) {
            string text = "Delete student with Id=" + student.id + "?";
            string caption = "Information";       
            if (MessageBox.Show(text, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) 
                    == System.Windows.Forms.DialogResult.Yes) {
                if (!dbManager.deleteStudentById(student))
                    MessageBox.Show("Can't delete student.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ReloadStudentsTable();
            }
        }

        private void showInformationMessage(string text) {
            MessageBox.Show(text, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void AddBtn_Click(object sender, EventArgs e) {
            StudentForm studentForm = new UniversityManagement.StudentForm(this);
            studentForm.Operation = StudentForm.OperationEnum.Add;
            studentForm.Show(this);
            this.Enabled = false;
        }

        private void ModifyBtn_Click(object sender, EventArgs e) {
            StudentForm studentForm = new UniversityManagement.StudentForm(this);
            studentForm.student = student;
            //MessageBox.Show(student.id.ToString());
            studentForm.Operation = StudentForm.OperationEnum.Modify;            
            //studentForm.Show(this);
            this.Enabled = false;
            studentForm.Show(this);
        }

        private void StudentGridView_SelectionChanged(object sender, EventArgs e) {
            if (StudentGridView.SelectedRows.Count == 1) {
                student = (Student)StudentGridView.SelectedRows[0].DataBoundItem;
                //MessageBox.Show(student.id.ToString());
                ModifyBtn.Text = "Modify (Id=" + student.id.ToString() + ")";
                ModifyBtn.Enabled = true;
                DeleteBtn.Text = "Delete (Id=" + student.id.ToString() + ")";
                DeleteBtn.Enabled = true;
            } else
                student = null;
        }
    }
}
