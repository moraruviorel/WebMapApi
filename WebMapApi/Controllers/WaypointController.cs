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
    public class WaypointController : ApiController
    {
		private WaypointRepository _ourWaypointRespository = new WaypointRepository();

		// GET: api/Waypoint
		public IEnumerable<Waypoint> Get()
		{
			var res = _ourWaypointRespository.GetWaypoints(25025780);
			return res;
		}

		// GET: api/Waypoint/5
		public IEnumerable<Waypoint> Get(int id)
        {
			var res = _ourWaypointRespository.GetWaypoints(id);
			return res;
        }

        //// POST: api/Waypoint
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Waypoint/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Waypoint/5
        //public void Delete(int id)
        //{
        //}
    }
}
