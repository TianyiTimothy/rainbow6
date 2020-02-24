using Rainbow6.Data;
using Rainbow6.Models;
using Rainbow6.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rainbow6.Controllers
{
    public class WeaponController : Controller
    {
        private Rainbow6Context db = new Rainbow6Context();

        // GET: weapon/List
        public ActionResult List(string searchKey)
        {
            string query = "select * from weapons";
            if (!string.IsNullOrEmpty(searchKey))
            {
                query += " where name like '%" + searchKey + "%'";
            }

            var weapons = db.Weapons.SqlQuery(query).ToList();

            return View(weapons);
        }

        // GET: weapon/detail/{id}
        //[Route("weapon/detail/{id}")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return Content("ERROR: ID NOT DEFINED <a href='../../weapon/list'>BACK TO LIST</a>");
            }
            string weaponQuery = "select * from Weapons where WeaponID = " + id;

            var w = db.Weapons.SqlQuery(weaponQuery).ToList()[0];

            // weapons
            string operatorQuery = "select * from WeaponOperators join Operators on Operator_OperatorID = OperatorID where Weapon_WeaponID = " + id;
            var operators = db.Operators.SqlQuery(operatorQuery).ToList();

            var viewModel = new ShowWeapon()
            {
                Weapon = w,
                Operators = operators
            };

            return View(viewModel);
        }

        // Jumps to Add from here
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Add(string Name, string Type, string IngameDescription, string Description, string FireMode, string BackgroundImageUrl, string ImageUrl)
        {

            string query = "insert into weapons (Name, Type, IngameDescription, Description, FireMode, BackgroundImageUrl, ImageUrl) values (@Name,@Type,@IngameDescription,@Description,@FireMode,@BackgroundImageUrl,@ImageUrl)";
            SqlParameter[] sqlparams = new SqlParameter[7]; //0,1,2,3,4 pieces of information to add
            //each piece of information is a key and value pair
            sqlparams[0] = new SqlParameter("@Name", Name);
            sqlparams[1] = new SqlParameter("@Type", Type);
            sqlparams[2] = new SqlParameter("@IngameDescription", IngameDescription);
            sqlparams[3] = new SqlParameter("@Description", Description);
            sqlparams[4] = new SqlParameter("@FireMode", FireMode);
            sqlparams[5] = new SqlParameter("@BackgroundImageUrl", BackgroundImageUrl);
            sqlparams[6] = new SqlParameter("@ImageUrl", ImageUrl);

            //db.Database.ExecuteSqlCommand will run insert, update, delete statements
            //db.Pets.SqlCommand will run a select statement, for example.
            db.Database.ExecuteSqlCommand(query, sqlparams);


            return RedirectToAction("List");
        }

        public ActionResult Delete(int id)
        {
            string query = "Delete from weapons where weaponid = " + id;

            db.Database.ExecuteSqlCommand(query);

            return RedirectToAction("List");
        }


        public ActionResult Edit(int id)
        {

            string query = "Select * from weapons where weaponid = " + id;
            var weapon = db.Weapons.SqlQuery(query).ToList()[0];

            return View(weapon); 
        }
        public ActionResult Update(int id, string Name, string Type, string IngameDescription, string Description, string FireMode, string BackgroundImageUrl, string ImageUrl)
        {

            string query = "Update weapons set Name=@Name,Type=@Type,IngameDescription=@IngameDescription,Description=@Description,FireMode=@FireMode,BackgroundImageUrl=@BackgroundImageUrl,ImageUrl=@ImageUrl where weaponid=" + id;
            SqlParameter[] sqlparams = new SqlParameter[7]; //0,1,2,3,4 pieces of information to add
            //each piece of information is a key and value pair
            sqlparams[0] = new SqlParameter("@Name", Name);
            sqlparams[1] = new SqlParameter("@Type", Type);
            sqlparams[2] = new SqlParameter("@IngameDescription", IngameDescription);
            sqlparams[3] = new SqlParameter("@Description", Description);
            sqlparams[4] = new SqlParameter("@FireMode", FireMode);
            sqlparams[5] = new SqlParameter("@BackgroundImageUrl", BackgroundImageUrl);
            sqlparams[6] = new SqlParameter("@ImageUrl", ImageUrl);

            //db.Database.ExecuteSqlCommand will run insert, update, delete statements
            //db.Pets.SqlCommand will run a select statement, for example.
            db.Database.ExecuteSqlCommand(query, sqlparams);

            return RedirectToAction("List");

        }

        //// GET: Operator/Edit
        //public ActionResult Edit(int id)
        //{
        //    return Content("id=" + id);
        //}

        //// operator
        //public ActionResult Index(int? pageIndex, string sortBy)
        //{
        //    if (!pageIndex.HasValue)
        //    {
        //        pageIndex = 1;
        //    }

        //    if (String.IsNullOrWhiteSpace(sortBy))
        //    {
        //        sortBy = "Name";
        //    }

        //    return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        //}
    }
}