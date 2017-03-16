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
    public partial class StudentForm : Form {
        public StudentForm() {
            InitializeComponent();
            ButtonText = "Add";
        }

        private string buttonText;
        public string ButtonText {
            get {
                return buttonText;
            }

            set {
                buttonText = value;
                AddButton.Text = value;
            }
        }

        private void AddButton_Click(object sender, EventArgs e) {
            this.Owner.Enabled = true;
            this.Hide();
        }

        private void CancelButton_Click(object sender, EventArgs e) {
            this.Owner.Enabled = true;
            this.Hide();
        }
    }
}
