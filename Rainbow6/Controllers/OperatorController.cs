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
    public class OperatorController : Controller
    {
        private Rainbow6Context db = new Rainbow6Context();

        // GET: Operator/List
        [Route("operator/List/{position}")]
        public ActionResult List(int position)
        {
            string query = "select * from operators";
            if (position != 0)
            {
                query += " where positionId = " + position;
            }
            //if (!string.IsNullOrEmpty(searchKey))
            //{
            //    query += " where name like '%" + searchKey + "%'";
            //}

            var operators = db.Operators.SqlQuery(query).ToList();

            return View(operators);
        }

        // GET: Operator/id/{id}
        //[Route("operator/Details/{id}")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return Content("ERROR: ID NOT DEFINED <a href='../../operator/list/0'>BACK TO LIST</a>");
            }
            string operatorQuery = "select * from Operators where OperatorID = " + id;

            var o = db.Operators.SqlQuery(operatorQuery).ToList()[0];

            // weapons
            string weaponQuery = "select * from WeaponOperators join Weapons on Weapon_WeaponID = WeaponID where Operator_OperatorID = " + id;
            var weapons = db.Weapons.SqlQuery(weaponQuery).ToList();

            var viewModel = new ShowOperator()
            {
                Operator = o,
                Weapons = weapons
            };

            return View(viewModel);
        }

        //[Route("operator/position/{position}")]
        //public ActionResult ByPosition(string position)
        //{

        //    return Content(position);
        //}
        // GET: Operator/Add
        //public ActionResult Add(string alias, string name, int year, int month, int day, int organizationID, int positionID)
        //{
        //    int height = 190;
        //    int weight = 70;

        //    string query = "insert into operators (alias, name, birthyear, birthmonth, birthday,height,weight, organizationid, positionid) values (@alias, @name, @birthyear, @birthmonth, @birthday, @height,@weight,@organizationid, @positionid)";

        //    SqlParameter[] sqlparams = new SqlParameter[9];
        //    sqlparams[0] = new SqlParameter("alias", alias);
        //    sqlparams[1] = new SqlParameter("name", name);
        //    sqlparams[2] = new SqlParameter("birthyear", year);
        //    sqlparams[3] = new SqlParameter("birthmonth", month);
        //    sqlparams[4] = new SqlParameter("birthday", day);
        //    sqlparams[3] = new SqlParameter("height", height);
        //    sqlparams[4] = new SqlParameter("weight", weight);
        //    sqlparams[5] = new SqlParameter("organizationid", organizationID);
        //    sqlparams[6] = new SqlParameter("positionid", positionID);

        //    db.Database.ExecuteSqlCommand(query, sqlparams);

        //    return RedirectToAction("List/0");
        //}

        public ActionResult Add()
        {
            return View();
        }

        public ActionResult AddAction(string alias, string name, int year, int month, int day, int organizationID, int positionID)
        {
            int height = 190;
            int weight = 70;

            string query = "insert into operators (alias, name, birthyear, birthmonth, birthday,height,weight, organizationid, positionid) values (@alias, @name, @birthyear, @birthmonth, @birthday, @height,@weight,@organizationid, @positionid)";

            SqlParameter[] sqlparams = new SqlParameter[9];
            sqlparams[0] = new SqlParameter("alias", alias);
            sqlparams[1] = new SqlParameter("name", name);
            sqlparams[2] = new SqlParameter("birthyear", year);
            sqlparams[3] = new SqlParameter("birthmonth", month);
            sqlparams[4] = new SqlParameter("birthday", day);
            sqlparams[3] = new SqlParameter("height", height);
            sqlparams[4] = new SqlParameter("weight", weight);
            sqlparams[5] = new SqlParameter("organizationid", organizationID);
            sqlparams[6] = new SqlParameter("positionid", positionID);

            db.Database.ExecuteSqlCommand(query, sqlparams);

            return RedirectToAction("List/0");
        }

        public ActionResult Delete(int id)
        {
            string query = "Delete from operators where operatorid = " + id;

            db.Database.ExecuteSqlCommand(query);

            return RedirectToAction("List/0");
        }

        // GET: Operator/Edit
        //public ActionResult Edit(int id)
        //{


        //    return View(o);
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