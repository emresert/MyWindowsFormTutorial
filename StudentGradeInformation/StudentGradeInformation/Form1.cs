using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; // for sql query and like sql command, sql adapter objects
using StudentGradeInformation.Models.EntityFramework; // it should be added for using entity model

namespace StudentGradeInformation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DbExamSystemEntities db = new DbExamSystemEntities();
        public void dgvRefreshListing()
        {
            dataGridView1.DataSource = db.tbl_Student.ToList();
            dataGridView1.Columns[4].Visible = false;
        }
        public void rmvStudentTxt()
        {
            txtStudentName.Clear();
            txtStudentSurname.Clear();
            txtStudentId.Clear();
            txtStudentImage.Clear();
        }
        private void btnClassList_Click(object sender, EventArgs e)
        {
            // With sql client library
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-9SG6I3G\SQLEXPRESS;Initial Catalog=DbExamSystem;Integrated Security=True");
            SqlCommand query = new SqlCommand("Select * from tbl_Lesson",connection);
            SqlDataAdapter da = new SqlDataAdapter(query);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt; //(listing method 1)

        }

        private void btnStudentList_Click(object sender, EventArgs e)
        {
            // with Entity Framework
            DbExamSystemEntities db = new DbExamSystemEntities();
            dataGridView1.DataSource = db.tbl_Student.ToList();
            // if we have an area which we dont want to show on Datagridview
            // we can make it hide (listing method 2)
            
            dataGridView1.Columns[4].Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnNoteList_Click(object sender, EventArgs e)
        {
            // Listing with LinQ query (listing method 3)
            var query = from item in db.tbl_Notes
                        select new { item.noteId, item.fkStudent, item.fkLesson,item.exam1,
                                     item.exam2,item.exam3,item.result,item.status };
            dataGridView1.DataSource = query.ToList();
                       

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var student = new tbl_Student();
            student.studentName = txtStudentName.Text;
            student.studentSurname = txtStudentSurname.Text;
            db.tbl_Student.Add(student);
            db.SaveChanges();
            MessageBox.Show("Öğrenci Listeye Eklenmiştir.");
            rmvStudentTxt();
            dgvRefreshListing();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtStudentId.Text);
            var student = db.tbl_Student.FirstOrDefault(s => s.studentId == id); //var student = db.tbl_Student.Find(id);
            db.tbl_Student.Remove(student);

            /* Delete process for selected row*/
            //foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            //{
            //    string value1 = row.Cells[0].Value.ToString();
            //    var id = Convert.ToInt32(value1);
            //    var student = db.tbl_Student.Find(id);
            //    db.tbl_Student.Remove(student);
            //}

            db.SaveChanges();
            dgvRefreshListing();
            rmvStudentTxt();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtStudentId.Text);
            var student = db.tbl_Student.Find(id);
            student.studentName = txtStudentName.Text;
            student.studentSurname = txtStudentSurname.Text;
            student.studentImage = txtStudentImage.Text;
            db.SaveChanges();
            MessageBox.Show("Öğrenci bilgileri güncellendi");
            dgvRefreshListing();
            rmvStudentTxt();
        }
    }
}
