using SFC_WEBAPI_MOCK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SFC_WEBAPI_MOCK.Controllers
{
    [Route("values")]
    public class ValuesController : ApiController
    {
        private List<SelectModel> Data = new List<SelectModel>();

        public ValuesController()
        {
            for (int i = 1; i <= 100; i++)
            {
                Data.Add(new SelectModel { Id = i, Value = $"value_{i}", Selected = i % 3 == 0 });
            }
        }

        // GET api/values
        public IEnumerable<SelectModel> Get()
        {
            return Data;
        }

        // GET api/values/5
        [Route("values/{id}")]
        public SelectModel Get(int id)
        {
            return Data.FirstOrDefault(m => m.Id == id);
        }        

        [HttpGet]
        [Route("values/pagination")]
        public PagedList<SelectModel> Get([FromUri]QueryStringParameters parameters)
        {
            parameters = parameters ?? new QueryStringParameters();
            return PagedList<SelectModel>.ToPagedList(Data.OrderBy(on => on.Id).AsQueryable(),
                    parameters.PageNumber,
                    parameters.PageSize);
        }

        [HttpPost]
        public IEnumerable<SelectModel> Get(List<int> ids)
        {
            return Data.Where(m => ids.Contains(m.Id));
        }
    }
}
