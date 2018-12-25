using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
	/// <summary>
	/// Класс описывающий работника
	/// </summary>
	class Emploee
	{
		public string name;
		public int id;
		public int DepId;

		public Emploee(string name, int id, int DepId)
		{
			this.name = name;
			this.id = id;
			this.DepId = DepId;
		}

		public override string ToString()
		{
			return name;
		}
	}
}
