using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMapApi.Models
{
	public class Waypoint
	{
		public DateTime UpdateTime { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }
	}
}