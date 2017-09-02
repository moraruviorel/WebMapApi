using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebMapApi.Models;
using Dapper;
using System.Web.Http;
using System.Net;

namespace WebMapApi.DAL
{
	
	public class WaypointRepository : IWaypointRepository
	{

		private IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
		
		public List<Waypoint> GetWaypoints(int orderId)
		{
			var order = GetOrder(orderId);
			if (order == null) throw new Exception($"this orderId = {orderId} don't exist");
			try
			{
				var hour = DateTime.Now.Hour;
				var minute = DateTime.Now.Minute;
				var sec = DateTime.Now.Second;
				var sqlString = "select Latitude, Longitude from MobileDeviceTrace " + 
					"where MobileDeviceId = 161 " +
					"and TraceTime between '2016-12-14 10:45:55' and '2016-12-14 " + hour + ":" + minute + ":" + sec + "' " +
					"order by TraceTime";
				//"Select Latitude, Longitude from MobileDeviceData where CarId = " + order?.CarId;
					//UpdateTime, 
				var waypoints = (List<Waypoint>)_db.Query<Waypoint>(sqlString);
				//delete the same points
				Waypoint waypoint = null;
				List<Waypoint> waypointList = new List<Waypoint>();
				foreach (var item in waypoints)
				{
					if (waypoint != null)
					{
						if (waypoint.Latitude != item.Latitude && waypoint.Longitude != item.Longitude)
							waypointList.Add(item);
					}
					else waypointList.Add(item);
					waypoint = item;
				}
				return waypointList;
			}
			catch (Exception ex)
			{
				throw new NotImplementedException(ex.Message);
			}			
		}

		public Order GetOrder(int orderId)
		{
			var order = new Order();
			try
			{
				var sqlString = "Select Id, CarId, CustomerArrivedTime, ClosedTime from [Order] where id = " + orderId;
				order = (Order)_db.Query<Order>(sqlString).FirstOrDefault();
			}
			catch (Exception ex)
			{
				throw new NotImplementedException(ex.Message);
			}
			return order;
		}

	}
}