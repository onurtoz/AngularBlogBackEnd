using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AngularBlog.Business.Model.Response
{
    [Serializable]
    public class ServiceResponse<T>
    {
        public bool HasExceptionError { get; set; }
        public bool ResultMessage { get; set; }
        public int Count { get; set; }
        public int TotalCount { get; set; }
        public int AddOrUpdateProcess { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ExceptionMessage { get; set; }
        [JsonProperty]
        public T Entity { get; set; }

    }
}
