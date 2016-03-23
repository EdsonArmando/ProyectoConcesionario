using AutoVentasASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoVentasASP.Controllers
{
    public class CuentaController : Controller
    {

        public DB_CONCESIONARIO db = new DB_CONCESIONARIO();
        // GET: Cuenta
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Usuario usuario)
        {
            var usr = db.usuario.FirstOrDefault(u => u.correo == usuario.correo && u.contraseña == usuario.contraseña);
            if (usr !=null)
            {
                Session["nombreUsuario"] = usr.nombre;
                Session["idUsuario"] = usr.idUsuario;
                return VerificarSesion();
            }
            else
            {
                ModelState.AddModelError("","Verifica tus credenciales");
            }
            return View();
        }
        // GET: Cuenta
        public ActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registro(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                Rol rol = db.rol.FirstOrDefault(r=> r.idRol==2);
                usuario.rol = rol;
                db.usuario.Add(usuario);
                db.SaveChanges();
                ViewBag.mensaje = "El usuario " + usuario.nombre + " Fue registrado satisfactoriamente.";
                ModelState.Clear();
            }
            return View();
        }
        public ActionResult VerificarSesion()
        {
            if (Session["idUsuario"]!=null)
            {
                return RedirectToAction("../Home/Index");
            }
            else
            {
                return RedirectToAction("Login");
            }
            return View();
        }


    }
}