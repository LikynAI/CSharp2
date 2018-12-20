using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfApp1
{
	class Data
	{
		public List<Department> Departments;

		public Data()
		{
			Departments = new List<Department>();

			List<Emploee> It = new List<Emploee>();
			It.Add(new Emploee("Саша"));
			It.Add(new Emploee("Коля"));
			It.Add(new Emploee("Петя"));
			Departments.Add(new Department("It", It));

			List<Emploee> Managment = new List<Emploee>();
			Managment.Add(new Emploee("Катя"));
			Managment.Add(new Emploee("Вова"));
			Managment.Add(new Emploee("Настя"));
			Departments.Add(new Department("Managment", Managment));
	}

		internal void Update(ComboBox List)
		{
			foreach (Department department in Departments)
			{
				List.Items.Add(department.name);
			}		
		}

		internal void AddEmployee(string empName, string depName)
		{
			for (int i = 0; i < Departments.Count; i++)
			{
				if (Departments[i].name == depName)
				{
					Departments[i].emplist.Add(new Emploee(empName));
					break;
				}
			}
		}

		internal void AddDepartment(string name, ComboBox List)
		{
			bool flag = true;
			foreach (Department department in Departments)
			{
				if (department.name == name)
				{
					flag = false;
				}
			}
			if (flag)
			{
				Department newDepartment = new Department(name, new List<Emploee>());
				Departments.Add(newDepartment);
				List.Items.Add(newDepartment.name);
			}
		}

		internal string GetEmployees(string text)
		{
			string emps = string.Empty;
			foreach (Department department in Departments)
			{
				if(department.name == text)
				{
					foreach (Emploee employee in department.emplist)
					{
						emps += employee.name + "\n";
					}
					return emps;
				}
			}
			return "Пусто";
		}
	}
}
