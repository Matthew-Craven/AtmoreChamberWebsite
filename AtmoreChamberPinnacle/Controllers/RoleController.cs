﻿using AtmoreChamberPinnacle.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AtmoreChamberPinnacle.Controllers
{
    public class RoleController : Controller
    {
        ApplicationDbContext context;

        public RoleController()
        {
            context = new ApplicationDbContext();
        }

        //index of roles
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var Roles = context.Roles.ToList();
            return View(Roles);
        }

        //Create GET
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            var Role = new IdentityRole();
            return View(Role);
        }

        //Create POST
        [Authorize(Roles ="Admin")]
        public ActionResult Create(IdentityRole Role)
        {
            context.Roles.Add(Role);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}