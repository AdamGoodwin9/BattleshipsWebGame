using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BattleshipsWebAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString;
        /// <summary>
        /// Registers a new user
        /// </summary>
        /// <param name="username">The user's display name</param>
        /// <returns>UserInfo model containing public ID and username</returns>
        [HttpPost]
        [Route("Register")]
        public UserInfo Register(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                return null;
            }

            DataTable table = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("usp_CreatePlayer", connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Username", username));
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                connection.Open();
                adapter.Fill(table);
                connection.Close();
            }

            DataRow row = table.Rows[0];

            return new UserInfo()
            {
                Username = username,
                PublicId = Guid.Parse(row["PublicId"].ToString())
            };
        }
    }
}