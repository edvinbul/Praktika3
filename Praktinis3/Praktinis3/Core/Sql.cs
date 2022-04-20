using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;
using System.Data;

namespace Core
{
    public static class Sql
    {
        static string connectionText;

        static Sql()
        {
            string path = Process.GetCurrentProcess().MainModule.FileName;
            int slashIndex = path.LastIndexOf(@"\");
            string source = path.Substring(0, slashIndex) + @"\Database1.mdf";
            connectionText = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + source + ";Integrated Security=True";
        }

        public static SqlConnection GetSqlConnection()
        {
            return new SqlConnection(connectionText);
        }
    }
}
