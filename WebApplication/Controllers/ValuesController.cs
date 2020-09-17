using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using indice.Edi;
using Newtonsoft.Json;

namespace WebApplication.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public HttpResponseMessage Get() {
            var grammar = EdiGrammar.NewX12();
            string file = @"C:\Users\dell\Desktop\New Text Document.txt";

            var x12_856 = new EdiSerializer().Deserialize<AdvanceShipNotice_856>(new StreamReader(file), grammar);

            string jsonResult = JsonConvert.SerializeObject(x12_856);
            File.WriteAllText(@"C:\Users\dell\Desktop\React\src\components\Result.json", jsonResult);

            string json = File.ReadAllText(@"C:\Users\dell\Desktop\React\src\components\Result.json");

            return Request.CreateResponse(HttpStatusCode.OK, json);


        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
