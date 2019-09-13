using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using madurativas.db;

namespace madurativas.Controllers
{
    public class mChatController : Controller
    {

        madurativasEntities db = new madurativasEntities();
        // GET: mChat
        public ActionResult Index(int id)
        {
            //if (id == 0) return HttpNotFound();

            mchat _mchat = db.mchats.Include(m => m.estudio).FirstOrDefault(m => m.estudio_id == id);

            if (_mchat == null)
            {
                mchat _newmchat = new mchat()
                {
                    estudio = db.estudios.FirstOrDefault(m=> m.estudioId == id),
                    estudio_id = id
                   
                };
                
                return View(_newmchat);
            }

            if (_mchat.completado) return View("Seguimiento", _mchat);

            return View(_mchat);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(mchat mChat)
        {
            if (ModelState.IsValid)
            {
                var _MC = db.mchats.Where(m => m.estudio_id == mChat.estudio_id);

                if (_MC.Count() != 0)
                {
                    
                    db.Entry(mChat).State = EntityState.Modified;
                }
                else
                {
                    AgregaRegistroSeguimiento(mChat);
                    db.mchats.Add(mChat);
                }
                mChat.completado = true;

                db.SaveChanges();

                ViewBag.Puntuacion =  puntuacion(mChat);
                
                var _estudio = db.mchats.Include("estudio").Single(m=> m.estudio_id == mChat.estudio_id).estudio;

                mChat.estudio = _estudio;
            }
            return View(mChat);

        }


        //public ActionResult Editar(int id)
        public ActionResult Editar(int id)
        {
            if (id == 0) return HttpNotFound();

            mchat _mchat = (from es in db.mchats
                            select es).FirstOrDefault(m => m.estudio_id == id);

            if (_mchat == null) return HttpNotFound("Registro no encontrado.");

            _mchat.completado = false;

            db.SaveChanges();

            //return Content("ok");
            return View("~/Views/Home/Edit.cshtml", _mchat);
            //return PartialView("~/Views/Home/PartialView/mChat/_mChat.cshtml", _mchat);
            //return View(_mchat);

        }

        private void AgregaRegistroSeguimiento(mchat mChat)
        {
            mChat.mchat_monitor_quest_1 = new mchat_monitor_quest_1() {estudioId = mChat.estudio_id};
            mChat.mchat_monitor_quest_2 = new mchat_monitor_quest_2(){estudioId = mChat.estudio_id};
            mChat.mchat_monitor_quest_3 = new mchat_monitor_quest_3(){estudioId = mChat.estudio_id};
            mChat.mchat_monitor_quest_4 = new mchat_monitor_quest_4(){estudioId = mChat.estudio_id};
            mChat.mchat_monitor_quest_5 = new mchat_monitor_quest_5(){estudioId = mChat.estudio_id};
            mChat.mchat_monitor_quest_6 = new mchat_monitor_quest_6(){estudioId = mChat.estudio_id};
            mChat.mchat_monitor_quest_7 = new mchat_monitor_quest_7(){estudioId = mChat.estudio_id};
            mChat.mchat_monitor_quest_8 = new mchat_monitor_quest_8(){estudioId = mChat.estudio_id};
            mChat.mchat_monitor_quest_9 = new mchat_monitor_quest_9() { estudioId = mChat.estudio_id };
            mChat.mchat_monitor_quest_10 = new mchat_monitor_quest_10(){estudioId = mChat.estudio_id};
            mChat.mchat_monitor_quest_11 = new mchat_monitor_quest_11(){estudioId = mChat.estudio_id};
            mChat.mchat_monitor_quest_12 = new mchat_monitor_quest_12(){estudioId = mChat.estudio_id};
            mChat.mchat_monitor_quest_13 = new mchat_monitor_quest_13(){estudioId = mChat.estudio_id};
            mChat.mchat_monitor_quest_14 = new mchat_monitor_quest_14(){estudioId = mChat.estudio_id};
            mChat.mchat_monitor_quest_15 = new mchat_monitor_quest_15(){estudioId = mChat.estudio_id};
            mChat.mchat_monitor_quest_16 = new mchat_monitor_quest_16(){estudioId = mChat.estudio_id};
            mChat.mchat_monitor_quest_17 = new mchat_monitor_quest_17(){estudioId = mChat.estudio_id};
            mChat.mchat_monitor_quest_18 = new mchat_monitor_quest_18(){estudioId = mChat.estudio_id};
            mChat.mchat_monitor_quest_19 = new mchat_monitor_quest_19(){estudioId = mChat.estudio_id};
            mChat.mchat_monitor_quest_20 = new mchat_monitor_quest_20(){estudioId = mChat.estudio_id};

        }

        private int puntuacion(mchat mChat)
        {
            int puntuacion = 0;
            
            if (mChat.quest_1 != null) { if (!Convert.ToBoolean(mChat.quest_1)) puntuacion++; }            
            if (mChat.quest_2 != null) { if (Convert.ToBoolean(mChat.quest_2)) puntuacion++; }
            if (mChat.quest_3 != null) { if (!Convert.ToBoolean(mChat.quest_3)) puntuacion++; }
            if (mChat.quest_4 != null) { if (!Convert.ToBoolean(mChat.quest_4)) puntuacion++; }            
            if (mChat.quest_5 != null) { if (Convert.ToBoolean(mChat.quest_5)) puntuacion++; }
            if (mChat.quest_6 != null) { if (!Convert.ToBoolean(mChat.quest_6)) puntuacion++; }
            if (mChat.quest_7 != null) { if (!Convert.ToBoolean(mChat.quest_7)) puntuacion++; }
            if (mChat.quest_8 != null) { if (!Convert.ToBoolean(mChat.quest_8)) puntuacion++; }
            if (mChat.quest_9 != null) { if (!Convert.ToBoolean(mChat.quest_9)) puntuacion++; }
            if (mChat.quest_10 != null) { if (!Convert.ToBoolean(mChat.quest_10)) puntuacion++; }
            if (mChat.quest_11 != null) { if (!Convert.ToBoolean(mChat.quest_11)) puntuacion++; }            
            if (mChat.quest_12 != null) { if (Convert.ToBoolean(mChat.quest_12)) puntuacion++; }   
            if (mChat.quest_13 != null) { if (!Convert.ToBoolean(mChat.quest_13)) puntuacion++; }
            if (mChat.quest_14 != null) { if (!Convert.ToBoolean(mChat.quest_14)) puntuacion++; }
            if (mChat.quest_15 != null) { if (!Convert.ToBoolean(mChat.quest_15)) puntuacion++; }
            if (mChat.quest_16 != null) { if (!Convert.ToBoolean(mChat.quest_16)) puntuacion++; }
            if (mChat.quest_17 != null) { if (!Convert.ToBoolean(mChat.quest_17)) puntuacion++; }
            if (mChat.quest_18 != null) { if (!Convert.ToBoolean(mChat.quest_18)) puntuacion++; }
            if (mChat.quest_19 != null) { if (!Convert.ToBoolean(mChat.quest_19)) puntuacion++; }
            if (mChat.quest_20 != null) { if (!Convert.ToBoolean(mChat.quest_20)) puntuacion++; }
            //if (!Convert.ToBoolean(mChat.quest_1)) puntuacion++;
            //if (Convert.ToBoolean(mChat.quest_2)) puntuacion++;
            //if (!Convert.ToBoolean(mChat.quest_3)) puntuacion++;
            //if (!Convert.ToBoolean(mChat.quest_4)) puntuacion++;
            //if (Convert.ToBoolean(mChat.quest_5)) puntuacion++;
            //if (!Convert.ToBoolean(mChat.quest_6)) puntuacion++;
            //if (!Convert.ToBoolean(mChat.quest_7)) puntuacion++;
            //if (!Convert.ToBoolean(mChat.quest_8)) puntuacion++;
            //if (!Convert.ToBoolean(mChat.quest_9)) puntuacion++;
            //if (!Convert.ToBoolean(mChat.quest_10)) puntuacion++;
            //if (!Convert.ToBoolean(mChat.quest_11)) puntuacion++;
            //if (Convert.ToBoolean(mChat.quest_12)) puntuacion++;
            //if (!Convert.ToBoolean(mChat.quest_13)) puntuacion++;
            //if (!Convert.ToBoolean(mChat.quest_14)) puntuacion++;
            //if (!Convert.ToBoolean(mChat.quest_15)) puntuacion++;
            //if (!Convert.ToBoolean(mChat.quest_16)) puntuacion++;
            //if (!Convert.ToBoolean(mChat.quest_17)) puntuacion++;
            //if (!Convert.ToBoolean(mChat.quest_18)) puntuacion++;
            //if (!Convert.ToBoolean(mChat.quest_19)) puntuacion++;
            //if (!Convert.ToBoolean(mChat.quest_20)) puntuacion++;

            return puntuacion;
        }
        
        public ActionResult Seguimiento(int id)
        {
            var mChat = db.mchats
                            .Include("estudio")
                            .Include("mchat_monitor_quest_1")
                            .Include("mchat_monitor_quest_2")
                            .Include("mchat_monitor_quest_3")
                            .Include("mchat_monitor_quest_4")
                            .Include("mchat_monitor_quest_5")
                            .Include("mchat_monitor_quest_6")
                            .Include("mchat_monitor_quest_7")
                            .Include("mchat_monitor_quest_8")
                            .Include("mchat_monitor_quest_9")
                            .Include("mchat_monitor_quest_10")
                            .Include("mchat_monitor_quest_11")
                            .Include("mchat_monitor_quest_12")
                            .Include("mchat_monitor_quest_13")
                            .Include("mchat_monitor_quest_14")
                            .Include("mchat_monitor_quest_15")
                            .Include("mchat_monitor_quest_16")
                            .Include("mchat_monitor_quest_17")
                            .Include("mchat_monitor_quest_18")
                            .Include("mchat_monitor_quest_19")
                            .Include("mchat_monitor_quest_20")
                            .Single(m => m.estudio_id == id);

            var pacientesLst = db.Pacientes.Where(p => p.inactivo == false).ToList();

            var pacientesSelectList = new SelectList(pacientesLst, "pacienteId", "FullName");
            ViewBag.Pacientes = pacientesSelectList;


            return View(mChat);
            //return PartialView("~/Views/Home/PartialView/mChat/_Seguimiento.cshtml", mChot);
        }        

        public ActionResult detailQuest(int qId)
        {
            switch (qId)
            {
                case 1:
                    return PartialView("PartialView/m-chat/details/_detailQuest_1");
                case 2:
                    return PartialView("PartialView/m-chat/details/_detailQuest_2");

                case 3:
                    return PartialView("PartialView/m-chat/details/_detailQuest_3");
                case 4:
                    return PartialView("PartialView/m-chat/details/_detailQuest_4");
                case 5:
                    return PartialView("PartialView/m-chat/details/_detailQuest_5");
                case 6:
                    return PartialView("PartialView/m-chat/details/_detailQuest_6");

                case 7:
                    return PartialView("PartialView/m-chat/details/_detailQuest_7");

                case 8:
                    return PartialView("PartialView/m-chat/details/_detailQuest_8");

                case 9:
                    return PartialView("PartialView/m-chat/details/_detailQuest_9");

                case 10:
                    return PartialView("PartialView/m-chat/details/_detailQuest_10");

                case 11:
                    return PartialView("PartialView/m-chat/details/_detailQuest_11");

                case 12:
                    return PartialView("PartialView/m-chat/details/_detailQuest_12");

                case 13:
                    return PartialView("PartialView/m-chat/details/_detailQuest_13");

                case 14:
                    return PartialView("PartialView/m-chat/details/_detailQuest_14");

                case 15:
                    return PartialView("PartialView/m-chat/details/_detailQuest_15");

                case 16:
                    return PartialView("PartialView/m-chat/details/_detailQuest_16");


                case 17:
                    return PartialView("PartialView/m-chat/details/_detailQuest_17");

                case 18:
                    return PartialView("PartialView/m-chat/details/_detailQuest_18");

                case 19:
                    return PartialView("PartialView/m-chat/details/_detailQuest_19");

                case 20:
                    return PartialView("PartialView/m-chat/details/_detailQuest_20");

            }

            return HttpNotFound();
        }

        private void GuardarSeguimiento<T>(T mchat) where T : class
        {
            db.Set<T>().AddOrUpdate(mchat);
            db.SaveChanges();
        }

        #region Seguimiento

        

        [HttpPost]
        public void SaveDetailQuest1(mchat_monitor_quest_1 mchat)
        {
            GuardarSeguimiento(mchat);
        }


        [HttpPost]
        public void SaveDetailQuest2(mchat_monitor_quest_2 mchat )
        {
           GuardarSeguimiento(mchat);
        }

        [HttpPost]
        public void SaveDetailQuest3(mchat_monitor_quest_3 mchat)
        {
            GuardarSeguimiento(mchat);
        }

        [HttpPost]
        public void SaveDetailQuest4(mchat_monitor_quest_4 mchat)
        {
            GuardarSeguimiento(mchat);
        }

        [HttpPost]
        public void SaveDetailQuest5(mchat_monitor_quest_5 mchat)
        {
            GuardarSeguimiento(mchat);
        }

        [HttpPost]
        public void SaveDetailQuest6(mchat_monitor_quest_6 mchat)
        {
            GuardarSeguimiento(mchat);
        }

        [HttpPost]
        public void SaveDetailQuest7(mchat_monitor_quest_7 mchat)
        {
            GuardarSeguimiento(mchat);
        }

        [HttpPost]
        public void SaveDetailQuest8(mchat_monitor_quest_8 mchat)
        {
            GuardarSeguimiento(mchat);
        }

        [HttpPost]
        public void SaveDetailQuest9(mchat_monitor_quest_9 mchat)
        {
            GuardarSeguimiento(mchat);
        }

        [HttpPost]
        public void SaveDetailQuest10(mchat_monitor_quest_10 mchat)
        {
            GuardarSeguimiento(mchat);
        }

        [HttpPost]
        public void SaveDetailQuest11(mchat_monitor_quest_11 mchat)
        {
            GuardarSeguimiento(mchat);
        }

        [HttpPost]
        public void SaveDetailQuest12(mchat_monitor_quest_12 mchat)
        {
            GuardarSeguimiento(mchat);
        }
        [HttpPost]
        public void SaveDetailQuest13(mchat_monitor_quest_13 mchat)
        {
            GuardarSeguimiento(mchat);
        }
        [HttpPost]
        public void SaveDetailQuest14(mchat_monitor_quest_14 mchat)
        {
            GuardarSeguimiento(mchat);
        }
        [HttpPost]
        public void SaveDetailQuest15(mchat_monitor_quest_15 mchat)
        {
            GuardarSeguimiento(mchat);
        }
        [HttpPost]
        public void SaveDetailQuest16(mchat_monitor_quest_16 mchat)
        {
            GuardarSeguimiento(mchat);
        }
        [HttpPost]
        public void SaveDetailQuest17(mchat_monitor_quest_17 mchat)
        {
            GuardarSeguimiento(mchat);
        }
        [HttpPost]
        public void SaveDetailQuest18(mchat_monitor_quest_18 mchat)
        {
            GuardarSeguimiento(mchat);
        }

        [HttpPost]
        public void SaveDetailQuest19(mchat_monitor_quest_19 mchat)
        {
            GuardarSeguimiento(mchat);
        }
        [HttpPost]
        public void SaveDetailQuest20(mchat_monitor_quest_20 mchat)
        {
            GuardarSeguimiento(mchat);
        }
        #endregion

        public string GuardaMChat(mchat mChat)
        {
            if (ModelState.IsValid)
            {
                var _MC = db.mchats.Where(m => m.estudio_id == mChat.estudio_id);
                
                if (_MC.Count() != 0)
                {

                    db.Entry(mChat).State = EntityState.Modified;

                }
                else
                {
                    AgregaRegistroSeguimiento(mChat);
                    db.mchats.Add(mChat);
                }
                mChat.completado = true;

                db.SaveChanges();

                ViewBag.Puntuacion = puntuacion(mChat);

                var _estudio = db.mchats.Include("estudio").Single(m => m.estudio_id == mChat.estudio_id).estudio;

                mChat.estudio = _estudio;
            }
            //return View(mChat);
            return ("Ok");
        }

    }
}