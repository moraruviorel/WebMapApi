using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMapApi.Models;

namespace WebMapApi.DAL
{
	internal interface IMobileDeviceTraceRepository
	{
		List<MobileDeviceTrace> MobileDeviceTraceList(int orderId);

		Order GetOrder(int orderId);
	}
}
