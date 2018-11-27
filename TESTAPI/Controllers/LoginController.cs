using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Script.Serialization;
using TESTAPI.Objetos;
namespace TESTAPI.Controllers
{
    public class LoginController : ApiController
    {

        BDClass conn = new BDClass();
        // GET: api/student
        [EnableCors(origins: "http://201.174.71.55", headers: "*", methods: "*")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/student/5
        public HttpResponseMessage Get(string usuario, string password)
        {
            ObjLogin login = conn.login(usuario, password);
            if (login.UserName != "")
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                string json = js.Serialize(login);
                var response = this.Request.CreateResponse(HttpStatusCode.OK);
                response.Content = new StringContent(json, Encoding.UTF8, "application/json");
                return response;
                // return Request.CreateResponse(HttpStatusCode.OK, json); ;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, "{\"id\":0,\"nombre\":\"\"}");
            }
        }

        // POST: api/student
        public HttpResponseMessage Post([FromBody]infoLogin value)
        {
            ObjLogin login = conn.login(value.UserName,value.Password);
            if (login.UserName != "")
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                string json = js.Serialize(login);
                var response = this.Request.CreateResponse(HttpStatusCode.OK);
                response.Content = new StringContent(json, Encoding.UTF8, "application/json");
                return response;
                // return Request.CreateResponse(HttpStatusCode.OK, json); ;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, "{\"id\":0,\"nombre\":\"\"}");
            }
        }

        // PUT: api/student/5
        public String Put(int id, int comezon, [FromBody]string value)
        {
            return "";
        }

        // DELETE: api/student/5
        public void Delete(int id)
        {
        }
    }
    public class infoLogin{
        public string UserName { get; set; }
        public string Password { get; set; }

    }
}
