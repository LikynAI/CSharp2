using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Models
{
	public class Department
	{
		public string name { get; set; }
		public int id { get; set; }

		public Department(string name, int id)
		{
			this.name = name;
			this.id = id;
		}

		public Department() { }

		public override string ToString()
		{
			return name;
		}
	}
}
