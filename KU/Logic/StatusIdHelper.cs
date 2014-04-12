using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KU.Models;

namespace KU.Logic
{
    public class StatusIdHelper 
    {
        private ZlecenieEntities db = new ZlecenieEntities();

        public int getStatusIdByName(String statusName) 
        {
            var idStatusCompleted = from s in db.StatusZlecenie
                                    where s.Nazwa.Equals(statusName)
                                    select s.Id;
            return idStatusCompleted.First();
        }
    }
}