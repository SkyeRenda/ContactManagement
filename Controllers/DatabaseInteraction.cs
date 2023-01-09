using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Microsoft.Data.SqlClient;

namespace ContactManagement.Controllers
{
    internal class DatabaseInteraction
    {
        private SqlConnection createConnection()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "dogskye.database.windows.net";
            builder.UserID = "skyerenda";
            builder.Password = "Angelicbeauty12";
            builder.InitialCatalog = "dogskye";

            SqlConnection connection = new SqlConnection(builder.ConnectionString);
            return connection;

        }
    }
        
}

