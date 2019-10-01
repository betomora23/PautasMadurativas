using System;
using madurativas.db;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;

namespace madurativas.Controllers
{
    public class HomeController : Controller
    {

        madurativasEntities db = new madurativasEntities();
        public ActionResult Index()

        {
            // Recibo los parametros desde DigiDoc con la info del paciente
            var source = Request.QueryString["src"];
            var apellido = Request.QueryString["apellido"];
            var nombre = Request.QueryString["nombre"];
            var fnac = Request.QueryString["fnac"];
            var ddPacienteId = Request.QueryString["pacienteId"];

            if(source == "dd")
            {
                ViewBag.fromDD = true;
                Session["fromDD"] = true;

                var pacienteDD = db.Pacientes.Where(p => p.pacienteIdDigidoc == ddPacienteId).FirstOrDefault();
                Paciente paciente;

                if(pacienteDD != null)
                {
                    paciente = pacienteDD;
                } 
                else
                {
                    paciente = new Paciente()
                    {
                        apellidos = apellido,
                        nombre = nombre,
                        fechaNacimiento = DateTime.Parse(fnac),
                        pacienteIdDigidoc = ddPacienteId
                    };
                }

                return View(paciente);
            }

            return View();
        }

        public JsonResult getPacientesJson()
        {
            var pacientesLst = db.Pacientes.Where(p => p.inactivo == false).ToList();            

            return Json(pacientesLst.Select(x => new {id= x.pacienteId, nombre = x.FullName, fechaNac = x.fechaNacimiento.ToString("dd/MM/yyyy") }), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult getEstudiosToDD(string pid)
        {
            var res = db.estudios.Where(e => e.Paciente.pacienteIdDigidoc == pid).ToList();

            return Json(res.Select(x => new { id = x.estudioId, fecha = x.fechaestudio.ToString("dd-MM-yyyy"), idPacienteDD = x.Paciente.pacienteIdDigidoc }), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Index([Bind(Include = "pacienteId,fechaestudio,digitado")] estudio estudio)
        public ActionResult Index(Paciente paciente)
        {

            if(Session["fromDD"] != null)
            {
                ViewBag.fromDD = Boolean.Parse(Session["fromDD"].ToString());
            }

            if(paciente.fechaNacimiento.Year == 1)
            {
                ViewBag.FaltaNombre = true;
                ViewBag.FaltaApellido = true;

                ViewBag.FaltaFNac = true;
                return View();
            }

            if(paciente.pacienteId != 0)
            {
                var ec = paciente.EC_antesNacimiento;
                var id = paciente.pacienteId;
                var aux = db.Pacientes.Where(p => p.pacienteId == id).FirstOrDefault();
                if (aux.EC_antesNacimiento != ec) aux.EC_antesNacimiento = ec;

                paciente = aux;
            }
            


            estudio estudio = new estudio();
            estudio.Paciente = paciente;
            //TODO: Lo saco porque no esta en la db
            //estudio.fechaestudio = Paciente.fechaestudio;
            estudio.fechaestudio = DateTime.Now;

            if (ModelState.IsValid)
            {              
                estudio.eval_riesgos = new eval_riesgos();
                estudio.mchat = new mchat();

                estudio.mchat.mchat_monitor_quest_1 = new mchat_monitor_quest_1();
                estudio.mchat.mchat_monitor_quest_2 = new mchat_monitor_quest_2();
                estudio.mchat.mchat_monitor_quest_3 = new mchat_monitor_quest_3();
                estudio.mchat.mchat_monitor_quest_4 = new mchat_monitor_quest_4();
                estudio.mchat.mchat_monitor_quest_5 = new mchat_monitor_quest_5();
                estudio.mchat.mchat_monitor_quest_6 = new mchat_monitor_quest_6();
                estudio.mchat.mchat_monitor_quest_7 = new mchat_monitor_quest_7();
                estudio.mchat.mchat_monitor_quest_8 = new mchat_monitor_quest_8();
                estudio.mchat.mchat_monitor_quest_9 = new mchat_monitor_quest_9();
                estudio.mchat.mchat_monitor_quest_10 = new mchat_monitor_quest_10();
                estudio.mchat.mchat_monitor_quest_11 = new mchat_monitor_quest_11();
                estudio.mchat.mchat_monitor_quest_12 = new mchat_monitor_quest_12();
                estudio.mchat.mchat_monitor_quest_13 = new mchat_monitor_quest_13();
                estudio.mchat.mchat_monitor_quest_14 = new mchat_monitor_quest_14();
                estudio.mchat.mchat_monitor_quest_15 = new mchat_monitor_quest_15();
                estudio.mchat.mchat_monitor_quest_16 = new mchat_monitor_quest_16();
                estudio.mchat.mchat_monitor_quest_17 = new mchat_monitor_quest_17();
                estudio.mchat.mchat_monitor_quest_18 = new mchat_monitor_quest_18();
                estudio.mchat.mchat_monitor_quest_19 = new mchat_monitor_quest_19();
                estudio.mchat.mchat_monitor_quest_20 = new mchat_monitor_quest_20();

                db.estudios.Add(estudio);
                db.SaveChanges();

                return RedirectToAction("Edit", new {id=estudio.estudioId});
            }

            return View(estudio);

        }


        public ActionResult Edit(int id)
        {
            estudio _estudio = db.estudios.FirstOrDefault(e => e.estudioId == id);

            var source = Request.QueryString["src"];
            if(source == "dd" || Session["fromDD"] != null)
            {
                ViewBag.fromDD = true;
                Session["fromDD"] = true;
            }

            //var pacientesLst = db.Pacientes.Where(p => p.inactivo == false).ToList();            

            //var pacientesSelectList = new SelectList(pacientesLst, "pacienteId", "FullName");
            //ViewBag.Pacientes = pacientesSelectList;

            if (_estudio == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);


            return View(_estudio);
        }


        public ActionResult evalRiesgos(int id)
        {
            var eval = db.eval_riesgos.FirstOrDefault(e => e.estudioid == id);            

            if(eval == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            ViewBag.px = eval.estudio.Paciente.FullName;
            ViewBag.fnacimiento = eval.estudio.Paciente.fechaNacimiento.Date.ToShortDateString();

            return View(eval);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]        
        //public void evalRiesgos(eval_riesgos evalRiesgos)
        public void evalRiesgos(eval_riesgos evalRiesgos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(evalRiesgos).State = EntityState.Modified;

                db.SaveChanges();
            }

            //ViewBag.px = evalRiesgos.estudio.Paciente.FullName;
            //ViewBag.fnacimiento = evalRiesgos.estudio.Paciente.fechaNacimiento.Date.ToShortDateString();       
        }


        public ActionResult EstudioDelDia()
        {

            var fechaBusqueda = DateTime.Now.AddDays(-1);
            var estudios = db.estudios.OrderByDescending(x => x.estudioId).ToList();

            return View(estudios);
        }

        public string SaveEvalRiesgos(eval_riesgos evalRiesgos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(evalRiesgos).State = EntityState.Modified;

                db.SaveChanges();
            }

            return ("ok");
        }

      
    }


}