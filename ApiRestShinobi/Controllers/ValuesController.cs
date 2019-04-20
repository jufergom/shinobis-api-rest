using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ApiRestShinobi.Models;
using MySql.Data.MySqlClient;

namespace ApiRestShinobi.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public List<Shinobi> Get()
        {
            return null;
        }
        
        // GET api/values/5
        public Shinobi Get(int id)
        {
            return null;
        }

        // POST api/values
        public void Post(Shinobi s)
        {
            
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string name, int age, string rank)
        {
            
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            
        }
    }
}
