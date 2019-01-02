using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfApp1
{
	class Data
	{
		public ObservableCollection<Department> Departments { get; set; }
		public ObservableCollection<Emploee> Employees { get; set; }

		string connectionString;

		SqlConnection connection;

		public Data()
		{
			Departments = new ObservableCollection<Department>();
			Employees = new ObservableCollection<Emploee>();

			connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Lesson7;Integrated Security=True;Pooling=True";

			var sql1 = @"Select * FROM Departments";

			var sql2 = @"Select * FROM Employees";

			using (connection = new SqlConnection(connectionString))
			{
				connection.Open();

				SqlCommand command1 = new SqlCommand(sql1, connection);

				SqlDataReader reader = command1.ExecuteReader();

				while (reader.Read())
				{
					string name = Convert.ToString(reader.GetValue(1));
					int id = Convert.ToInt16(reader.GetValue(0));
					Departments.Add(new Department(name,id));
				}
				reader.Close();

				SqlCommand command2 = new SqlCommand(sql2, connection);

				reader = command2.ExecuteReader();

				while (reader.Read())
				{
					string name = Convert.ToString(reader.GetValue(1));
					int id = Convert.ToInt16(reader.GetValue(0));
					int DepId = Convert.ToInt16(reader.GetValue(2));
					Employees.Add(new Emploee(name,id,DepId));
				}
				reader.Close();
			}
		}

		public void Refresh(ListBox Employees, ComboBox Departments)
		{
			Employees.ItemsSource = this.Employees.Where
				(w => w.DepId == (Departments.SelectedValue as Department)?.id);
		}

		public void DeletDep(ComboBox Departments)
		{
			var sql = String.Format("DELETE FROM Employees WHERE DepId = '{0}'",
				(Departments.SelectedItem as Department).id);

			var sql2 = String.Format("DELETE FROM Departments WHERE id = '{0}'",
				(Departments.SelectedItem as Department).id);

			using (connection = new SqlConnection(connectionString))
			{
				connection.Open();

				SqlCommand command = new SqlCommand(sql, connection);
				command.ExecuteNonQuery();

				SqlCommand command2 = new SqlCommand(sql2, connection);
				command2.ExecuteNonQuery();
			}

			for (int i = 0; i < Employees.Count; i++)
			{
				if (Employees[i].DepId == (Departments.SelectedItem as Department).id)
				{
					Employees.Remove(Employees[i]);
				}
			}
			this.Departments.Remove(Departments.SelectedItem as Department);
		}

		internal void DelEmployee(ListBox employeesList)
		{
			var sql = String.Format("DELETE FROM Employees WHERE Id = '{0}'",
				(employeesList.SelectedItem as Emploee).id);

			using (connection = new SqlConnection(connectionString))
			{
				connection.Open();

				SqlCommand command = new SqlCommand(sql, connection);
				command.ExecuteNonQuery();
			}

			Employees.Remove(employeesList.SelectedItem as Emploee);
		}

		internal void AddDep(string name, int id)
		{
			Department d = new Department(name, id);
			Departments.Add(d);

			var sql = String.Format("INSERT INTO Departments (Id, name)" +
				"VALUES ('{0}', N'{1}')",
				d.id,
				d.name);

			using (connection = new SqlConnection(connectionString))
			{
				connection.Open();

				SqlCommand command = new SqlCommand(sql, connection);
				command.ExecuteNonQuery();
			}
		}

		internal void AddEmpl(string text, int v1, int v2)
		{
			Emploee e = new Emploee(text, v1, v2);
			Employees.Add(e);

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
	}
}
