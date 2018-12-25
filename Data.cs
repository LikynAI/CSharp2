using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfApp1
{
	class Data
	{
		public ObservableCollection<Department> Departments;
		public ObservableCollection<Emploee> Employees;

		public Data()
		{
			Departments = new ObservableCollection<Department>();
			Employees = new ObservableCollection<Emploee>();
			for (int i = 1; i < 4; i++)
			{
				Departments.Add(new Department($"Департамент_{i}",i));
			}
			for (int i = 1; i < 4; i++)
			{
				for (int j = 1; j < 6; j++)
				{
					Employees.Add(new Emploee($"Имя_{i*j}", i*j,i));
				}
			}
		}
		public void Refresh(ListBox Employees, ComboBox Departments)
		{
			Employees.ItemsSource = this.Employees.Where
				(w => w.DepId == (Departments.SelectedValue as Department)?.id);
		}

		public void DeletDep(ComboBox Departments)
		{
			for (int i = 0; i < Employees.Count; i++)
			{
				if (Employees[i].DepId == (Departments.SelectedItem as Department).id)
				{
					Employees.Remove(Employees[i]);
				}
			}
			this.Departments.Remove(Departments.SelectedItem as Department);
		}

		internal void AddDep(string name, int id)
		{
			Departments.Add(new Department(name, id));
		}
	}
}
