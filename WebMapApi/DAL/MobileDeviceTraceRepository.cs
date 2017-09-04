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
	
	public class MobileDeviceTraceRepository : IMobileDeviceTraceRepository
	{

		private IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
		
		public List<MobileDeviceTrace> MobileDeviceTraceList(int orderId)
		{
			var order = GetOrder(orderId);
			if (order == null) throw new Exception($"this orderId = {orderId} don't exist");
			try
			{
				string pattern = "yyyy-MM-dd HH:mm:ss";
				//
				string dt1;
				if (order.CustomerArrivedTime == null || order.CustomerArrivedTime == DateTime.MinValue)
					dt1 = order.CarArrivedTime.ToString(pattern);
				else dt1 = order.CustomerArrivedTime.ToString(pattern);
				//
				var dt2 = DateTime.Now.ToString(pattern);
				if (order.ClosedTime != null)
				{
					dt2 = order.ClosedTime.AddMinutes(10).ToString(pattern);
				}
				//
				var sqlString = "select mdt.CarNicknameId, mdt.MobileDeviceId, mdt.TraceTime, mdt.Latitude, mdt.Longitude " +
								"from MobileDeviceTrace mdt " +
								"where mdt.MobileDeviceId = " + order.MobileDeviceId + " " +
								"and TraceTime between '" + dt1 + "' and '" + dt2 + "' " +
								"order by TraceTime"; 


				var MobileDeviceTraceDbList = (List<MobileDeviceTrace>)_db.Query<MobileDeviceTrace>(sqlString);
				//delete the same points
				MobileDeviceTrace mobileDeviceTrace = null;
				List<MobileDeviceTrace> mobileDeviceTraceList = new List<MobileDeviceTrace>();
				foreach (var item in MobileDeviceTraceDbList)
				{
					if (mobileDeviceTrace != null)
					{
						if (mobileDeviceTrace.Latitude != item.Latitude && mobileDeviceTrace.Longitude != item.Longitude)
							mobileDeviceTraceList.Add(item);
					}
					else mobileDeviceTraceList.Add(item);
					mobileDeviceTrace = item;
				}
				return mobileDeviceTraceList;
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
				var sqlString = "select o.id, mdd.MobileDeviceId, mdd.CarId, o.CarArrivedTime, o.CustomerArrivedTime, o.ClosedTime " +
								"from[Order] o " +
								"inner join MobileDeviceData mdd on mdd.CarId = o.CarId " +
								"where o.Id = " + orderId;
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