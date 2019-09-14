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
        private void btnClassList_Click(object sender, EventArgs e)
        {
            // With sql client library
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-9SG6I3G\SQLEXPRESS;Initial Catalog=DbExamSystem;Integrated Security=True");
            SqlCommand query = new SqlCommand("Select * from tbl_Lesson",connection);
            SqlDataAdapter da = new SqlDataAdapter(query);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void btnStudentList_Click(object sender, EventArgs e)
        {
            // with Entity Framework
            DbExamSystemEntities db = new DbExamSystemEntities();
            dataGridView1.DataSource = db.tbl_Student.ToList();
            // if we have an area which we dont want to show on Datagridview
            // we can make it hide (method 1)
            
            dataGridView1.Columns[4].Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnNoteList_Click(object sender, EventArgs e)
        {
            // Listing with LinQ query 
            var query = from item in db.tbl_Notes
                        select new { item.noteId, item.fkStudent, item.fkLesson,item.exam1,
                                     item.exam2,item.exam3,item.result,item.status };
            dataGridView1.DataSource = query.ToList();
                       

        }
    }
}
