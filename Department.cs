using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
	class Department
	{
		public string name;
		public List<Emploee> emplist;

		public Department(string name, List<Emploee> emplist)
		{
			this.name = name;
			this.emplist = emplist;
		}
	}
}
