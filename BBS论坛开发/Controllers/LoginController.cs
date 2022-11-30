
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MyBBSWebApi.BLL.InterFace;
using MyBBSWebApi.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BBS论坛开发.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserBll userBll;

        public LoginController(IUserBll userBll) 
        {
            this.userBll = userBll;
        }

        [HttpGet]
        public List<User> GetAll()
        {
            
            return userBll.GetAll();
            
        }
        [HttpGet]
        public User Get(string userNo,string password)
        {
            
            return userBll.CheakLogin(userNo, password);
            
        }

        [HttpPost] //数据添加
        public string Insert(int userNo, string userName, string userSex)
        {
            userBll.Insert(userNo, userName, userSex);
            return "添加成功";
        }

        //[HttpDelete]
        //public int Delete(int id)
        //{
        //    string sqlText = "delete from StudentInfo where stuId = @Id";
        //    return SqlHelper.ExecuteNonQuery(sqlText, new SqlParameter[] {
        //        new SqlParameter("@Id",id)
        //    });

        //}

        [HttpPut]
        public string Updata(int id, int? userNo, string userName, int? userlevel, string password, string userSex)
        {
            userBll.Updata(id, userNo, userName, userlevel, password, userSex);
            return "修改成功";

        }
    }
}
