using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebMapApi.Models;
using WebMapApi.DAL;

namespace WebMapApi.Controllers
{
    public class MobileDeviceTraceController : ApiController
    {
		private MobileDeviceTraceRepository _ourMobileDeviceTraceRespository = new MobileDeviceTraceRepository();

		// GET: api/MobileDeviceTrace/5
		public IEnumerable<MobileDeviceTrace> Get(int id)
        {
			var res = _ourMobileDeviceTraceRespository.MobileDeviceTraceList(id);
			return res;
        }
		
    }
}
