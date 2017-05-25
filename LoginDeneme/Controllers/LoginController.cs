using LoginDeneme.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;

namespace LoginDeneme.Controllers
{
    public class LoginController : ApiController
    {
        List<Credential> UserList = new List<Credential>();

        /*  [HttpPost]
          public IHttpActionResult CheckCredential(Credential credential)
          {
              using (linqLoginDataContext dc = new linqLoginDataContext())
              {
                  var user = dc.loginforms.FirstOrDefault(f => f.username == credential.UserName && f.password == credential.Password);
                  //UserList.Add(user);
                  if (user != null)
                  {
                      return Json(new AuthenticationDetail { Detail="Success" , ErrorCode=0, user=credential.UserName, pass=credential.Password });
                  }
              }
              return Json(new AuthenticationDetail { Detail = "Failed", ErrorCode = -1, user = credential.UserName, pass = credential.Password });
          }*/
        private AuthenticationDetail GetCredential(Credential credential)
        {
            using (linqloginDataContext dc = new linqloginDataContext())
            {

                var user = dc.loginforms.FirstOrDefault(f => f.username == credential.UserName && f.password == credential.Password);
                if (user != null)
                {
                    return new AuthenticationDetail { Detail = "Success", ErrorCode = 0, user = credential.UserName, name = credential.Name, surname = credential.Surname, email = credential.Email };
                }
            }
            return new AuthenticationDetail { Detail = "Failed", ErrorCode = -1, user = credential.UserName, name = credential.Name, surname = credential.Surname, email = credential.Email };
        }
        [HttpPost]
        public IHttpActionResult GetAllCredentials()
        {
            using (linqloginDataContext dc = new linqloginDataContext())
            {
                var users2 = from user in dc.users select user;
                foreach (var user in users2)
                {
                    Credential cs = new Credential();
                    cs.UserName = user.username;
                    cs.Name = user.name;
                    cs.Surname = user.surname;
                    cs.Email = user.email;
                    UserList.Add(cs);
                }
                if (UserList != null)
                {
                    return Json(UserList.ToList());
                }
                return Json(UserList.ToList());
            }

        }
        /*
              public List<Credential> GetMyTypes(Credential credential)
              {
                  using (linqLoginDataContext dc = new linqLoginDataContext())
                  {
                      var user = dc.loginforms.FirstOrDefault(f => f.username == credential.UserName && f.password == credential.Password);
                      return (from myType in dc.loginforms
                              select new AuthenticationDetail
                              {
                                  MyValue = AuthenticationDetail.
                              }).ToList();
                  }
              }*/

    }
}
