using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HttpServerTest
{
    public partial class server : Page
    {
        private static string goodToken = "Boom!";

        [WebMethod]
        public static string authenticate(string username, string password)
        {
         
        //HttpContext ctx = HttpContext.Current;
        string token = "";
            if(username == "alfred" && password == "nobel")
            {
                token = goodToken;
            }

            return token;

        }

        [WebMethod]
        public static People[] getData()
        {
            HttpContext context = HttpContext.Current;
            string token = context.Request.Headers.Get("X-Api-Token");
            if(token != null && token == goodToken)
            {
                return users;
            }
            else
            {
                return null;
            }
        }

    public class People
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public int role { get; set; }
    }

      public static People[] users = new People[]
        {
            new People { id = 1, name = "Haleemah Redfern", email = "email1@mail.com", phone = "01111111", role = 1},
            new People { id = 2, name = "Aya Bostock", email = "email2@mail.com", phone = "01111111", role = 1},
            new People { id = 3, name = "Sohail Perez", email = "email3@mail.com", phone = "01111111", role = 1},
            new People { id = 4, name = "Merryn Peck", email = "email4@mail.com", phone = "01111111", role = 2},
            new People { id = 5, name = "Cairon Reynolds", email = "email5@mail.com", phone = "01111111", role = 3}
        };

    }

}