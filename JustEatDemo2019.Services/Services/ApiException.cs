using System;
using System.Runtime.Serialization;

namespace JustEatDemo2019.Services.Services
{
    [Serializable]
    public class ApiException : Exception
    {
        public int StatusCode { get; set; }
        public string Content { get; set; }
    }
}