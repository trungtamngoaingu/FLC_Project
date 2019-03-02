using Project.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Models;
using Project.Util;
using PagedList;

namespace Project.Controllers
{
    public class AboutController : Controller
    {
        //kết nối dbase
        DbConnection con = new DbConnection();
        /// <summary>
        /// In ra About
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            try
            {
                var query = from About in con.Abouts
                            where About.IsActive == true
                            select About;
                if (query != null && query.Count() > 0)
                {
                    List<GetAboutModels> listAbout = new List<GetAboutModels>();
                    foreach (var item in query)
                    {
                        GetAboutModels aboutModel = new GetAboutModels();
                        aboutModel.ID = item.ID;
                        aboutModel.Name = item.Name;
                        aboutModel.MetaTitle = item.MetaTitle;
                        aboutModel.Description = item.Description;
                        aboutModel.Image = item.Image;
                        aboutModel.Detail = item.Detail;
                        aboutModel.CreatedDate = (DateTime)item.CreatedDate;
                        aboutModel.CreatedBy = item.CreatedBy;
                        aboutModel.ModifiedDate = (DateTime)item.ModifiedDate;
                        aboutModel.ModifiedBy = item.ModifiedBy;
                        aboutModel.MetaKeywords = item.MetaKeywords;
                        aboutModel.MetaDescriptions = item.MetaDescriptions;
                        aboutModel.Status = (bool)item.Status;
                        aboutModel.IsActive = (bool)item.IsActive;
                        listAbout.Add(aboutModel);
                    }
                    return View(listAbout);
                }
                else
                {
                    return View(new List<GetAboutModels>());
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Tìm kiếm About
        /// </summary>
        /// <param name="Page"></param>
        /// <param name="FullName"></param>
        /// <param name="AboutName"></param>
        /// <param name="Phone"></param>
        /// <param name="Group"></param>
        /// <returns></returns>
        //public PartialViewResult Seach(int Page, string FullName, string AboutName, string Phone, int Group = 0)
        //{
        //    try
        //    {

        //    }
        //    catch
        //    {

        //    }
        //}

        /// <summary>
        /// Thêm About
        /// </summary>
        /// <param name="addAbout"></param>
        /// <returns></returns>
        public int AddAbout(AddAboutModels addAbout)
        {
            try
            {
                About ab = new About()
                {
                    Name = addAbout.Name,
                    MetaTitle = addAbout.MetaTitle,
                    Description = addAbout.Description,
                    Image = addAbout.Image,
                    Detail = addAbout.Detail,
                    CreatedDate = (DateTime)addAbout.CreatedDate,
                    CreatedBy = addAbout.CreatedBy,
                    ModifiedDate = (DateTime)addAbout.ModifiedDate,
                    ModifiedBy = addAbout.ModifiedBy,
                    MetaKeywords = addAbout.MetaKeywords,
                    MetaDescriptions = addAbout.MetaDescriptions,
                    Status = (bool)addAbout.Status,
                    IsActive = true
                };
                con.Abouts.Add(ab);
                con.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public JsonResult GetAboutById(long Id)
        {
            try
            {
                var query = con.Abouts.Find(Id);

                if (query != null)
                {
                    GetAboutModels AboutModels = new GetAboutModels()
                    {
                        ID = query.ID,
                        //  userModels.GroupId = (long)us.GroupId;
                        Name = query.Name,
                        MetaTitle = query.MetaTitle,
                        Description = query.Description,
                        Image = query.Image,
                        Detail = query.Detail,
                        CreatedDate = (DateTime)query.CreatedDate,
                        CreatedBy = query.CreatedBy,
                        ModifiedDate = (DateTime)query.ModifiedDate,
                        ModifiedBy = query.ModifiedBy,
                        MetaKeywords = query.MetaKeywords,
                        MetaDescriptions = query.MetaDescriptions,
                        Status = (bool)query.Status,
                        IsActive = true
                    };
                    return Json(AboutModels, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new GetAboutModels(), JsonRequestBehavior.AllowGet);
                }
            }
            catch
            {
                return Json(new GetAboutModels(), JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// Sửa Thông Tin About 
        /// </summary>
        /// <param name="editAboutModels">Thông Tin About Cần Sủa</param>
        /// <returns></returns>
        public int EditAbout(EditAboutModels editAboutModels)
        {
            try
            {
                About about = con.Abouts.Find(editAboutModels.ID);

                if (about != null)
                {

                    about.Name = editAboutModels.Name;
                    about.MetaTitle = editAboutModels.MetaTitle;
                    about.Description = editAboutModels.Description;
                    about.Image = editAboutModels.Image;
                    about.Detail = editAboutModels.Detail;
                    about.CreatedDate = (DateTime)editAboutModels.CreatedDate;
                    about.CreatedBy = editAboutModels.CreatedBy;
                    about.ModifiedDate = (DateTime)editAboutModels.ModifiedDate;
                    about.ModifiedBy = editAboutModels.ModifiedBy;
                    about.MetaKeywords = editAboutModels.MetaKeywords;
                    about.MetaDescriptions = editAboutModels.MetaDescriptions;
                    about.Status = (bool)editAboutModels.Status;
                    about.IsActive = (bool)editAboutModels.IsActive;
                    con.SaveChanges();
                    return Constants.RETURN_TRUE;
                }
                else
                {
                    return Constants.RETURN_FALSE;
                }
            }
            catch
            {
                return Constants.RETURN_FALSE;
            }
        }

        /// <summary>
        /// Xóa Thông Tin About
        /// </summary>
        /// <param name="Id">Mã của About</param>
        /// <returns></returns>
        public int DeleteAbout(long Id)
        {

            try
            {
                About about = con.Abouts.Find(Id);
                if (about != null)
                {
                    about.IsActive = false;
                    con.SaveChanges();
                    return Constants.RETURN_TRUE;

                }
                return Constants.RETURN_FALSE;

            }
            catch
            {
                return Constants.RETURN_FALSE;
            }
        }

    }
}