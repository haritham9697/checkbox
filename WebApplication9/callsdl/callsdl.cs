using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using WebApplication9.Models;
using System.Data.Sql;



namespace WebApplication9 .callsdl
{
    public class calldl
    {
        SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString);

        public List<Models.calls> Getcalls(string user, string category, string speciality,string v1,string v2,string v3)
        {
            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = connection;
            List<calls> lstcalls = new List<Models.calls>();



            string query = "";

            if (!string.IsNullOrEmpty(Convert.ToString(user)) && user != "''")
            {
                query += "[user] in (" + v1 + ")";
            }

            if (!string.IsNullOrEmpty(Convert.ToString(category)) && category != "''")
            {
                if (!string.IsNullOrEmpty(Convert.ToString(query)))
                {
                    query += " and ";
                }

                query += "[category] in(" + v2 + ")";
            }


            if (!string.IsNullOrEmpty(Convert.ToString(speciality)) && speciality != "''")
            {
                if (!string.IsNullOrEmpty(Convert.ToString(query)))
                {
                    query += " and ";
                }
                query += "[speciality] in(" + v3 + " )";
            }

            //string check = "";

            //if (!string.IsNullOrEmpty(Convert.ToString(query)))
            //{


            //        check += " where " + query;

            //}

            SqlCmd.CommandType = CommandType.Text;
            SqlCmd.Parameters.Add("@user", SqlDbType.VarChar, 50).Value = user;
            SqlCmd.Parameters.Add("@category", SqlDbType.VarChar, 50).Value = category;
            SqlCmd.Parameters.Add("@speciality", SqlDbType.VarChar, 50).Value = speciality;

            SqlCmd.CommandText = "SELECT [id] ,[user] ,[category] ,[speciality],[duration]  FROM [project2].[dbo].[calltable]  where"  + query ;

            SqlDataReader reader = null;
            connection.Open();
            reader = SqlCmd.ExecuteReader();
            calls c = null;

            while (reader.Read())
            {
                c = new calls();
                c.id = Convert.ToInt32(reader.GetValue(0));
                c.user = reader.GetValue(1).ToString();
                c.category = reader.GetValue(2).ToString();
                c.speciality = reader.GetValue(3).ToString();
                c.duration = reader.GetValue(4).ToString();



                lstcalls.Add(c);
            }
            connection.Close();
            return lstcalls;
        }

    }
}