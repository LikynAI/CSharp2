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
		Data data;
		public MainWindow()
		{
			InitializeComponent();

			data = new Data();
			DepartmentsList.DataContext = data;
		}

		private void EmployeesListUpdate(object sender, SelectionChangedEventArgs e)
		{
			data.Refresh(EmployeesList, DepartmentsList);
		}

		private void AddDepartment(object sender, RoutedEventArgs e)
		{
			data.AddDep(DepartmentName.Text,int.Parse(DepartmentId.Text));
		}

		private void DeletDepartment(object sender, RoutedEventArgs e)
		{
			data.DeletDep(DepartmentsList);
		}

		private void AddEmployee(object sender, RoutedEventArgs e)
		{
			data.AddEmpl(EmployeeName.Text,int.Parse(EmployeeId.Text),int.Parse(EmployeeDepId.Text));
			data.Refresh(EmployeesList, DepartmentsList);
		}

		private void DeletEmployee(object sender, RoutedEventArgs e)
		{
			data.DelEmployee(EmployeesList);
		}
	}
}
