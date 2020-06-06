using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SFC_WEBAPI_MOCK.Models
{
    public class SelectGroupModel
    {
        public int GroupId { get; set; }

        public string GroupValue { get; set; }

        public List<SelectModel> Options { get; set; }
    }
}