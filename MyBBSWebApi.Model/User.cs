using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBBSWebApi.Model
{
    public class User
    {
        public int Id { get; set; }
        public int UserNo { get; set; }
        public string UserName { get; set; }
        public int Userlevel { get; set; }
        public string Password { get; set; }
        public string UserSex { get; set; }
        public bool IsDelete { get; set; }

    }
}
