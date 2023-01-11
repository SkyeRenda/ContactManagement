using ContactManagement.Controllers;
using ContactManagement.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactManagement
{
    public partial class Home : Form
    {

        public Home()
        {
            InitializeComponent();
        }


        private void Home_Load(object sender, EventArgs e)
        {

            DatabaseInteraction databaseInteraction = new DatabaseInteraction();
            SqlDataAdapter adapter = databaseInteraction.FetchAllData();
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            this.dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.AllowUserToAddRows = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            refreshData();
        }

        private void NewButton_Click(object sender, EventArgs e)
        {
            AddContactForm addContactForm = new AddContactForm();
            addContactForm.ShowDialog();
            refreshData();
        }
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            Contact contact = createContactFromRow(index);
            DatabaseInteraction databaseInteraction = new DatabaseInteraction();
            bool success = databaseInteraction.EditData(contact);
            refreshData();

        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("Are you sure you wish to delete this contact?", "Delete Contact", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                int index = dataGridView1.CurrentCell.RowIndex;
                Contact contact = createContactFromRow(index);
                
                DatabaseInteraction databaseInteraction = new DatabaseInteraction();
                bool success = databaseInteraction.DeleteData(contact);
                if (success)
                {
                    refreshData();
                }
            }
        }
        private void refreshData()
        {
            DataTable dt = new DataTable();
            DatabaseInteraction databaseInteraction = new DatabaseInteraction();
            SqlDataAdapter adapter = databaseInteraction.FetchSearchedData(textBox1.Text);
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            this.dataGridView1.Columns["ID"].Visible = false;
            
        }

        private Contact createContactFromRow(int index)
        {
            int id = Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value);
            string name = dataGridView1.Rows[index].Cells[1].Value.ToString();
            string surname = dataGridView1.Rows[index].Cells[2].Value.ToString();
            string address = dataGridView1.Rows[index].Cells[3].Value.ToString();
            string city = dataGridView1.Rows[index].Cells[4].Value.ToString();
            string province = dataGridView1.Rows[index].Cells[5].Value.ToString();
            string postalCode = dataGridView1.Rows[index].Cells[6].Value.ToString();
            string country = dataGridView1.Rows[index].Cells[7].Value.ToString();
            string phone = dataGridView1.Rows[index].Cells[8].Value.ToString();
            string emailAddress = dataGridView1.Rows[index].Cells[9].Value.ToString();
            string contactGroup = dataGridView1.Rows[index].Cells[10].Value.ToString();

            Contact contact = new(id, name, surname, address, city, province, postalCode, country, phone, emailAddress, contactGroup);
            return contact;

        }
    }

}
