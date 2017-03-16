namespace UniversityManagement
{
    partial class MainForm
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
            this.TabControl = new System.Windows.Forms.TabControl();
            this.StudentPage = new System.Windows.Forms.TabPage();
            this.StudentGridView = new System.Windows.Forms.DataGridView();
            this.adressTextBox = new System.Windows.Forms.RichTextBox();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.ModifyBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.RichTextBox();
            this.CoursePage = new System.Windows.Forms.TabPage();
            this.StudentToCoursePage = new System.Windows.Forms.TabPage();
            this.studentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.universitydatabaseDataSet = new UniversityManagement.universitydatabaseDataSet();
            this.studentTableAdapter = new UniversityManagement.universitydatabaseDataSetTableAdapters.studentTableAdapter();
            this.addBtn = new System.Windows.Forms.Button();
            this.TabControl.SuspendLayout();
            this.StudentPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StudentGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.universitydatabaseDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.StudentPage);
            this.TabControl.Controls.Add(this.CoursePage);
            this.TabControl.Controls.Add(this.StudentToCoursePage);
            this.TabControl.Location = new System.Drawing.Point(12, 12);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(656, 331);
            this.TabControl.TabIndex = 0;
            // 
            // StudentPage
            // 
            this.StudentPage.Controls.Add(this.addBtn);
            this.StudentPage.Controls.Add(this.StudentGridView);
            this.StudentPage.Controls.Add(this.adressTextBox);
            this.StudentPage.Controls.Add(this.dateTimePicker);
            this.StudentPage.Controls.Add(this.ModifyBtn);
            this.StudentPage.Controls.Add(this.label3);
            this.StudentPage.Controls.Add(this.label2);
            this.StudentPage.Controls.Add(this.label1);
            this.StudentPage.Controls.Add(this.nameTextBox);
            this.StudentPage.Location = new System.Drawing.Point(4, 22);
            this.StudentPage.Name = "StudentPage";
            this.StudentPage.Padding = new System.Windows.Forms.Padding(3);
            this.StudentPage.Size = new System.Drawing.Size(648, 305);
            this.StudentPage.TabIndex = 0;
            this.StudentPage.Text = "Students";
            this.StudentPage.UseVisualStyleBackColor = true;
            // 
            // StudentGridView
            // 
            this.StudentGridView.AllowUserToAddRows = false;
            this.StudentGridView.AllowUserToDeleteRows = false;
            this.StudentGridView.AllowUserToResizeRows = false;
            this.StudentGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StudentGridView.Location = new System.Drawing.Point(6, 138);
            this.StudentGridView.Name = "StudentGridView";
            this.StudentGridView.Size = new System.Drawing.Size(636, 164);
            this.StudentGridView.TabIndex = 9;
            this.StudentGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.StudentGridView_CellContentClick);
            // 
            // adressTextBox
            // 
            this.adressTextBox.Location = new System.Drawing.Point(268, 66);
            this.adressTextBox.Name = "adressTextBox";
            this.adressTextBox.Size = new System.Drawing.Size(179, 22);
            this.adressTextBox.TabIndex = 8;
            this.adressTextBox.Text = "";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker.Location = new System.Drawing.Point(268, 37);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(179, 20);
            this.dateTimePicker.TabIndex = 7;
            this.dateTimePicker.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged_1);
            // 
            // ModifyBtn
            // 
            this.ModifyBtn.Enabled = false;
            this.ModifyBtn.Location = new System.Drawing.Point(247, 94);
            this.ModifyBtn.Name = "ModifyBtn";
            this.ModifyBtn.Size = new System.Drawing.Size(87, 22);
            this.ModifyBtn.TabIndex = 5;
            this.ModifyBtn.Text = "Modify";
            this.ModifyBtn.UseVisualStyleBackColor = true;
            this.ModifyBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(220, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Adress:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(210, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Birthdate:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(224, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name:";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(268, 6);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(179, 22);
            this.nameTextBox.TabIndex = 0;
            this.nameTextBox.Text = "";
            this.nameTextBox.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // CoursePage
            // 
            this.CoursePage.Location = new System.Drawing.Point(4, 22);
            this.CoursePage.Name = "CoursePage";
            this.CoursePage.Padding = new System.Windows.Forms.Padding(3);
            this.CoursePage.Size = new System.Drawing.Size(648, 305);
            this.CoursePage.TabIndex = 1;
            this.CoursePage.Text = "Courses";
            this.CoursePage.UseVisualStyleBackColor = true;
            // 
            // StudentToCoursePage
            // 
            this.StudentToCoursePage.Location = new System.Drawing.Point(4, 22);
            this.StudentToCoursePage.Name = "StudentToCoursePage";
            this.StudentToCoursePage.Padding = new System.Windows.Forms.Padding(3);
            this.StudentToCoursePage.Size = new System.Drawing.Size(648, 305);
            this.StudentToCoursePage.TabIndex = 2;
            this.StudentToCoursePage.Text = "Grades";
            this.StudentToCoursePage.UseVisualStyleBackColor = true;
            // 
            // studentBindingSource
            // 
            this.studentBindingSource.DataMember = "student";
            this.studentBindingSource.DataSource = this.universitydatabaseDataSet;
            // 
            // universitydatabaseDataSet
            // 
            this.universitydatabaseDataSet.DataSetName = "universitydatabaseDataSet";
            this.universitydatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // studentTableAdapter
            // 
            this.studentTableAdapter.ClearBeforeFill = true;
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(340, 94);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(75, 23);
            this.addBtn.TabIndex = 10;
            this.addBtn.Text = "Add";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 355);
            this.Controls.Add(this.TabControl);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.TabControl.ResumeLayout(false);
            this.StudentPage.ResumeLayout(false);
            this.StudentPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StudentGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.universitydatabaseDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage StudentPage;
        private System.Windows.Forms.TabPage CoursePage;
        private System.Windows.Forms.TabPage StudentToCoursePage;
        private System.Windows.Forms.Button ModifyBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox nameTextBox;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.RichTextBox adressTextBox;
        private System.Windows.Forms.DataGridView StudentGridView;
        private universitydatabaseDataSet universitydatabaseDataSet;
        private System.Windows.Forms.BindingSource studentBindingSource;
        private universitydatabaseDataSetTableAdapters.studentTableAdapter studentTableAdapter;
        private System.Windows.Forms.Button addBtn;
    }
}

