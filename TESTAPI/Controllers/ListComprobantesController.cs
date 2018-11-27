using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using TESTAPI.Objetos;

namespace TESTAPI.Controllers
{
    public class ListComprobantesController : ApiController
    {
        BDClass conn = new BDClass();
        // GET: api/ListComprobantes
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ListComprobantes/5
        public HttpResponseMessage Get(string id)
        {
            DataTable lsit = conn.listComprobantes(id);
            string strserialize = JsonConvert.SerializeObject(lsit,Formatting.Indented);
            var response = this.Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(strserialize, Encoding.UTF8, "application/json");
            return response;
        }

        // POST: api/ListComprobantes
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ListComprobantes/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ListComprobantes/5
        public void Delete(int id)
        {
        }
    }
}
