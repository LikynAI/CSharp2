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

			data.Update(Departments);

			Departments.DropDownClosed += EmpUpdate;
			depbtn.Click += AddNewDepartment;
			emplbtn.Click += AddNewEmployee;
		}

		/// <summary>
		/// Добавление нового департамента
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void AddNewEmployee(object sender, RoutedEventArgs e)
		{
			data.AddEmployee(AddEmployee.Text, Departments.Text);
			EmpUpdate(Departments,new EventArgs());
		}

		/// <summary>
		/// Добавление нового работника в выбранный в данный момент департамент
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void AddNewDepartment(object sender, RoutedEventArgs e)
		{
			data.AddDepartment(AddDepartment.Text,Departments);			
		}

		/// <summary>
		/// Обновление TextBox'а со списком работников
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void EmpUpdate(object sender, EventArgs e)
		{
			Employees.Text = data.GetEmployees(Departments.Text);			
		}
	}
}
