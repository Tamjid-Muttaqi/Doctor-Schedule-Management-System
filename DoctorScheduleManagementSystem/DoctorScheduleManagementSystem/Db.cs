using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DoctorScheduleManagementSystem
{
    public static class Db
    {
        public static string ConnectionString = @"Data Source=TAMJID;Initial Catalog=DoctorScheduleDB;Integrated Security=True";
        public static DataTable GetData(string query, params SqlParameter[] parameters)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                using (SqlCommand cmd = new SqlCommand(query, con))
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    if (parameters != null) cmd.Parameters.AddRange(parameters);
                    da.Fill(dt);
                }
            }
            catch (Exception ex) { MessageBox.Show("Database error: " + ex.Message); }
            return dt;
        }
        public static bool Execute(string query, params SqlParameter[] parameters)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (parameters != null) cmd.Parameters.AddRange(parameters);
                    con.Open(); cmd.ExecuteNonQuery(); return true;
                }
            }
            catch (Exception ex) { MessageBox.Show("Database error: " + ex.Message); return false; }
        }
        public static object Scalar(string query, params SqlParameter[] parameters)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (parameters != null) cmd.Parameters.AddRange(parameters);
                    con.Open(); return cmd.ExecuteScalar();
                }
            }
            catch (Exception ex) { MessageBox.Show("Database error: " + ex.Message); return null; }
        }
    }
}
