using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DhWeb.Models
{
    public class HomeViewmodel
    {
        private adminDatabaseEntities db = new adminDatabaseEntities();
  
        public string mainImageUrl { get; set; }
        public string presentationText { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        public HomeViewmodel()
        {
            SiteOptions so = db.SiteOptions.Find(getLatestEntryId());
            
            mainImageUrl = so.ImageUrl;
            presentationText = so.mainPresentationText;

        }

        private int getLatestEntryId()
        {
            var lastEntry = db.SiteOptions.OrderByDescending(o => o.Id).First().Id;
            int ID = Convert.ToInt32(lastEntry);
            return ID ;
        }

      
    }


}