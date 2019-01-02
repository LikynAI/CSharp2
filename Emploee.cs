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
		public string name { get; set; }
		public int id { get; set; }
		public int DepId { get; set; }

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
