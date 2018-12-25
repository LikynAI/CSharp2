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
			Departments.ItemsSource = data.Departments;
			Departments.SelectedIndex = 0;
			this.DataContext = data;
		}

		private void Departments_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			data.Refresh(Employees, Departments);
			if (!(Departments.SelectedItem is null))
			{
				iddep.Text = Convert.ToString((Departments.SelectedItem as Department).id);
			}
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			data.Employees.Remove(Employees.SelectedItem as Emploee);
			data.Refresh(Employees, Departments);
		}

		private void depdel_Click(object sender, RoutedEventArgs e)
		{
			data.DeletDep(Departments);
			Departments.SelectedIndex = 0;
		}

		private void AddDep_Click(object sender, RoutedEventArgs e)
		{
			data.AddDep(depname.Text,int.Parse(iddep.Text));
		}

		private void depChange_Click(object sender, RoutedEventArgs e)
		{
			data.Departments[data.Departments.IndexOf(Departments.SelectedItem as Department)].id
				= int.Parse(iddep.Text);
			data.Departments[data.Departments.IndexOf(Departments.SelectedItem as Department)].name
				= depname.Text;
		}
	}
}
