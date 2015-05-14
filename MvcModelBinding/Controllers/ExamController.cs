using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcModelBinding.Controllers
{
    public class ExamController : Controller
    {
        public ActionResult InsertMarkInformation()
        {
            Models.MarksClass mark = new Models.MarksClass();
            return View(mark);
        }

        [HttpPost]
        public ActionResult InsertMarkInformation(Models.MarksClass mark)
        {
            mark.insertMark();
            ViewBag.msg = "Insert Completed..";
            return View(mark);
        }

        public ActionResult SearchMarkInformation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SearchMarkInformation(FormCollection frm)
        {
            Models.MarksClass mark = new Models.MarksClass();
            mark = mark.getMark(Convert.ToInt32(frm[0]),Convert.ToInt32(frm[1]));
            ViewBag.tid = mark.traineeID;
            ViewBag.tround = mark.traineeRound;
            ViewBag.examNum = mark.examNumber;
            ViewBag.eviMark = mark.evidenceMark;
            ViewBag.desMark = mark.descriptiveMark;
            ViewBag.mcqMark = mark.mcqMark;
            ViewBag.exmDate = mark.examDate;
            return View();
        }
    }
}
