using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebMapApi.Models;

namespace WebMapApi.Controllers
{
    public class HeroesController : ApiController
    {
		// GET api/values
		public IEnumerable<Hero> Get()
		{
			return new Hero[] { new Hero { Id = 11, Name = "Mr. Nice" }, new Hero { Id = 12, Name = "Narco" } };

		}

		// GET api/values/5
		public Hero Get(int id)
		{
			return new Hero { Id = 11, Name = "Mr. Nice" };
		}

		// POST api/values
		public void Post([FromBody]string value)
		{
		}

		// PUT api/values/5
		public void Put(int id, [FromBody]string value)
		{
		}

		// DELETE api/values/5
		public void Delete(int id)
		{
		}
	}
}
