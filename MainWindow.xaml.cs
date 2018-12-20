using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		Data data = new Data();

		public MainWindow()
		{
			InitializeComponent();

			data.DepartmentUpdate(Departments);

			Departments.DropDownClosed += EmpUpdate;
		}

		
		/// <summary>
		/// Обновление TextBox'а со списком работников
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void EmpUpdate(object sender, EventArgs e)
		{
			data.UpdateEmployees(Employees,Departments.Text);			
		}

		private void DeletDep_Click(object sender, RoutedEventArgs e)
		{
			data.Delet(Departments.Text);
		}

		private void DeletEmp_Click(object sender, RoutedEventArgs e)
		{
			data.Delet(Departments.Text, Employees.SelectedIndex);
			EmpUpdate(Departments, new EventArgs());
		}

		private void depbtn_Click(object sender, RoutedEventArgs e)
		{
			data.AddDepartment(AddDepartment.Text, Departments);
		}

		private void emplbtn_Click(object sender, RoutedEventArgs e)
		{
			data.AddEmployee(AddEmployee.Text, Departments.Text);
			EmpUpdate(Departments, new EventArgs());
		}
	}
}
