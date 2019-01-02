using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Models
{
	/// <summary>
	/// Класс описывающий работника
	/// </summary>
	public class Emploee
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

		public Emploee() { }

		public override string ToString()
		{
			return name;
		}
	}
}
