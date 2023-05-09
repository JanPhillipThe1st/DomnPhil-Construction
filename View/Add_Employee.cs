using DomnPhil_Construction.Controller;
using DomnPhil_Construction.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DomnPhil_Construction
{
    public partial class Add_Employee : Form
    {
        Database db = new Database();
        Employee employee = new Employee();
        InputUtilities inputUtilities = new InputUtilities();
        DataGridView dgv = new DataGridView();
        public Add_Employee(ref DataGridView dgv)
        {
            InitializeComponent();
            this.dgv = dgv;
        }

        private void btnTogglePasswordVisibilty_Click(object sender, EventArgs e)
        {
        }

        private void Employees_Load(object sender, EventArgs e)
        {
            AutoCompleteStringCollection source = new AutoCompleteStringCollection();
            source.AddRange(db.getSiteList().ToArray());
            tbSite.AutoCompleteSource = AutoCompleteSource.CustomSource;
            tbSite.AutoCompleteCustomSource = source;
            
            AutoCompleteStringCollection designationSource = new AutoCompleteStringCollection();
            designationSource.AddRange(db.getDesignationList().ToArray());
            tbDesignation.AutoCompleteSource = AutoCompleteSource.CustomSource;
            tbDesignation.AutoCompleteCustomSource = designationSource;
            
            AutoCompleteStringCollection positionSource = new AutoCompleteStringCollection();
            positionSource.AddRange(db.getPositionList().ToArray());
            tbPosition.AutoCompleteSource = AutoCompleteSource.CustomSource;
            tbPosition.AutoCompleteCustomSource = positionSource;

        }

        private void tbSearchEmployee_TextChanged(object sender, EventArgs e)
        {
        }

        private void cbSites_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void dgvEmployees_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want Add "+tbFullName.Text+"' ?", "Add "+tbFullName.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {

                    employee.control_number =  tbControlNumber.Text;
                    employee.last_name =  tbLastName.Text;
                    employee.first_name = tbFirstName.Text;
                    employee.name = tbFullName.Text;
                    employee.position = tbPosition.Text;
                    employee.designation = tbDesignation.Text;
                    employee.site = tbSite.Text;
                    employee.shop_rate = Convert.ToInt32(tbShopRate.Text);
                    employee.operational_rate = Convert.ToInt32(tbOperationalRate.Text);
                    if (cbRateCalculationType.Text.Contains("flat"))
                    {
                        employee.rate = employee.operational_rate;
                    }
                    else
                    {
                        employee.rate = 0;
                    }

                    db.addEmployee(employee);

                db.fillEmployeesTable(ref dgv);
                    this.Close();
                }
                catch (Exception ex )
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void tbNonOperationalDays_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void tbOperationalDays_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void tbAbsences_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void btnDeductibles_Click(object sender, EventArgs e)
        {
        }

        private void cbRateCalculationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbRateCalculationType.Text.Contains("flat"))
            {
                employee.rate = employee.operational_rate;
            }
            else {
                employee.rate = 0;
            }
        }
    }
}
