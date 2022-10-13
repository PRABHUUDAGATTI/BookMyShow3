using Book_Show_Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Book_Show_DAL.Repost
{
    public class ShowTimingsRepost :IShowTimingsRepost
    {
        Book_show_db _db;
        public ShowTimingsRepost(Book_show_db db)
        {
            _db = db;
        }
        public void AddShowTiming(ShowTiming showTiming)
        {
            _db.showTiming.Add(showTiming);
            _db.SaveChanges();
        }
        public void DeleteShowTiming(int ShowTimingId)
        {
            var ShowTiming = _db.showTiming.Find(ShowTimingId);
            _db.showTiming.Remove(ShowTiming);
            _db.SaveChanges();
        }
        public ShowTiming GetShowTimingById(int ShowTimingId)
        {
            return _db.showTiming.Find(ShowTimingId);
        }
        public IEnumerable<ShowTiming> GetAll()
        {
            return _db.showTiming.ToList();
        }
        public void UpdateShowTiming(ShowTiming ShowTiming)
        {
            _db.Entry(ShowTiming).State = EntityState.Modified;
            _db.SaveChanges();
        }

    }
}
