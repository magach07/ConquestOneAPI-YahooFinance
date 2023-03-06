using System.Data;
using Microsoft.Data.SqlClient;

namespace ConquestOne.Infrastructure.Factory
{
    public class SqlFactory
    {
        public IDbConnection SqlConnection()
        {
            return new SqlConnection("Server=desktop-n3ub7sm;DataBase=YAHOO_FINANCE;User=sa;Password=windowslinuxj;Trusted_Connection=false;TrustServerCertificate=True;");
        }
    }
}