using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using backend.Models;

namespace backend.Controllers
{
    [RoutePrefix("api/Test")]
    public class TestController : ApiController
    {
        SqlConnection conn=new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
        SqlCommand cmd=null;
        SqlDataAdapter da=null;

        [HttpPost]
        [Route("Register")]
        public string Register(Customer customer)
        {
            string msg=string.Empty;
            try
            {
                cmd = new SqlCommand("Register", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TITLE", customer.Title);
                cmd.Parameters.AddWithValue("@FNAME", customer.FName);
                cmd.Parameters.AddWithValue("@LNAME", customer.LName);
                cmd.Parameters.AddWithValue("@DOB", customer.Dob);
                cmd.Parameters.AddWithValue("@GENDER", customer.Gender);
                cmd.Parameters.AddWithValue("@PASSWORD", customer.Password);
                cmd.Parameters.AddWithValue("@REMARK", customer.Remark);

                conn.Open();
                int i = cmd.ExecuteNonQuery();
                conn.Close();
                if (i > 0)
                {
                    msg = "Data inserted";
                }
                else
                {
                    msg = "Error adding";
                }

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            
            return msg;
        }


        [HttpPost]
        [Route("Login")]
        public string Login(Customer customer)
        {
            string msg = string.Empty;
            try
            {
                da = new SqlDataAdapter("Login", conn);
                da.SelectCommand.CommandType= CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@FNAME", customer.FName);
                da.SelectCommand.Parameters.AddWithValue("@PASSWORD", customer.Password);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if(dt.Rows.Count > 0) { msg = "User loggin sucess"; }
                else { msg = "Invaild user"; }

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return msg;
        }
    }
}
