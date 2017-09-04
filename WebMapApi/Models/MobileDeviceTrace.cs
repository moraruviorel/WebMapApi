using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMapApi.Models
{
	public class MobileDeviceTrace
	{
		public string Id { get; set; }
		
		public int CarNicknameId { get; set; }

		public int MobileDeviceId { get; set; }
		
		public DateTime TraceTime { get; set; }

		public Double Latitude { get; set; }

		public Double Longitude { get; set; }
	}
}