using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Microsoft.Data.SqlClient;
using System.Data.SqlTypes;
using ContactManagement.Models;

namespace ContactManagement.Controllers
{
    internal class DatabaseInteraction
    {
        SqlDataAdapter adapt { get; set; } = new();
        
        SqlCommand command { get; set; }=new();

        SqlConnection? con {get; set;}

        private static SqlConnection CreateConnection()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "dogskye.database.windows.net";
            builder.UserID = "skyerenda";
            builder.Password = "Angelicbeauty12";
            builder.InitialCatalog = "contacts";
            SqlConnection connection = new SqlConnection(builder.ConnectionString);
            return connection;

        }

        public SqlDataAdapter FetchAllData()
        {
            string SqlQuery = "select id as 'ID', name as 'Name', surname as 'Surname',contactGroup as 'Group', address as 'Address', city as 'City', province as 'Province', postalCode AS 'Postal Code', country as 'Country', phone as 'Phone', emailAddress as 'Email Address' from [dbo].[Contacts]";
            con = CreateConnection();
            adapt = new(SqlQuery, con);
            return adapt;
        }

        public SqlDataAdapter FetchSearchedData(string searchTerm)
        {
            string SqlQuery = $"select id as 'ID', name as 'Name', surname as 'Surname',contactGroup as 'Group', address as 'Address', city as 'City', province as 'Province', postalCode AS 'Postal Code', country as 'Country', phone as 'Phone', emailAddress as 'Email Address' from [dbo].[Contacts] where Name Like '%{searchTerm}%' OR Phone LIKE '%{searchTerm}%' ";
            con = CreateConnection();
            adapt = new(SqlQuery, con);
            return adapt;
        }

        
        public void InsertData(Contact contact)
        {
            string SqlQuery = $"insert into [dbo].[Contacts] values('{contact.Name}','{contact.Surname}','{contact.Address}','{contact.City}','{contact.Region}','{contact.PostalCode}','{ contact.Country}','{contact.Phone}','{contact.EmailAddress}','{contact.ContactGroup}');";
            
            con = CreateConnection();
            con.Open();
            command = new SqlCommand(SqlQuery, con);
            try
            {
                command.ExecuteNonQuery();
                con.Close();
                
            }
            catch {
                con.Close();
                throw new Exception("Error deleting object");
            }
        }
        public void EditData(Contact contact)
        {
            string SqlQuery = $"UPDATE [dbo].[Contacts] SET name = '{contact.Name}', surname ='{contact.Surname}', address = '{contact.Address}', city = '{contact.City}', province = '{contact.Region}', postalCode = '{contact.PostalCode}', country ='{contact.Country}', phone = '{contact.Phone}', emailAddress = '{contact.EmailAddress}'  WHERE id = '{contact.ID}';";
            
            con = CreateConnection();
            con.Open();
            command = new SqlCommand(SqlQuery, con);
            try
            {
                command.ExecuteNonQuery();
                con.Close();
                
            }
            catch
            {
                
                con.Close();
                throw new Exception("Error editing object");
            }
        }
            public void DeleteData(Contact contact)
        {
            string SqlQuery = $"delete from [dbo].[Contacts] where id = {contact.ID};";
            con = CreateConnection();
            con.Open();
            command = new SqlCommand(SqlQuery, con);
            try
            {
                command.ExecuteNonQuery();
                con.Close();

            }
            catch
            {
                con.Close();
                throw new Exception("Error deleting object");

            }

        }
    }

}

