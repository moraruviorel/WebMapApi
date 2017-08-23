using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMapApi.Models;

namespace WebMapApi.DAL
{
	internal interface IWaypointRepository
	{
		List<Waypoint> GetWaypoints(int orderId);

		Order GetCarId(int orderId);



	}
}
