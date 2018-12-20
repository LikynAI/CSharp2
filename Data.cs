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

		/// <summary>
		/// Обновление СоmboBox с департаментами
		/// </summary>
		/// <param name="List"></param>
		internal void DepartmentUpdate(ComboBox List)
		{
			List.Items.Clear();
			foreach (Department department in Departments)
			{
				List.Items.Add(department.name);
			}		
		}

		/// <summary>
		/// Добавление департамента в список
		/// </summary>
		/// <param name="empName"></param>
		/// <param name="depName"></param>
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

		/// <summary>
		/// Удаление сотрудника
		/// </summary>
		/// <param name="text"></param>
		/// <param name="index"></param>
		internal void Delet(string text, int index)
		{
			if (!(index >= 0)) { return; }
			for (int i = 0; i < Departments.Count; i++)
			{
				if (Departments[i].name == text)
				{
					Departments[i].emplist.RemoveAt(index);
					break;
				}
			}
		}

		/// <summary>
		/// Удаление депвртамента
		/// </summary>
		/// <param name="text"></param>
		internal void Delet(string text)
		{
			for (int i = 0; i < Departments.Count; i++)
			{
				if (Departments[i].name == text)
				{
					Departments.RemoveAt(i);
					break;
				}
			}
		}

		/// <summary>
		/// Добавление рабочего в список департамента
		/// </summary>
		/// <param name="name"></param>
		/// <param name="List"></param>
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
				DepartmentUpdate(List);
			}
		}

		/// <summary>
		/// Возвращает список работников Ввиде строки 
		/// </summary>
		/// <param name="text"></param>
		/// <returns></returns>
		internal void UpdateEmployees(ListBox employees, string text)
		{
			employees.Items.Clear();
			foreach (Department department in Departments)
			{
				if(department.name == text)
				{
					foreach (Emploee employee in department.emplist)
					{
						employees.Items.Add(employee.name);
					}
				}
			}
		}
	}
}
