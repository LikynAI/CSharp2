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
		public int id;

		public Department(string name, int id)
		{
			this.name = name;
			this.id = id;
		}

		public override string ToString()
		{
			return name;
		}
	}
}
