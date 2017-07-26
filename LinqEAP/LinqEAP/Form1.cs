using LinqEAP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinqEAP
{
    public partial class Form1 : Form
    {
        BindingSource elist = new BindingSource();
        public Form1()
        {
            InitializeComponent();
            loaddb();
            binding();
        }

        void binding()
        {
            txtID.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "EmployeeID", true, DataSourceUpdateMode.Never));
            txtName.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "EmployeeName", true, DataSourceUpdateMode.Never));
            txtDepartment.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "Department", true, DataSourceUpdateMode.Never));
            txtSalary.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "Salary", true, DataSourceUpdateMode.Never));
        }
        void loaddb()
        {
            DataClasses1DataContext context = new DataClasses1DataContext();
            var result = from e in context.Employees
                         select e;
            elist.DataSource = result;
            dataGridView1.DataSource = elist;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext context = new DataClasses1DataContext();
            Employee empl = new Employee();
            empl.EmployeeID = txtID.Text;
            empl.EmployeeName = txtName.Text;
            empl.Department = txtDepartment.Text;
            empl.Salary = Convert.ToDouble(txtSalary.Text);
            context.Employees.InsertOnSubmit(empl);
            context.SubmitChanges();
            MessageBox.Show("Thêm thành công");
            loaddb();
            txtID.Text = "";
            txtName.Text = "";
            txtDepartment.Text = "";
            txtSalary.Text = "";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext context = new DataClasses1DataContext();

            Employee empl = context.Employees.FirstOrDefault(i => i.EmployeeID.Equals(txtID.Text));
            empl.EmployeeName = txtName.Text;
            empl.Department = txtDepartment.Text;
            empl.Salary = Convert.ToDouble(txtSalary.Text);
            context.SubmitChanges();
            MessageBox.Show("Edit thành công");
            loaddb();
            txtID.Text = "";
            txtName.Text = "";
            txtDepartment.Text = "";
            txtSalary.Text = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext context = new DataClasses1DataContext();

            Employee deleteEmployee = context.Employees.FirstOrDefault(f => f.EmployeeID.Equals(txtID.Text));

            context.Employees.DeleteOnSubmit(deleteEmployee);

            context.SubmitChanges();
            MessageBox.Show("Delete thành công");
            loaddb();
            txtID.Text = "";
            txtName.Text = "";
            txtDepartment.Text = "";
            txtSalary.Text = "";

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext context = new DataClasses1DataContext();
            var result = from f in context.Employees
                         where f.EmployeeName.Contains(txtS.Text) || f.EmployeeID.Contains(txtS.Text)
                         || f.Department.Contains(txtS.Text) || f.Salary.ToString().Contains(txtS.Text)
                         orderby f.EmployeeName
                         select f;
            dataGridView1.DataSource = result;
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
