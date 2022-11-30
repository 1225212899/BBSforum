using Microsoft.Data.SqlClient;
using MyBBSWebApi.DAL.Core;
using MyBBSWebApi.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace MyBBSWebApi.DAL
{
    public class UserDal
    {
        public List<User> GetAll()
        {
            string sqlText = "select * from Users ";
            DataTable res = SqlHelper.ExecuteTable(sqlText);
            List<User> UserList = DataTableToModelList(res);
            return UserList;
        }

        public List<User> UserListGetByUserNoAndPwd(string userNo, string pwd)
        {
            string sqlText = "select * from Users where UserNo = @userNo and PassWord = @PassWord";
            DataTable res = SqlHelper.ExecuteTable(sqlText, new SqlParameter[] {
                new SqlParameter("@userNo", userNo),
                new SqlParameter("@PassWord", pwd)
            });
            List<User> UserList = DataTableToModelList(res);
            return UserList;
        }

        public User UserGetById(int id) //有问题
        {
            string sqlText = "select * from Users where id = @id";
            DataTable res = SqlHelper.ExecuteTable(sqlText, new SqlParameter("@id", id));
            DataRow dr = res.Rows[0];
            User user = DataRowToModel(dr);
            return user;
        }

        public void UserInsert(int userNo, string userName, string userSex)
        {
            string sqlText = "insert into Users(userNo,userName,userSex)values(@userNo, @userName, @userSex)";

            SqlHelper.ExecuteNonQuery(sqlText, new SqlParameter[] {
                new SqlParameter("@userNo",userNo),
                new SqlParameter("@userName",userName),
                new SqlParameter("userSex",userSex)
            });
        }

        public void UserUpdata(int id, int? userNo, string userName, int? userlevel, string password, string userSex)
        {
            string sqlText =
                "UPDATE Users SET userNo=@userNo,userName=@userName,userlevel=@userlevel,password=@password,userSex=@userSex WHERE id =@Id ";
            User user1 = UserGetById(id);
            User user2 = new User();
            user2.Id = user1.Id;
            user2.UserNo = userNo ?? user1.UserNo;
            user2.UserName = userName ?? user1.UserName;
            user2.Userlevel = userlevel ?? user1.Userlevel;
            user2.Password = password ?? user1.Password;
            user2.UserSex = userSex ?? user1.UserSex;
            SqlHelper.ExecuteNonQuery(sqlText, new SqlParameter[]
            {
                new SqlParameter("@Id",user2.Id),
                new SqlParameter("@userNo",user2.UserNo),
                new SqlParameter("@userName",user2.UserName),
                new SqlParameter("@userlevel",user2.Userlevel),
                new SqlParameter("@password",user2.Password),
                new SqlParameter("@userSex",user2.UserSex),
            });

        }

        private User DataRowToModel(DataRow dr)
        {
            User user = new User();
            user.Id = Convert.ToInt32(dr["Id"]); //如果值为空就会报错！！！！！！！！！！！！！！
            user.UserNo = Convert.ToInt32(dr["userNo"]);
            user.UserName = dr["UserName"].ToString();
            user.Userlevel = Convert.ToInt32(dr["userlevel"]);
            user.Password = dr["Password"].ToString();
            user.UserSex = dr["UserSex"].ToString();
            user.IsDelete = (bool)dr["IsDelete"];
            return user;
        }
        private List<User> DataTableToModelList(DataTable res)
        {
            List<User> UserList = new List<User>();
            for (int i = 0; i < res.Rows.Count; i++)
            {
                DataRow dr = res.Rows[i];
                UserList.Add(new User
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    UserNo = Convert.ToInt32(dr["userNo"]),
                    UserName = dr["UserName"].ToString(),
                    Userlevel = Convert.ToInt32(dr["Userlevel"]),
                    Password = dr["Password"].ToString(),
                    UserSex = dr["UserSex"].ToString(),
                    IsDelete = (bool)dr["IsDelete"]
                });
            }
            return UserList;
        }

    }
}

