using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMapApi.Models
{
	public class Order
	{		
		public int Id { get; set; }

		public int MobileDeviceId { get; set; }

		public int CarId { get; set; }

		public DateTime CarArrivedTime { get; set; }

		public DateTime CustomerArrivedTime { get; set; }

		public DateTime ClosedTime { get; set; }
	}
}