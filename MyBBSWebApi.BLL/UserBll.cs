using MyBBSWebApi.BLL.InterFace;
using MyBBSWebApi.DAL;
using MyBBSWebApi.Model;
using System;
using System.Collections.Generic;

namespace MyBBSWebApi.BLL
{
    public class UserBll : IUserBll
    {

        public List<User> GetAll()
        {
            UserDal userDal = new UserDal();
            List<User> userList = userDal.GetAll();
            return userList.FindAll(m => m.IsDelete == false);
        }

        public User CheakLogin(string userNo, string passWord)
        {
            UserDal userDal = new UserDal();
            List<User> userList = userDal.UserListGetByUserNoAndPwd(userNo, passWord);
            if (userList.Count <= 0)
            {
                return default;
            }
            else
            {
                User user = userList.Find(m => m.IsDelete == false);
                return user;
            }
        }

        public void Insert(int userNo, string userName, string userSex)
        {
            UserDal userDal = new UserDal();
            userDal.UserInsert(userNo, userName, userSex);
        }

        public void Updata(int id, int? userNo, string userName, int? userlevel, string password, string userSex)
        {
            UserDal userDal = new UserDal();
            userDal.UserUpdata(id, userNo, userName, userlevel, password, userSex);
        }

       
    }
}
