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
    public class ListServiciosPendientesController : ApiController
    {
        BDClass conn = new BDClass();
        // GET: api/ListServiciosPendientes
        public string Get()
        {
            List<ObjListFallas> lsit = conn.listReportesPendientes();
            string strserialize = JsonConvert.SerializeObject(lsit);
            return strserialize;
        }

        // GET: api/ListServiciosPendientes/5
        public HttpResponseMessage Get(string ContribuyenteID, string uuid)
        {

            DataTable lsit = conn.listComprobantesUUID(ContribuyenteID,uuid);
            string strserialize = JsonConvert.SerializeObject(lsit, Formatting.Indented);
            var response = this.Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(strserialize, Encoding.UTF8, "application/json");
            return response;
        }

        // POST: api/ListServiciosPendientes
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ListServiciosPendientes/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ListServiciosPendientes/5
        public void Delete(int id)
        {
        }
    }
}
