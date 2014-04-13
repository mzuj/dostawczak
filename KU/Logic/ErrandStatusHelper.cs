using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KU.Models;
using System.Data.Entity;

namespace KU.Logic
{
    public class ErrandStatusHelper 
    {
        private ZlecenieEntities db = new ZlecenieEntities();

        public int GetStatusIdByName(String statusName) 
        {
            var idStatusCompleted = from s in db.StatusZlecenie
                                    where s.Nazwa.Equals(statusName)
                                    select s.Id;
            return idStatusCompleted.First();
        }

        public void SetErrandStatus(String statusName, int erandId)
        {
            var statusIdToSet = GetStatusIdByName(statusName);
            var errandToSetStatus = db.Zlecenie.Find(erandId);

            errandToSetStatus.Status = statusIdToSet;
            db.SaveChanges();
        }
    }
}