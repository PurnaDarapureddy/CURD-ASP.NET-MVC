using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace curd.Models
{
    public class repo
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ToString());
        public void addemp(addemp ad)
        {
            SqlCommand cmd = new SqlCommand("proc_addemp", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@a", ad.empid);
            cmd.Parameters.AddWithValue("@b", ad.empname);
            cmd.Parameters.AddWithValue("@c", ad.city);
            cmd.Parameters.AddWithValue("@d", ad.address);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public List<addemp> getemp()
        {
            List<addemp> obj = new List<addemp>();
            SqlDataAdapter da = new SqlDataAdapter("proc_getemp", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                /* obj.Add(new addemp()
                 {
                     empid = Convert.ToInt32(dr["empid"]),
                     empname = (dr["empname"].ToString()),
                     city = dr["city"].ToString(),
                     address = dr["address"].ToString()
                 });*/
                addemp ad = new addemp();
                ad.empid = Convert.ToInt32(dr["empid"]);
                ad.empname = dr["empname"].ToString();
                ad.city = dr["city"].ToString();
                ad.address = dr["address"].ToString();

                obj.Add(ad);
            }
            return obj;
        }
        public void updateemp(addemp ad)
        {
            SqlCommand cmd = new SqlCommand("proc_updateemp", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@a", ad.empid);
            cmd.Parameters.AddWithValue("@b", ad.empname);
            cmd.Parameters.AddWithValue("@c", ad.city);
            cmd.Parameters.AddWithValue("@d", ad.address);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void deleteemp(int id)
        {
            SqlCommand cmd = new SqlCommand("proc_delete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@a", id);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}