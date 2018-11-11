﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Homework6.Service;
using Homework6.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Homework6.Controllers
{
    public class AdminController : Controller
    {
        TestpapersRepository testpapersRepository = new TestpapersRepository();
        TestpaperitemRepository testpaperitemRepository = new TestpaperitemRepository();

        // GET: Admin
        public ActionResult Index(string id)
        {
            ViewData["Userno"] = id;
            //ViewData["Userno"] = HttpContext.Session.GetString("user");
            ViewBag.Papers = testpapersRepository.SelectAll();
            return View();
        }
        public ActionResult Paper(int paperid)
        {
            ViewData["Userno"] = HttpContext.Session.GetString("user");
            ViewBag.Paperitem = testpaperitemRepository.SelectByPaperid(paperid);
            ViewBag.Papers = testpapersRepository.SelectByid(paperid);
            return View();
        }
        public ActionResult PaperAdd()
        {
            ViewData["Userno"] = HttpContext.Session.GetString("user");

            return View();
        }

        public RedirectToRouteResult AddTestPaper(TestpapersModel testpapers)
        {
            Debug.WriteLine(testpapers.papername + "!!!!!!!!!!!!");
            testpapersRepository.Insert(testpapers);
            return RedirectToRoute(new
            {
                controller = "Admin",
                action = "PaperAdd",
            });//重定向  
        }
        public int AddQuestion([FromBody]dynamic Json)
        {
            TestpaperitemModel testpaperitemModel = new TestpaperitemModel
            {
                question = Json.question,
                paperid = Json.paperid,
            };
            return testpaperitemRepository.Insert(testpaperitemModel);
        }
        public RedirectToRouteResult PaperDel(string userno, int paperid)
        {
            testpapersRepository.Delete(paperid);
            return RedirectToRoute(new
            {
                controller = "Admin",
                action = "Index",
                id = userno,
            });//重定向  
        }
    }
}