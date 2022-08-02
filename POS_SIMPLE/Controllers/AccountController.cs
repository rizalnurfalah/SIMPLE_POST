using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS_SIMPLE.Models;
using System.Data.SqlClient;

namespace POS_SIMPLE.Controllers
{
    public class AccountController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        public ActionResult Login()
        {
            return View();
        }
        void connectionString()
        {
            con.ConnectionString = "Data Source=.;Initial Catalog=DB_POS_SIMPLE;Integrated Security=True";
        }
        public ActionResult Dashboard(Account acc)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "SELECT * FROM MD_USERS WHERE username='"+acc.Name+"' and password='"+acc.Password+"'";
            dr = com.ExecuteReader();
            if(dr.Read())
            {
                con.Close();
                return View("Dasboard");
            }
            else
            {
                con.Close();
                return View("Error");
            }
            con.Close();
        }
    }
}