using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ProductQuotationMVC.EFDB;
using ProductQuotationMVC.Models;

namespace ProductQuotationMVC.Abstract
{
    public class AbstructUserClass
    {
        private static readonly ProductQuotationDBEntities dbEF = new ProductQuotationDBEntities();
        //public AbstructUserClass()
        //{
        //    dbEF = new ProductQuotationDBEntities();
        //}
        public static async Task<bool> UdateUserInfo(string aspNetuserID, RegisterViewModel obj)
        {
            try
            {
                dbEF.UserDetails.Add(new UserDetail()
                {
                    UserName = obj.UserName,
                    EmailID = obj.Email,
                    ContactNo = obj.Contact,
                    CreatedDate = DateTime.Now,
                    UserID = await GetUserIDAsync(aspNetuserID)
                });
                await dbEF.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public static async Task<int> GetUserIDAsync(string userID)
        {
            try
            {
                int userid = 0;
                if (dbEF.UserDetails.Count() > 0)
                {
                    userid = dbEF.UserDetails.Where(u => u.AspNetUsersID == userID).FirstOrDefault().UserID;
                }
                return userid;
            }
            catch (Exception ex)
            {
            }
            return 0;
        }


        public static int GetUserID(string userID)
        {
            try
            {
                int userid = 0;
                if (dbEF.UserDetails.Count() > 0)
                {
                    userid = dbEF.UserDetails.Where(u => u.AspNetUsersID == userID).FirstOrDefault().UserID;
                }
                return userid;
            }
            catch (Exception ex)
            {
            }
            return 0;
        }

        public static int GetUserID()
        {
            try
            {
                int userid = 0;
                string userID = User.Identity.GetUserId();
                if (dbEF.UserDetails.Count() > 0)
                {
                    userid = dbEF.UserDetails.Where(u => u.AspNetUsersID == userID).FirstOrDefault().UserID;
                }
                return userid;
            }
            catch (Exception ex)
            {
            }
            return 0;
        }
    }
}