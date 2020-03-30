using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace Nancy_REST
{
    public class DBPopulator
    {
        public static void Populate()
        {
            using (var context = new UserContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                List<User> users = new List<User>()
                {
                    new User() {Name = "Jumbo", Password = "2345"},
                    new User() {Name = "Bimbo", Password = "2345"},
                    new User() {Name = "Steve", Password = "2345"},
                    new User() {Name = "Corentin", Password = "2345"},
                    new User() {Name = "Lameboy$$$", Password = "2345"},
                    new User() {Name = "Marabou", Password = "2345"},
                    new User() {Name = "Biba", Password = "2345"},
                    new User() {Name = "Mudak", Password = "2345"},
                    new User() {Name = "CocoRo", Password = "2345"},
                };
                context.AddRange(users);
                context.SaveChanges();
            }         
        }
    }
}
