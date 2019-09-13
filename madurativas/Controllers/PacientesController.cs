using madurativas.db;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace madurativas.Controllers
{
    public class PacientesController : Controller
    {
        private madurativasEntities db = new madurativasEntities();

        // GET: Pacientes
        public ActionResult Index()
        {
            return View(db.Pacientes.Where(px => px.inactivo == false).ToList());
        }

        // GET: Pacientes/Details/5
        public ActionResult Details(decimal id)
        {
 

            Paciente paciente = db.Pacientes.Find(id);
            
            if (paciente == null)
            {
                return HttpNotFound();
            }

            var estudiosRealizados = paciente.estudios.AsEnumerable();

            ViewBag.Estudios = estudiosRealizados;

            return View(paciente);
        }

        // GET: Pacientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pacientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "pacienteId,nombre,apellidos,fechaNacimiento,EC_antesNacimiento,inactivo")] Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                db.Pacientes.Add(paciente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(paciente);
        }

        // GET: Pacientes/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paciente paciente = db.Pacientes.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }

        // POST: Pacientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "pacienteId,nombre,apellidos,fechaNacimiento,EC_antesNacimiento")] Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paciente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(paciente);
        }

        // GET: Pacientes/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paciente paciente = db.Pacientes.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }

        // POST: Pacientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            Paciente paciente = db.Pacientes.Find(id);

            paciente.inactivo = true;

            //db.Pacientes.Remove(paciente);

            
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public string getFechaNacimientoPaciente(int id)
        {
            var _paciente = db.Pacientes.FirstOrDefault(p => p.pacienteId == id);

            var FechaPX = _paciente?.fechaNacimiento.Date.ToString("yyyy-MM-dd") ?? DateTime.Today.Date.ToString("yyyy-MM-dd");

            return FechaPX;

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
