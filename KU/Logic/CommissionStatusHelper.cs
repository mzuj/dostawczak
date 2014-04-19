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
            if (idStatusCompleted == null)
                return 0;
            else
                return idStatusCompleted.First();
        }

        public void SetCommissionStatus(String statusName, int erandId)
        {
            var statusIdToSet = GetStatusIdByName(statusName);
            var commissionToSetStatus = db.Zlecenie.Find(erandId);

            commissionToSetStatus.Status = statusIdToSet;
            db.SaveChanges();
        }
    }
}