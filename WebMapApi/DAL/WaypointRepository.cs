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
			var order = GetCarId(orderId);
			if (order == null) throw new Exception($"this orderId = {orderId} don't exist");
			try
			{
				var sqlString = "Select UpdateTime, Latitude, Longitude from MobileDeviceData where CarId = " + order?.CarId;
				var waypoints = (List<Waypoint>)_db.Query<Waypoint>(sqlString);
				return waypoints;
			}
			catch (Exception ex)
			{
				throw new NotImplementedException(ex.Message);
			}			
		}

		public Order GetCarId(int orderId)
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