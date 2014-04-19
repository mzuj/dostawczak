using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KU.Models;
using System.Data.Entity;

namespace KU.Logic
{
    public class CommissionStatusHelper 
    {
        private ZlecenieEntities db = new ZlecenieEntities();

        public int GetStatusIdByName(String statusName) 
        {
            var idStatusCompleted = from s in db.StatusZlecenie
                                    where s.Nazwa.Equals(statusName)
                                    select s.Id;
            return idStatusCompleted.First();
        }

        public void SetCommissionStatus(String statusName, int erandId)
        {
            var statusIdToSet = GetStatusIdByName(statusName);
            var CommissionToSetStatus = db.Zlecenie.Find(erandId);

            CommissionToSetStatus.Status = statusIdToSet;
            db.SaveChanges();
        }
    }
}