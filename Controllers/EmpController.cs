using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class EmpController : ApiController
    {
		string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Lesson7;Integrated Security=True;Pooling=True";
		SqlConnection connection;

		[Route("getlist")]
		public List<Emploee> Get()
        {
			List<Emploee> Employees = new List<Emploee>();

			var sql2 = @"Select * FROM Employees";

			using ( connection = new SqlConnection(connectionString))
			{
				connection.Open();

				SqlCommand command2 = new SqlCommand(sql2, connection);

				SqlDataReader reader = command2.ExecuteReader();

				while (reader.Read())
				{
					string name = Convert.ToString(reader.GetValue(1));
					int id = Convert.ToInt16(reader.GetValue(0));
					int DepId = Convert.ToInt16(reader.GetValue(2));
					Employees.Add(new Emploee(name, id, DepId));
				}
				reader.Close();
			}
			
			return Employees;
        }

		[Route("getlist/{id}")]
		public Emploee Get(int id)
        {
			var sql2 = @"Select * FROM Employees";

			using (connection = new SqlConnection(connectionString))
			{
				connection.Open();

				SqlCommand command2 = new SqlCommand(sql2, connection);

				SqlDataReader reader = command2.ExecuteReader();
				if (reader.Read())
				{
					string name = Convert.ToString(reader.GetValue(1));
					int Id = Convert.ToInt16(reader.GetValue(0));
					int DepId = Convert.ToInt16(reader.GetValue(2));
					reader.Close();

					return new Emploee(name, Id, DepId);
				}
			}return new Emploee();
		}

		[Route("addemp")]
		public void Post([FromBody]string value)
        {
			Emploee e = new Emploee(/*text, v1, v2*/);

			var sql = String.Format("INSERT INTO Employees (Id, name, DepId)" +
				"VALUES ('{0}', N'{1}', '{2}')",
				e.id,
				e.name,
				e.DepId);

			using (connection = new SqlConnection(connectionString))
			{
				connection.Open();

				SqlCommand command = new SqlCommand(sql, connection);
				command.ExecuteNonQuery();
			}
		}

        // PUT: api/Emp/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Emp/5
        public void Delete(int id)
        {
			var sql = String.Format("DELETE FROM Employees WHERE Id = '{0}'",
				id);

			using (connection = new SqlConnection(connectionString))
			{
				connection.Open();

				SqlCommand command = new SqlCommand(sql, connection);
				command.ExecuteNonQuery();
			}
		}
    }
}
