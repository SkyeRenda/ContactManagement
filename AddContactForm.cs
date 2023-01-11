using ContactManagement.Controllers;
using ContactManagement.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ContactManagement
{
    public partial class AddContactForm : Form
    {
        public AddContactForm()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            Contact contact = new(0,NameBox.Text, SurnameBox.Text,StreetAddressBox.Text,CityBox.Text,ProvinceBox.Text, PostalCodeBox.Text, CountryBox.Text, PhoneBox.Text, EmailBox.Text, GroupBox.Text);
            DatabaseInteraction databaseInteraction = new DatabaseInteraction();
            bool success = databaseInteraction.InsertData(contact);
            if (success == true ) { Close(); };
        }

        private void AddContactForm_Load(object sender, EventArgs e)
        {
            GroupBox.Items.Add("Family");
            GroupBox.Items.Add("Friends");
            GroupBox.Items.Add("Work");
        }
    }
}
