using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.DynamicData;

namespace GoodsInventory
{
    public class DAL
    {
        protected readonly SqlConnection connection = new SqlConnection();
        public SqlCommand cmd = new SqlCommand();
        private SqlDataReader rdr;
        //private static string connectionString= "Data Source=(local);Initial Catalog=Forecasting;User ID=sa;Password=Pass@1234;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private static string connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];

        public DAL()
        {
            cmd = new SqlCommand();
        }
        protected void DBOpenconnection()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.ConnectionString = connectionString;
                connection.Open();
            }
            else
            {
                connection.Dispose();
                connection.Close();
                DBOpenconnection();
            }
        }

        protected void DBCloseconnection()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Dispose();
                connection.Close();
            }
        }

        public SqlDataReader GetExecuteReader(string storedProcName)
        {
            using (cmd)
            {
                DBOpenconnection();
                cmd.Connection = connection;
                cmd.CommandTimeout = 0;
                cmd.CommandText = storedProcName;
                cmd.CommandType = CommandType.StoredProcedure;
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
            }
            return rdr;
        }

        public DataTable GetDataTable(string storedProcName)
        {
            DataTable dataTable = new DataTable();
            using (cmd)
            {
                DBOpenconnection();
                cmd.Connection = connection;
                cmd.CommandTimeout = 0;
                cmd.CommandText = storedProcName;
                cmd.CommandType = CommandType.StoredProcedure;
                //rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dataTable);
                cmd.Parameters.Clear();

            }
            return dataTable;
        }


        public string GetExecuteNonQuery(string StoredProcName)
        {
            string rValue = "";
            try
            {
                DBOpenconnection();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = StoredProcName.Trim();
                cmd.CommandTimeout = 2000;
                cmd.Connection = connection;
                rValue = Convert.ToString(cmd.ExecuteNonQuery());
                cmd.Parameters.Clear();
            }
            finally
            {
                cmd.Dispose();
                DBCloseconnection();
            }
            return rValue;
        }

        public string GetExecuteNonQuery(string StoredProcName, string outPutParameter)
        {
            string rValue = "";
            try
            {
                DBOpenconnection();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = StoredProcName.Trim();
                cmd.CommandTimeout = 2000;
                cmd.Connection = connection;
                cmd.ExecuteNonQuery();
                rValue = cmd.Parameters[outPutParameter].Value.ToString();
                cmd.Parameters.Clear();
            }
            finally
            {
                cmd.Dispose();
                DBCloseconnection();
            }
            return rValue;
        }

        public Dictionary<string, string> GetExecuteNonQuery(string StoredProcName, Dictionary<string, string> outParameters)
        {
            try
            {
                DBOpenconnection();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = StoredProcName.Trim();
                cmd.CommandTimeout = 2000;
                cmd.Connection = connection;
                cmd.ExecuteNonQuery();

                foreach (KeyValuePair<string, string> keyValuePair in outParameters)
                    outParameters[keyValuePair.Key] = cmd.Parameters[keyValuePair.Key].Value.ToString();

                cmd.Parameters.Clear();
            }
            finally
            {
                cmd.Dispose();
                DBCloseconnection();
            }
            return outParameters;
        }
    }
}