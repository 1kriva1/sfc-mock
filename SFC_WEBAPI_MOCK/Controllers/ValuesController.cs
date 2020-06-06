using SFC_WEBAPI_MOCK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SFC_WEBAPI_MOCK.Controllers
{
    [Route("values")]
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class ValuesController : ApiController
    {
        private List<SelectModel> Data = new List<SelectModel>();

        private List<SelectGroupModel> DataGroup = new List<SelectGroupModel>();

        public ValuesController()
        {
            for (int i = 1; i <= 100; i++)
            {
                Data.Add(new SelectModel { Id = i, Value = $"value_{i}", Selected = i % 3 == 0 });
            }

            for (int i = 1; i <= 4; i++)
            {
                var dataGroup = new SelectGroupModel { GroupId = i, GroupValue = $"group_value_{i}", Options = new List<SelectModel>() };
                for (int j = 1; j <= 5; j++)
                {
                    dataGroup.Options.Add(new SelectModel { Id = j, Value = $"value_{j}", Selected = j % 3 == 0 });
                }

                DataGroup.Add(dataGroup);
            }
        }

        // GET api/values
        [HttpGet]
        [Route("values/sleep/{sleep?}")]
        public IEnumerable<SelectModel> GetSleep(int sleep = 0)
        {
            Thread.Sleep(sleep);
            return Data;
        }

        // GET api/values
        [HttpGet]
        [Route("values/group/sleep/{sleep?}")]
        public IEnumerable<SelectGroupModel> GetGroupSleep(int sleep = 0)
        {
            Thread.Sleep(sleep);
            return DataGroup;
        }

        // GET api/values/5
        [Route("values/{id}")]
        public SelectModel Get(int id)
        {
            return Data.FirstOrDefault(m => m.Id == id);
        }

        [HttpGet]
        [Route("values/pagination")]
        public IHttpActionResult Get([FromUri]QueryStringParameters parameters)
        {
            Thread.Sleep(parameters.Sleep);

            parameters = parameters ?? new QueryStringParameters();
            var data = PagedList<SelectModel>.ToPagedList(Data.OrderBy(on => on.Id).AsQueryable(),
                    parameters.PageNumber,
                    parameters.PageSize);

            return Json(new
            {
                Items = data,
                Total = data.TotalCount,
                CurrentPage = data.CurrentPage,
                TotalPages = data.TotalPages,
                HasPrevious = data.HasPrevious,
                HasNext = data.HasNext
            });
        }

        //[HttpPost]
        //public IEnumerable<SelectModel> Get(List<int> ids)
        //{
        //    return Data.Where(m => ids.Contains(m.Id));
        //}

        [HttpPost]
        public HttpResponseMessage Post()
        {
            var res = Request.CreateResponse(HttpStatusCode.Forbidden);
            res.Content = new StringContent("test", Encoding.UTF8, "text/html");

            return res;
        }
    }
}
