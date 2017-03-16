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
        private int CurrentId;
        private StudentForm AddStudentForm, ModifyStudentForm;

        public MainForm(IDbManager dbManager) {
            this.dbManager = dbManager;
            AddStudentForm = new StudentForm();
            AddStudentForm.ButtonText = "Add";
            ModifyStudentForm = new StudentForm();
            ModifyStudentForm.ButtonText = "Modify";
            InitializeComponent();
        }

        private void ReloadStudentsTable() {
            StudentGridView.DataSource = dbManager.getStudentsDataTable();
        }

        private void MainForm_Load(object sender, EventArgs e) {
            ReloadStudentsTable();
        }

        private void StudentGridView_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            DataTable t = (DataTable) StudentGridView.DataSource;
            int tmp = (int) t.Rows[e.RowIndex][0];
            if (tmp > 0) {
                CurrentId = tmp;
                ModifyBtn.Enabled = DeleteBtn.Enabled = true;
                ModifyBtn.Text = "Modify (Id = " + CurrentId.ToString() + ")";
                DeleteBtn.Text = "Delete (Id = " + CurrentId.ToString() + ")";
            } else {
                ModifyBtn.Enabled = DeleteBtn.Enabled = false;
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e) {
            if (!dbManager.DeleteStudent(CurrentId)) {
                string message = "Can't delete student with ID = " + CurrentId.ToString() +
                    ". Check if it is not enrolled into a current course.";
                MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ReloadStudentsTable();
        }

        private void ModifyBtn_Click(object sender, EventArgs e) {
            ModifyStudentForm.Show(this);
            this.Enabled = false;
        }

        private void AddBtn_Click(object sender, EventArgs e) {
            AddStudentForm.Show(this);
            this.Enabled = false;
        }
    }
}
