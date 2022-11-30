using MyBBSWebApi.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBBSWebApi.BLL.InterFace
{
    public interface IUserBll
    {
        public List<User> GetAll();

        public User CheakLogin(string userNo, string passWord);

        public void Insert(int userNo, string userName, string userSex);

        public void Updata(int id, int? userNo, string userName, int? userlevel, string password, string userSex);

    }
}
