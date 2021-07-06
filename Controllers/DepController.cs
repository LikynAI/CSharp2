using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DepController : ApiController
    {
		string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Lesson7;Integrated Security=True;Pooling=True";
		SqlConnection connection;

		[Route("deplist")]
		public List<Department> Get()
        {
			List<Department> Departments = new List<Department>();

			var sql2 = @"Select * FROM Departments";

			using (connection = new SqlConnection(connectionString))
			{
				connection.Open();

				SqlCommand command2 = new SqlCommand(sql2, connection);

				SqlDataReader reader = command2.ExecuteReader();

				while (reader.Read())
				{
					string name = Convert.ToString(reader.GetValue(1));
					int id = Convert.ToInt16(reader.GetValue(0));
					Departments.Add(new Department(name, id));
				}
				reader.Close();
			}
			return Departments;
		}

		[Route("addemp/{id}")]
		public Department Get(int id)
        {
			var sql2 = @"Select * FROM Departments";

			using (connection = new SqlConnection(connectionString))
			{
				connection.Open();

				SqlCommand command2 = new SqlCommand(sql2, connection);

				SqlDataReader reader = command2.ExecuteReader();

				if (reader.Read())
				{
					string name = Convert.ToString(reader.GetValue(1));
					int Id = Convert.ToInt16(reader.GetValue(0));
					Department d = new Department(name, id);
					reader.Close();
					return d;
				}
				else return new Department();
			}
			
		}

		[Route("adddep")]
		public void Post([FromBody]string value)
        {
			Department d = new Department(/*text, v1, v2*/);

			var sql = String.Format("INSERT INTO Employees (Id, name, DepId)" +
				"VALUES ('{0}', N'{1}')",
				d.id,
				d.name);
		}

        // PUT: api/Dep/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Dep/5
        public void Delete(int id)
        {
        }
    }
}
