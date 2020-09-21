using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SFC_WEBAPI_MOCK.Models
{
    public class RadioButtonModel
    {
        public int Id { get; set; }

        public string Value { get; set; }

        public string Icon { get; set; }

        public bool? IsDefault { get; set; }

        public bool? IsDisabled { get; set; }
    }
}