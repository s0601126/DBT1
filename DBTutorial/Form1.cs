using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBTutorial
{
    public partial class Form1 : Form
    {
        public Form1() {
            InitializeComponent();
        }
private void Form1_Load(object sender, EventArgs e)
        {
            {

                using (var classicContext = new classicmodelsEntities())
                {
                    var emp = classicContext.employees.Select(i => i);

                    //var emp = (from list in classicContext.employees
                    //select list);    // select * from employees

                    foreach (var emp2 in emp.ToList())
                    {
                        dataGridView1.Rows.Add(emp2.employeeNumber, emp2.lastName, emp2.firstName, emp2.extension, emp2.email, emp2.officeCode, emp2.jobTitle);
                    }


                    var custQuery = from list in classicContext.customers
                                    where list.customerName.Contains("Mini")
                                    select list;

                    var custName = custQuery.FirstOrDefault<customers>();
                    textBox1.Text = custName.customerName;

                }

            }
        }
    }
}
