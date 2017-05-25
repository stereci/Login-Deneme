using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoginDeneme.Models
{
    public class AuthenticationDetail
    {
        public string Detail { set; get; }
        public int ErrorCode { set; get; }
        public string user { set; get; }
        public string name { set; get; }
        public string surname { set; get; }
        public string email { set; get; }
        
        //public List<Credential> credentials { set; get; }
    }
}